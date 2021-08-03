/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */



/****** Object:  StoredProcedure [dbo].[Content_SELECT_ListLatestLiveByPageId]    Script Date: 05/27/2009 13:10:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Content_SELECT_ListLatestLiveByPageId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Content_SELECT_ListLatestLiveByPageId]



/****** Object:  StoredProcedure [dbo].[Content_SELECT_ListLatestLiveByPageId]    Script Date: 05/27/2009 13:10:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO




/****** Object:  Stored Procedure dbo.Content_SELECT_ByContentID    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_ListLatestLiveByPageId]

	@intPageID int,
	@txtContentType char(4) = 'BPST'

AS

	-- Content_SELECT_ListLatestLiveByPageId 61, 'BPST'
	-- Content_SELECT_ListLatestLiveByPageId 62, 'BPST'
	-- Content_SELECT_ListLatestLiveByPageId 53, 'CONT'
	-- Content_SELECT_ListLatestLiveByPageId 53


	SET NOCOUNT ON

	IF @intPageId > -1
	BEGIN

		SELECT	DISTINCT
				--P.PageId,
				C.ContentID, 
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.ContentFilter,
				C.LastModified, 
				C.LastModifiedBy,
				(SELECT Count(*) FROM dbo.ControlProperties CP WHERE PropertyType = 'CONT' AND PropertyValue = C.ContentID) PageUsageCount

		FROM	dbo.Content C
			INNER JOIN ControlProperties Props ON C.ContentId = Props.PropertyValue 
			INNER JOIN Page P ON Props.InstanceID = P.PageID

		WHERE 	Props.PropertyType = @txtContentType
		AND		C.ContentType = @txtContentType
		AND		P.IsLive = 1
		AND		C.IsLive = 1
		AND		P.PageId = @intPageId

		ORDER BY C.LastModified DESC

	END
	ELSE
	BEGIN

		SELECT	DISTINCT
				--P.PageId,
				C.ContentID, 
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.ContentFilter,
				C.LastModified, 
				C.LastModifiedBy,
				(SELECT Count(*) FROM dbo.ControlProperties CP WHERE PropertyType = 'CONT' AND PropertyValue = C.ContentID) PageUsageCount

		FROM	dbo.Content C
			INNER JOIN ControlProperties Props ON C.ContentId = Props.PropertyValue 
			INNER JOIN Page P ON Props.InstanceID = P.PageID

		WHERE 	Props.PropertyType = @txtContentType
		AND		C.ContentType = @txtContentType
		AND		P.IsLive = 1
		AND		C.IsLive = 1

		ORDER BY C.LastModified DESC

	END