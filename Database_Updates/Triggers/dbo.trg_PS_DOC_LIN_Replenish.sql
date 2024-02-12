IF OBJECT_ID('[dbo].[trg_PS_DOC_LIN_Replenish]') IS NOT NULL
	DROP TRIGGER [trg_PS_DOC_LIN_Replenish]
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[trg_PS_DOC_LIN_Replenish] ON [dbo].[PS_DOC_LIN]
AFTER INSERT, UPDATE, DELETE
AS 

/*********************************************************************************
*	Revision History
*
*	Name: trg_PS_DOC_LIN_Replenish
*	Description: 
*
*	Date:				Author:		Ref#:		Comments:
*	February 12, 2024	RMarinas	N/A			Created.
**********************************************************************************/
BEGIN

	DECLARE @action AS CHAR(1)
    SET @action = 'I'; -- Set Action to Insert by default.
    
	IF EXISTS(SELECT 1 FROM DELETED)
    BEGIN
    
		SET @action = 
            CASE
                WHEN EXISTS(SELECT 1 FROM INSERTED) THEN 'U' -- Set Action to Updated.
                ELSE 'D' -- Set Action to Deleted.     
			END     

    END
	
	IF (@action IN ('I', 'U'))
	BEGIN

		INSERT INTO dbo.USER_SUGGESTED_REPLENISHMENT
		(
			ITEM_NO, 
			LOC_ID, 
			MIN_QTY,
			QTY_SOLD,
			[ACTION],
			REMARKS
		)
		SELECT
			ins.ITEM_NO,
			ins.STK_LOC_ID,
			inv.MIN_QTY,
			ins.QTY_SOLD,			
			@action,
			CASE
                WHEN ins.QTY_SOLD > inv.MIN_QTY THEN 'Quantity sold is greater than minimum quantity. Please buy ' + CAST(ins.QTY_SOLD - inv.MIN_QTY AS VARCHAR) + ' items from vendor.'
				WHEN ins.QTY_SOLD = inv.MIN_QTY THEN 'Quantity sold is equal to minimum quantity.'
                ELSE 'Quantity sold is less than minimum quantity.'      
            END
		FROM
			INSERTED ins INNER JOIN
			dbo.IM_INV inv ON ins.ITEM_NO = inv.ITEM_NO AND ins.STK_LOC_ID = inv.LOC_ID

	END
	ELSE IF (@action = 'D')
	BEGIN

		INSERT INTO dbo.USER_SUGGESTED_REPLENISHMENT
		(
			ITEM_NO, 
			LOC_ID, 
			MIN_QTY,
			QTY_SOLD,
			[ACTION],
			REMARKS
		)
		SELECT
			inv.ITEM_NO, 
			inv.LOC_ID, 
			inv.MIN_QTY,
			0.0000,
			@action,
			'Item is deleted. No need to replenish.'
		FROM
			DELETED del INNER JOIN
			dbo.IM_INV inv ON del.ITEM_NO = inv.ITEM_NO AND del.STK_LOC_ID = inv.LOC_ID

	END
		
END