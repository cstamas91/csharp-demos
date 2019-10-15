USE [Concurrency]
GO

/****** Object: Table Valued Function [dbo].[fnTestFunc] Script Date: 10/15/2019 10:09:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION fnTestFunc (
	@term nvarchar(max)
)
returns @resultTable TABLE (
	Content1 NVARCHAR(MAX),
	Content2 NVARCHAR(MAX)
)
AS
BEGIN
	INSERT INTO @resultTable
	SELECT
		Content Content1,
		@term Content2
	FROM ASD

	RETURN;
END;
