/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */



/****** Object:  Stored Procedure dbo.ContentIndex_SELECT_WordIndexList    Script Date: 20/05/2007 9:23:12 a.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ContentIndex_SELECT_WordIndexList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ContentIndex_SELECT_WordIndexList]
GO



/****** Object:  Stored Procedure dbo.ContentIndex_SELECT_WordIndexList    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec ContentIndex_SELECT_WordIndexList @txtSearchCriteria = '%acc%'


/****** Object:  Stored Procedure dbo.ContentIndex_SELECT_WordIndexList    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure ContentIndex_SELECT_WordIndexList

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
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_Default Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
	END
GO


