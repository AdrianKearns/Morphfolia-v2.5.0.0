/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ControlProperties_INSERT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ControlProperties_INSERT]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure ControlProperties_INSERT

-- ControlProperties_INSERT 1, 'aa1', 'bb1'
-- ControlProperties_INSERT 1, 'aa2', 'bb2'
-- ControlProperties_INSERT 2, 'sdaa1', 'asdadas1'
-- ControlProperties_INSERT 2, 'sdaaX', 'asdadasZ'
-- SELECT * FROM ControlProperties

	@intInstanceID int,
	@txtPropertyType char(4),
	@txtPropertyKey varchar(200),
	@txtPropertyValue varchar(2000)

AS

	SET NOCOUNT ON

	
	INSERT INTO [ControlProperties]
	(
		[InstanceID], 
		[PropertyType],
		[PropertyKey], 
		[PropertyValue]
	)
	VALUES	
	(
		@intInstanceID, 
		@txtPropertyType,
		@txtPropertyKey, 
		@txtPropertyValue
	)


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

