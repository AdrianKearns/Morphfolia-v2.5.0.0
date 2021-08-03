/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO




/****** Object:  StoredProcedure [dbo].[ContentIndex_SELECT_Overview]    Script Date: 06/29/2009 20:38:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContentIndex_SELECT_Overview]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ContentIndex_SELECT_Overview]




/****** Object:  StoredProcedure [dbo].[ContentIndex_SELECT_Overview]    Script Date: 05/14/2009 16:56:02 ******/
 
GO
 
GO
/****** Object:  Stored Procedure dbo.ContentIndex_SELECT_Overview    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure [dbo].[ContentIndex_SELECT_Overview]



AS

	SET NOCOUNT ON
	

	CREATE TABLE #ContentIndexOverview (Total INT, Letter varchar(50))


	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'A' Letter FROM ContentIndex_A

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'B' Letter FROM ContentIndex_B

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'C' Letter FROM ContentIndex_C

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'D' Letter FROM ContentIndex_D

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'E' Letter FROM ContentIndex_E

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'F' Letter FROM ContentIndex_F

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'G' Letter FROM ContentIndex_G

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'H' Letter FROM ContentIndex_H

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'I' Letter FROM ContentIndex_I

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'J' Letter FROM ContentIndex_J

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'K' Letter FROM ContentIndex_K

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'L' Letter FROM ContentIndex_L

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'M' Letter FROM ContentIndex_M

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'N' Letter FROM ContentIndex_N

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'O' Letter FROM ContentIndex_O

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'P' Letter FROM ContentIndex_P

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'Q' Letter FROM ContentIndex_Q

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'R' Letter FROM ContentIndex_R

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'S' Letter FROM ContentIndex_S

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'T' Letter FROM ContentIndex_T

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'U' Letter FROM ContentIndex_U

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'V' Letter FROM ContentIndex_V

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'W' Letter FROM ContentIndex_W

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'X' Letter FROM ContentIndex_X

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'Y' Letter FROM ContentIndex_Y

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'Z' Letter FROM ContentIndex_Z

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'Default' Letter FROM ContentIndex_Default


	SELECT * FROM #ContentIndexOverview ORDER BY Total DESC, Letter
		




	CREATE TABLE #ContentIndexTop3Overview (Word varchar(255), Total INT, Letter varchar(50))

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'A' Letter FROM ContentIndex_A GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'B' Letter FROM ContentIndex_B GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'C' Letter FROM ContentIndex_C GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'D' Letter FROM ContentIndex_D GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'E' Letter FROM ContentIndex_E GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'F' Letter FROM ContentIndex_F GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'G' Letter FROM ContentIndex_G GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'H' Letter FROM ContentIndex_H GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'I' Letter FROM ContentIndex_I GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'J' Letter FROM ContentIndex_J GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'K' Letter FROM ContentIndex_K GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'L' Letter FROM ContentIndex_L GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'M' Letter FROM ContentIndex_M GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'N' Letter FROM ContentIndex_N GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'O' Letter FROM ContentIndex_O GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'P' Letter FROM ContentIndex_P GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'Q' Letter FROM ContentIndex_Q GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'R' Letter FROM ContentIndex_R GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'S' Letter FROM ContentIndex_S GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'T' Letter FROM ContentIndex_T GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'U' Letter FROM ContentIndex_U GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'V' Letter FROM ContentIndex_V GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'W' Letter FROM ContentIndex_W GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'X' Letter FROM ContentIndex_X GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'Y' Letter FROM ContentIndex_Y GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'Z' Letter FROM ContentIndex_Z GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'Default' Letter FROM ContentIndex_Default GROUP BY Word ORDER BY Occurances DESC

	SELECT * FROM #ContentIndexTop3Overview ORDER BY Total DESC, Word
GO
/****** Object:  StoredProcedure [dbo].[Content_UPDATE]    Script Date: 05/14/2009 16:56:01 ******/
 
GO
 
GO




/****** Object:  StoredProcedure [dbo].[Content_UPDATE]    Script Date: 06/29/2009 20:39:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Content_UPDATE]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Content_UPDATE]
GO

/****** Object:  Stored Procedure dbo.Content_UPDATE    Script Date: 10/02/2007 8:11:37 p.m. ******/
/****** Object:  Stored Procedure dbo.Content_UPDATE    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_UPDATE]

	-- Content_UPDATE 1

	@intContentID int,
	@txtContent ntext,
	@txtTextContent ntext,
	@txtNote varchar(500),
	@bitIsLive bit,
	@bitIsSearchable bit,
	@txtLastUpdatedBy varchar(101)

AS

	SET NOCOUNT ON

	UPDATE	dbo.Content

	SET
		Content = @txtContent,
		TextContent = @txtTextContent,
		Note = @txtNote,
		IsLive = @bitIsLive,
		IsSearchable = @bitIsSearchable,
		LastModified = GetDate(),
		LastModifiedBy = @txtLastUpdatedBy

	WHERE	ContentID = @intContentID
GO
/****** Object:  StoredProcedure [dbo].[GetUsageSummary]    Script Date: 05/14/2009 16:56:06 ******/
 
GO
 
GO




/****** Object:  StoredProcedure [dbo].[GetUsageSummary]    Script Date: 06/29/2009 20:40:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetUsageSummary]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetUsageSummary]
GO

CREATE PROCEDURE [dbo].[GetUsageSummary]

AS
BEGIN
	    

	exec sp_spaceused

	exec sp_spaceused aspnet_Users
	exec sp_spaceused AuditLog
	exec sp_spaceused [Content]
	exec sp_spaceused Page
	exec sp_spaceused ContentIndex_Default
	exec sp_spaceused ContentIndex_A
	exec sp_spaceused ContentIndex_B
	exec sp_spaceused ContentIndex_C
	exec sp_spaceused ContentIndex_D
	exec sp_spaceused ContentIndex_E
	exec sp_spaceused ContentIndex_F
	exec sp_spaceused ContentIndex_G
	exec sp_spaceused ContentIndex_H
	exec sp_spaceused ContentIndex_I
	exec sp_spaceused ContentIndex_J
	exec sp_spaceused ContentIndex_K
	exec sp_spaceused ContentIndex_L
	exec sp_spaceused ContentIndex_M
	exec sp_spaceused ContentIndex_N
	exec sp_spaceused ContentIndex_O
	exec sp_spaceused ContentIndex_P
	exec sp_spaceused ContentIndex_Q
	exec sp_spaceused ContentIndex_R
	exec sp_spaceused ContentIndex_S
	exec sp_spaceused ContentIndex_T
	exec sp_spaceused ContentIndex_U
	exec sp_spaceused ContentIndex_V
	exec sp_spaceused ContentIndex_W
	exec sp_spaceused ContentIndex_X
	exec sp_spaceused ContentIndex_Y
	exec sp_spaceused ContentIndex_Z
	exec sp_spaceused ControlProperties
	exec sp_spaceused PropertyType
	exec sp_spaceused HttpLog
	exec sp_spaceused [Log]



END
GO
/****** Object:  StoredProcedure [dbo].[ContentIndex_SELECT_WordIndexList]    Script Date: 05/14/2009 16:56:02 ******/
 
GO
 
