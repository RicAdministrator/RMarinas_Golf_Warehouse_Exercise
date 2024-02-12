IF OBJECT_ID ('usp_PS_DOC_HDR_TOT_insert') IS NOT NULL
	DROP PROCEDURE [dbo].usp_PS_DOC_HDR_TOT_insert
GO

CREATE PROCEDURE [dbo].usp_PS_DOC_HDR_TOT_insert
(
	@DOC_ID	BIGINT,
	@TOT_TYP VARCHAR(1),
	@HAS_TAX_OVRD VARCHAR(1),
	@LINS INT,
	@SUB_TOT DECIMAL(15, 2),
	@TAX_OVRD_LINS INT,
	@TOT_EXT_COST DECIMAL(15, 2),
	@TOT_MISC DECIMAL(15, 2),
	@TAX_AMT DECIMAL(15, 2),
	@NORM_TAX_AMT DECIMAL(15, 2),
	@TOT_TND DECIMAL(15, 2),
	@TOT_CHNG DECIMAL(15, 2),
	@TOT_WEIGHT MONEY,
	@TOT_CUBE MONEY,
	@TOT_HDR_DISC DECIMAL(15, 2),
	@TOT_LIN_DISC DECIMAL(15, 2),
	@TOT_HDR_DISCNTBL_AMT DECIMAL(15, 2),
	@TOT_TIP_AMT DECIMAL(15, 2)
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

INSERT INTO dbo.PS_DOC_HDR_TOT
(
	DOC_ID,
	TOT_TYP,
	HAS_TAX_OVRD,
	LINS,
	SUB_TOT,
	TAX_OVRD_LINS,
	TOT_EXT_COST,
	TOT_MISC,
	TAX_AMT,
	NORM_TAX_AMT,
	TOT_TND,
	TOT_CHNG,
	TOT_WEIGHT,
	TOT_CUBE,
	TOT,
	AMT_DUE,
	TOT_HDR_DISC,
	TOT_LIN_DISC,
	TOT_HDR_DISCNTBL_AMT,
	TOT_TIP_AMT
)
VALUES
(
	@DOC_ID,
	@TOT_TYP,
	@HAS_TAX_OVRD,
	@LINS,
	@SUB_TOT,
	@TAX_OVRD_LINS,
	@TOT_EXT_COST,
	@TOT_MISC,
	@TAX_AMT,
	@NORM_TAX_AMT,
	@TOT_TND,
	@TOT_CHNG,
	@TOT_WEIGHT,
	@TOT_CUBE,
	@SUB_TOT + @TAX_AMT,
	@SUB_TOT + @TAX_AMT - @TOT_TND,
	@TOT_HDR_DISC,
	@TOT_LIN_DISC,
	@TOT_HDR_DISCNTBL_AMT,
	@TOT_TIP_AMT
)