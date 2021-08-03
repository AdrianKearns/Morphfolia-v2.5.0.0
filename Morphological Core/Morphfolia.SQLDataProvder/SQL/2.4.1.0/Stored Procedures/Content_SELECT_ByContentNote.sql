/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */


/****** Object:  StoredProcedure [Content_SELECT_ByContentNote]    Script Date: 03/21/2009 11:13:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Content_SELECT_ByContentNote]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Content_SELECT_ByContentNote]


/****** Object:  StoredProcedure [Content_SELECT_ByContentNote]    Script Date: 03/21/2009 11:13:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO




/****** Object:  Stored Procedure dbo.Content_SELECT_ByContentID    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [Content_SELECT_ByContentNote]

	-- Content_SELECT_ByContentNote 'zz Test - Not Live, Searchable', 1
	-- Content_SELECT_ByContentNote 'zz Test - Not Live, Searchable', 0
	-- Content_SELECT_ByContentNote 'Wow! This is a blog post', 1
	-- Content_SELECT_ByContentNote 'Wow! This is a blog post', 0


	@txtNote varchar(500),
	@bLiveOnly bit

AS

	SET NOCOUNT ON


	IF @bLiveOnly = 1
	BEGIN

		SELECT	C.ContentID, 
				C.Content, 
				C.TextContent,
				C.Note, 
				C.IsLive, 
				C.IsSearchable, 
				C.ContentFilter,
				C.LastModified, 
				C.LastModifiedBy

		FROM	dbo.Content C

		WHERE	C.Note = @txtNote
		AND		C.IsLive = 1

		ORDER BY C.LastModified DESC

	END
	ELSE
	BEGIN

		SELECT	C.ContentID, 
				C.Content, 
				C.TextContent,
				C.Note, 
				C.IsLive, 
				C.IsSearchable, 
				C.ContentFilter,
				C.LastModified, 
				C.LastModifiedBy

		FROM	dbo.Content C

		WHERE	C.Note = @txtNote

		ORDER BY C.LastModified DESC

	END