GO
/****** Object:  Stored Procedure dbo.ContentIndex_SELECT_WordIndexList    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec ContentIndex_SELECT_WordIndexList @txtSearchCriteria = '%acc%'



/****** Object:  StoredProcedure [dbo].[ContentIndex_SELECT_WordIndexList]    Script Date: 06/29/2009 20:40:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContentIndex_SELECT_WordIndexList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ContentIndex_SELECT_WordIndexList]

GO

/****** Object:  Stored Procedure dbo.ContentIndex_SELECT_WordIndexList    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[ContentIndex_SELECT_WordIndexList]

	-- ContentIndex_SELECT_WordIndexList 'a'
	-- ContentIndex_SELECT_WordIndexList 'A'
	-- ContentIndex_SELECT_WordIndexList 'T'
	-- ContentIndex_SELECT_WordIndexList 'z'
	-- ContentIndex_SELECT_WordIndexList '%'

	@txtLetter char(1)

AS

	SET NOCOUNT ON


	DECLARE @bLetterFound bit
	SET @bLetterFound = 0


	IF @txtLetter = 'A'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_A Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'B'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_B Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'C'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_C Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'D'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_D Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'E'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_E Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'F'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_F Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'G'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_G Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'H'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_H Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'I'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_I Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'J'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_J Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'K'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_K Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'L'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_L Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'M'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_M Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'N'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_N Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'O'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_O Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'P'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_P Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'Q'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_Q Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'R'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_R Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'S'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_S Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'T'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_T Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'U'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_U Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'V'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_V Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'W'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_W Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'X'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_X Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'Y'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_Y Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'Z'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_Z Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END


	IF @bLetterFound = 0
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType
		FROM dbo.ContentIndex_Default Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
	END
GO
/****** Object:  StoredProcedure [dbo].[ContentIndex_SELECT_WordsForTagCloud]    Script Date: 05/14/2009 16:56:03 ******/
 
GO
 
GO
/****** Object:  Stored Procedure dbo.ContentIndex_SELECT_WordsForTagCloud    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec ContentIndex_SELECT_WordsForTagCloud @txtSearchCriteria = '%acc%'





/****** Object:  StoredProcedure [dbo].[ContentIndex_SELECT_WordsForTagCloud]    Script Date: 06/29/2009 20:41:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContentIndex_SELECT_WordsForTagCloud]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ContentIndex_SELECT_WordsForTagCloud]
GO

/****** Object:  Stored Procedure dbo.ContentIndex_SELECT_WordsForTagCloud    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[ContentIndex_SELECT_WordsForTagCloud]

	-- ContentIndex_SELECT_WordsForTagCloud 100
	-- ContentIndex_SELECT_WordsForTagCloud 200
	-- ContentIndex_SELECT_WordsForTagCloud 300

	@intMinOccurrances int

AS

	SET NOCOUNT ON


	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_A subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_A mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_A subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_B subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_B mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_B subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_C subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_C mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_C subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_D subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_D mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_D subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_E subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_E mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_E subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_F subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_F mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_F subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_G subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_G mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_G subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_H subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_H mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_H subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_I subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_I mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_I subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_J subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_J mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_J subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_K subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_K mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_K subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_L subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_L mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_L subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_M subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_M mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_M subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_N subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_N mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_N subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_O subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_O mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_O subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_P subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_P mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_P subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_Q subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_Q mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_Q subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_R subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_R mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_R subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_S subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_S mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_S subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_T subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_T mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_T subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_U subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_U mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_U subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_V subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_V mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_V subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_W subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_W mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_W subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_X subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_X mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_X subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_Y subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_Y mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_Y subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_Z subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_Z mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_Z subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_Default subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_Default mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_Default subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


--        ORDER BY WordCount DESC, Word
        ORDER BY Word
GO
/****** Object:  StoredProcedure [dbo].[Content_DELETE_ByContentID]    Script Date: 05/14/2009 16:55:56 ******/
 
GO
 
GO



/****** Object:  StoredProcedure [dbo].[Content_DELETE_ByContentID]    Script Date: 06/29/2009 20:41:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Content_DELETE_ByContentID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Content_DELETE_ByContentID]

GO

/****** Object:  Stored Procedure dbo.Content_DELETE_ByContentID    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure [dbo].[Content_DELETE_ByContentID]

	@intContentID int

AS

	SET NOCOUNT ON

	DELETE FROM dbo.ContentIndex_A WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_B WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_C WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_D WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_E WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_F WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_G WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_H WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_I WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_J WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_K WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_L WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_M WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_N WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_O WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_P WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_Q WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_R WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_S WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_T WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_U WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_V WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_W WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_X WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_Y WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_Z WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_Default WHERE ContentId = @intContentID

	-- SELECT * FROM dbo.ContentMarshal WHERE ContentID = 1
	DELETE FROM dbo.ContentMarshal WHERE ContentID = @intContentID

	-- SELECT * FROM dbo.ControlProperties WHERE PropertyType = 'CONT' AND PropertyValue = 1
	DELETE FROM dbo.ControlProperties WHERE PropertyType = 'CONT' AND PropertyValue = @intContentID

	-- SELECT * FROM dbo.Content WHERE ContentID = 1
	DELETE FROM dbo.Content WHERE ContentID = @intContentID
GO
/****** Object:  StoredProcedure [dbo].[ContentIndex_DELETE_UnwantedWords]    Script Date: 05/14/2009 16:56:02 ******/
 
GO
 
GO


/****** Object:  StoredProcedure [dbo].[ContentIndex_DELETE_UnwantedWords]    Script Date: 06/29/2009 20:42:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContentIndex_DELETE_UnwantedWords]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ContentIndex_DELETE_UnwantedWords]

GO

/****** Object:  Stored Procedure dbo.ContentIndex_DELETE_UnwantedWords    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure [dbo].[ContentIndex_DELETE_UnwantedWords]

	@txtFirstCharacter char(1),
	@txtWord varchar(256)

AS

	SET NOCOUNT ON


	DECLARE @done bit
	SET @done = 0





	IF (@txtFirstCharacter = 'A')
	BEGIN
		DELETE FROM dbo.ContentIndex_A WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'B')
	BEGIN
		DELETE FROM dbo.ContentIndex_B WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'C')
	BEGIN
		DELETE FROM dbo.ContentIndex_C WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'D')
	BEGIN
		DELETE FROM dbo.ContentIndex_D WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'E')
	BEGIN
		DELETE FROM dbo.ContentIndex_E WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'F')
	BEGIN
		DELETE FROM dbo.ContentIndex_F WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'G')
	BEGIN
		DELETE FROM dbo.ContentIndex_G WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'H')
	BEGIN
		DELETE FROM dbo.ContentIndex_H WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'I')
	BEGIN
		DELETE FROM dbo.ContentIndex_I WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'J')
	BEGIN
		DELETE FROM dbo.ContentIndex_J WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'K')
	BEGIN
		DELETE FROM dbo.ContentIndex_K WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'L')
	BEGIN
		DELETE FROM dbo.ContentIndex_L WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'M')
	BEGIN
		DELETE FROM dbo.ContentIndex_M WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'N')
	BEGIN
		DELETE FROM dbo.ContentIndex_N WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'O')
	BEGIN
		DELETE FROM dbo.ContentIndex_O WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'P')
	BEGIN
		DELETE FROM dbo.ContentIndex_P WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'Q')
	BEGIN
		DELETE FROM dbo.ContentIndex_Q WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'R')
	BEGIN
		DELETE FROM dbo.ContentIndex_R WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'S')
	BEGIN
		DELETE FROM dbo.ContentIndex_S WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'T')
	BEGIN
		DELETE FROM dbo.ContentIndex_T WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'U')
	BEGIN
		DELETE FROM dbo.ContentIndex_U WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'V')
	BEGIN
		DELETE FROM dbo.ContentIndex_V WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'W')
	BEGIN
		DELETE FROM dbo.ContentIndex_W WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'X')
	BEGIN
		DELETE FROM dbo.ContentIndex_X WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'Y')
	BEGIN
		DELETE FROM dbo.ContentIndex_Y WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'Z')
	BEGIN
		DELETE FROM dbo.ContentIndex_Z WHERE [Word] = @txtWord	
		SET @done = 1
	END






	if (@done = 0)
	BEGIN
		DELETE FROM dbo.ContentIndex_Default WHERE [Word] = @txtWord
	END
GO
/****** Object:  StoredProcedure [dbo].[ContentIndex_INSERT_Word]    Script Date: 05/14/2009 16:56:02 ******/
 
GO
 
GO



