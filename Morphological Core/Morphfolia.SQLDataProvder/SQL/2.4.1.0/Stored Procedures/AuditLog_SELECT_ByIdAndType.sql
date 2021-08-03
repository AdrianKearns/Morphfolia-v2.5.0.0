/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */



/****** Object:  StoredProcedure [dbo].[AuditLog_SELECT_ByIdAndType]    Script Date: 11/14/2008 20:05:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AuditLog_SELECT_ByIdAndType]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AuditLog_SELECT_ByIdAndType]


-- AuditLog_SELECT_ByIdAndType -1, 'TestObject'
-- SELECT * FROM [AuditLog]


/****** Object:  StoredProcedure [dbo].[AuditLog_SELECT_ByIdAndType]    Script Date: 11/14/2008 20:06:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [AuditLog_SELECT_ByIdAndType] 

	@intObjectId int,
	@txtObjectType varchar(50)
	
AS 

-- AuditLog_SELECT_ByIdAndType 70, 'Licence'
-- SELECT * FROM AuditLog

	SELECT * 

	FROM [AuditLog]

	WHERE	ObjectId = @intObjectId
	AND		ObjectType = @txtObjectType

SET NOCOUNT OFF