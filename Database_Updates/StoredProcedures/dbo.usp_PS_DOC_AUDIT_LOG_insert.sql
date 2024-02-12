IF OBJECT_ID ('usp_PS_DOC_AUDIT_LOG_insert') IS NOT NULL
	DROP PROCEDURE [dbo].usp_PS_DOC_AUDIT_LOG_insert
GO

CREATE PROCEDURE [dbo].usp_PS_DOC_AUDIT_LOG_insert
(
	@DOC_ID	BIGINT,
	@LOG_SEQ_NO INT,
	@DOC_TYP VARCHAR(1),
	@DOC_GUID UNIQUEIDENTIFIER,	
	@STR_ID VARCHAR(10),
	@STA_ID VARCHAR(10),
	@DRW_ID VARCHAR(10),
	@SLS_REP VARCHAR(10),
	@MACHINE_NAM VARCHAR(128),
	@SERVER_NAM VARCHAR(128),
	@DB_NAM VARCHAR(128),
	@ACTIV VARCHAR(1),
	@LOG_ENTRY VARCHAR(250)
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

INSERT INTO dbo.PS_DOC_AUDIT_LOG
(
	DOC_ID,
	LOG_SEQ_NO,
	DOC_TYP,
	DOC_GUID,	
	AUDIT_DT,
	STR_ID,
	STA_ID,
	DRW_ID,
	SLS_REP,
	MACHINE_NAM,
	SERVER_NAM,
	DB_NAM,
	ACTIV,
	LOG_ENTRY
)
VALUES
(
	@DOC_ID,
	@LOG_SEQ_NO,
	@DOC_TYP,
	@DOC_GUID,	
	GETDATE(),
	@STR_ID,
	@STA_ID,
	@DRW_ID,
	@SLS_REP,
	@MACHINE_NAM,
	@SERVER_NAM,
	@DB_NAM,
	@ACTIV,
	@LOG_ENTRY
)