/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */



/****** Object:  StoredProcedure [dbo].[Content_SELECT_ForBlogRSS]    Script Date: 05/27/2009 13:10:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Content_SELECT_ForBlogRSS]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Content_SELECT_ForBlogRSS]


/****** Object:  StoredProcedure [dbo].[Content_SELECT_ForBlogRSS]    Script Date: 06/07/2009 09:41:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



/****** Object:  Stored Procedure dbo.Content_SELECT_ForBlogRSS    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_ForBlogRSS]

	-- Content_SELECT_ForBlogRSS 62
	-- Content_SELECT_ForBlogRSS 14, 'CONT'
	-- Content_SELECT_ForBlogRSS 61, 'BPST'

	@intPageID int,
	@txtContentType char(4) = 'BPST'

AS

	SET NOCOUNT ON

	SELECT	TOP 25
			C.ContentID, 
			C.Note ContentNote, 
			C.Content,
			C.ContentType,
			C.IsLive ContentIsLive, 
			C.IsSearchable ContentIsSearchable, 
			C.ContentFilter ContentEntryFilter,
			C.LastModified ContentLastModified, 
			C.LastModifiedBy ContentLastModifiedBy,

			P.PageID,
			P.Title PageTitle, 
			P.Url PageUrl, 
			P.MetaKeywords PageKeywords, 
			P.MetaDescription PageDescription, 
			P.LastModified PageLastModified,
			P.LastModifiedBy PageLastModifiedBy,
			P.IsSearchable PageIsSearchable,
			P.IsLive PageIsLive  

/*
,
			(
				SELECT	PropertyValue

				FROM 	[ControlProperties]

				WHERE 	[InstanceID] = C.ContentID
				AND		PropertyType = 'CTAG'

				ORDER BY PropertyValue
			)
*/



	FROM	dbo.Content C
	INNER JOIN dbo.ControlProperties CP ON C.ContentID = CP.PropertyValue
	INNER JOIN dbo.Page P ON CP.InstanceID = P.PageID

	WHERE		P.PageID = @intPageID
		AND		CP.PropertyType = @txtContentType
		AND		P.IsLive = 1
		AND		C.IsLive = 1

	ORDER BY C.LastModified DESC