/****** Object:  StoredProcedure [dbo].[ContentIndex_INSERT_Word]    Script Date: 06/29/2009 20:42:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContentIndex_INSERT_Word]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ContentIndex_INSERT_Word]

GO

/****** Object:  Stored Procedure dbo.ContentIndex_INSERT_Word    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure [dbo].[ContentIndex_INSERT_Word]

	@txtFirstCharacter char(1),
	@txtWord varchar(256),
	@intPageId int,
	@intContentId int

AS

	SET NOCOUNT ON


	DECLARE @done bit
	SET @done = 0


	IF (@txtFirstCharacter = 'A')
	BEGIN
		INSERT INTO  dbo.ContentIndex_A
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)		
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'B')
	BEGIN
		INSERT INTO dbo.ContentIndex_B 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'C')
	BEGIN
		INSERT INTO dbo.ContentIndex_C 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'D')
	BEGIN
		INSERT INTO dbo.ContentIndex_D 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'E')
	BEGIN
		INSERT INTO dbo.ContentIndex_E 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'F')
	BEGIN
		INSERT INTO dbo.ContentIndex_F 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'G')
	BEGIN
		INSERT INTO dbo.ContentIndex_G 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'H')
	BEGIN
		INSERT INTO dbo.ContentIndex_H 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'I')
	BEGIN
		INSERT INTO dbo.ContentIndex_I 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'J')
	BEGIN
		INSERT INTO dbo.ContentIndex_J 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'K')
	BEGIN
		INSERT INTO dbo.ContentIndex_K 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'L')
	BEGIN
		INSERT INTO dbo.ContentIndex_L 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'M')
	BEGIN
		INSERT INTO dbo.ContentIndex_M 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'N')
	BEGIN
		INSERT INTO dbo.ContentIndex_N 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'O')
	BEGIN
		INSERT INTO dbo.ContentIndex_O 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'P')
	BEGIN
		INSERT INTO dbo.ContentIndex_P 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'Q')
	BEGIN
		INSERT INTO dbo.ContentIndex_Q 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'R')
	BEGIN
		INSERT INTO dbo.ContentIndex_R 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'S')
	BEGIN
		INSERT INTO dbo.ContentIndex_S 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'T')
	BEGIN
		INSERT INTO dbo.ContentIndex_T 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'U')
	BEGIN
		INSERT INTO dbo.ContentIndex_U 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'V')
	BEGIN
		INSERT INTO dbo.ContentIndex_V 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'W')
	BEGIN
		INSERT INTO dbo.ContentIndex_W 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'X')
	BEGIN
		INSERT INTO dbo.ContentIndex_X 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'Y')
	BEGIN
		INSERT INTO dbo.ContentIndex_Y 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'Z')
	BEGIN
		INSERT INTO dbo.ContentIndex_Z 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END


	if (@done = 0)
	BEGIN
		INSERT INTO dbo.ContentIndex_Default
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
	END
GO
/****** Object:  StoredProcedure [dbo].[ContentIndex_DELETE_OrphanRecords]    Script Date: 05/14/2009 16:56:01 ******/
 
GO
 
GO



/****** Object:  StoredProcedure [dbo].[ContentIndex_DELETE_OrphanRecords]    Script Date: 06/29/2009 20:43:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContentIndex_DELETE_OrphanRecords]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ContentIndex_DELETE_OrphanRecords]

GO

CREATE Procedure [dbo].[ContentIndex_DELETE_OrphanRecords]

AS

	SET NOCOUNT ON

	
	
	DELETE FROM ContentIndex_A WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_B WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_C WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_D WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_E WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_F WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_G WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_H WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_I WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_J WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_K WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_L WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_M WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_N WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_O WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_P WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_Q WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_R WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_S WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_T WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_U WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_V WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_W WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_X WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_Y WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_Z WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_Default WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
		
	
	DELETE FROM ContentIndex_A WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_B WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_C WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_D WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_E WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_F WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_G WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_H WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_I WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_J WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_K WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_L WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_M WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_N WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_O WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_P WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_Q WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_R WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_S WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_T WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_U WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_V WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_W WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_X WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_Y WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_Z WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_Default WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
GO
/****** Object:  StoredProcedure [dbo].[Content_SEARCH]    Script Date: 05/14/2009 16:55:57 ******/
 
GO
 
