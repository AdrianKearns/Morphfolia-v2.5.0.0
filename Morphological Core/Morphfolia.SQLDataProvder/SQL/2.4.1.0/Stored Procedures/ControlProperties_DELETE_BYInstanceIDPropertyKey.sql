/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ControlProperties_DELETE_BYInstanceIDPropertyKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ControlProperties_DELETE_BYInstanceIDPropertyKey]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure ControlProperties_DELETE_BYInstanceIDPropertyKey

-- ControlProperties_DELETE_BYInstanceIDPropertyKey 150, 'LayoutWebControlType'
-- SELECT * FROM ControlProperties

	@intInstanceID int,
	@txtPropertyKey varchar(200)

AS

	SET NOCOUNT ON

	
	DELETE FROM [ControlProperties]
	WHERE 	InstanceID = @intInstanceID 
	AND		PropertyKey = @txtPropertyKey


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

