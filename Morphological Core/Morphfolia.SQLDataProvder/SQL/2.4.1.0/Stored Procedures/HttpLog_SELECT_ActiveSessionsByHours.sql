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

/****** Object:  Stored Procedure dbo.HttpLog_SELECT_ActiveSessionsByHours    Script Date: 2/09/2007 3:19:29 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[HttpLog_SELECT_ActiveSessionsByHours]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[HttpLog_SELECT_ActiveSessionsByHours]
GO




/****** Object:  Stored Procedure dbo.HttpLog_SELECT_ActiveSessionsByHours    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec HttpLog_SELECT_ActiveSessionsByHours @txtSearchCriteria = '%acc%'


/****** Object:  Stored Procedure dbo.HttpLog_SELECT_ActiveSessionsByHours    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure HttpLog_SELECT_ActiveSessionsByHours

	@numberOfHours int = 24

AS

	SET NOCOUNT ON

	-- HttpLog_SELECT_ActiveSessionsByHours
	-- HttpLog_SELECT_ActiveSessionsByHours 24
	-- HttpLog_SELECT_ActiveSessionsByHours 672 	--( weeks)

	-- SELECT * FROM HttpLog
	-- HttpLog_SELECT_ActiveSessionsByDateRange '2007-9-9', '2007-9-10'

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
	WHERE DATEDIFF(hour, TimeLogged, getdate()) <= @numberOfHours
	GROUP BY H.SessionId, H.UserHostName
	ORDER BY LastUrlRequest DESC

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

