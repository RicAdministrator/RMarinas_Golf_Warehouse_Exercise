IF OBJECT_ID ('usp_PS_DOC_CONTACT_insert') IS NOT NULL
	DROP PROCEDURE [dbo].usp_PS_DOC_CONTACT_insert
GO

CREATE PROCEDURE [dbo].usp_PS_DOC_CONTACT_insert
(
	@DOC_ID	BIGINT,
	@CONTACT_ID TINYINT,
	@NAM VARCHAR(40),
	@FST_NAM VARCHAR(15),
	@LST_NAM VARCHAR(25),
	@ADRS_1 VARCHAR(40),
	@ADRS_2 VARCHAR(40),
	@ADRS_3 VARCHAR(40),
	@CITY VARCHAR(20),
	@STATE VARCHAR(10),
	@ZIP_COD VARCHAR(15),
	@CNTRY VARCHAR(20),
	@PHONE VARCHAR(25),
	@ADRS_ID VARCHAR(10),
	@EMAIL_ADRS VARCHAR(50),
	@CONTCT VARCHAR(40)
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

INSERT INTO dbo.PS_DOC_CONTACT
(
	DOC_ID,
	CONTACT_ID,
	NAM,
	FST_NAM,
	LST_NAM,
	ADRS_1,
	ADRS_2,
	ADRS_3,
	CITY,
	[STATE],
	ZIP_COD,
	CNTRY,
	PHONE,
	ADRS_ID,
	EMAIL_ADRS,
	CONTCT
)
VALUES
(
	@DOC_ID,
	@CONTACT_ID,
	@NAM,
	@FST_NAM,
	@LST_NAM,
	@ADRS_1,
	@ADRS_2,
	@ADRS_3,
	@CITY,
	@STATE,
	@ZIP_COD,
	@CNTRY,
	@PHONE,
	@ADRS_ID,
	@EMAIL_ADRS,
	@CONTCT
)