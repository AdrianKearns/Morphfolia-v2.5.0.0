/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].ControlProperties_SELECT_BYPropertyType') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ControlProperties_SELECT_BYPropertyType
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


CREATE Procedure ControlProperties_SELECT_BYPropertyType

	-- ControlProperties_SELECT_BYPropertyType 'BPST'
	-- ControlProperties_SELECT_BYPropertyType 'BPST', '109'
	-- SELECT * FROM ControlProperties

	@txtPropertyType char(4),
	@txtPropertyValue varchar(2000) = null

AS

	SET NOCOUNT ON

	IF @txtPropertyValue IS NULL
	BEGIN
		SELECT	[ID], 
			InstanceId,
			PropertyType,
			PropertyKey,
			PropertyValue
		FROM	[ControlProperties]
		WHERE 	PropertyType = @txtPropertyType
		ORDER BY InstanceId, [ID]
	END
	ELSE
	BEGIN
		SELECT	[ID], 
			InstanceId,
			PropertyType,
			PropertyKey,
			PropertyValue
		FROM	[ControlProperties]
		WHERE 	PropertyType = @txtPropertyType
		AND		PropertyValue = @txtPropertyValue
		ORDER BY InstanceId, [ID]
	END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

