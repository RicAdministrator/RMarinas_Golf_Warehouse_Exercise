IF OBJECT_ID ('usp_PS_DOC_HDR_MISC_CHRG_insert') IS NOT NULL
	DROP PROCEDURE [dbo].usp_PS_DOC_HDR_MISC_CHRG_insert
GO

CREATE PROCEDURE [dbo].usp_PS_DOC_HDR_MISC_CHRG_insert
(
	@DOC_ID	BIGINT,
	@TOT_TYP VARCHAR(1),
	@MISC_CHRG_NO INT,
	@MISC_TYP VARCHAR(1),
	@MISC_AMT DECIMAL(15, 2),
	@MISC_PCT DECIMAL(9, 3),
	@MISC_TAX_AMT_ALLOC DECIMAL(15, 2),
	@MISC_NORM_TAX_AMT_ALLOC DECIMAL(15, 2)
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

INSERT INTO dbo.PS_DOC_HDR_MISC_CHRG
(
	DOC_ID,
	TOT_TYP,
	MISC_CHRG_NO,
	MISC_TYP,
	MISC_AMT,
	MISC_PCT,
	MISC_TAX_AMT_ALLOC,
	MISC_NORM_TAX_AMT_ALLOC
)
VALUES
(
	@DOC_ID,
	@TOT_TYP,
	@MISC_CHRG_NO,
	@MISC_TYP,
	@MISC_AMT,
	@MISC_PCT,
	@MISC_TAX_AMT_ALLOC,
	@MISC_NORM_TAX_AMT_ALLOC
)