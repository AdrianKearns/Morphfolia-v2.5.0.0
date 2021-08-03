/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */



/****** Object:  StoredProcedure [dbo].[HttpLog_SELECT_UrlHistory]    Script Date: 06/22/2010 18:04:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HttpLog_SELECT_UrlHistory]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[HttpLog_SELECT_UrlHistory]



/****** Object:  StoredProcedure [dbo].[HttpLog_SELECT_UrlHistory]    Script Date: 06/22/2010 18:04:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO




/****** Object:  Stored Procedure dbo.HttpLog_SELECT_UrlHistory    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec HttpLog_SELECT_UrlHistory @txtSearchCriteria = '%acc%'


/****** Object:  Stored Procedure dbo.HttpLog_SELECT_UrlHistory    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[HttpLog_SELECT_UrlHistory]

	@targetUrl varchar(500),
	@rangeStart datetime,
	@rangeEnd datetime
	
AS

	SET NOCOUNT ON

	-- SELECT * FROM HttpLog ORDER BY LogId DESC
	-- SELECT TimeLogged, Count(*) c FROM HttpLog GROUP BY TimeLogged ORDER BY c DESC
	-- SELECT DATEPART(dd, TimeLogged) M, Count(*) c FROM HttpLog GROUP BY DATEPART(dd, TimeLogged) ORDER BY M DESC
	-- HttpLog_SELECT_UrlHistory 'http://localhost/Morphfolia.Web/SearchResults.aspx'
/*
	exec HttpLog_SELECT_UrlHistory 'http://localhost/Morphfolia.Web/default.aspx', '1999-04-08 00:00:00.000', '1999-04-14 00:00:00.000'
	exec HttpLog_SELECT_UrlHistory 'http://localhost/Morphfolia.Web/default.aspx', '2010-01-08 00:00:00.000', '2010-04-14 00:00:00.000'
	exec HttpLog_SELECT_UrlHistory 'http://localhost/Morphfolia.Web/default.aspx', '2010-04-08 00:00:00.000', '2010-04-14 00:00:00.000'
	exec HttpLog_SELECT_UrlHistory 'http://localhost/Morphfolia.Web/default.aspx', '2010-04-08 00:00:00.000', '2010-04-11 00:00:00.000'
	exec HttpLog_SELECT_UrlHistory 'http://localhost/Morphfolia.Web/default.aspx', '2010-04-11 00:00:00.000', '2010-04-14 00:00:00.000'
*/
	SELECT @targetUrl 'TargetURL', @rangeStart 'RangeStart', @rangeEnd 'RangeEnd'


	-- The number of hits aganist the target URL, by Referrer.
	SELECT	UrlReferrer, Url, Count(*) HitCount
	FROM 	HttpLog 
	WHERE 	(Url = @targetUrl OR Url LIKE @targetUrl + '?%')
	AND 	(TimeLogged >= @rangeStart AND TimeLogged < @rangeEnd)
	GROUP BY Url, UrlReferrer
	ORDER BY HitCount DESC

	-- The number of times the target URL has been a Referrer.
	SELECT	Url, Count(*) ReferrerHits
	FROM 	HttpLog 
	WHERE 	(UrlReferrer = @targetUrl OR UrlReferrer LIKE @targetUrl + '?%')
	AND 	(TimeLogged >= @rangeStart AND TimeLogged < @rangeEnd)
	GROUP BY Url
	ORDER BY ReferrerHits DESC

	-- List of sessions that have hit the target URL, plus the number 
	-- of hits that session has had.
	SELECT	SessionId, Count(*) Hits
	FROM 	HttpLog 
	WHERE 	(Url = @targetUrl OR Url LIKE @targetUrl + '?%')
	AND 	(TimeLogged >= @rangeStart AND TimeLogged < @rangeEnd)
	GROUP BY SessionId
	ORDER BY Hits DESC



	-- The total number of hits for the target URL, regardless of client/user 
	-- so may include robots, RSS readers and legitimate human traffic.
	SELECT	Count(*) HitsTotal
	FROM 	HttpLog 
	WHERE 	(Url = @targetUrl OR Url LIKE @targetUrl + '?%')
	AND 	(TimeLogged >= @rangeStart AND TimeLogged < @rangeEnd)

	-- The total number of times the target URL has been a referrer.
	SELECT	Count(*) ReferrerHitsTotal
	FROM 	HttpLog 
	WHERE 	(UrlReferrer = @targetUrl OR UrlReferrer LIKE @targetUrl + '?%')
	AND 	(TimeLogged >= @rangeStart AND TimeLogged < @rangeEnd)

	-- The total of hits for the same period - by search bots.
	SELECT	Count(*) BotTotal
	FROM 	HttpLog 
	WHERE 	(Url = @targetUrl OR Url LIKE @targetUrl + '?%')
	AND 	(TimeLogged >= @rangeStart AND TimeLogged < @rangeEnd)
	AND		MiscInfo LIKE 'Browser%bot%'





	-- The grand total of hits for the same period.
	SELECT	Count(*) GrandTotal
	FROM 	HttpLog 
	WHERE 	(TimeLogged >= @rangeStart AND TimeLogged < @rangeEnd)

	-- The grand total of hits for the same period - by search bots.
	SELECT	Count(*) BotGrandTotal
	FROM 	HttpLog 
	WHERE 	(TimeLogged >= @rangeStart AND TimeLogged < @rangeEnd)
	AND	MiscInfo LIKE 'Browser%bot%'

	-- The grand total of hits for the same period - by RSS readers.
	SELECT	Count(*) RSSReaderGrandTotal
	FROM 	HttpLog 
	WHERE 	(TimeLogged >= @rangeStart AND TimeLogged < @rangeEnd)
	AND		(URL LIKE '%rss.ashx' OR URL LIKE '%atom.ashx')

