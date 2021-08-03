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

/****** Object:  Stored Procedure dbo.ControlProperties_SELECT_ContentItemIdsBYInstanceID    Script Date: 16/11/2006 8:04:18 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ControlProperties_SELECT_ContentItemIdsBYInstanceID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ControlProperties_SELECT_ContentItemIdsBYInstanceID]
GO


CREATE Procedure ControlProperties_SELECT_ContentItemIdsBYInstanceID

-- ControlProperties_SELECT_ContentItemIdsBYInstanceID 2
-- SELECT * FROM ControlProperties

	@intInstanceID int,
	@txtPropertyType char(4)

AS

	SET NOCOUNT ON

	
	SELECT	[ID], 
			PropertyType,
			PropertyKey, 
			PropertyValue

	FROM 	[ControlProperties]

	WHERE 	[InstanceID] = @intInstanceID
	AND		PropertyType = @txtPropertyType

	ORDER BY [ID], PropertyKey



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

