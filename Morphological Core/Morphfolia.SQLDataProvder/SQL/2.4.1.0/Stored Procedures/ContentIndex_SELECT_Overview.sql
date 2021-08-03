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

/****** Object:  Stored Procedure dbo.ContentIndex_SELECT_Overview    Script Date: 11/09/2008 6:52:51 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ContentIndex_SELECT_Overview]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ContentIndex_SELECT_Overview]
GO


/****** Object:  Stored Procedure dbo.ContentIndex_SELECT_Overview    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure ContentIndex_SELECT_Overview



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

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

