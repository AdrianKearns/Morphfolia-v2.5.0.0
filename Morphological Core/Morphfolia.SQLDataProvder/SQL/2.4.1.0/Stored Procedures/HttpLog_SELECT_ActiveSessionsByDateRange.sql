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

/****** Object:  Stored Procedure dbo.HttpLog_SELECT_ActiveSessionsByDateRange    Script Date: 27/09/2008 9:03:04 a.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[HttpLog_SELECT_ActiveSessionsByDateRange]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[HttpLog_SELECT_ActiveSessionsByDateRange]
GO





/****** Object:  Stored Procedure dbo.HttpLog_SELECT_ActiveSessionsByDateRange    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec HttpLog_SELECT_ActiveSessionsByDateRange @txtSearchCriteria = '%acc%'


/****** Object:  Stored Procedure dbo.HttpLog_SELECT_ActiveSessionsByDateRange    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure HttpLog_SELECT_ActiveSessionsByDateRange

	@rangeStart varchar(10),
	@rangeEnd varchar(10)

AS

	SET NOCOUNT ON


	-- SELECT * FROM HttpLog
	-- HttpLog_SELECT_ActiveSessionsByDateRange '2007-9-9', '2009-9-10'
	-- HttpLog_SELECT_ActiveSessionsByDateRange '2007-9-10', '2007-9-11'
	-- HttpLog_SELECT_ActiveSessionsByDateRange '2007-9-11', '2007-9-12'

	-- HttpLog_SELECT_ActiveSessionsByDateRange '2008-9-24', '2008-9-27'
	-- HttpLog_SELECT_ActiveSessionsByDateRange '2008-9-24', '2008-9-25'
	-- HttpLog_SELECT_ActiveSessionsByDateRange '2008-9-27', '2008-9-28'

/*
	SELECT 	H.SessionId, H.TimeLogged
	FROM HttpLog H
	WHERE TimeLogged >= '2008-9-24' AND TimeLogged < '2008-9-27'
*/

	-- Unique sessions within specific timespan:
	SELECT 	H.SessionId, 
			H.UserHostName,
		count(*) TotalPageRequests,
		(
			SELECT 	TOP 1 TimeLogged
			FROM	HttpLog
			WHERE	SessionId = H.SessionId
			ORDER BY TimeLogged ASC

		) 'FirstUrlRequest',
		(
			SELECT 	TOP 1 TimeLogged
			FROM	HttpLog
			WHERE	SessionId = H.SessionId
			ORDER BY TimeLogged DESC

		) 'LastUrlRequest',
		(
			SELECT 	TOP 1 Url
			FROM	HttpLog
			WHERE	SessionId = H.SessionId
			ORDER BY TimeLogged ASC

		) 'FirstUrlRequested',
		(
			SELECT 	TOP 1 Url
			FROM	HttpLog
			WHERE	SessionId = H.SessionId
			ORDER BY TimeLogged DESC

		) 'LastUrlRequested'


		
	FROM HttpLog H
	WHERE (TimeLogged >= @rangeStart) AND (TimeLogged < @rangeEnd)
	GROUP BY H.SessionId, H.UserHostName
	ORDER BY LastUrlRequest DESC

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