GO
/****** Object:  Stored Procedure dbo.Content_SEARCH    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec Content_SEARCH @txtSearchCriteria = '%acc%'



/****** Object:  StoredProcedure [dbo].[Content_SEARCH]    Script Date: 06/29/2009 20:43:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Content_SEARCH]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Content_SEARCH]

GO

/****** Object:  Stored Procedure dbo.Content_SEARCH    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SEARCH]

	-- Content_SEARCH '%SQL%'
	-- Content_SEARCH '%brian%'
	-- Content_SEARCH '%frodo%'
	-- Content_SEARCH '%fool%'

	@txtSearchCriteria varchar(100)

AS

	SET NOCOUNT ON

	SELECT	DISTINCT TOP 100			 
			P.PageID, 
			P.Title, 
			P.Url, 
			P.MetaKeywords, 
			P.MetaDescription, 
			P.LastModified LastModified, 
			P.LastModifiedBy LastModifiedBy,
			(
				SELECT 
				(
					SELECT Count(*) FROM dbo.ContentIndex_A AIndex
					WHERE AIndex.Word LIKE @txtSearchCriteria AND AIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_B BIndex
					WHERE BIndex.Word LIKE @txtSearchCriteria AND BIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_C CIndex
					WHERE CIndex.Word LIKE @txtSearchCriteria AND CIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_D DIndex
					WHERE DIndex.Word LIKE @txtSearchCriteria AND DIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_E EIndex
					WHERE EIndex.Word LIKE @txtSearchCriteria AND EIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_F FIndex
					WHERE FIndex.Word LIKE @txtSearchCriteria AND FIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_G GIndex
					WHERE GIndex.Word LIKE @txtSearchCriteria AND GIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_H HIndex
					WHERE HIndex.Word LIKE @txtSearchCriteria AND HIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_I IIndex
					WHERE IIndex.Word LIKE @txtSearchCriteria AND IIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_J JIndex
					WHERE JIndex.Word LIKE @txtSearchCriteria AND JIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_K KIndex
					WHERE KIndex.Word LIKE @txtSearchCriteria AND KIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_L LIndex
					WHERE LIndex.Word LIKE @txtSearchCriteria AND LIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_M MIndex
					WHERE MIndex.Word LIKE @txtSearchCriteria AND MIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_N NIndex
					WHERE NIndex.Word LIKE @txtSearchCriteria AND NIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_O OIndex
					WHERE OIndex.Word LIKE @txtSearchCriteria AND OIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_P PIndex
					WHERE PIndex.Word LIKE @txtSearchCriteria AND PIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_Q QIndex
					WHERE QIndex.Word LIKE @txtSearchCriteria AND QIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_R RIndex
					WHERE RIndex.Word LIKE @txtSearchCriteria AND RIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_S SIndex
					WHERE SIndex.Word LIKE @txtSearchCriteria AND SIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_T TIndex
					WHERE TIndex.Word LIKE @txtSearchCriteria AND TIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_U UIndex
					WHERE UIndex.Word LIKE @txtSearchCriteria AND UIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_V VIndex
					WHERE VIndex.Word LIKE @txtSearchCriteria AND VIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_W WIndex
					WHERE WIndex.Word LIKE @txtSearchCriteria AND WIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_X XIndex
					WHERE XIndex.Word LIKE @txtSearchCriteria AND XIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_Y YIndex
					WHERE YIndex.Word LIKE @txtSearchCriteria AND YIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_Z ZIndex
					WHERE ZIndex.Word LIKE @txtSearchCriteria AND ZIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_Default DefaultIndex
					WHERE DefaultIndex.Word LIKE @txtSearchCriteria AND DefaultIndex.PageId = P.PageID
				)
			) Matches, --PageMatches

			0 ContentID,
			'CONT' ContentType,
			'' Note


		

	FROM	Content C 
		INNER JOIN dbo.ControlProperties CP ON C.ContentID = CP.PropertyValue
		INNER JOIN Page P ON CP.InstanceID = P.PageID

	WHERE	(C.TextContent LIKE @txtSearchCriteria) 
	AND 	(C.IsLive = 1) AND (C.IsSearchable = 1) 
	AND 	(P.IsLive = 1) AND (P.IsSearchable = 1)
	AND		CP.PropertyType = 'CONT'


	UNION


	SELECT	DISTINCT TOP 100			 
			P.PageID, 
			P.Title, 
			P.Url, 
			P.MetaKeywords, 
			P.MetaDescription, 
			P.LastModified LastModified, 
			P.LastModifiedBy LastModifiedBy,
/*
			(
				SELECT LastModified FROM [Content] C
				
				WHERE 
				ORDER BY LastModified DESC
			) XXX,
*/
			(
				SELECT 
				(
					SELECT Count(*) FROM dbo.ContentIndex_A AIndex
					WHERE AIndex.Word LIKE @txtSearchCriteria AND AIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_B BIndex
					WHERE BIndex.Word LIKE @txtSearchCriteria AND BIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_C CIndex
					WHERE CIndex.Word LIKE @txtSearchCriteria AND CIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_D DIndex
					WHERE DIndex.Word LIKE @txtSearchCriteria AND DIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_E EIndex
					WHERE EIndex.Word LIKE @txtSearchCriteria AND EIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_F FIndex
					WHERE FIndex.Word LIKE @txtSearchCriteria AND FIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_G GIndex
					WHERE GIndex.Word LIKE @txtSearchCriteria AND GIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_H HIndex
					WHERE HIndex.Word LIKE @txtSearchCriteria AND HIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_I IIndex
					WHERE IIndex.Word LIKE @txtSearchCriteria AND IIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_J JIndex
					WHERE JIndex.Word LIKE @txtSearchCriteria AND JIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_K KIndex
					WHERE KIndex.Word LIKE @txtSearchCriteria AND KIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_L LIndex
					WHERE LIndex.Word LIKE @txtSearchCriteria AND LIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_M MIndex
					WHERE MIndex.Word LIKE @txtSearchCriteria AND MIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_N NIndex
					WHERE NIndex.Word LIKE @txtSearchCriteria AND NIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_O OIndex
					WHERE OIndex.Word LIKE @txtSearchCriteria AND OIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_P PIndex
					WHERE PIndex.Word LIKE @txtSearchCriteria AND PIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_Q QIndex
					WHERE QIndex.Word LIKE @txtSearchCriteria AND QIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_R RIndex
					WHERE RIndex.Word LIKE @txtSearchCriteria AND RIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_S SIndex
					WHERE SIndex.Word LIKE @txtSearchCriteria AND SIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_T TIndex
					WHERE TIndex.Word LIKE @txtSearchCriteria AND TIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_U UIndex
					WHERE UIndex.Word LIKE @txtSearchCriteria AND UIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_V VIndex
					WHERE VIndex.Word LIKE @txtSearchCriteria AND VIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_W WIndex
					WHERE WIndex.Word LIKE @txtSearchCriteria AND WIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_X XIndex
					WHERE XIndex.Word LIKE @txtSearchCriteria AND XIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_Y YIndex
					WHERE YIndex.Word LIKE @txtSearchCriteria AND YIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_Z ZIndex
					WHERE ZIndex.Word LIKE @txtSearchCriteria AND ZIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_Default DefaultIndex
					WHERE DefaultIndex.Word LIKE @txtSearchCriteria AND DefaultIndex.ContentId = C.ContentId
				)
			) Matches, --ContentMatches


			C.ContentId,
			C.ContentType,
			C.Note

	FROM	Content C 
		INNER JOIN dbo.ControlProperties CP ON C.ContentID = CP.PropertyValue
		INNER JOIN Page P ON CP.InstanceID = P.PageID

	WHERE	(C.TextContent LIKE @txtSearchCriteria) 
	AND 	(C.IsLive = 1) AND (C.IsSearchable = 1) 
	AND 	(P.IsLive = 1) AND (P.IsSearchable = 1)
	AND		CP.PropertyType = 'BLOG'


















	--ORDER BY PageMatches DESC, ContentMatches DESC, P.LastModified DESC, P.PageID DESC	--, C.ContentID
	ORDER BY Matches DESC, LastModified DESC

	-- Content_SEARCH '%SQL%'
	-- Content_SEARCH '%fool%'
	-- Content_SEARCH '%frodo%'
	-- Content_SEARCH '%because%'
GO
/****** Object:  StoredProcedure [dbo].[ContentMarshal_DELETE_ContentForPage]    Script Date: 05/14/2009 16:56:03 ******/
 
GO
 
GO




/****** Object:  StoredProcedure [dbo].[ContentMarshal_DELETE_ContentForPage]    Script Date: 06/29/2009 20:44:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContentMarshal_DELETE_ContentForPage]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ContentMarshal_DELETE_ContentForPage]

GO

/****** Object:  Stored Procedure dbo.ContentMarshal_DELETE_ContentForPage    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure [dbo].[ContentMarshal_DELETE_ContentForPage]

	@intPageID int

AS

	SET NOCOUNT ON

	DELETE FROM [dbo].[ContentMarshal]
	WHERE	PageID = @intPageID
GO
/****** Object:  StoredProcedure [dbo].[ContentMarshal_INSERT_ContentItemForPage]    Script Date: 05/14/2009 16:56:03 ******/
 
GO
 
GO



/****** Object:  StoredProcedure [dbo].[ContentMarshal_INSERT_ContentItemForPage]    Script Date: 06/29/2009 20:44:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContentMarshal_INSERT_ContentItemForPage]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ContentMarshal_INSERT_ContentItemForPage]

GO

/****** Object:  Stored Procedure dbo.ContentMarshal_INSERT_ContentItemForPage    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure [dbo].[ContentMarshal_INSERT_ContentItemForPage]

	@intPageID int,
	@intContentID int,
	@intSortOrder int

AS

	SET NOCOUNT ON

	INSERT INTO [dbo].[ContentMarshal]([PageID], [ContentID], [SortOrder])
	VALUES (
		@intPageID,
		@intContentID,
		@intSortOrder
	)
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_ActiveContentForIndexing]    Script Date: 05/14/2009 16:55:57 ******/
 
GO
 
GO



/****** Object:  StoredProcedure [dbo].[Content_SELECT_ActiveContentForIndexing]    Script Date: 06/29/2009 20:45:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Content_SELECT_ActiveContentForIndexing]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Content_SELECT_ActiveContentForIndexing]

GO

/****** Object:  Stored Procedure dbo.Content_SELECT_ActiveContentForIndexing    Script Date: 10/02/2007 8:11:37 p.m. ******/
/****** Object:  Stored Procedure dbo.Content_SELECT_ActiveContentForIndexing    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_ActiveContentForIndexing]


AS


	/*
	Selects text ready to be indexed:
	 * TextContent of Content Items where:
		- IsLive = 1
		- IsSearchable = 1



	*/



	SET NOCOUNT ON



	SELECT Content.TextContent   --,Content.ContentID 

	FROM	dbo.Content

	WHERE	Content.ContentID IN (
	
		SELECT DISTINCT C.ContentID
	
		FROM	Content C 
			INNER JOIN ContentMarshal CM ON C.ContentID = CM.ContentID 
			INNER JOIN Page P ON CM.PageID = P.PageID
	
		WHERE	(C.IsLive = 1) 
		AND 	(C.IsSearchable = 1) 
		AND 	(P.IsSearchable = 1) 
		AND 	(P.IsLive = 1)
	)

	ORDER BY Content.ContentID
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_List_ById]    Script Date: 05/14/2009 16:55:59 ******/
 
GO
 
GO



