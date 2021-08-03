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

/****** Object:  Stored Procedure dbo.HttpLog_SELECT_ReferreringUrlsForVisitedUrlByHours    Script Date: 2/09/2007 3:19:29 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[HttpLog_SELECT_ReferreringUrlsForVisitedUrlByHours]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[HttpLog_SELECT_ReferreringUrlsForVisitedUrlByHours]
GO




/****** Object:  Stored Procedure dbo.HttpLog_SELECT_ReferreringUrlsForVisitedUrlByHours    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec HttpLog_SELECT_ReferreringUrlsForVisitedUrlByHours @txtSearchCriteria = '%acc%'


/****** Object:  Stored Procedure dbo.HttpLog_SELECT_ReferreringUrlsForVisitedUrlByHours    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure HttpLog_SELECT_ReferreringUrlsForVisitedUrlByHours

	@visitedUrl varchar(500),
	@numberOfHours int = 24

AS

	SET NOCOUNT ON

	-- HttpLog_SELECT_ReferreringUrlsForVisitedUrlByHours '/SearchResults.aspx', 3000
	-- HttpLog_SELECT_ReferreringUrlsForVisitedUrlByHours 'http://localhost/Morphfolia.Web/SearchResults.aspx', 24
	-- HttpLog_SELECT_ReferreringUrlsForVisitedUrlByHours 
	
	-- Where did sessions go (destinations) after visiting the url specified?:
	SELECT	UrlReferrer, 
		Count(*) NumberOfHitsOnDestination
	FROM 	HttpLog 
	WHERE 	(Url = @visitedUrl OR Url LIKE @visitedUrl + '?%')
	AND	(DATEDIFF(hour, TimeLogged, getdate()) <= @numberOfHours)
	GROUP BY UrlReferrer
	ORDER BY NumberOfHitsOnDestination DESC

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

