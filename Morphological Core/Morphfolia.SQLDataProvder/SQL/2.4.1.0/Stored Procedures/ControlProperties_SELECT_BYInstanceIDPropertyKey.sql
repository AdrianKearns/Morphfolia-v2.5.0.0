/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ControlProperties_SELECT_BYInstanceIDPropertyKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ControlProperties_SELECT_BYInstanceIDPropertyKey]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure ControlProperties_SELECT_BYInstanceIDPropertyKey

-- ControlProperties_SELECT_BYInstanceIDPropertyKey 86, 'LayoutWebControlType'
-- SELECT * FROM ControlProperties

	@intInstanceID int,
	@txtPropertyKey varchar(200)

AS

	SET NOCOUNT ON

	
	SELECT	[ID], 
			PropertyType,
			PropertyValue

	FROM [ControlProperties]

	WHERE 	InstanceID = @intInstanceID
	AND		PropertyKey = @txtPropertyKey

	ORDER BY [ID]


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

