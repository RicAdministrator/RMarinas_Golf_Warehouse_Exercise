/********************************************************************************
*	Revision History
*	Name: USER_SUGGESTED_REPLENISHMENT
*	Description: 
*
*	Date:	  			Author:		Ref#:		Comments:
*	February 12, 2024	RMarinas	N/A			Created.
*
**********************************************************************************/

IF OBJECT_ID ('[dbo].[USER_SUGGESTED_REPLENISHMENT]') IS NULL
BEGIN

	CREATE TABLE USER_SUGGESTED_REPLENISHMENT
	(
		ID INT IDENTITY(1, 1),
		ITEM_NO VARCHAR(20), 
		LOC_ID VARCHAR(10), 
		MIN_QTY DECIMAL(15, 4),
		QTY_SOLD DECIMAL(15, 4),
		[ACTION] VARCHAR(10),
		REMARKS VARCHAR(MAX) NULL
	)

END
