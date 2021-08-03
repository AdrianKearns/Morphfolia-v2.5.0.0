/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */




/****** Object:  StoredProcedure [dbo].[ControlProperties_DELETE_BYPropertyKeyAndPropertyValue]    Script Date: 03/31/2009 21:55:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlProperties_DELETE_BYPropertyKeyAndPropertyValue]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ControlProperties_DELETE_BYPropertyKeyAndPropertyValue]



/****** Object:  StoredProcedure [dbo].[ControlProperties_DELETE_BYPropertyKeyAndPropertyValue]    Script Date: 03/31/2009 21:55:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


/****** Object:  Stored Procedure dbo.ControlProperties_DELETE_BYPropertyKeyAndPropertyValue    Script Date: 10/02/2007 8:11:37 p.m. ******/

CREATE Procedure [dbo].[ControlProperties_DELETE_BYPropertyKeyAndPropertyValue]

	-- SELECT * FROM ControlProperties

	@txtPropertyKey varchar(200),
	@txtPropertyValue varchar(2000)

AS

	SET NOCOUNT ON

	
	DELETE FROM [ControlProperties]
	WHERE 	PropertyKey = @txtPropertyKey 
	AND		PropertyValue = @txtPropertyValue




