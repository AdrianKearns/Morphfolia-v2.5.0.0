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

/****** Object:  Stored Procedure dbo.Content_SELECT_ByContentID    Script Date: 27/11/2005 7:09:00 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Content_SELECT_ByContentID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Content_SELECT_ByContentID]
GO



/****** Object:  Stored Procedure dbo.Content_SELECT_ByContentID    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure Content_SELECT_ByContentID

	-- Content_SELECT_ByContentID 1

	@intContentID int

AS

	SET NOCOUNT ON

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

	WHERE	C.ContentID = @intContentID


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

