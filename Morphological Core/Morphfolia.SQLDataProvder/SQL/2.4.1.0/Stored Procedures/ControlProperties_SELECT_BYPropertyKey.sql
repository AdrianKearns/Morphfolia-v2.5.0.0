/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ControlProperties_SELECT_BYPropertyKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ControlProperties_SELECT_BYPropertyKey]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

	       --ControlProperties_SELECT_BYPropertyKey
CREATE Procedure ControlProperties_SELECT_BYPropertyKey


-- ControlProperties_SELECT_BYPropertyKey 'LayoutWebControlType'
-- SELECT * FROM ControlProperties

	@txtPropertyKey varchar(200)

AS

	SET NOCOUNT ON

	
	SELECT	[ID], 
		InstanceId,
		PropertyType,
		PropertyKey,
		PropertyValue

	FROM [ControlProperties]

	WHERE 	PropertyKey = @txtPropertyKey

	ORDER BY InstanceId, [ID]


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

