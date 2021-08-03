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

/****** Object:  Stored Procedure dbo.HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange    Script Date: 2/09/2007 3:19:29 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange]
GO




/****** Object:  Stored Procedure dbo.HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange @txtSearchCriteria = '%acc%'


/****** Object:  Stored Procedure dbo.HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange

	@visitedUrl varchar(500),
	@visitedUrlOptional varchar(500) = '',
	@rangeStart varchar(10),
	@rangeEnd varchar(10)

AS

	SET NOCOUNT ON

	-- SELECT * FROM HttpLog ORDER BY LogId DESC
	-- HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange '/Morphfolia.Web/default.aspx', '/Morphfolia.Web/', '2007-9-9', '2007-9-10'

	IF @visitedUrlOptional <> ''
	BEGIN

		SELECT	Url, 
			Count(*) NumberOfHitsOnDestination
		FROM 	HttpLog 
		--WHERE 	(Url = @visitedUrl OR Url LIKE @visitedUrl + '?%')
		WHERE 	((UrlReferrer LIKE @visitedUrl + '%') OR (UrlReferrer LIKE @visitedUrlOptional + '%'))
		AND 	(TimeLogged >= @rangeStart AND TimeLogged < @rangeEnd)
		GROUP BY Url
		ORDER BY NumberOfHitsOnDestination DESC

		SELECT	Url, TimeLogged
		FROM 	HttpLog 
		WHERE 	((UrlReferrer LIKE @visitedUrl + '%') OR (UrlReferrer LIKE @visitedUrlOptional + '%'))
		AND 	(TimeLogged >= @rangeStart AND TimeLogged < @rangeEnd)

	END
	ELSE
	BEGIN

		SELECT	Url, 
			Count(*) NumberOfHitsOnDestination
		FROM 	HttpLog 
		WHERE 	UrlReferrer LIKE @visitedUrl + '%'
		AND 	(TimeLogged >= @rangeStart AND TimeLogged < @rangeEnd)
		GROUP BY Url
		ORDER BY NumberOfHitsOnDestination DESC


		SELECT	Url, TimeLogged
		FROM 	HttpLog 
		WHERE 	UrlReferrer LIKE @visitedUrl + '%'
		AND 	(TimeLogged >= @rangeStart AND TimeLogged < @rangeEnd)

	END





GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

