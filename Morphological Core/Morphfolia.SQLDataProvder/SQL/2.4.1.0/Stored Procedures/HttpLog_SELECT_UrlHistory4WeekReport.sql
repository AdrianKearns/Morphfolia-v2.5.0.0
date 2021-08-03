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

/****** Object:  Stored Procedure dbo.HttpLog_SELECT_UrlHistory4WeekReport    Script Date: 2/09/2007 3:19:29 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[HttpLog_SELECT_UrlHistory4WeekReport]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[HttpLog_SELECT_UrlHistory4WeekReport]
GO




/****** Object:  Stored Procedure dbo.HttpLog_SELECT_UrlHistory4WeekReport    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec HttpLog_SELECT_UrlHistory4WeekReport @txtSearchCriteria = '%acc%'


/****** Object:  Stored Procedure dbo.HttpLog_SELECT_UrlHistory4WeekReport    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure HttpLog_SELECT_UrlHistory4WeekReport

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

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

