/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/****** Object:  Stored Procedure dbo.WordIndex_SEARCH    Script Date: 27/11/2005 4:05:16 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[WordIndex_SEARCH]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[WordIndex_SEARCH]
GO



/****** Object:  Stored Procedure dbo.WordIndex_SEARCH    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure WordIndex_SEARCH

	-- WordIndex_SEARCH '1'
	-- WordIndex_SEARCH '16'

	-- WordIndex_SEARCH 'a'
	-- WordIndex_SEARCH 'ac'
	-- WordIndex_SEARCH 'acc'
	-- WordIndex_SEARCH 'acco'
	-- WordIndex_SEARCH 'Acco'

	@txtCriteria varchar(100)

AS

	SET NOCOUNT ON


	DECLARE @txtLetter varchar(1)
	DECLARE @done bit

	SET @txtLetter = LEFT(@txtCriteria, 1)
	SET @txtCriteria = @txtCriteria + '%'
	SET @done = 0
	

	IF @txtLetter = 'a'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_A Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_A Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_A Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'b'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_B Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_B Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_B Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'c'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_C Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_C Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_C Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'd'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_D Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_D Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_D Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'e'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_E Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_E Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_E Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'f'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_F Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_F Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_F Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'g'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_G Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_G Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_G Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'h'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_H Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_H Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_H Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'i'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_I Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_I Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_I Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'j'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_J Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_J Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_J Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'k'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_K Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_K Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_K Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'l'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_L Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_L Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_L Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'm'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_M Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_M Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_M Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'n'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_N Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_N Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_N Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'o'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_O Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_O Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_O Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'p'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_P Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_P Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_P Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'q'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_Q Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_Q Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_Q Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'r'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_R Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_R Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_R Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 's'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_S Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_S Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_S Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 't'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_T Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_T Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_T Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'u'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_U Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_U Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_U Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'v'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_V Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_V Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_V Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'w'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_W Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_W Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_W Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'x'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_X Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_X Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_X Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'y'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_Y Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_Y Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_Y Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'z'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_Z Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_Z Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_Z Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF (@done = 0)
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_Default Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_Default Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_Default Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END






GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

