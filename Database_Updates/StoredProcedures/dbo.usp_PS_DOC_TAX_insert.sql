IF OBJECT_ID ('usp_PS_DOC_TAX_insert') IS NOT NULL
	DROP PROCEDURE [dbo].usp_PS_DOC_TAX_insert
GO

CREATE PROCEDURE [dbo].usp_PS_DOC_TAX_insert
(
	@DOC_ID BIGINT,
	@AUTH_COD VARCHAR(10),
	@RUL_COD VARCHAR(10),
	@TAX_DOC_PART VARCHAR(1),
	@LIN_AMT DECIMAL(15, 2),
	@TXBL_LIN_AMT DECIMAL(15, 2),
	@TXBL_MISC_CHG_AMT_1 DECIMAL(15, 2),
	@TXBL_MISC_CHG_AMT_2 DECIMAL(15, 2),
	@TXBL_MISC_CHG_AMT_3 DECIMAL(15, 2),
	@TXBL_MISC_CHG_AMT_4 DECIMAL(15, 2),
	@TXBL_MISC_CHG_AMT_5 DECIMAL(15, 2),
	@TXBL_GFC_AMT DECIMAL(15, 2),
	@TXBL_SVC_AMT DECIMAL(15, 2),
	@TXBL_TAX_AMT DECIMAL(15, 2),
	@TXBL_QTY DECIMAL(15, 4),
	@TAX_AMT DECIMAL(15, 2),
	@NORM_TAX_AMT DECIMAL(15, 2),
	@TAX_AMT_EXACT DECIMAL(15, 4),
	@NORM_TAX_AMT_EXACT DECIMAL(15, 4),
	@TOT_TXBL_AMT DECIMAL(15, 2)
)
AS
/*********************************************************************************
*	Revision History
*
*	Name: 
*	Description: 
*
*	Date:				Author:		Ref#:		Comments:
*	February 12, 2024	RMarinas	N/A			Created.
*
**********************************************************************************/

INSERT INTO dbo.PS_DOC_TAX
(
	DOC_ID,
	AUTH_COD,
	RUL_COD,
	TAX_DOC_PART,
	LIN_AMT,
	TXBL_LIN_AMT,
	TXBL_MISC_CHG_AMT_1,
	TXBL_MISC_CHG_AMT_2,
	TXBL_MISC_CHG_AMT_3,
	TXBL_MISC_CHG_AMT_4,
	TXBL_MISC_CHG_AMT_5,
	TXBL_GFC_AMT,
	TXBL_SVC_AMT,
	TXBL_TAX_AMT,
	TXBL_QTY,
	TAX_AMT,
	NORM_TAX_AMT,
	TAX_AMT_EXACT,
	NORM_TAX_AMT_EXACT,
	TOT_TXBL_AMT
)
VALUES
(
	@DOC_ID,
	@AUTH_COD,
	@RUL_COD,
	@TAX_DOC_PART,
	@LIN_AMT,
	@TXBL_LIN_AMT,
	@TXBL_MISC_CHG_AMT_1,
	@TXBL_MISC_CHG_AMT_2,
	@TXBL_MISC_CHG_AMT_3,
	@TXBL_MISC_CHG_AMT_4,
	@TXBL_MISC_CHG_AMT_5,
	@TXBL_GFC_AMT,
	@TXBL_SVC_AMT,
	@TXBL_TAX_AMT,
	@TXBL_QTY,
	@TAX_AMT,
	@NORM_TAX_AMT,
	@TAX_AMT_EXACT,
	@NORM_TAX_AMT_EXACT,
	@TOT_TXBL_AMT
)