/****** Object:  StoredProcedure [dbo].[Content_SELECT_List_ById]    Script Date: 06/29/2009 20:45:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Content_SELECT_List_ById]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Content_SELECT_List_ById]

GO

/****** Object:  Stored Procedure dbo.Content_SELECT_List_ById    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_List_ById]

	@intContentId_1 int,
	@intContentId_2 int = -1,
	@intContentId_3 int = -1,
	@intContentId_4 int = -1,
	@intContentId_5 int = -1
	

AS

	-- Content_SELECT_List_ById 67
	-- Content_SELECT_List_ById 51, 53, 44, 67, 68
	SET NOCOUNT ON

	SELECT	C.ContentID, 
			C.Note, 
			C.ContentType,
			C.IsLive, 
			C.IsSearchable, 
			C.LastModified, 
			C.LastModifiedBy,
			(SELECT Count(*) FROM dbo.ControlProperties CP WHERE PropertyType = 'CONT' AND PropertyValue = C.ContentID) PageUsageCount

	FROM		dbo.Content C

	WHERE		C.ContentID = @intContentId_1
			OR	C.ContentID = @intContentId_2
			OR	C.ContentID = @intContentId_3
			OR	C.ContentID = @intContentId_4
			OR	C.ContentID = @intContentId_5
	
	ORDER BY 	C.Note,
				C.ContentID
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_List_Search]    Script Date: 05/14/2009 16:56:00 ******/
 
GO
 
GO


/****** Object:  StoredProcedure [dbo].[Content_SELECT_List_Search]    Script Date: 06/29/2009 20:45:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Content_SELECT_List_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Content_SELECT_List_Search]

GO

/****** Object:  Stored Procedure dbo.Content_SELECT_List_Search    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_List_Search]

	@txtNotes varchar(25),
	@txtContentType char(4) = '____'

AS

	SET NOCOUNT ON
	-- Content_SELECT_List_Search '%a%'
	-- Content_SELECT_List_Search '%a%', 'CONT'

	IF @txtContentType = '____'
	BEGIN

		SELECT	C.ContentID, 
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.LastModified, 
				C.LastModifiedBy,
				(SELECT Count(*) FROM dbo.ControlProperties CP WHERE PropertyType = 'CONT' AND PropertyValue = C.ContentID) PageUsageCount

		FROM		dbo.Content C

		WHERE		C.Note LIKE @txtNotes
		
		ORDER BY 	C.Note,
					C.ContentID

	END
	ELSE
	BEGIN

		SELECT	C.ContentID, 
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.LastModified, 
				C.LastModifiedBy,
				(SELECT Count(*) FROM dbo.ControlProperties CP WHERE PropertyType = 'CONT' AND PropertyValue = C.ContentID) PageUsageCount

		FROM		dbo.Content C

		WHERE		C.Note LIKE @txtNotes
			AND		C.ContentType = @txtContentType
		
		ORDER BY 	C.Note,
					C.ContentID
	END
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_CTagsForLiveBlogs]    Script Date: 05/14/2009 16:56:06 ******/
 
GO
 
GO


/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_CTagsForLiveBlogs]    Script Date: 06/29/2009 20:46:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlProperties_SELECT_CTagsForLiveBlogs]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ControlProperties_SELECT_CTagsForLiveBlogs]

GO

CREATE Procedure [dbo].[ControlProperties_SELECT_CTagsForLiveBlogs]

-- ControlProperties_SELECT_CTagsForLiveBlogs
-- SELECT * FROM ControlProperties



AS

	SET NOCOUNT ON


	SELECT	CP.PropertyValue, Count(*) TagCount
	FROM	[ControlProperties] CP
		INNER JOIN [Content] C ON InstanceId = C.ContentId
	WHERE	[InstanceID] IN 
	(
		SELECT DISTINCT PropertyValue
		FROM 	[ControlProperties]
			INNER JOIN Page P ON InstanceId = P.PageId
		WHERE	PropertyType = 'BLOG'
		AND		P.IsLive = 1
	)
	AND		CP.PropertyType = 'CTAG'
	AND		C.IsLive = 1
	GROUP BY PropertyValue
	ORDER BY PropertyValue
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_ContentItemIdsBYInstanceID]    Script Date: 05/14/2009 16:55:59 ******/
 
GO
 
GO
/****** Object:  Stored Procedure dbo.Content_SELECT_PageByID_ForLivePublishing    Script Date: 10/02/2007 8:11:37 p.m. ******/




/****** Object:  StoredProcedure [dbo].[Content_SELECT_ContentItemIdsBYInstanceID]    Script Date: 06/29/2009 20:47:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Content_SELECT_ContentItemIdsBYInstanceID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Content_SELECT_ContentItemIdsBYInstanceID]

GO

--dbo.Content_SELECT_PageByID_ForLivePublishing
CREATE Procedure [dbo].[Content_SELECT_ContentItemIdsBYInstanceID]

-- Content_SELECT_PageByID_ForLivePublishing 4, 'CONT'
-- SELECT * FROM ControlProperties

	@intInstanceID int,
	@txtPropertyType char(4)

AS

	SET NOCOUNT ON

	
	SELECT	PropertyValue

	FROM 	[ControlProperties]

	WHERE 	[InstanceID] = @intInstanceID
	AND	PropertyType = @txtPropertyType

	ORDER BY [ID], PropertyKey
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_List_SearchLiveOnlyLiveOnly]    Script Date: 05/14/2009 16:56:00 ******/
 


/****** Object:  StoredProcedure [dbo].[Content_SELECT_List_SearchLiveOnlyLiveOnly]    Script Date: 06/29/2009 20:47:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Content_SELECT_List_SearchLiveOnlyLiveOnly]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Content_SELECT_List_SearchLiveOnlyLiveOnly]

GO

/****** Object:  Stored Procedure dbo.Content_SELECT_List_SearchLiveOnly    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_List_SearchLiveOnlyLiveOnly]

	@txtNotes varchar(25)

AS

	-- Content_SELECT_List_Search 'Book%'
	-- Content_SELECT_List_SearchLiveOnly 'Book%'

	SET NOCOUNT ON

	SELECT		C.ContentID, 
			C.TextContent, 
			C.Note, 
			C.IsLive, 
			C.IsSearchable, 
			C.LastModified, 
			C.LastModifiedBy,
			(SELECT Count(*) FROM dbo.ControlProperties CP WHERE PropertyType = 'CONT' AND PropertyValue = C.ContentID) PageUsageCount

	FROM		dbo.Content C

	WHERE		C.Note LIKE @txtNotes
	AND		C.IsLive = 1
	
	ORDER BY 	C.Note,
			C.ContentID
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_List]    Script Date: 05/14/2009 16:55:59 ******/
 




/****** Object:  StoredProcedure [dbo].[Content_SELECT_List]    Script Date: 06/29/2009 20:48:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Content_SELECT_List]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Content_SELECT_List]

GO

/****** Object:  Stored Procedure dbo.Content_SELECT_List    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_List]

	@txtContentType char(4) = '____'

AS

	SET NOCOUNT ON

	IF @txtContentType = '____'
	BEGIN

		SELECT	C.ContentID, 
				C.TextContent, 
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.LastModified, 
				C.LastModifiedBy,
				--(SELECT Count(*) FROM dbo.ContentMarshal CM WHERE ContentID = C.ContentID) PageUsageCount,
				(SELECT Count(*) FROM dbo.ControlProperties CP WHERE PropertyType = 'CONT' AND PropertyValue = C.ContentID) PageUsageCount

		FROM	dbo.Content C
		
		ORDER BY 
				C.Note,
				C.ContentID

	END
	ELSE
	BEGIN

		SELECT	C.ContentID, 
				C.TextContent, 
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.LastModified, 
				C.LastModifiedBy,
				--(SELECT Count(*) FROM dbo.ContentMarshal CM WHERE ContentID = C.ContentID) PageUsageCount,
				(SELECT Count(*) FROM dbo.ControlProperties CP WHERE PropertyType = 'CONT' AND PropertyValue = C.ContentID) PageUsageCount

		FROM	dbo.Content C

		WHERE	C.ContentType = @txtContentType
		
		ORDER BY 
				C.Note,
				C.ContentID

	END
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_PageByID]    Script Date: 05/14/2009 16:56:00 ******/
 
GO
 
GO



