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

/****** Object:  Stored Procedure dbo.Content_SELECT_ActiveContentForIndexing    Script Date: 27/11/2005 4:05:16 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Content_SELECT_ActiveContentForIndexing]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Content_SELECT_ActiveContentForIndexing]
GO



/****** Object:  Stored Procedure dbo.Content_SELECT_ActiveContentForIndexing    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure Content_SELECT_ActiveContentForIndexing


AS


	/*
	Selects text ready to be indexed:
	 * TextContent of Content Items where:
		- IsLive = 1
		- IsSearchable = 1



	*/



	SET NOCOUNT ON



	SELECT Content.TextContent   --,Content.ContentID 

	FROM	dbo.Content

	WHERE	Content.ContentID IN (
	
		SELECT DISTINCT C.ContentID
	
		FROM	Content C 
			INNER JOIN ContentMarshal CM ON C.ContentID = CM.ContentID 
			INNER JOIN Page P ON CM.PageID = P.PageID
	
		WHERE	(C.IsLive = 1) 
		AND 	(C.IsSearchable = 1) 
		AND 	(P.IsSearchable = 1) 
		AND 	(P.IsLive = 1)
	)

	ORDER BY Content.ContentID







GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

