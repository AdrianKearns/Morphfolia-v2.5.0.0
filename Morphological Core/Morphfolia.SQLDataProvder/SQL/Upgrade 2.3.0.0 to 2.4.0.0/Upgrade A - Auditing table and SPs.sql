/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */





UPDATE dbo.ControlProperties SET PropertyType = 'BPST' WHERE PropertyType = 'BLOG'



/****** Object:  StoredProcedure [dbo].[AuditLog_INSERT]    Script Date: 05/14/2009 16:29:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AuditLog_INSERT]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AuditLog_INSERT]

/****** Object:  StoredProcedure [dbo].[AuditLog_SELECT_ByIdAndType]    Script Date: 05/14/2009 16:29:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AuditLog_SELECT_ByIdAndType]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AuditLog_SELECT_ByIdAndType]

/****** Object:  StoredProcedure [dbo].[AuditLog_SELECT_Search]    Script Date: 05/14/2009 16:29:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AuditLog_SELECT_Search]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AuditLog_SELECT_Search]

/****** Object:  Table [dbo].[AuditLog]    Script Date: 05/14/2009 16:26:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AuditLog]') AND type in (N'U'))
DROP TABLE [dbo].[AuditLog]











/****** Object:  Table [dbo].[AuditLog]    Script Date: 05/14/2009 16:26:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AuditLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ObjectId] [int] NULL,
	[ObjectType] [varchar](50) NULL,
	[UserIdentity] [varchar](101) NOT NULL,
	[WindowsIdentity] [varchar](101) NULL,
	[AppDomainName] [varchar](300) NULL,
	[WhenLogged] [datetime] NOT NULL CONSTRAINT [DF_AuditLog_WhenLogged]  DEFAULT (getdate()),
	[Information] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_AuditLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Row Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditLog', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Id of the object the audit entry refers to (if applicable)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditLog', @level2type=N'COLUMN',@level2name=N'ObjectId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Describes the what kind of object the entry refers to (such as a table name or class name)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditLog', @level2type=N'COLUMN',@level2name=N'ObjectType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The user who invoked the audit process or task that is audited' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditLog', @level2type=N'COLUMN',@level2name=N'UserIdentity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'When the entry was recorded' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditLog', @level2type=N'COLUMN',@level2name=N'WhenLogged'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Information captured as part of the entry (such as item created, updated, user logged in, and so on)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditLog', @level2type=N'COLUMN',@level2name=N'Information'








/****** Object:  StoredProcedure [dbo].[AuditLog_INSERT]    Script Date: 05/14/2009 16:30:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AuditLog_INSERT] 

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








/****** Object:  StoredProcedure [dbo].[AuditLog_SELECT_ByIdAndType]    Script Date: 05/14/2009 16:30:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AuditLog_SELECT_ByIdAndType] 

	@intObjectId int,
	@txtObjectType varchar(50)
	
AS 

	SELECT * 

	FROM [AuditLog]

	WHERE	ObjectId = @intObjectId
	AND		ObjectType = @txtObjectType

SET NOCOUNT OFF








/****** Object:  StoredProcedure [dbo].[AuditLog_SELECT_Search]    Script Date: 05/14/2009 16:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AuditLog_SELECT_Search] 

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



exec spGrantExectoAllStoredProcs 'ASPNET'