/****** Object:  StoredProcedure [dbo].[Content_SELECT_PageByID]    Script Date: 06/29/2009 20:48:41 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Content_SELECT_PageByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Content_SELECT_PageByID]

GO

/****** Object:  Stored Procedure dbo.Content_SELECT_PageByID    Script Date: 10/02/2007 8:11:37 p.m. ******/
/****** Object:  Stored Procedure dbo.Content_SELECT_PageByID    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_PageByID]

-- Content_SELECT_PageByID 1

	@intPageInstanceID int

AS

	SET NOCOUNT ON


	SELECT	
		C.ContentID, 
		C.Content, 
		C.TextContent,
		C.Note, 
		C.ContentType,
		C.IsLive, 
		C.IsSearchable,
		C.ContentFilter, 
		C.LastModified, 
		C.LastModifiedBy

	FROM	dbo.Content C

	WHERE	C.ContentID IN 
		(
			SELECT	PropertyValue

			FROM 	[ControlProperties]

			WHERE 	[InstanceID] = @intPageInstanceID
			AND		PropertyType = 'CONT'
		)
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_DELETE_BYID]    Script Date: 05/14/2009 16:56:04 ******/
 
GO
 
GO
/****** Object:  Stored Procedure dbo.ControlProperties_DELETE_BYID    Script Date: 10/02/2007 8:11:37 p.m. ******/



/****** Object:  StoredProcedure [dbo].[ControlProperties_DELETE_BYID]    Script Date: 06/29/2009 20:48:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlProperties_DELETE_BYID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ControlProperties_DELETE_BYID]

GO

CREATE Procedure [dbo].[ControlProperties_DELETE_BYID]

-- ControlProperties_DELETE_BYID 2, 'sdaa1', 'asdadas1'
-- SELECT * FROM ControlProperties

	@intID int

AS

	SET NOCOUNT ON

	
	DELETE FROM [ControlProperties]
	WHERE [ID] = @intID
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_DELETE_BYInstanceID]    Script Date: 05/14/2009 16:56:04 ******/
 
GO
 
GO
/****** Object:  Stored Procedure dbo.ControlProperties_DELETE_BYInstanceID    Script Date: 10/02/2007 8:11:37 p.m. ******/



/****** Object:  StoredProcedure [dbo].[ControlProperties_DELETE_BYInstanceID]    Script Date: 06/29/2009 20:49:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlProperties_DELETE_BYInstanceID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ControlProperties_DELETE_BYInstanceID]

GO

CREATE Procedure [dbo].[ControlProperties_DELETE_BYInstanceID]

-- ControlProperties_DELETE_BYInstanceID 1
-- SELECT * FROM ControlProperties

	@intInstanceID int

AS

	SET NOCOUNT ON

	
	DELETE FROM [ControlProperties]
	WHERE InstanceID = @intInstanceID
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_DELETE_BYInstanceIDPropertyKey]    Script Date: 05/14/2009 16:56:04 ******/
 
GO
 
GO
/****** Object:  Stored Procedure dbo.ControlProperties_DELETE_BYInstanceIDPropertyKey    Script Date: 10/02/2007 8:11:37 p.m. ******/



/****** Object:  StoredProcedure [dbo].[ControlProperties_DELETE_BYInstanceIDPropertyKey]    Script Date: 06/29/2009 20:49:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlProperties_DELETE_BYInstanceIDPropertyKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ControlProperties_DELETE_BYInstanceIDPropertyKey]

GO

CREATE Procedure [dbo].[ControlProperties_DELETE_BYInstanceIDPropertyKey]

-- ControlProperties_DELETE_BYInstanceIDPropertyKey 150, 'LayoutWebControlType'
-- SELECT * FROM ControlProperties

	@intInstanceID int,
	@txtPropertyKey varchar(200)

AS

	SET NOCOUNT ON

	
	DELETE FROM [ControlProperties]
	WHERE 	InstanceID = @intInstanceID 
	AND		PropertyKey = @txtPropertyKey
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_INSERT]    Script Date: 05/14/2009 16:56:05 ******/
 
GO
 
GO
/****** Object:  Stored Procedure dbo.ControlProperties_INSERT    Script Date: 10/02/2007 8:11:37 p.m. ******/




/****** Object:  StoredProcedure [dbo].[ControlProperties_INSERT]    Script Date: 06/29/2009 20:49:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlProperties_INSERT]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ControlProperties_INSERT]

GO

CREATE Procedure [dbo].[ControlProperties_INSERT]

-- ControlProperties_INSERT 1, 'aa1', 'bb1'
-- ControlProperties_INSERT 1, 'aa2', 'bb2'
-- ControlProperties_INSERT 2, 'sdaa1', 'asdadas1'
-- ControlProperties_INSERT 2, 'sdaaX', 'asdadasZ'
-- SELECT * FROM ControlProperties

	@intInstanceID int,
	@txtPropertyType char(4),
	@txtPropertyKey varchar(200),
	@txtPropertyValue varchar(2000)

AS

	SET NOCOUNT ON

	
	INSERT INTO [ControlProperties]
	(
		[InstanceID], 
		[PropertyType],
		[PropertyKey], 
		[PropertyValue]
	)
	VALUES	
	(
		@intInstanceID, 
		@txtPropertyType,
		@txtPropertyKey, 
		@txtPropertyValue
	)
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_BYID]    Script Date: 05/14/2009 16:56:05 ******/
 
GO
 
GO
/****** Object:  Stored Procedure dbo.ControlProperties_SELECT_BYID    Script Date: 10/02/2007 8:11:37 p.m. ******/





/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_BYID]    Script Date: 06/29/2009 20:50:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlProperties_SELECT_BYID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ControlProperties_SELECT_BYID]

GO

CREATE Procedure [dbo].[ControlProperties_SELECT_BYID]

-- ControlProperties_SELECT_BYID 5
-- SELECT * FROM ControlProperties

	@intID int

AS

	SET NOCOUNT ON

	
	SELECT	InstanceID, 
			PropertyKey, 
			PropertyValue

	FROM [ControlProperties]

	WHERE [ID] = @intID
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_BYInstanceID]    Script Date: 05/14/2009 16:56:05 ******/
 
GO
 
GO



/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_BYInstanceID]    Script Date: 06/29/2009 20:50:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlProperties_SELECT_BYInstanceID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ControlProperties_SELECT_BYInstanceID]

GO

CREATE Procedure [dbo].[ControlProperties_SELECT_BYInstanceID]

-- ControlProperties_SELECT_BYInstanceID 47
-- ControlProperties_SELECT_BYInstanceID 47, 'CONT'
-- ControlProperties_SELECT_BYInstanceID 47, 'CUST'
-- SELECT * FROM ControlProperties

	@intInstanceID int

AS

	SET NOCOUNT ON


		SELECT	[ID], 
			PropertyType,
			PropertyKey, 
			PropertyValue

		FROM 	[ControlProperties]

		WHERE 	[InstanceID] = @intInstanceID

		ORDER BY PropertyType, PropertyKey, [ID]
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_BYInstanceIDPropertyKey]    Script Date: 05/14/2009 16:56:06 ******/
 
GO
 
GO
/****** Object:  Stored Procedure dbo.ControlProperties_SELECT_BYInstanceIDPropertyKey    Script Date: 10/02/2007 8:11:37 p.m. ******/



/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_BYInstanceIDPropertyKey]    Script Date: 06/29/2009 20:50:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlProperties_SELECT_BYInstanceIDPropertyKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ControlProperties_SELECT_BYInstanceIDPropertyKey]

GO

CREATE Procedure [dbo].[ControlProperties_SELECT_BYInstanceIDPropertyKey]

-- ControlProperties_SELECT_BYInstanceIDPropertyKey 86, 'LayoutWebControlType'
-- SELECT * FROM ControlProperties

	@intInstanceID int,
	@txtPropertyKey varchar(200)

AS

	SET NOCOUNT ON

	
	SELECT	[ID], 
			PropertyType,
			PropertyValue

	FROM [ControlProperties]

	WHERE 	InstanceID = @intInstanceID
	AND		PropertyKey = @txtPropertyKey

	ORDER BY [ID]
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_BYInstanceIDPropertyType]    Script Date: 05/14/2009 16:56:06 ******/
 
GO
 
GO





/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_BYInstanceIDPropertyType]    Script Date: 06/29/2009 20:55:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlProperties_SELECT_BYInstanceIDPropertyType]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ControlProperties_SELECT_BYInstanceIDPropertyType]

