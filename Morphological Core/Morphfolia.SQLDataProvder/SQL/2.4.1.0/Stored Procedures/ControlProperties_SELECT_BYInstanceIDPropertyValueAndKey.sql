/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */



/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_BYInstanceIDPropertyValueAndKey]    Script Date: 05/27/2009 13:10:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlProperties_SELECT_BYInstanceIDPropertyValueAndKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ControlProperties_SELECT_BYInstanceIDPropertyValueAndKey]



/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_BYInstanceIDPropertyValueAndKey]    Script Date: 05/27/2009 13:10:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO




/****** Object:  Stored Procedure dbo.Content_SELECT_ByContentID    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[ControlProperties_SELECT_BYInstanceIDPropertyValueAndKey]

	@intInstanceId int,
	@txtPropertyValue varchar(2000),
	@txtPropertyKey varchar(200)

AS

	SET NOCOUNT ON

	-- ControlProperties_SELECT_BYInstanceIDPropertyValueAndKey 61, 70, 'BlogPost'

	SELECT	ID, 
			InstanceID, 
			PropertyType, 
			PropertyKey, 
			PropertyValue
	FROM	ControlProperties 
	WHERE	InstanceId = @intInstanceId
	AND		PropertyKey = @txtPropertyKey
	AND		PropertyValue = @txtPropertyValue

	