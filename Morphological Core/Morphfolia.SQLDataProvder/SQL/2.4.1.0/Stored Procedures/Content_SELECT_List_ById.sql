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

/****** Object:  Stored Procedure dbo.Content_SELECT_List_ById    Script Date: 27/11/2005 4:05:16 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Content_SELECT_List_ById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Content_SELECT_List_ById]
GO



/****** Object:  Stored Procedure dbo.Content_SELECT_List_ById    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure Content_SELECT_List_ById

	@intContentId_1 int,
	@intContentId_2 int = -1,
	@intContentId_3 int = -1,
	@intContentId_4 int = -1,
	@intContentId_5 int = -1
	

AS

	-- Content_SELECT_List_ById 67
	-- Content_SELECT_List_ById 51, 53, 44, 67, 68
	SET NOCOUNT ON

	SELECT	C.ContentID, 
			C.Note, 
			C.ContentType,
			C.IsLive, 
			C.IsSearchable, 
			C.LastModified, 
			C.LastModifiedBy,
			(SELECT Count(*) FROM dbo.ControlProperties CP WHERE PropertyType = 'CONT' AND PropertyValue = C.ContentID) PageUsageCount

	FROM		dbo.Content C

	WHERE		C.ContentID = @intContentId_1
			OR	C.ContentID = @intContentId_2
			OR	C.ContentID = @intContentId_3
			OR	C.ContentID = @intContentId_4
			OR	C.ContentID = @intContentId_5
	
	ORDER BY 	C.Note,
				C.ContentID


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

