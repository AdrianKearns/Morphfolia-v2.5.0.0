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

/****** Object:  Stored Procedure dbo.Content_SELECT_ListAllOrphans    Script Date: 21/06/2007 7:45:01 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Content_SELECT_ListAllOrphans]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Content_SELECT_ListAllOrphans]
GO




/****** Object:  Stored Procedure dbo.Content_SELECT_ListAllOrphans    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure Content_SELECT_ListAllOrphans



AS

	-- Content_SELECT_ListAllOrphans 58
	-- SELECT * FROM dbo.Page WHERE PageID = 58
	-- SELECT * FROM dbo.ContentMarshal
	/*

SELECT PropertyValue FROM dbo.ControlProperties WHERE PropertyType = 'CONT'

SELECT CAST(PropertyValue AS INT) FROM dbo.ControlProperties WHERE PropertyType = 'CONT'

-- used content
SELECT C.ContentID, C.Note FROM Content C WHERE C.ContentID IN 
(
	SELECT CAST(PropertyValue AS INT) ContentId FROM dbo.ControlProperties WHERE PropertyType = 'CONT'
) ORDER BY C.ContentID

-- Orphan Content
SELECT C.ContentID OrphanContent, C.Note FROM Content C WHERE C.ContentID NOT IN 
(
	SELECT CAST(PropertyValue AS INT) FROM dbo.ControlProperties WHERE PropertyType = 'CONT'
) ORDER BY C.ContentID



SELECT * FROM Page WHERE PageID IN (
	SELECT InstanceId FROM dbo.ControlProperties WHERE PropertyType = 'CONT'
)

*/

	-- Content_SELECT_ListAllOrphans

	SET NOCOUNT ON

	SELECT	C.ContentID, 
		C.TextContent, 
		C.Note, 
		C.IsLive, 
		C.IsSearchable, 
		C.LastModified, 
		C.LastModifiedBy,
		0 PageUsageCount

	FROM Content C 

	WHERE C.ContentID NOT IN 
	(
		SELECT CAST(PropertyValue AS INT) ContentId FROM dbo.ControlProperties WHERE PropertyType = 'CONT'
	) 

	ORDER BY C.ContentID



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

