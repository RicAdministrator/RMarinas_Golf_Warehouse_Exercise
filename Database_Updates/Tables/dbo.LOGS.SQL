/********************************************************************************
*	Revision History
*	Name: LOGS
*	Description: 
*
*	Date:	  			Author:		Ref#:		Comments:
*	February 12, 2024	RMarinas	N/A			Created.
*
**********************************************************************************/

IF OBJECT_ID ('[dbo].[LOGS]') IS NULL
BEGIN

	CREATE TABLE LOGS
	(
		ID INT IDENTITY(1, 1),
		DOC_ID BIGINT,
		LOG_DATE DATETIME,
		REMARKS VARCHAR(MAX) NULL
	)

END