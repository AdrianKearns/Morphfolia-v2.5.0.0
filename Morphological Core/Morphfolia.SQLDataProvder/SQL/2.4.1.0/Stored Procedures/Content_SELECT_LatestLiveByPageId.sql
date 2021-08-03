/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */



/****** Object:  StoredProcedure [dbo].[Content_SELECT_LatestLiveByPageId]    Script Date: 04/17/2009 15:37:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Content_SELECT_LatestLiveByPageId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Content_SELECT_LatestLiveByPageId]




/****** Object:  StoredProcedure [dbo].[Content_SELECT_LatestLiveByPageId]    Script Date: 06/02/2009 20:30:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



/****** Object:  Stored Procedure dbo.Content_SELECT_LatestLiveByPageId    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_LatestLiveByPageId]

	-- Content_SELECT_LatestLiveByPageId 62
	-- Content_SELECT_LatestLiveByPageId 14, 'CONT'
	-- Content_SELECT_LatestLiveByPageId 61, 'BPST'

	@intPageID int,
	@txtContentType char(4) = 'BPST'

AS

	SET NOCOUNT ON

	SELECT	TOP 3
			C.ContentID, 
			C.Content, 
			C.TextContent,
			C.Note, 
			C.ContentType,
			C.IsLive, 
			C.IsSearchable, 
			C.ContentFilter,
			C.LastModified, 
			C.LastModifiedBy

	FROM	dbo.Content C
	INNER JOIN dbo.ControlProperties CP ON C.ContentID = CP.PropertyValue
	INNER JOIN dbo.Page P ON CP.InstanceID = P.PageID

	WHERE	P.PageID = @intPageID
		AND	CP.PropertyType = @txtContentType
		AND	P.IsLive = 1
		AND	C.IsLive = 1

	ORDER BY C.LastModified DESC
