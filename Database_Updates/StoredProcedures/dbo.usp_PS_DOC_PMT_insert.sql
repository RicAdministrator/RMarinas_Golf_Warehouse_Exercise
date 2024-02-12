IF OBJECT_ID ('usp_PS_DOC_PMT_insert') IS NOT NULL
	DROP PROCEDURE [dbo].usp_PS_DOC_PMT_insert
GO

CREATE PROCEDURE [dbo].usp_PS_DOC_PMT_insert
(
	@DOC_ID BIGINT,
	@PMT_SEQ_NO INT,
	@CARD_NO VARCHAR(30),
	@PAY_COD_TYP VARCHAR(1),
	@AMT DECIMAL(15, 2),
	@STR_ID VARCHAR(10),
	@FINAL_PMT VARCHAR(1),
	@STA_ID VARCHAR(10),
	@CARD_IS_NEW VARCHAR(1),
	@TKT_NO VARCHAR(15),
	@SECURE_ECOMM_TRX VARCHAR(1),
	@PMT_LIN_TYP VARCHAR(1),
	@PAY_COD VARCHAR(10),
	@PAY_DAT DATETIME,
	@DEP_LIN_COPIED_TO_REL_DOC VARCHAR(1),
	@HOME_CURNCY_AMT DECIMAL(15, 2),
	@EXCH_LOSS DECIMAL(15, 2),
	@SIG_IMG IMAGE,
	@SWIPED VARCHAR(1),
	@SIG_IMG_VECTOR IMAGE,
	@EDC_AUTH_COD VARCHAR(10),
	@DESCR VARCHAR(30),
	@EDC_AUTH_FLG VARCHAR(1),
	@CURNCY_COD VARCHAR(10),
	@EBT_BAL_REMAIN DECIMAL(15, 2),
	@EXCH_RATE_NUMER DECIMAL(15, 4),
	@EXCH_RATE_DENOM DECIMAL(15, 4),
	@LOY_PTS_RDM INT,
	@SVC_BAL_REMAIN DECIMAL(15, 2),
	@SVC_REF_NO VARCHAR(10),
	@EDC_AUTH_RESP VARCHAR(80),
	@ROUND_GAIN_LOSS DECIMAL(15, 2),
	@HOME_CURNCY_ROUND_GAIN_LOSS DECIMAL(15, 2),
	@TIP_AMT DECIMAL(15, 2),
	@GFC_AUTHED VARCHAR(1)
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

INSERT INTO dbo.PS_DOC_PMT
(
	DOC_ID,
	PMT_SEQ_NO,
	CARD_NO,
	PAY_COD_TYP,
	AMT,
	STR_ID,
	FINAL_PMT,
	STA_ID,
	CARD_IS_NEW,
	TKT_NO,
	SECURE_ECOMM_TRX,
	PMT_LIN_TYP,
	PAY_COD,
	PAY_DAT,
	DEP_LIN_COPIED_TO_REL_DOC,
	HOME_CURNCY_AMT,
	EXCH_LOSS,
	SIG_IMG,
	SWIPED,
	SIG_IMG_VECTOR,
	EDC_AUTH_COD,
	DESCR,
	EDC_AUTH_FLG,
	CURNCY_COD,
	EBT_BAL_REMAIN,
	EXCH_RATE_NUMER,
	EXCH_RATE_DENOM,
	LOY_PTS_RDM,
	SVC_BAL_REMAIN,
	SVC_REF_NO,
	EDC_AUTH_RESP,
	ROUND_GAIN_LOSS,
	HOME_CURNCY_ROUND_GAIN_LOSS,
	TIP_AMT,
	GFC_AUTHED
)
VALUES
(
	@DOC_ID,
	@PMT_SEQ_NO,
	@CARD_NO,
	@PAY_COD_TYP,
	@AMT,
	@STR_ID,
	@FINAL_PMT,
	@STA_ID,
	@CARD_IS_NEW,
	@TKT_NO,
	@SECURE_ECOMM_TRX,
	@PMT_LIN_TYP,
	@PAY_COD,
	@PAY_DAT,
	@DEP_LIN_COPIED_TO_REL_DOC,
	@HOME_CURNCY_AMT,
	@EXCH_LOSS,
	@SIG_IMG,
	@SWIPED,
	@SIG_IMG_VECTOR,
	@EDC_AUTH_COD,
	@DESCR,
	@EDC_AUTH_FLG,
	@CURNCY_COD,
	@EBT_BAL_REMAIN,
	@EXCH_RATE_NUMER,
	@EXCH_RATE_DENOM,
	@LOY_PTS_RDM,
	@SVC_BAL_REMAIN,
	@SVC_REF_NO,
	@EDC_AUTH_RESP,
	@ROUND_GAIN_LOSS,
	@HOME_CURNCY_ROUND_GAIN_LOSS,
	@TIP_AMT,
	@GFC_AUTHED
)