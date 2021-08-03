/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */






/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_CTagsForLiveBlogs]    Script Date: 04/17/2009 15:37:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlProperties_SELECT_CTagsForLiveBlogs]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ControlProperties_SELECT_CTagsForLiveBlogs]



/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_CTagsForLiveBlogs]    Script Date: 04/17/2009 14:59:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE Procedure [dbo].[ControlProperties_SELECT_CTagsForLiveBlogs]

-- ControlProperties_SELECT_CTagsForLiveBlogs 
-- ControlProperties_SELECT_CTagsForLiveBlogs 1
-- ControlProperties_SELECT_CTagsForLiveBlogs 0
-- SELECT * FROM ControlProperties

	@bOrderAlphabetically bit = 1

AS

	SET NOCOUNT ON

	IF @bOrderAlphabetically = 1
	BEGIN

		SELECT	CP.PropertyValue, Count(*) TagCount
		FROM	[ControlProperties] CP
			INNER JOIN [Content] C ON InstanceId = C.ContentId
		WHERE	[InstanceID] IN 
		(
			SELECT DISTINCT PropertyValue
			FROM 	[ControlProperties]
				INNER JOIN Page P ON InstanceId = P.PageId
			WHERE	PropertyType = 'BPST'
			AND		P.IsLive = 1
		)
		AND		CP.PropertyType = 'CTAG'
		AND		C.IsLive = 1
		GROUP BY PropertyValue
		ORDER BY PropertyValue

	END
	ELSE
	BEGIN

		SELECT	CP.PropertyValue, Count(*) TagCount
		FROM	[ControlProperties] CP
			INNER JOIN [Content] C ON InstanceId = C.ContentId
		WHERE	[InstanceID] IN 
		(
			SELECT DISTINCT PropertyValue
			FROM 	[ControlProperties]
				INNER JOIN Page P ON InstanceId = P.PageId
			WHERE	PropertyType = 'BPST'
			AND		P.IsLive = 1
		)
		AND		CP.PropertyType = 'CTAG'
		AND		C.IsLive = 1
		GROUP BY PropertyValue
		ORDER BY TagCount DESC

	END


