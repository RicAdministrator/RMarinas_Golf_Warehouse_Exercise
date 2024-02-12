IF OBJECT_ID ('usp_LOGS_insert') IS NOT NULL
	DROP PROCEDURE [dbo].usp_LOGS_insert
GO

CREATE PROCEDURE [dbo].usp_LOGS_insert
(
	@DOC_ID BIGINT,
	@REMARKS VARCHAR(MAX)
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

INSERT INTO dbo.LOGS
(
	DOC_ID,
	LOG_DATE,
	REMARKS
)
VALUES
(
	@DOC_ID,
	GETDATE(),
	@REMARKS
)