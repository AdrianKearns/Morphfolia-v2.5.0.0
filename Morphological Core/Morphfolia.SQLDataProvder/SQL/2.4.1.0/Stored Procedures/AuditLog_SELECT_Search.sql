/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */



/****** Object:  StoredProcedure [dbo].[AuditLog_SELECT_Search]    Script Date: 11/14/2008 20:05:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AuditLog_SELECT_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [AuditLog_SELECT_Search]


-- AuditLog_SELECT_Search -1, 'TestObject'
-- SELECT * FROM [AuditLog]


/****** Object:  StoredProcedure [dbo].[AuditLog_SELECT_Search]    Script Date: 11/14/2008 20:06:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [AuditLog_SELECT_Search] 

	@intObjectId int,
	@txtObjectType varchar(50),
	@txtAuditInformation varchar(200),
	@txtUserIdentity varchar(101), 
	@txtWindowsIdentity varchar(101),
	@txtAppDomainName varchar(300),
	@dtWhenLoggedFrom datetime,
	@dtWhenLoggedTill datetime
	
AS 

	-- AuditLog_SELECT_Search 30, '%', '%', '%', '%', '%', '2009-01-11 14:51:44.000', '2019-01-11 19:21:00.000'
	-- AuditLog_SELECT_Search -1, 'Page', '%', '%', '%', '%', '2009-01-11 14:51:44.000', '2019-01-11 19:21:00.000'
	-- AuditLog_SELECT_Search -1, '%', '%', '%', '%', '%', '2000-01-11 14:51:44.000', '2019-01-11 19:21:00.000'
	
	-- SELECT * FROM AuditLog


	IF @intObjectId = -1
	BEGIN

		SELECT TOP 200 * 

		FROM [AuditLog]

		WHERE	ObjectType LIKE @txtObjectType
		AND		UserIdentity LIKE @txtUserIdentity
		AND		WindowsIdentity LIKE @txtWindowsIdentity
		AND		AppDomainName LIKE @txtAppDomainName
		AND		Information LIKE @txtAuditInformation
		AND		(WhenLogged >= @dtWhenLoggedFrom AND WhenLogged <= @dtWhenLoggedTill)

		ORDER BY WhenLogged DESC

	END
	ELSE
	BEGIN

		SELECT * 

		FROM [AuditLog]

		WHERE	ObjectType LIKE @txtObjectType
		AND		UserIdentity LIKE @txtUserIdentity
		AND		WindowsIdentity LIKE @txtWindowsIdentity
		AND		AppDomainName LIKE @txtAppDomainName
		AND		Information LIKE @txtAuditInformation
		AND		(WhenLogged >= @dtWhenLoggedFrom AND WhenLogged <= @dtWhenLoggedTill)
		AND		ObjectId = @intObjectId

		ORDER BY WhenLogged DESC

	END

SET NOCOUNT OFF