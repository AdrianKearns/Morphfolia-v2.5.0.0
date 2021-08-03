/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */






/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_BlogPostsByCTag]    Script Date: 04/17/2009 15:37:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlProperties_SELECT_BlogPostsByCTag]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ControlProperties_SELECT_BlogPostsByCTag]



/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_BlogPostsByCTag]    Script Date: 04/17/2009 14:59:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE Procedure [dbo].[ControlProperties_SELECT_BlogPostsByCTag]

-- ControlProperties_SELECT_BlogPostsByCTag 'EASTER'
-- ControlProperties_SELECT_BlogPostsByCTag 'JAZZ'
-- ControlProperties_SELECT_BlogPostsByCTag 'Test'
-- SELECT * FROM ControlProperties

	@txtTag varchar(2000)

AS

	SET NOCOUNT ON

	SELECT DISTINCT P.PageId, 
		P.Title,
		P.Url, 
		P.MetaKeywords,
		P.MetaDescription,
		C.LastModified, 
		C.LastModifiedBy,
		1 Matches, --Count(*),
		C.ContentId, 
		C.Note,
		C.ContentType		
	FROM 	[ControlProperties] CP2 INNER JOIN Page P ON InstanceId = P.PageId
		INNER JOIN [Content] C ON CP2.PropertyValue = C.ContentId
	WHERE	PropertyType = 'BPST'
	AND		P.IsLive = 1
	AND		C.IsLive = 1
	AND		CP2.PropertyValue IN 
	(
		SELECT	CP.InstanceId
		FROM	[ControlProperties] CP INNER JOIN [Content] C ON CP.InstanceId = C.ContentId
		WHERE	CP.PropertyType = 'CTAG'
		AND		CP.PropertyValue = @txtTag
		AND		CP.InstanceId IS NOT NULL
		AND		CP2.PropertyValue = CP.InstanceId 
	)
	ORDER BY C.LastModified DESC
	





