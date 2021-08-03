/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ControlProperties_SELECT_BYInstanceIDPropertyType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ControlProperties_SELECT_BYInstanceIDPropertyType]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure ControlProperties_SELECT_BYInstanceIDPropertyType

-- ControlProperties_SELECT_BYInstanceIDPropertyType 47
-- ControlProperties_SELECT_BYInstanceIDPropertyType 47, 'CONT'
-- ControlProperties_SELECT_BYInstanceIDPropertyType 47, 'CUST'
-- ControlProperties_SELECT_BYInstanceIDPropertyType 71, 'CTAG'

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
		AND	PropertyType = @txtPropertyType

		ORDER BY PropertyType, PropertyKey, [ID]

	

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

