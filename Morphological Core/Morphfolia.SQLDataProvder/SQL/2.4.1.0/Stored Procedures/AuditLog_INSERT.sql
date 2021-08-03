/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */



/****** Object:  StoredProcedure [dbo].[AuditLog_INSERT]    Script Date: 11/14/2008 20:05:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AuditLog_INSERT]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AuditLog_INSERT]


-- AuditLog_INSERT -1, 'TestObject', 'AdrianK', 'Test'
-- SELECT * FROM [AuditLog]


/****** Object:  StoredProcedure [dbo].[AuditLog_INSERT]    Script Date: 11/14/2008 20:06:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [AuditLog_INSERT] 

	@intObjectId int,
	@txtObjectType varchar(50),
	@txtUserIdentity varchar(101),
	@txtWindowsIdentity varchar(101),
	@txtAppDomainName varchar(300),
	@txtInformation varchar(1000)
	
AS 

	INSERT INTO [AuditLog]
           ([ObjectId]
           ,[ObjectType]
           ,[UserIdentity]
		   ,[WindowsIdentity]
		   ,[AppDomainName]
           ,[Information])
     VALUES
           (@intObjectId
           ,@txtObjectType
           ,@txtUserIdentity
		   ,@txtWindowsIdentity
		   ,@txtAppDomainName
           ,@txtInformation)

SET NOCOUNT OFF