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


/****** Object:  Stored Procedure dbo.Content_SELECT_PageByID_ForLivePublishing    Script Date: 13/03/2007 1:50:46 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Content_SELECT_PageByID_ForLivePublishing]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Content_SELECT_PageByID_ForLivePublishing]
GO


/****** Object:  Stored Procedure dbo.Content_SELECT_PageByID_ForLivePublishing    Script Date: 13/03/2007 1:50:46 p.m. ******/

--dbo.Content_SELECT_PageByID_ForLivePublishing
CREATE Procedure Content_SELECT_PageByID_ForLivePublishing

-- Content_SELECT_PageByID_ForLivePublishing 14
-- SELECT * FROM ControlProperties

	@intPageInstanceID int

AS

	SET NOCOUNT ON


	SELECT	
		C.ContentID, 
		C.Content, 
		C.TextContent,
		C.ContentType,
		C.Note, 
		C.IsLive, 
		C.IsSearchable, 
		C.ContentFilter,
		C.LastModified, 
		C.LastModifiedBy

	FROM	dbo.Content C

	WHERE	C.ContentID IN 
		(
			SELECT	PropertyValue

			FROM 	[ControlProperties]

			WHERE 	[InstanceID] = @intPageInstanceID
			AND	(PropertyType = 'CONT' OR PropertyType = 'BPST')
		)
	AND	C.IsLive = 1
	

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

