/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */



/****** Object:  StoredProcedure [dbo].[HttpLog_SELECT_UrlHistory4WeekReport]    Script Date: 06/22/2010 18:01:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HttpLog_SELECT_UrlHistory4WeekReport]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[HttpLog_SELECT_UrlHistory4WeekReport]



/****** Object:  StoredProcedure [dbo].[HttpLog_SELECT_UrlHistory4WeekReport]    Script Date: 06/22/2010 18:01:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO




/****** Object:  Stored Procedure dbo.HttpLog_SELECT_UrlHistory4WeekReport    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec HttpLog_SELECT_UrlHistory4WeekReport @txtSearchCriteria = '%acc%'


/****** Object:  Stored Procedure dbo.HttpLog_SELECT_UrlHistory4WeekReport    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[HttpLog_SELECT_UrlHistory4WeekReport]

	@targetUrl varchar(500),
	@periodEnding datetime = null
	
AS

	SET NOCOUNT ON

	-- SELECT * FROM HttpLog ORDER BY LogId DESC
	-- SELECT TimeLogged, Count(*) c FROM HttpLog GROUP BY TimeLogged ORDER BY c DESC
	-- SELECT DATEPART(dd, TimeLogged) M, Count(*) c FROM HttpLog GROUP BY DATEPART(dd, TimeLogged) ORDER BY M DESC
	-- HttpLog_SELECT_UrlHistory4WeekReport 'http://localhost/Morphfolia.Web/SearchResults.aspx'
/*
	exec HttpLog_SELECT_UrlHistory4WeekReport 'http://localhost/Morphfolia.Web/default.aspx'
	exec HttpLog_SELECT_UrlHistory4WeekReport 'http://localhost/Morphfolia.Web/default.aspx', '2010-04-13 00:00:00.000'
*/
	-- SELECT @targetUrl 'TargetURL', @rangeStart 'RangeStart', @rangeEnd 'RangeEnd'

	DECLARE @dtNow datetime, @dt1 datetime, @dt2 datetime

	IF @periodEnding Is NULL
	BEGIN
		SELECT @dtNow = GetDate()
	END
	ELSE
	BEGIN
		SELECT @dtNow = @periodEnding
	END
	
	-- Drop the time component, go from midnight?

	SET @dt1 = @dtNow

	SET @dt2 = DATEADD(week, -1, @dt1)
	EXEC HttpLog_SELECT_UrlHistory @targetUrl, @dt2, @dt1

	SET @dt1 = DATEADD(week, -1, @dt1)
	SET @dt2 = DATEADD(week, -1, @dt1)
	EXEC HttpLog_SELECT_UrlHistory @targetUrl, @dt2, @dt1

	SET @dt1 = DATEADD(week, -1, @dt1)
	SET @dt2 = DATEADD(week, -1, @dt1)
	EXEC HttpLog_SELECT_UrlHistory @targetUrl, @dt2, @dt1

	SET @dt1 = DATEADD(week, -1, @dt1)
	SET @dt2 = DATEADD(week, -1, @dt1)
	EXEC HttpLog_SELECT_UrlHistory @targetUrl, @dt2, @dt1