GO

CREATE Procedure [dbo].[ControlProperties_SELECT_BYInstanceIDPropertyType]

-- ControlProperties_SELECT_BYInstanceIDPropertyType 47
-- ControlProperties_SELECT_BYInstanceIDPropertyType 47, 'CONT'
-- ControlProperties_SELECT_BYInstanceIDPropertyType 47, 'CUST'
-- SELECT * FROM ControlProperties

	@intInstanceID int,
	@txtPropertyType char(4)

AS

	SET NOCOUNT ON




		SELECT	[ID], 
			PropertyType,
			PropertyKey, 
			PropertyValue

		FROM 	[ControlProperties]

		WHERE 	[InstanceID] = @intInstanceID
		AND	PropertyType = @txtPropertyType

		ORDER BY PropertyType, PropertyKey, [ID]
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_BYPropertyKey]    Script Date: 05/14/2009 16:56:06 ******/
 
GO
 
GO
--ControlProperties_SELECT_BYPropertyKey




/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_BYPropertyKey]    Script Date: 06/29/2009 20:56:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlProperties_SELECT_BYPropertyKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ControlProperties_SELECT_BYPropertyKey]

GO

CREATE Procedure [dbo].[ControlProperties_SELECT_BYPropertyKey]


-- ControlProperties_SELECT_BYPropertyKey 'LayoutWebControlType'
-- SELECT * FROM ControlProperties

	@txtPropertyKey varchar(200)

AS

	SET NOCOUNT ON

	
	SELECT	[ID], 
		InstanceId,
		PropertyType,
		PropertyKey,
		PropertyValue

	FROM [ControlProperties]

	WHERE 	PropertyKey = @txtPropertyKey

	ORDER BY InstanceId, [ID]
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_ContentItemIdsBYInstanceID]    Script Date: 05/14/2009 16:56:07 ******/
 
GO
 
GO
/****** Object:  Stored Procedure dbo.ControlProperties_SELECT_ContentItemIdsBYInstanceID    Script Date: 10/02/2007 8:11:37 p.m. ******/




/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_ContentItemIdsBYInstanceID]    Script Date: 06/29/2009 20:56:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlProperties_SELECT_ContentItemIdsBYInstanceID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ControlProperties_SELECT_ContentItemIdsBYInstanceID]

GO

CREATE Procedure [dbo].[ControlProperties_SELECT_ContentItemIdsBYInstanceID]

-- ControlProperties_SELECT_ContentItemIdsBYInstanceID 2
-- SELECT * FROM ControlProperties

	@intInstanceID int,
	@txtPropertyType char(4)

AS

	SET NOCOUNT ON

	
	SELECT	[ID], 
			PropertyType,
			PropertyKey, 
			PropertyValue

	FROM 	[ControlProperties]

	WHERE 	[InstanceID] = @intInstanceID
	AND		PropertyType = @txtPropertyType

	ORDER BY [ID], PropertyKey
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_PageByID_ForLivePublishing]    Script Date: 05/14/2009 16:56:00 ******/
 
GO
 
GO
/****** Object:  Stored Procedure dbo.Content_SELECT_PageByID_ForLivePublishing    Script Date: 13/03/2007 1:50:46 p.m. ******/




/****** Object:  StoredProcedure [dbo].[Content_SELECT_PageByID_ForLivePublishing]    Script Date: 06/29/2009 20:56:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Content_SELECT_PageByID_ForLivePublishing]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Content_SELECT_PageByID_ForLivePublishing]

GO

--dbo.Content_SELECT_PageByID_ForLivePublishing
CREATE Procedure [dbo].[Content_SELECT_PageByID_ForLivePublishing]

-- Content_SELECT_PageByID_ForLivePublishing 14
-- SELECT * FROM ControlProperties

	@intPageInstanceID int

AS

	SET NOCOUNT ON


	SELECT	
		C.ContentID, 
		C.Content, 
		C.TextContent,
		C.ContentType,
		C.Note, 
		C.IsLive, 
		C.IsSearchable, 
		C.ContentFilter,
		C.LastModified, 
		C.LastModifiedBy

	FROM	dbo.Content C

	WHERE	C.ContentID IN 
		(
			SELECT	PropertyValue

			FROM 	[ControlProperties]

			WHERE 	[InstanceID] = @intPageInstanceID
			AND	(PropertyType = 'CONT' OR PropertyType = 'BLOG')
		)
	AND	C.IsLive = 1
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_BYPropertyType]    Script Date: 05/14/2009 16:56:07 ******/
 
GO
 
GO



/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_BYPropertyType]    Script Date: 06/29/2009 20:57:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlProperties_SELECT_BYPropertyType]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ControlProperties_SELECT_BYPropertyType]

GO

CREATE Procedure [dbo].[ControlProperties_SELECT_BYPropertyType]

	-- ControlProperties_SELECT_BYPropertyType 'BLOG'
	-- SELECT * FROM ControlProperties

	@txtPropertyType char(4),
	@txtPropertyValue varchar(2000) = null

AS

	SET NOCOUNT ON

	IF @txtPropertyValue IS NULL
	BEGIN
		SELECT	[ID], 
			InstanceId,
			PropertyType,
			PropertyKey,
			PropertyValue
		FROM	[ControlProperties]
		WHERE 	PropertyType = @txtPropertyType
		ORDER BY InstanceId, [ID]
	END
	ELSE
	BEGIN
		SELECT	[ID], 
			InstanceId,
			PropertyType,
			PropertyKey,
			PropertyValue
		FROM	[ControlProperties]
		WHERE 	PropertyType = @txtPropertyType
		AND		PropertyValue = @txtPropertyValue
		ORDER BY InstanceId, [ID]
	END
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_ListAllOrphans]    Script Date: 05/14/2009 16:56:00 ******/
 
GO
 
GO




/****** Object:  StoredProcedure [dbo].[Content_SELECT_ListAllOrphans]    Script Date: 06/29/2009 20:57:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Content_SELECT_ListAllOrphans]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Content_SELECT_ListAllOrphans]

GO

/****** Object:  Stored Procedure dbo.Content_SELECT_ListAllOrphans    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_ListAllOrphans]



AS

	-- Content_SELECT_ListAllOrphans 58
	-- SELECT * FROM dbo.Page WHERE PageID = 58
	-- SELECT * FROM dbo.ContentMarshal
	
	-- Content_SELECT_ListAllOrphans

	SET NOCOUNT ON

	SELECT	C.ContentID, 
		C.TextContent, 
		C.Note, 
		C.ContentType,
		C.IsLive, 
		C.IsSearchable, 
		C.LastModified, 
		C.LastModifiedBy,
		0 PageUsageCount

	FROM Content C 

	WHERE C.ContentID NOT IN 
	(
		SELECT CAST(PropertyValue AS INT) ContentId FROM dbo.ControlProperties WHERE PropertyType = 'CONT'
	) 

	ORDER BY C.ContentID
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_DELETE_BYInstanceIDPropertyType]    Script Date: 05/14/2009 16:56:04 ******/
 
GO
 
GO
/****** Object:  Stored Procedure dbo.ControlProperties_DELETE_BYInstanceIDPropertyType    Script Date: 10/02/2007 8:11:37 p.m. ******/




/****** Object:  StoredProcedure [dbo].[ControlProperties_DELETE_BYInstanceIDPropertyType]    Script Date: 06/29/2009 20:58:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlProperties_DELETE_BYInstanceIDPropertyType]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ControlProperties_DELETE_BYInstanceIDPropertyType]

GO

CREATE Procedure [dbo].[ControlProperties_DELETE_BYInstanceIDPropertyType]

	-- SELECT * FROM ControlProperties

	@intInstanceID int,
	@txtPropertyType char(4)

AS

	SET NOCOUNT ON

	
	DELETE FROM [ControlProperties]
	WHERE 	InstanceID = @intInstanceID 
	AND		PropertyType = @txtPropertyType
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_ByDateLastModified]    Script Date: 05/14/2009 16:55:58 ******/
 
GO
 
GO



