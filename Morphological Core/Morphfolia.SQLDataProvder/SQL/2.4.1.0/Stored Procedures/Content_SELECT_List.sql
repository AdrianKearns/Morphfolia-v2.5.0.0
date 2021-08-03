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

/****** Object:  Stored Procedure dbo.Content_SELECT_List    Script Date: 27/11/2005 4:05:16 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Content_SELECT_List]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Content_SELECT_List]
GO



/****** Object:  Stored Procedure dbo.Content_SELECT_List    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure Content_SELECT_List


AS

	SET NOCOUNT ON

SELECT	C.ContentID, 
			C.TextContent, 
			C.Note, 
			C.IsLive, 
			C.IsSearchable, 
			C.LastModified, 
			C.LastModifiedBy,
			--(SELECT Count(*) FROM dbo.ContentMarshal CM WHERE ContentID = C.ContentID) PageUsageCount,
			(SELECT Count(*) FROM dbo.ControlProperties CP WHERE PropertyType = 'CONT' AND PropertyValue = C.ContentID) PageUsageCount

	FROM	dbo.Content C
	
	ORDER BY 
			C.Note,
			C.ContentID


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

