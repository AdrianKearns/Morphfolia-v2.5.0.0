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

/****** Object:  Stored Procedure dbo.ContentIndex_SELECT_WordsForTagCloud    Script Date: 5/07/2007 12:45:04 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ContentIndex_SELECT_WordsForTagCloud]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ContentIndex_SELECT_WordsForTagCloud]
GO




/****** Object:  Stored Procedure dbo.ContentIndex_SELECT_WordsForTagCloud    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec ContentIndex_SELECT_WordsForTagCloud @txtSearchCriteria = '%acc%'


/****** Object:  Stored Procedure dbo.ContentIndex_SELECT_WordsForTagCloud    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure ContentIndex_SELECT_WordsForTagCloud

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

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