/****** Object:  StoredProcedure [dbo].[Content_SELECT_ByDateLastModified]    Script Date: 06/29/2009 20:59:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Content_SELECT_ByDateLastModified]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Content_SELECT_ByDateLastModified]

GO

/****** Object:  Stored Procedure dbo.Content_SELECT_ByContentID    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_ByDateLastModified]

	-- Content_SELECT_ByDateLastModified '2009-01-09 00:00:00.000', '2009-04-09 23:59:59.000'


	@startDate datetime,
	@endDate datetime

AS

	SET NOCOUNT ON


	SELECT	C.ContentID, 
			C.Note ContentNote, 
			C.Content,
			C.ContentType,
			C.IsLive ContentIsLive, 
			C.IsSearchable ContentIsSearchable, 
			C.ContentFilter ContentEntryFilter,
			C.LastModified ContentLastModified, 
			C.LastModifiedBy ContentLastModifiedBy,
			P.PageID,
			P.Title PageTitle, 
			P.Url PageUrl, 
			P.MetaKeywords PageKeywords, 
			P.MetaDescription PageDescription, 
			P.LastModified PageLastModified,
			P.LastModifiedBy PageLastModifiedBy,
			P.IsSearchable PageIsSearchable,
			P.IsLive PageIsLive


	FROM	dbo.Content C
		INNER JOIN ControlProperties Props ON C.ContentId = Props.PropertyValue 
		INNER JOIN Page P ON Props.InstanceID = P.PageID

	WHERE 	Props.PropertyKey = 'BlogPost'
	AND		(C.LastModified >= @startDate AND C.LastModified < @endDate)
	AND		P.IsLive = 1
	AND		C.IsLive = 1

	ORDER BY C.LastModified DESC


GO





/****** Object:  StoredProcedure [dbo].[Content_SELECT_SearchLiveOnly]    Script Date: 06/29/2009 21:00:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Content_SELECT_SearchLiveOnly]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Content_SELECT_SearchLiveOnly]

GO

/****** Object:  Stored Procedure dbo.Content_SELECT_SearchLiveOnly    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_SearchLiveOnly]

	@txtNotes varchar(25),
	@txtContentType char(4) = '____'

AS

	-- Content_SELECT_List_Search 'Book%'
	-- Content_SELECT_SearchLiveOnly 'Book%'

	SET NOCOUNT ON

	IF @txtContentType = '____'
	BEGIN

		SELECT	C.ContentID, 
				C.Content,
				C.TextContent, 
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.ContentFilter,
				C.LastModified, 
				C.LastModifiedBy

		FROM		dbo.Content C

		WHERE	C.Note LIKE @txtNotes
		AND		C.IsLive = 1
		
		ORDER BY 	C.Note, C.ContentID

	END
	ELSE
	BEGIN

		SELECT	C.ContentID, 
				C.Content,
				C.TextContent, 
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.ContentFilter,
				C.LastModified, 
				C.LastModifiedBy

		FROM		dbo.Content C

		WHERE	C.Note LIKE @txtNotes
		AND		C.IsLive = 1
		AND		C.ContentType = @txtContentType
		
		ORDER BY 	C.Note, C.ContentID

	END
GO
/****** Object:  StoredProcedure [dbo].[Content_INSERT]    Script Date: 05/14/2009 16:55:57 ******/
 
GO
 
GO



/****** Object:  StoredProcedure [dbo].[Content_INSERT]    Script Date: 06/29/2009 21:00:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Content_INSERT]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Content_INSERT]

GO

/****** Object:  Stored Procedure dbo.Content_INSERT    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_INSERT]


	@IDENTITY int OUTPUT,
	@txtContent ntext,
	@txtTextContent ntext,
	@txtNote varchar(500),
	@txtContentType char(4),
	@bitIsLive bit,
	@bitIsSearchable bit,
	@txtContentEntryFilter varchar(300),
	@txtLastUpdatedBy varchar(101)

AS

	SET NOCOUNT ON



	INSERT INTO [dbo].[Content](
		[Content], 
		[TextContent], 
		[Note], 
		[ContentType],
		[IsLive], 
		[IsSearchable], 
		[ContentFilter],
		[LastModified], 
		[LastModifiedBy]
	)
	VALUES (
		@txtContent,
		@txtTextContent,
		@txtNote,
		@txtContentType,
		@bitIsLive,
		@bitIsSearchable,
		@txtContentEntryFilter,
		GetDate(), 
		@txtLastUpdatedBy
	)


	SELECT @IDENTITY = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_ByContentID]    Script Date: 05/14/2009 16:55:58 ******/
 
GO
 
GO



/****** Object:  StoredProcedure [dbo].[Content_SELECT_ByContentID]    Script Date: 06/29/2009 21:01:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Content_SELECT_ByContentID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Content_SELECT_ByContentID]

GO

/****** Object:  Stored Procedure dbo.Content_SELECT_ByContentID    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_ByContentID]

	-- Content_SELECT_ByContentID 1

	@intContentID int

AS

	SET NOCOUNT ON

	SELECT	C.ContentID, 
			C.Content, 
			C.TextContent,
			C.Note, 
			C.ContentType,
			C.IsLive, 
			C.IsSearchable, 
			C.ContentFilter,
			C.LastModified, 
			C.LastModifiedBy

	FROM	dbo.Content C

	WHERE	C.ContentID = @intContentID
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT]    Script Date: 05/14/2009 16:55:57 ******/
 
GO
 
GO



/****** Object:  StoredProcedure [dbo].[Content_SELECT]    Script Date: 06/29/2009 21:01:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Content_SELECT]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Content_SELECT]

GO

/****** Object:  Stored Procedure dbo.Content_SELECT    Script Date: 10/02/2007 8:11:37 p.m. ******/
/****** Object:  Stored Procedure dbo.Content_SELECT    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT]

	@txtContentType char(4) = '____'

AS

	SET NOCOUNT ON

	IF @txtContentType = '____'
	BEGIN

		SELECT	C.ContentID, 
				C.Content,
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.ContentFilter,
				C.LastModified, 
				C.LastModifiedBy

		FROM	dbo.Content C
		
		ORDER BY C.LastModified DESC

	END
	ELSE
	BEGIN

		SELECT	C.ContentID, 
				C.Content,
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.ContentFilter,
				C.LastModified, 
				C.LastModifiedBy

		FROM	dbo.Content C

		WHERE	C.ContentType = @txtContentType
		
		ORDER BY C.LastModified DESC

	END
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_ByContentNote]    Script Date: 05/14/2009 16:55:58 ******/
 
GO
 
GO




/****** Object:  StoredProcedure [dbo].[Content_SELECT_ByContentNote]    Script Date: 06/29/2009 21:01:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Content_SELECT_ByContentNote]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Content_SELECT_ByContentNote]

GO

/****** Object:  Stored Procedure dbo.Content_SELECT_ByContentID    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_ByContentNote]

	-- Content_SELECT_ByContentNote 'zz Test - Not Live, Searchable', 1
	-- Content_SELECT_ByContentNote 'zz Test - Not Live, Searchable', 0
	-- Content_SELECT_ByContentNote 'Wow! This is a blog post', 1
	-- Content_SELECT_ByContentNote 'Wow! This is a blog post', 0


	@txtNote varchar(500),
	@bLiveOnly bit

AS

	SET NOCOUNT ON


	IF @bLiveOnly = 1
	BEGIN

		SELECT	C.ContentID, 
				C.Content, 
				C.TextContent,
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.ContentFilter,
				C.LastModified, 
				C.LastModifiedBy

		FROM	dbo.Content C

		WHERE	C.Note = @txtNote
		AND		C.IsLive = 1

		ORDER BY C.LastModified DESC

	END
	ELSE
	BEGIN

		SELECT	C.ContentID, 
				C.Content, 
				C.TextContent,
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.ContentFilter,
				C.LastModified, 
				C.LastModifiedBy

		FROM	dbo.Content C

		WHERE	C.Note = @txtNote

		ORDER BY C.LastModified DESC

	END
GO




exec spGrantExectoAllStoredProcs 'ASPNET'

