/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */

-- #### Blank Database creation ############################################################

USE [master]
GO
/****** Object:  Database [Morphfolia_v2_4_1_0]    Script Date: 10/28/2009 12:28:50 ******/
CREATE DATABASE [Morphfolia_v2_4_1_0] ON  PRIMARY 
( NAME = N'Morphfolia_v2_4_1_0', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\Morphfolia_v2_4_1_0.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Morphfolia_v2_4_1_0_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\Morphfolia_v2_4_1_0_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 1024KB )
GO
EXEC dbo.sp_dbcmptlevel @dbname=N'Morphfolia_v2_4_1_0', @new_cmptlevel=90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Morphfolia_v2_4_1_0].[dbo].[sp_fulltext_database] @action = 'disable'
end
GO
ALTER DATABASE [Morphfolia_v2_4_1_0] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Morphfolia_v2_4_1_0] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Morphfolia_v2_4_1_0] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Morphfolia_v2_4_1_0] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Morphfolia_v2_4_1_0] SET ARITHABORT OFF
GO
ALTER DATABASE [Morphfolia_v2_4_1_0] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Morphfolia_v2_4_1_0] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Morphfolia_v2_4_1_0] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Morphfolia_v2_4_1_0] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Morphfolia_v2_4_1_0] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Morphfolia_v2_4_1_0] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Morphfolia_v2_4_1_0] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Morphfolia_v2_4_1_0] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Morphfolia_v2_4_1_0] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Morphfolia_v2_4_1_0] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Morphfolia_v2_4_1_0] SET  ENABLE_BROKER
GO
ALTER DATABASE [Morphfolia_v2_4_1_0] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Morphfolia_v2_4_1_0] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Morphfolia_v2_4_1_0] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Morphfolia_v2_4_1_0] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Morphfolia_v2_4_1_0] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Morphfolia_v2_4_1_0] SET  READ_WRITE
GO
ALTER DATABASE [Morphfolia_v2_4_1_0] SET RECOVERY SIMPLE
GO
ALTER DATABASE [Morphfolia_v2_4_1_0] SET  MULTI_USER
GO
ALTER DATABASE [Morphfolia_v2_4_1_0] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Morphfolia_v2_4_1_0] SET DB_CHAINING OFF
GO
USE [Morphfolia_v2_4_1_0]
GO
/****** Object:  User [ASPNET]    Script Date: 10/28/2009 12:28:50 ******/
CREATE USER [ASPNET] FOR LOGIN [FASSIN\ASPNET] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[ContentIndex_D]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentIndex_D](
	[Word] [varchar](256) NOT NULL,
	[PageId] [int] NOT NULL,
	[ContentId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentIndex_Default]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentIndex_Default](
	[Word] [varchar](256) NOT NULL,
	[PageId] [int] NOT NULL,
	[ContentId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentIndex_C]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentIndex_C](
	[Word] [varchar](256) NOT NULL,
	[PageId] [int] NOT NULL,
	[ContentId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentIndex_E]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentIndex_E](
	[Word] [varchar](256) NOT NULL,
	[PageId] [int] NOT NULL,
	[ContentId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentIndex_G]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentIndex_G](
	[Word] [varchar](256) NOT NULL,
	[PageId] [int] NOT NULL,
	[ContentId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentIndex_F]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentIndex_F](
	[Word] [varchar](256) NOT NULL,
	[PageId] [int] NOT NULL,
	[ContentId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentIndex_H]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentIndex_H](
	[Word] [varchar](256) NOT NULL,
	[PageId] [int] NOT NULL,
	[ContentId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentIndex_J]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentIndex_J](
	[Word] [varchar](256) NOT NULL,
	[PageId] [int] NOT NULL,
	[ContentId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Setup_RemoveAllRoleMembers]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Setup_RemoveAllRoleMembers]
    @name   sysname
AS
BEGIN
    CREATE TABLE #aspnet_RoleMembers
    (
        Group_name      sysname,
        Group_id        smallint,
        Users_in_group  sysname,
        User_id         smallint
    )

    INSERT INTO #aspnet_RoleMembers
    EXEC sp_helpuser @name

    DECLARE @user_id smallint
    DECLARE @cmd nvarchar(500)
    DECLARE c1 cursor FORWARD_ONLY FOR
        SELECT User_id FROM #aspnet_RoleMembers

    OPEN c1

    FETCH c1 INTO @user_id
    WHILE (@@fetch_status = 0)
    BEGIN
        SET @cmd = 'EXEC sp_droprolemember ' + '''' + @name + ''', ''' + USER_NAME(@user_id) + ''''
        EXEC (@cmd)
        FETCH c1 INTO @user_id
    END

    CLOSE c1
    DEALLOCATE c1
END
GO
/****** Object:  Table [dbo].[ContentIndex_K]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentIndex_K](
	[Word] [varchar](256) NOT NULL,
	[PageId] [int] NOT NULL,
	[ContentId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Setup_RestorePermissions]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Setup_RestorePermissions]
    @name   sysname
AS
BEGIN
    DECLARE @object sysname
    DECLARE @protectType char(10)
    DECLARE @action varchar(60)
    DECLARE @grantee sysname
    DECLARE @cmd nvarchar(500)
    DECLARE c1 cursor FORWARD_ONLY FOR
        SELECT Object, ProtectType, [Action], Grantee FROM #aspnet_Permissions where Object = @name

    OPEN c1

    FETCH c1 INTO @object, @protectType, @action, @grantee
    WHILE (@@fetch_status = 0)
    BEGIN
        SET @cmd = @protectType + ' ' + @action + ' on ' + @object + ' TO [' + @grantee + ']'
        EXEC (@cmd)
        FETCH c1 INTO @object, @protectType, @action, @grantee
    END

    CLOSE c1
    DEALLOCATE c1
END
GO
/****** Object:  Table [dbo].[ContentIndex_L]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentIndex_L](
	[Word] [varchar](256) NOT NULL,
	[PageId] [int] NOT NULL,
	[ContentId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentIndex_M]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentIndex_M](
	[Word] [varchar](256) NOT NULL,
	[PageId] [int] NOT NULL,
	[ContentId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentIndex_N]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentIndex_N](
	[Word] [varchar](256) NOT NULL,
	[PageId] [int] NOT NULL,
	[ContentId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentIndex_O]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentIndex_O](
	[Word] [varchar](256) NOT NULL,
	[PageId] [int] NOT NULL,
	[ContentId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentIndex_P]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentIndex_P](
	[Word] [varchar](256) NOT NULL,
	[PageId] [int] NOT NULL,
	[ContentId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentIndex_Q]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentIndex_Q](
	[Word] [varchar](256) NOT NULL,
	[PageId] [int] NOT NULL,
	[ContentId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentIndex_R]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentIndex_R](
	[Word] [varchar](256) NOT NULL,
	[PageId] [int] NOT NULL,
	[ContentId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentIndex_I]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentIndex_I](
	[Word] [varchar](256) NOT NULL,
	[PageId] [int] NOT NULL,
	[ContentId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentIndex_S]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentIndex_S](
	[Word] [varchar](256) NOT NULL,
	[PageId] [int] NOT NULL,
	[ContentId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentIndex_T]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentIndex_T](
	[Word] [varchar](256) NOT NULL,
	[PageId] [int] NOT NULL,
	[ContentId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentIndex_V]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentIndex_V](
	[Word] [varchar](256) NOT NULL,
	[PageId] [int] NOT NULL,
	[ContentId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentIndex_W]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentIndex_W](
	[Word] [varchar](256) NOT NULL,
	[PageId] [int] NOT NULL,
	[ContentId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentIndex_X]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentIndex_X](
	[Word] [varchar](256) NOT NULL,
	[PageId] [int] NOT NULL,
	[ContentId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentIndex_Y]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentIndex_Y](
	[Word] [varchar](256) NOT NULL,
	[PageId] [int] NOT NULL,
	[ContentId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentIndex_Z]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentIndex_Z](
	[Word] [varchar](256) NOT NULL,
	[PageId] [int] NOT NULL,
	[ContentId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentMarshal]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContentMarshal](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PageID] [int] NOT NULL,
	[ContentID] [int] NOT NULL,
	[SortOrder] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ControlProperties]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ControlProperties](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InstanceID] [int] NOT NULL,
	[PropertyType] [char](4) NULL,
	[PropertyKey] [varchar](200) NOT NULL,
	[PropertyValue] [varchar](2000) NULL,
 CONSTRAINT [PK_ControlProperties] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Images]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Images](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ImageName] [varchar](500) NOT NULL,
	[Width] [int] NOT NULL,
	[Height] [int] NOT NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[aspnet_Applications]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Applications](
	[ApplicationName] [nvarchar](256) NOT NULL,
	[LoweredApplicationName] [nvarchar](256) NOT NULL,
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](256) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_Membership]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Membership](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordFormat] [int] NOT NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[MobilePIN] [nvarchar](16) NULL,
	[Email] [nvarchar](256) NULL,
	[LoweredEmail] [nvarchar](256) NULL,
	[PasswordQuestion] [nvarchar](256) NULL,
	[PasswordAnswer] [nvarchar](128) NULL,
	[IsApproved] [bit] NOT NULL,
	[IsLockedOut] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[LastPasswordChangedDate] [datetime] NOT NULL,
	[LastLockoutDate] [datetime] NOT NULL,
	[FailedPasswordAttemptCount] [int] NOT NULL,
	[FailedPasswordAttemptWindowStart] [datetime] NOT NULL,
	[FailedPasswordAnswerAttemptCount] [int] NOT NULL,
	[FailedPasswordAnswerAttemptWindowStart] [datetime] NOT NULL,
	[Comment] [ntext] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_Paths]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Paths](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[PathId] [uniqueidentifier] NOT NULL,
	[Path] [nvarchar](256) NOT NULL,
	[LoweredPath] [nvarchar](256) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditLog]    Script Date: 10/28/2009 12:28:50 ******/
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
GO
/****** Object:  Table [dbo].[aspnet_PersonalizationAllUsers]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_PersonalizationAllUsers](
	[PathId] [uniqueidentifier] NOT NULL,
	[PageSettings] [image] NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_PersonalizationPerUser]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_PersonalizationPerUser](
	[Id] [uniqueidentifier] NOT NULL,
	[PathId] [uniqueidentifier] NULL,
	[UserId] [uniqueidentifier] NULL,
	[PageSettings] [image] NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HttpLog]    Script Date: 10/28/2009 12:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HttpLog](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[SessionId] [varchar](50) NULL,
	[UserHostName] [varchar](50) NULL,
	[Url] [varchar](500) NULL,
	[UrlReferrer] [varchar](500) NULL,
	[TimeLogged] [datetime] NOT NULL CONSTRAINT [DF_HttpLog_TimeLogged]  DEFAULT (getdate()),
	[MiscInfo] [varchar](500) NULL,
 CONSTRAINT [PK_HttpLog] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Log]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NULL,
	[Priority] [int] NOT NULL,
	[Severity] [nvarchar](32) NOT NULL,
	[Title] [nvarchar](256) NOT NULL,
	[Timestamp] [datetime] NOT NULL,
	[MachineName] [nvarchar](32) NOT NULL,
	[AppDomainName] [nvarchar](512) NOT NULL,
	[ProcessID] [nvarchar](256) NOT NULL,
	[ProcessName] [nvarchar](512) NOT NULL,
	[ThreadName] [nvarchar](512) NULL,
	[Win32ThreadId] [nvarchar](128) NULL,
	[Message] [nvarchar](1500) NULL,
	[FormattedMessage] [ntext] NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Page]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Page](
	[PageID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](500) NOT NULL,
	[Url] [varchar](1000) NOT NULL,
	[MetaKeywords] [varchar](2000) NULL,
	[MetaDescription] [varchar](2000) NULL,
	[LastModified] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](101) NOT NULL,
	[IsSearchable] [bit] NOT NULL,
	[IsLive] [bit] NOT NULL,
	[ts] [timestamp] NOT NULL,
 CONSTRAINT [PK_Page] PRIMARY KEY CLUSTERED 
(
	[PageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PropertyType]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PropertyType](
	[ID] [char](4) NOT NULL,
	[PropertyType] [varchar](250) NOT NULL,
 CONSTRAINT [PK_PropertyType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentIndex_U]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentIndex_U](
	[Word] [varchar](256) NOT NULL,
	[PageId] [int] NOT NULL,
	[ContentId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[aspnet_Profile]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Profile](
	[UserId] [uniqueidentifier] NOT NULL,
	[PropertyNames] [ntext] NOT NULL,
	[PropertyValuesString] [ntext] NOT NULL,
	[PropertyValuesBinary] [image] NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_Roles]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Roles](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL CONSTRAINT [DF_aspnet_Roles_RoleId]  DEFAULT (newid()),
	[RoleName] [nvarchar](256) NOT NULL,
	[LoweredRoleName] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](256) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_SchemaVersions]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_SchemaVersions](
	[Feature] [nvarchar](128) NOT NULL,
	[CompatibleSchemaVersion] [nvarchar](128) NOT NULL,
	[IsCurrentVersion] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_UsersInRoles]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_UsersInRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_WebEvent_Events]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[aspnet_WebEvent_Events](
	[EventId] [char](32) NOT NULL,
	[EventTimeUtc] [datetime] NOT NULL,
	[EventTime] [datetime] NOT NULL,
	[EventType] [nvarchar](256) NOT NULL,
	[EventSequence] [decimal](19, 0) NOT NULL,
	[EventOccurrence] [decimal](19, 0) NOT NULL,
	[EventCode] [int] NOT NULL,
	[EventDetailCode] [int] NOT NULL,
	[Message] [nvarchar](1024) NULL,
	[ApplicationPath] [nvarchar](256) NULL,
	[ApplicationVirtualPath] [nvarchar](256) NULL,
	[MachineName] [nvarchar](256) NOT NULL,
	[RequestUrl] [nvarchar](1024) NULL,
	[ExceptionType] [nvarchar](256) NULL,
	[Details] [ntext] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[aspnet_Users]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Users](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[LoweredUserName] [nvarchar](256) NOT NULL,
	[MobileAlias] [nvarchar](16) NULL,
	[IsAnonymous] [bit] NOT NULL,
	[LastActivityDate] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Content]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Content](
	[ContentID] [int] IDENTITY(1,1) NOT NULL,
	[Content] [ntext] NOT NULL,
	[TextContent] [ntext] NOT NULL,
	[Note] [varchar](500) NULL,
	[ContentType] [char](4) NOT NULL CONSTRAINT [DF_Content_ContentType]  DEFAULT ('CONT'),
	[IsLive] [bit] NOT NULL,
	[IsSearchable] [bit] NOT NULL,
	[ContentFilter] [varchar](300) NULL,
	[LastModified] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](101) NOT NULL,
	[ts] [timestamp] NULL,
 CONSTRAINT [PK_Content] PRIMARY KEY CLUSTERED 
(
	[ContentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Describes the nature of the content in terms of how it was entered or needs to be read.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Content', @level2type=N'COLUMN',@level2name=N'ContentFilter'
GO
/****** Object:  StoredProcedure [dbo].[ContentIndex_SELECT_Overview]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.ContentIndex_SELECT_Overview    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure [dbo].[ContentIndex_SELECT_Overview]



AS

	SET NOCOUNT ON
	

	CREATE TABLE #ContentIndexOverview (Total INT, Letter varchar(50))


	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'A' Letter FROM ContentIndex_A

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'B' Letter FROM ContentIndex_B

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'C' Letter FROM ContentIndex_C

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'D' Letter FROM ContentIndex_D

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'E' Letter FROM ContentIndex_E

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'F' Letter FROM ContentIndex_F

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'G' Letter FROM ContentIndex_G

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'H' Letter FROM ContentIndex_H

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'I' Letter FROM ContentIndex_I

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'J' Letter FROM ContentIndex_J

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'K' Letter FROM ContentIndex_K

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'L' Letter FROM ContentIndex_L

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'M' Letter FROM ContentIndex_M

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'N' Letter FROM ContentIndex_N

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'O' Letter FROM ContentIndex_O

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'P' Letter FROM ContentIndex_P

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'Q' Letter FROM ContentIndex_Q

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'R' Letter FROM ContentIndex_R

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'S' Letter FROM ContentIndex_S

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'T' Letter FROM ContentIndex_T

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'U' Letter FROM ContentIndex_U

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'V' Letter FROM ContentIndex_V

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'W' Letter FROM ContentIndex_W

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'X' Letter FROM ContentIndex_X

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'Y' Letter FROM ContentIndex_Y

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'Z' Letter FROM ContentIndex_Z

	INSERT INTO #ContentIndexOverview (Total, Letter)
	SELECT Count(*) Total, 'Default' Letter FROM ContentIndex_Default


	SELECT * FROM #ContentIndexOverview ORDER BY Total DESC, Letter
		




	CREATE TABLE #ContentIndexTop3Overview (Word varchar(255), Total INT, Letter varchar(50))

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'A' Letter FROM ContentIndex_A GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'B' Letter FROM ContentIndex_B GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'C' Letter FROM ContentIndex_C GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'D' Letter FROM ContentIndex_D GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'E' Letter FROM ContentIndex_E GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'F' Letter FROM ContentIndex_F GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'G' Letter FROM ContentIndex_G GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'H' Letter FROM ContentIndex_H GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'I' Letter FROM ContentIndex_I GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'J' Letter FROM ContentIndex_J GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'K' Letter FROM ContentIndex_K GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'L' Letter FROM ContentIndex_L GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'M' Letter FROM ContentIndex_M GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'N' Letter FROM ContentIndex_N GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'O' Letter FROM ContentIndex_O GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'P' Letter FROM ContentIndex_P GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'Q' Letter FROM ContentIndex_Q GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'R' Letter FROM ContentIndex_R GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'S' Letter FROM ContentIndex_S GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'T' Letter FROM ContentIndex_T GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'U' Letter FROM ContentIndex_U GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'V' Letter FROM ContentIndex_V GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'W' Letter FROM ContentIndex_W GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'X' Letter FROM ContentIndex_X GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'Y' Letter FROM ContentIndex_Y GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'Z' Letter FROM ContentIndex_Z GROUP BY Word ORDER BY Occurances DESC

	INSERT INTO #ContentIndexTop3Overview (Word, Total, Letter)
	SELECT TOP 3 Word, Count(Word) Occurances, 'Default' Letter FROM ContentIndex_Default GROUP BY Word ORDER BY Occurances DESC

	SELECT * FROM #ContentIndexTop3Overview ORDER BY Total DESC, Word
GO
/****** Object:  StoredProcedure [dbo].[GetUsageSummary]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[GetUsageSummary]

AS
BEGIN
	    

	exec sp_spaceused

	exec sp_spaceused aspnet_Users
	exec sp_spaceused AuditLog
	exec sp_spaceused [Content]
	exec sp_spaceused Page
	exec sp_spaceused ContentIndex_Default
	exec sp_spaceused ContentIndex_A
	exec sp_spaceused ContentIndex_B
	exec sp_spaceused ContentIndex_C
	exec sp_spaceused ContentIndex_D
	exec sp_spaceused ContentIndex_E
	exec sp_spaceused ContentIndex_F
	exec sp_spaceused ContentIndex_G
	exec sp_spaceused ContentIndex_H
	exec sp_spaceused ContentIndex_I
	exec sp_spaceused ContentIndex_J
	exec sp_spaceused ContentIndex_K
	exec sp_spaceused ContentIndex_L
	exec sp_spaceused ContentIndex_M
	exec sp_spaceused ContentIndex_N
	exec sp_spaceused ContentIndex_O
	exec sp_spaceused ContentIndex_P
	exec sp_spaceused ContentIndex_Q
	exec sp_spaceused ContentIndex_R
	exec sp_spaceused ContentIndex_S
	exec sp_spaceused ContentIndex_T
	exec sp_spaceused ContentIndex_U
	exec sp_spaceused ContentIndex_V
	exec sp_spaceused ContentIndex_W
	exec sp_spaceused ContentIndex_X
	exec sp_spaceused ContentIndex_Y
	exec sp_spaceused ContentIndex_Z
	exec sp_spaceused ControlProperties
	exec sp_spaceused PropertyType
	exec sp_spaceused HttpLog
	exec sp_spaceused [Log]



END
GO
/****** Object:  Table [dbo].[ContentType]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentType](
	[Id] [char](4) NOT NULL,
	[ContentType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ContentType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationAdministration_FindState]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_PersonalizationAdministration_FindState] (
    @AllUsersScope bit,
    @ApplicationName NVARCHAR(256),
    @PageIndex              INT,
    @PageSize               INT,
    @Path NVARCHAR(256) = NULL,
    @UserName NVARCHAR(256) = NULL,
    @InactiveSinceDate DATETIME = NULL)
AS
BEGIN
    DECLARE @ApplicationId UNIQUEIDENTIFIER
    EXEC dbo.aspnet_Personalization_GetApplicationId @ApplicationName, @ApplicationId OUTPUT
    IF (@ApplicationId IS NULL)
        RETURN

    -- Set the page bounds
    DECLARE @PageLowerBound INT
    DECLARE @PageUpperBound INT
    DECLARE @TotalRecords   INT
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize - 1 + @PageLowerBound

    -- Create a temp table to store the selected results
    CREATE TABLE #PageIndex (
        IndexId int IDENTITY (0, 1) NOT NULL,
        ItemId UNIQUEIDENTIFIER
    )

    IF (@AllUsersScope = 1)
    BEGIN
        -- Insert into our temp table
        INSERT INTO #PageIndex (ItemId)
        SELECT Paths.PathId
        FROM dbo.aspnet_Paths Paths,
             ((SELECT Paths.PathId
               FROM dbo.aspnet_PersonalizationAllUsers AllUsers, dbo.aspnet_Paths Paths
               WHERE Paths.ApplicationId = @ApplicationId
                      AND AllUsers.PathId = Paths.PathId
                      AND (@Path IS NULL OR Paths.LoweredPath LIKE LOWER(@Path))
              ) AS SharedDataPerPath
              FULL OUTER JOIN
              (SELECT DISTINCT Paths.PathId
               FROM dbo.aspnet_PersonalizationPerUser PerUser, dbo.aspnet_Paths Paths
               WHERE Paths.ApplicationId = @ApplicationId
                      AND PerUser.PathId = Paths.PathId
                      AND (@Path IS NULL OR Paths.LoweredPath LIKE LOWER(@Path))
              ) AS UserDataPerPath
              ON SharedDataPerPath.PathId = UserDataPerPath.PathId
             )
        WHERE Paths.PathId = SharedDataPerPath.PathId OR Paths.PathId = UserDataPerPath.PathId
        ORDER BY Paths.Path ASC

        SELECT @TotalRecords = @@ROWCOUNT

        SELECT Paths.Path,
               SharedDataPerPath.LastUpdatedDate,
               SharedDataPerPath.SharedDataLength,
               UserDataPerPath.UserDataLength,
               UserDataPerPath.UserCount
        FROM dbo.aspnet_Paths Paths,
             ((SELECT PageIndex.ItemId AS PathId,
                      AllUsers.LastUpdatedDate AS LastUpdatedDate,
                      DATALENGTH(AllUsers.PageSettings) AS SharedDataLength
               FROM dbo.aspnet_PersonalizationAllUsers AllUsers, #PageIndex PageIndex
               WHERE AllUsers.PathId = PageIndex.ItemId
                     AND PageIndex.IndexId >= @PageLowerBound AND PageIndex.IndexId <= @PageUpperBound
              ) AS SharedDataPerPath
              FULL OUTER JOIN
              (SELECT PageIndex.ItemId AS PathId,
                      SUM(DATALENGTH(PerUser.PageSettings)) AS UserDataLength,
                      COUNT(*) AS UserCount
               FROM aspnet_PersonalizationPerUser PerUser, #PageIndex PageIndex
               WHERE PerUser.PathId = PageIndex.ItemId
                     AND PageIndex.IndexId >= @PageLowerBound AND PageIndex.IndexId <= @PageUpperBound
               GROUP BY PageIndex.ItemId
              ) AS UserDataPerPath
              ON SharedDataPerPath.PathId = UserDataPerPath.PathId
             )
        WHERE Paths.PathId = SharedDataPerPath.PathId OR Paths.PathId = UserDataPerPath.PathId
        ORDER BY Paths.Path ASC
    END
    ELSE
    BEGIN
        -- Insert into our temp table
        INSERT INTO #PageIndex (ItemId)
        SELECT PerUser.Id
        FROM dbo.aspnet_PersonalizationPerUser PerUser, dbo.aspnet_Users Users, dbo.aspnet_Paths Paths
        WHERE Paths.ApplicationId = @ApplicationId
              AND PerUser.UserId = Users.UserId
              AND PerUser.PathId = Paths.PathId
              AND (@Path IS NULL OR Paths.LoweredPath LIKE LOWER(@Path))
              AND (@UserName IS NULL OR Users.LoweredUserName LIKE LOWER(@UserName))
              AND (@InactiveSinceDate IS NULL OR Users.LastActivityDate <= @InactiveSinceDate)
        ORDER BY Paths.Path ASC, Users.UserName ASC

        SELECT @TotalRecords = @@ROWCOUNT

        SELECT Paths.Path, PerUser.LastUpdatedDate, DATALENGTH(PerUser.PageSettings), Users.UserName, Users.LastActivityDate
        FROM dbo.aspnet_PersonalizationPerUser PerUser, dbo.aspnet_Users Users, dbo.aspnet_Paths Paths, #PageIndex PageIndex
        WHERE PerUser.Id = PageIndex.ItemId
              AND PerUser.UserId = Users.UserId
              AND PerUser.PathId = Paths.PathId
              AND PageIndex.IndexId >= @PageLowerBound AND PageIndex.IndexId <= @PageUpperBound
        ORDER BY Paths.Path ASC, Users.UserName ASC
    END

    RETURN @TotalRecords
END
GO
/****** Object:  Table [dbo].[Category]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](64) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoryLog]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryLog](
	[CategoryLogID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[LogID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContentIndex_A]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentIndex_A](
	[Word] [varchar](256) NOT NULL,
	[PageId] [int] NOT NULL,
	[ContentId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Profile_DeleteProfiles]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Profile_DeleteProfiles]
    @ApplicationName        nvarchar(256),
    @UserNames              nvarchar(4000)
AS
BEGIN
    DECLARE @UserName     nvarchar(256)
    DECLARE @CurrentPos   int
    DECLARE @NextPos      int
    DECLARE @NumDeleted   int
    DECLARE @DeletedUser  int
    DECLARE @TranStarted  bit
    DECLARE @ErrorCode    int

    SET @ErrorCode = 0
    SET @CurrentPos = 1
    SET @NumDeleted = 0
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
        BEGIN TRANSACTION
        SET @TranStarted = 1
    END
    ELSE
    	SET @TranStarted = 0

    WHILE (@CurrentPos <= LEN(@UserNames))
    BEGIN
        SELECT @NextPos = CHARINDEX(N',', @UserNames,  @CurrentPos)
        IF (@NextPos = 0 OR @NextPos IS NULL)
            SELECT @NextPos = LEN(@UserNames) + 1

        SELECT @UserName = SUBSTRING(@UserNames, @CurrentPos, @NextPos - @CurrentPos)
        SELECT @CurrentPos = @NextPos+1

        IF (LEN(@UserName) > 0)
        BEGIN
            SELECT @DeletedUser = 0
            EXEC dbo.aspnet_Users_DeleteUser @ApplicationName, @UserName, 4, @DeletedUser OUTPUT
            IF( @@ERROR <> 0 )
            BEGIN
                SET @ErrorCode = -1
                GOTO Cleanup
            END
            IF (@DeletedUser <> 0)
                SELECT @NumDeleted = @NumDeleted + 1
        END
    END
    SELECT @NumDeleted
    IF (@TranStarted = 1)
    BEGIN
    	SET @TranStarted = 0
    	COMMIT TRANSACTION
    END
    SET @TranStarted = 0

    RETURN 0

Cleanup:
    IF (@TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
    	ROLLBACK TRANSACTION
    END
    RETURN @ErrorCode
END
GO
/****** Object:  Table [dbo].[ContentIndex_B]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentIndex_B](
	[Word] [varchar](256) NOT NULL,
	[PageId] [int] NOT NULL,
	[ContentId] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[ContentIndex_DELETE_OrphanRecords]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[ContentIndex_DELETE_OrphanRecords]

AS

	SET NOCOUNT ON

	
	
	DELETE FROM ContentIndex_A WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_B WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_C WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_D WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_E WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_F WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_G WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_H WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_I WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_J WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_K WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_L WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_M WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_N WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_O WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_P WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_Q WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_R WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_S WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_T WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_U WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_V WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_W WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_X WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_Y WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_Z WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_Default WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
		
	
	DELETE FROM ContentIndex_A WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_B WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_C WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_D WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_E WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_F WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_G WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_H WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_I WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_J WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_K WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_L WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_M WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_N WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_O WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_P WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_Q WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_R WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_S WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_T WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_U WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_V WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_W WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_X WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_Y WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_Z WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_Default WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
GO
/****** Object:  StoredProcedure [dbo].[Page_DELETE_ByPageID]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Page_DELETE_ByPageID    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure [dbo].[Page_DELETE_ByPageID]

	@intPageID int

AS

	-- Page_DELETE_ByPageID 58
	-- SELECT * FROM dbo.Page WHERE PageID = 58
	-- SELECT * FROM dbo.Page

	SET NOCOUNT ON


	DELETE FROM dbo.ContentIndex_A WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_B WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_C WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_D WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_E WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_F WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_G WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_H WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_I WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_J WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_K WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_L WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_M WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_N WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_O WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_P WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_Q WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_R WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_S WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_T WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_U WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_V WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_W WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_X WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_Y WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_Z WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_Default WHERE PageID = @intPageID


	DELETE FROM dbo.ContentMarshal WHERE PageID = @intPageID

	DELETE FROM dbo.ControlProperties WHERE InstanceID = @intPageID

	DELETE FROM dbo.Page WHERE PageID = @intPageID
GO
/****** Object:  StoredProcedure [dbo].[Page_SELECT_FullReportByPageID]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Page_SELECT_FullReportByPageID    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure [dbo].[Page_SELECT_FullReportByPageID]

	@intPageID int

AS

	-- Page_SELECT_FullReportByPageID 58
	-- SELECT * FROM dbo.Page WHERE PageID = 9
	-- SELECT * FROM dbo.Page

	SET NOCOUNT ON


	SELECT * FROM dbo.ContentIndex_A WHERE PageID = @intPageID
	SELECT * FROM dbo.ContentIndex_B WHERE PageID = @intPageID
	SELECT * FROM dbo.ContentIndex_C WHERE PageID = @intPageID
	SELECT * FROM dbo.ContentIndex_D WHERE PageID = @intPageID
	SELECT * FROM dbo.ContentIndex_E WHERE PageID = @intPageID
	SELECT * FROM dbo.ContentIndex_F WHERE PageID = @intPageID
	SELECT * FROM dbo.ContentIndex_G WHERE PageID = @intPageID
	SELECT * FROM dbo.ContentIndex_H WHERE PageID = @intPageID
	SELECT * FROM dbo.ContentIndex_I WHERE PageID = @intPageID
	SELECT * FROM dbo.ContentIndex_J WHERE PageID = @intPageID
	SELECT * FROM dbo.ContentIndex_K WHERE PageID = @intPageID
	SELECT * FROM dbo.ContentIndex_L WHERE PageID = @intPageID
	SELECT * FROM dbo.ContentIndex_M WHERE PageID = @intPageID
	SELECT * FROM dbo.ContentIndex_N WHERE PageID = @intPageID
	SELECT * FROM dbo.ContentIndex_O WHERE PageID = @intPageID
	SELECT * FROM dbo.ContentIndex_P WHERE PageID = @intPageID
	SELECT * FROM dbo.ContentIndex_Q WHERE PageID = @intPageID
	SELECT * FROM dbo.ContentIndex_R WHERE PageID = @intPageID
	SELECT * FROM dbo.ContentIndex_S WHERE PageID = @intPageID
	SELECT * FROM dbo.ContentIndex_T WHERE PageID = @intPageID
	SELECT * FROM dbo.ContentIndex_U WHERE PageID = @intPageID
	SELECT * FROM dbo.ContentIndex_V WHERE PageID = @intPageID
	SELECT * FROM dbo.ContentIndex_W WHERE PageID = @intPageID
	SELECT * FROM dbo.ContentIndex_X WHERE PageID = @intPageID
	SELECT * FROM dbo.ContentIndex_Y WHERE PageID = @intPageID
	SELECT * FROM dbo.ContentIndex_Z WHERE PageID = @intPageID
	SELECT * FROM dbo.ContentIndex_Default WHERE PageID = @intPageID


	SELECT * FROM dbo.ContentMarshal WHERE PageID = @intPageID

	SELECT * FROM dbo.ControlProperties WHERE InstanceID = @intPageID

	SELECT * FROM dbo.Page WHERE PageID = @intPageID
GO
/****** Object:  StoredProcedure [dbo].[WordIndex_SEARCH]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.WordIndex_SEARCH    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[WordIndex_SEARCH]

	-- WordIndex_SEARCH '1'
	-- WordIndex_SEARCH '16'

	-- WordIndex_SEARCH 'a'
	-- WordIndex_SEARCH 'ac'
	-- WordIndex_SEARCH 'acc'
	-- WordIndex_SEARCH 'acco'
	-- WordIndex_SEARCH 'Acco'

	@txtCriteria varchar(100)

AS

	SET NOCOUNT ON


	DECLARE @txtLetter varchar(1)
	DECLARE @done bit

	SET @txtLetter = LEFT(@txtCriteria, 1)
	SET @txtCriteria = @txtCriteria + '%'
	SET @done = 0
	

	IF @txtLetter = 'a'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_A Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_A Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_A Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'b'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_B Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_B Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_B Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'c'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_C Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_C Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_C Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'd'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_D Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_D Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_D Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'e'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_E Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_E Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_E Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'f'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_F Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_F Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_F Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'g'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_G Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_G Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_G Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'h'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_H Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_H Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_H Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'i'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_I Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_I Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_I Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'j'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_J Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_J Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_J Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'k'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_K Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_K Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_K Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'l'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_L Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_L Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_L Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'm'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_M Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_M Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_M Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'n'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_N Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_N Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_N Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'o'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_O Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_O Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_O Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'p'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_P Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_P Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_P Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'q'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_Q Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_Q Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_Q Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'r'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_R Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_R Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_R Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 's'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_S Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_S Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_S Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 't'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_T Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_T Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_T Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'u'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_U Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_U Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_U Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'v'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_V Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_V Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_V Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'w'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_W Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_W Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_W Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'x'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_X Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_X Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_X Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'y'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_Y Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_Y Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_Y Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF @txtLetter = 'z'
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_Z Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_Z Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_Z Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END

	IF (@done = 0)
	BEGIN
			SELECT	DISTINCT Obiwan.Word, 
			(
				SELECT Count(*) 
				FROM dbo.ContentIndex_Default Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [TotalOccurances],
			(
				SELECT count(DISTINCT Yoda.PageId)
				FROM dbo.ContentIndex_Default Yoda 
				WHERE Yoda.Word = Obiwan.Word
			) [DistinctPageCount]

			FROM	dbo.ContentIndex_Default Obiwan
			WHERE [Word] LIKE @txtCriteria
			ORDER BY Obiwan.Word
			SET @done = 1
	END
GO
/****** Object:  StoredProcedure [dbo].[Content_SEARCH]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Content_SEARCH    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec Content_SEARCH @txtSearchCriteria = '%acc%'


/****** Object:  Stored Procedure dbo.Content_SEARCH    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SEARCH]

	-- Content_SEARCH '%SQL%'
	-- Content_SEARCH '%brian%'
	-- Content_SEARCH '%frodo%'
	-- Content_SEARCH '%fool%'

	@txtSearchCriteria varchar(100)

AS

	SET NOCOUNT ON

	SELECT	DISTINCT TOP 100			 
			P.PageID, 
			P.Title, 
			P.Url, 
			P.MetaKeywords, 
			P.MetaDescription, 
			P.LastModified LastModified, 
			P.LastModifiedBy LastModifiedBy,
			(
				SELECT 
				(
					SELECT Count(*) FROM dbo.ContentIndex_A AIndex
					WHERE AIndex.Word LIKE @txtSearchCriteria AND AIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_B BIndex
					WHERE BIndex.Word LIKE @txtSearchCriteria AND BIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_C CIndex
					WHERE CIndex.Word LIKE @txtSearchCriteria AND CIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_D DIndex
					WHERE DIndex.Word LIKE @txtSearchCriteria AND DIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_E EIndex
					WHERE EIndex.Word LIKE @txtSearchCriteria AND EIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_F FIndex
					WHERE FIndex.Word LIKE @txtSearchCriteria AND FIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_G GIndex
					WHERE GIndex.Word LIKE @txtSearchCriteria AND GIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_H HIndex
					WHERE HIndex.Word LIKE @txtSearchCriteria AND HIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_I IIndex
					WHERE IIndex.Word LIKE @txtSearchCriteria AND IIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_J JIndex
					WHERE JIndex.Word LIKE @txtSearchCriteria AND JIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_K KIndex
					WHERE KIndex.Word LIKE @txtSearchCriteria AND KIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_L LIndex
					WHERE LIndex.Word LIKE @txtSearchCriteria AND LIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_M MIndex
					WHERE MIndex.Word LIKE @txtSearchCriteria AND MIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_N NIndex
					WHERE NIndex.Word LIKE @txtSearchCriteria AND NIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_O OIndex
					WHERE OIndex.Word LIKE @txtSearchCriteria AND OIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_P PIndex
					WHERE PIndex.Word LIKE @txtSearchCriteria AND PIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_Q QIndex
					WHERE QIndex.Word LIKE @txtSearchCriteria AND QIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_R RIndex
					WHERE RIndex.Word LIKE @txtSearchCriteria AND RIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_S SIndex
					WHERE SIndex.Word LIKE @txtSearchCriteria AND SIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_T TIndex
					WHERE TIndex.Word LIKE @txtSearchCriteria AND TIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_U UIndex
					WHERE UIndex.Word LIKE @txtSearchCriteria AND UIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_V VIndex
					WHERE VIndex.Word LIKE @txtSearchCriteria AND VIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_W WIndex
					WHERE WIndex.Word LIKE @txtSearchCriteria AND WIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_X XIndex
					WHERE XIndex.Word LIKE @txtSearchCriteria AND XIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_Y YIndex
					WHERE YIndex.Word LIKE @txtSearchCriteria AND YIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_Z ZIndex
					WHERE ZIndex.Word LIKE @txtSearchCriteria AND ZIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_Default DefaultIndex
					WHERE DefaultIndex.Word LIKE @txtSearchCriteria AND DefaultIndex.PageId = P.PageID
				)
			) Matches, --PageMatches

			0 ContentID,
			'CONT' ContentType,
			'' Note


		

	FROM	Content C 
		INNER JOIN dbo.ControlProperties CP ON C.ContentID = CP.PropertyValue
		INNER JOIN Page P ON CP.InstanceID = P.PageID

	WHERE	(C.TextContent LIKE @txtSearchCriteria) 
	AND 	(C.IsLive = 1) AND (C.IsSearchable = 1) 
	AND 	(P.IsLive = 1) AND (P.IsSearchable = 1)
	AND		CP.PropertyType = 'CONT'


	UNION


	SELECT	DISTINCT TOP 100			 
			P.PageID, 
			P.Title, 
			P.Url, 
			P.MetaKeywords, 
			P.MetaDescription, 
			P.LastModified LastModified, 
			P.LastModifiedBy LastModifiedBy,
/*
			(
				SELECT LastModified FROM [Content] C
				
				WHERE 
				ORDER BY LastModified DESC
			) XXX,
*/
			(
				SELECT 
				(
					SELECT Count(*) FROM dbo.ContentIndex_A AIndex
					WHERE AIndex.Word LIKE @txtSearchCriteria AND AIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_B BIndex
					WHERE BIndex.Word LIKE @txtSearchCriteria AND BIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_C CIndex
					WHERE CIndex.Word LIKE @txtSearchCriteria AND CIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_D DIndex
					WHERE DIndex.Word LIKE @txtSearchCriteria AND DIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_E EIndex
					WHERE EIndex.Word LIKE @txtSearchCriteria AND EIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_F FIndex
					WHERE FIndex.Word LIKE @txtSearchCriteria AND FIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_G GIndex
					WHERE GIndex.Word LIKE @txtSearchCriteria AND GIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_H HIndex
					WHERE HIndex.Word LIKE @txtSearchCriteria AND HIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_I IIndex
					WHERE IIndex.Word LIKE @txtSearchCriteria AND IIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_J JIndex
					WHERE JIndex.Word LIKE @txtSearchCriteria AND JIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_K KIndex
					WHERE KIndex.Word LIKE @txtSearchCriteria AND KIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_L LIndex
					WHERE LIndex.Word LIKE @txtSearchCriteria AND LIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_M MIndex
					WHERE MIndex.Word LIKE @txtSearchCriteria AND MIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_N NIndex
					WHERE NIndex.Word LIKE @txtSearchCriteria AND NIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_O OIndex
					WHERE OIndex.Word LIKE @txtSearchCriteria AND OIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_P PIndex
					WHERE PIndex.Word LIKE @txtSearchCriteria AND PIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_Q QIndex
					WHERE QIndex.Word LIKE @txtSearchCriteria AND QIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_R RIndex
					WHERE RIndex.Word LIKE @txtSearchCriteria AND RIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_S SIndex
					WHERE SIndex.Word LIKE @txtSearchCriteria AND SIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_T TIndex
					WHERE TIndex.Word LIKE @txtSearchCriteria AND TIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_U UIndex
					WHERE UIndex.Word LIKE @txtSearchCriteria AND UIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_V VIndex
					WHERE VIndex.Word LIKE @txtSearchCriteria AND VIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_W WIndex
					WHERE WIndex.Word LIKE @txtSearchCriteria AND WIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_X XIndex
					WHERE XIndex.Word LIKE @txtSearchCriteria AND XIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_Y YIndex
					WHERE YIndex.Word LIKE @txtSearchCriteria AND YIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_Z ZIndex
					WHERE ZIndex.Word LIKE @txtSearchCriteria AND ZIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_Default DefaultIndex
					WHERE DefaultIndex.Word LIKE @txtSearchCriteria AND DefaultIndex.ContentId = C.ContentId
				)
			) Matches, --ContentMatches


			C.ContentId,
			C.ContentType,
			C.Note

	FROM	Content C 
		INNER JOIN dbo.ControlProperties CP ON C.ContentID = CP.PropertyValue
		INNER JOIN Page P ON CP.InstanceID = P.PageID

	WHERE	(C.TextContent LIKE @txtSearchCriteria) 
	AND 	(C.IsLive = 1) AND (C.IsSearchable = 1) 
	AND 	(P.IsLive = 1) AND (P.IsSearchable = 1)
	AND		CP.PropertyType = 'BPST'



	--ORDER BY PageMatches DESC, ContentMatches DESC, P.LastModified DESC, P.PageID DESC	--, C.ContentID
	ORDER BY Matches DESC, LastModified DESC

	-- Content_SEARCH '%SQL%'
	-- Content_SEARCH '%fool%'
	-- Content_SEARCH '%frodo%'
	-- Content_SEARCH '%because%'
GO
/****** Object:  StoredProcedure [dbo].[ContentIndex_SELECT_WordsForTagCloud]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.ContentIndex_SELECT_WordsForTagCloud    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[ContentIndex_SELECT_WordsForTagCloud]

	-- ContentIndex_SELECT_WordsForTagCloud 100
	-- ContentIndex_SELECT_WordsForTagCloud 200
	-- ContentIndex_SELECT_WordsForTagCloud 300

	@intMinOccurrances int

AS

	SET NOCOUNT ON


	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_A subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_A mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_A subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_B subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_B mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_B subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_C subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_C mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_C subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_D subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_D mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_D subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_E subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_E mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_E subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_F subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_F mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_F subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_G subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_G mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_G subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_H subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_H mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_H subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_I subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_I mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_I subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION





	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_J subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_J mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_J subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_K subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_K mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_K subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_L subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_L mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_L subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_M subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_M mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_M subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_N subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_N mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_N subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_O subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_O mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_O subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_P subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_P mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_P subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_Q subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_Q mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_Q subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_R subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_R mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_R subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_S subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_S mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_S subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_T subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_T mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_T subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_U subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_U mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_U subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_V subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_V mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_V subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_W subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_W mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_W subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_X subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_X mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_X subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_Y subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_Y mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_Y subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_Z subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_Z mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_Z subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


        UNION




	SELECT DISTINCT mainQuery.Word, 
	(
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_Default subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) as WordCount

	FROM dbo.ContentIndex_Default mainQuery 

	WHERE (
		SELECT Count(*) as innerCount
		FROM dbo.ContentIndex_Default subQuery
		WHERE subQuery.Word = mainQuery.Word 
	) > @intMinOccurrances 


--        ORDER BY WordCount DESC, Word
        ORDER BY Word
GO
/****** Object:  StoredProcedure [dbo].[Content_DELETE_ByContentID]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Content_DELETE_ByContentID    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure [dbo].[Content_DELETE_ByContentID]

	@intContentID int

AS

	SET NOCOUNT ON

	DELETE FROM dbo.ContentIndex_A WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_B WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_C WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_D WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_E WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_F WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_G WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_H WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_I WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_J WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_K WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_L WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_M WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_N WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_O WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_P WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_Q WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_R WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_S WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_T WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_U WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_V WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_W WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_X WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_Y WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_Z WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_Default WHERE ContentId = @intContentID

	-- SELECT * FROM dbo.ContentMarshal WHERE ContentID = 1
	DELETE FROM dbo.ContentMarshal WHERE ContentID = @intContentID

	-- SELECT * FROM dbo.ControlProperties WHERE PropertyType = 'CONT' AND PropertyValue = 1
	DELETE FROM dbo.ControlProperties WHERE PropertyType = 'CONT' AND PropertyValue = @intContentID

	-- SELECT * FROM dbo.Content WHERE ContentID = 1
	DELETE FROM dbo.Content WHERE ContentID = @intContentID
GO
/****** Object:  StoredProcedure [dbo].[ContentIndex_DELETE_UnwantedWords]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.ContentIndex_DELETE_UnwantedWords    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure [dbo].[ContentIndex_DELETE_UnwantedWords]

	@txtFirstCharacter char(1),
	@txtWord varchar(256)

AS

	SET NOCOUNT ON


	DECLARE @done bit
	SET @done = 0





	IF (@txtFirstCharacter = 'A')
	BEGIN
		DELETE FROM dbo.ContentIndex_A WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'B')
	BEGIN
		DELETE FROM dbo.ContentIndex_B WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'C')
	BEGIN
		DELETE FROM dbo.ContentIndex_C WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'D')
	BEGIN
		DELETE FROM dbo.ContentIndex_D WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'E')
	BEGIN
		DELETE FROM dbo.ContentIndex_E WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'F')
	BEGIN
		DELETE FROM dbo.ContentIndex_F WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'G')
	BEGIN
		DELETE FROM dbo.ContentIndex_G WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'H')
	BEGIN
		DELETE FROM dbo.ContentIndex_H WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'I')
	BEGIN
		DELETE FROM dbo.ContentIndex_I WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'J')
	BEGIN
		DELETE FROM dbo.ContentIndex_J WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'K')
	BEGIN
		DELETE FROM dbo.ContentIndex_K WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'L')
	BEGIN
		DELETE FROM dbo.ContentIndex_L WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'M')
	BEGIN
		DELETE FROM dbo.ContentIndex_M WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'N')
	BEGIN
		DELETE FROM dbo.ContentIndex_N WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'O')
	BEGIN
		DELETE FROM dbo.ContentIndex_O WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'P')
	BEGIN
		DELETE FROM dbo.ContentIndex_P WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'Q')
	BEGIN
		DELETE FROM dbo.ContentIndex_Q WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'R')
	BEGIN
		DELETE FROM dbo.ContentIndex_R WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'S')
	BEGIN
		DELETE FROM dbo.ContentIndex_S WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'T')
	BEGIN
		DELETE FROM dbo.ContentIndex_T WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'U')
	BEGIN
		DELETE FROM dbo.ContentIndex_U WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'V')
	BEGIN
		DELETE FROM dbo.ContentIndex_V WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'W')
	BEGIN
		DELETE FROM dbo.ContentIndex_W WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'X')
	BEGIN
		DELETE FROM dbo.ContentIndex_X WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'Y')
	BEGIN
		DELETE FROM dbo.ContentIndex_Y WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'Z')
	BEGIN
		DELETE FROM dbo.ContentIndex_Z WHERE [Word] = @txtWord	
		SET @done = 1
	END






	if (@done = 0)
	BEGIN
		DELETE FROM dbo.ContentIndex_Default WHERE [Word] = @txtWord
	END
GO
/****** Object:  StoredProcedure [dbo].[PURGE_ContentIndexDataForContentInstance]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.PURGE_ContentIndexDataForContentInstance    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure [dbo].[PURGE_ContentIndexDataForContentInstance]

	@txtFirstCharacter char(1),
	@intPageId int,
	@intContentId int

AS

	-- PURGE_ContentIndexDataForContentInstance 28

	SET NOCOUNT ON

	DECLARE @done bit
	SET @done = 0

	--DELETE FROM dbo.Page WHERE PageID = @intPageID

	IF (@txtFirstCharacter = 'A')
	BEGIN
		DELETE FROM  dbo.ContentIndex_A
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'B')
	BEGIN
		DELETE FROM dbo.ContentIndex_B 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'C')
	BEGIN
		DELETE FROM dbo.ContentIndex_C 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'D')
	BEGIN
		DELETE FROM dbo.ContentIndex_D 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'E')
	BEGIN
		DELETE FROM dbo.ContentIndex_E 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'F')
	BEGIN
		DELETE FROM dbo.ContentIndex_F 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'G')
	BEGIN
		DELETE FROM dbo.ContentIndex_G 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'H')
	BEGIN
		DELETE FROM dbo.ContentIndex_H 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'I')
	BEGIN
		DELETE FROM dbo.ContentIndex_I 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'J')
	BEGIN
		DELETE FROM dbo.ContentIndex_J 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'K')
	BEGIN
		DELETE FROM dbo.ContentIndex_K 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'L')
	BEGIN
		DELETE FROM dbo.ContentIndex_L 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'M')
	BEGIN
		DELETE FROM dbo.ContentIndex_M 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'N')
	BEGIN
		DELETE FROM dbo.ContentIndex_N 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'O')
	BEGIN
		DELETE FROM dbo.ContentIndex_O 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'P')
	BEGIN
		DELETE FROM dbo.ContentIndex_P 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'Q')
	BEGIN
		DELETE FROM dbo.ContentIndex_Q 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'R')
	BEGIN
		DELETE FROM dbo.ContentIndex_R 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'S')
	BEGIN
		DELETE FROM dbo.ContentIndex_S 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'T')
	BEGIN
		DELETE FROM dbo.ContentIndex_T 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'U')
	BEGIN
		DELETE FROM dbo.ContentIndex_U 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'V')
	BEGIN
		DELETE FROM dbo.ContentIndex_V 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'W')
	BEGIN
		DELETE FROM dbo.ContentIndex_W 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'X')
	BEGIN
		DELETE FROM dbo.ContentIndex_X 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'Y')
	BEGIN
		DELETE FROM dbo.ContentIndex_Y 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'Z')
	BEGIN
		DELETE FROM dbo.ContentIndex_Z 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END


	if (@done = 0)
	BEGIN
		DELETE FROM dbo.ContentIndex_Default
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
	END
GO
/****** Object:  StoredProcedure [dbo].[ContentIndex_INSERT_Word]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.ContentIndex_INSERT_Word    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure [dbo].[ContentIndex_INSERT_Word]

	@txtFirstCharacter char(1),
	@txtWord varchar(256),
	@intPageId int,
	@intContentId int

AS

	SET NOCOUNT ON


	DECLARE @done bit
	SET @done = 0


	IF (@txtFirstCharacter = 'A')
	BEGIN
		INSERT INTO  dbo.ContentIndex_A
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)		
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'B')
	BEGIN
		INSERT INTO dbo.ContentIndex_B 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'C')
	BEGIN
		INSERT INTO dbo.ContentIndex_C 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'D')
	BEGIN
		INSERT INTO dbo.ContentIndex_D 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'E')
	BEGIN
		INSERT INTO dbo.ContentIndex_E 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'F')
	BEGIN
		INSERT INTO dbo.ContentIndex_F 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'G')
	BEGIN
		INSERT INTO dbo.ContentIndex_G 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'H')
	BEGIN
		INSERT INTO dbo.ContentIndex_H 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'I')
	BEGIN
		INSERT INTO dbo.ContentIndex_I 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'J')
	BEGIN
		INSERT INTO dbo.ContentIndex_J 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'K')
	BEGIN
		INSERT INTO dbo.ContentIndex_K 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'L')
	BEGIN
		INSERT INTO dbo.ContentIndex_L 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'M')
	BEGIN
		INSERT INTO dbo.ContentIndex_M 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'N')
	BEGIN
		INSERT INTO dbo.ContentIndex_N 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'O')
	BEGIN
		INSERT INTO dbo.ContentIndex_O 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'P')
	BEGIN
		INSERT INTO dbo.ContentIndex_P 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'Q')
	BEGIN
		INSERT INTO dbo.ContentIndex_Q 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'R')
	BEGIN
		INSERT INTO dbo.ContentIndex_R 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'S')
	BEGIN
		INSERT INTO dbo.ContentIndex_S 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'T')
	BEGIN
		INSERT INTO dbo.ContentIndex_T 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'U')
	BEGIN
		INSERT INTO dbo.ContentIndex_U 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'V')
	BEGIN
		INSERT INTO dbo.ContentIndex_V 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'W')
	BEGIN
		INSERT INTO dbo.ContentIndex_W 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'X')
	BEGIN
		INSERT INTO dbo.ContentIndex_X 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'Y')
	BEGIN
		INSERT INTO dbo.ContentIndex_Y 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'Z')
	BEGIN
		INSERT INTO dbo.ContentIndex_Z 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END


	if (@done = 0)
	BEGIN
		INSERT INTO dbo.ContentIndex_Default
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
	END
GO
/****** Object:  StoredProcedure [dbo].[PURGE_SearchIndexDataForContentInstance]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.PURGE_SearchIndexDataForContentInstance    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure [dbo].[PURGE_SearchIndexDataForContentInstance]

	@txtFirstCharacter char(1),
	@intPageId int,
	@intContentId int

AS

	-- PURGE_SearchIndexDataForContentInstance 28

	SET NOCOUNT ON

	DECLARE @done bit
	SET @done = 0

	--DELETE FROM dbo.Page WHERE PageID = @intPageID

	IF (@txtFirstCharacter = 'A')
	BEGIN
		DELETE FROM  dbo.ContentIndex_A
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'B')
	BEGIN
		DELETE FROM dbo.ContentIndex_B 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'C')
	BEGIN
		DELETE FROM dbo.ContentIndex_C 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'D')
	BEGIN
		DELETE FROM dbo.ContentIndex_D 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'E')
	BEGIN
		DELETE FROM dbo.ContentIndex_E 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'F')
	BEGIN
		DELETE FROM dbo.ContentIndex_F 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'G')
	BEGIN
		DELETE FROM dbo.ContentIndex_G 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'H')
	BEGIN
		DELETE FROM dbo.ContentIndex_H 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'I')
	BEGIN
		DELETE FROM dbo.ContentIndex_I 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'J')
	BEGIN
		DELETE FROM dbo.ContentIndex_J 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'K')
	BEGIN
		DELETE FROM dbo.ContentIndex_K 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'L')
	BEGIN
		DELETE FROM dbo.ContentIndex_L 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'M')
	BEGIN
		DELETE FROM dbo.ContentIndex_M 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'N')
	BEGIN
		DELETE FROM dbo.ContentIndex_N 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'O')
	BEGIN
		DELETE FROM dbo.ContentIndex_O 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'P')
	BEGIN
		DELETE FROM dbo.ContentIndex_P 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'Q')
	BEGIN
		DELETE FROM dbo.ContentIndex_Q 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'R')
	BEGIN
		DELETE FROM dbo.ContentIndex_R 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'S')
	BEGIN
		DELETE FROM dbo.ContentIndex_S 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'T')
	BEGIN
		DELETE FROM dbo.ContentIndex_T 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'U')
	BEGIN
		DELETE FROM dbo.ContentIndex_U 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'V')
	BEGIN
		DELETE FROM dbo.ContentIndex_V 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'W')
	BEGIN
		DELETE FROM dbo.ContentIndex_W 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'X')
	BEGIN
		DELETE FROM dbo.ContentIndex_X 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'Y')
	BEGIN
		DELETE FROM dbo.ContentIndex_Y 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'Z')
	BEGIN
		DELETE FROM dbo.ContentIndex_Z 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END


	if (@done = 0)
	BEGIN
		DELETE FROM dbo.ContentIndex_Default
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
	END
GO
/****** Object:  StoredProcedure [dbo].[ContentIndex_SELECT_WordIndexList]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.ContentIndex_SELECT_WordIndexList    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec ContentIndex_SELECT_WordIndexList @txtSearchCriteria = '%acc%'


/****** Object:  Stored Procedure dbo.ContentIndex_SELECT_WordIndexList    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[ContentIndex_SELECT_WordIndexList]

	-- ContentIndex_SELECT_WordIndexList 'a'
	-- ContentIndex_SELECT_WordIndexList 'A'
	-- ContentIndex_SELECT_WordIndexList 'T'
	-- ContentIndex_SELECT_WordIndexList 'z'
	-- ContentIndex_SELECT_WordIndexList '%'

	@txtLetter char(1)

AS

	SET NOCOUNT ON


	DECLARE @bLetterFound bit
	SET @bLetterFound = 0


	IF @txtLetter = 'A'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_A Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'B'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_B Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'C'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_C Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'D'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_D Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'E'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_E Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'F'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_F Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'G'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_G Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'H'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_H Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'I'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_I Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'J'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_J Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'K'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_K Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'L'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_L Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'M'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_M Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'N'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_N Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'O'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_O Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'P'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_P Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'Q'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_Q Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'R'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_R Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'S'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_S Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'T'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_T Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'U'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_U Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'V'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_V Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'W'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_W Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'X'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_X Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'Y'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_Y Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'Z'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_Z Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END


	IF @bLetterFound = 0
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_Default Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
	END
GO
/****** Object:  StoredProcedure [dbo].[ContentMarshal_DELETE_ContentForPage]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.ContentMarshal_DELETE_ContentForPage    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure [dbo].[ContentMarshal_DELETE_ContentForPage]

	@intPageID int

AS

	SET NOCOUNT ON

	DELETE FROM [dbo].[ContentMarshal]
	WHERE	PageID = @intPageID
GO
/****** Object:  StoredProcedure [dbo].[ContentMarshal_INSERT_ContentItemForPage]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.ContentMarshal_INSERT_ContentItemForPage    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure [dbo].[ContentMarshal_INSERT_ContentItemForPage]

	@intPageID int,
	@intContentID int,
	@intSortOrder int

AS

	SET NOCOUNT ON

	INSERT INTO [dbo].[ContentMarshal]([PageID], [ContentID], [SortOrder])
	VALUES (
		@intPageID,
		@intContentID,
		@intSortOrder
	)
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_ActiveContentForIndexing]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Content_SELECT_ActiveContentForIndexing    Script Date: 10/02/2007 8:11:37 p.m. ******/
/****** Object:  Stored Procedure dbo.Content_SELECT_ActiveContentForIndexing    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_ActiveContentForIndexing]


AS


	/*
	Selects text ready to be indexed:
	 * TextContent of Content Items where:
		- IsLive = 1
		- IsSearchable = 1



	*/



	SET NOCOUNT ON



	SELECT Content.TextContent   --,Content.ContentID 

	FROM	dbo.Content

	WHERE	Content.ContentID IN (
	
		SELECT DISTINCT C.ContentID
	
		FROM	Content C 
			INNER JOIN ContentMarshal CM ON C.ContentID = CM.ContentID 
			INNER JOIN Page P ON CM.PageID = P.PageID
	
		WHERE	(C.IsLive = 1) 
		AND 	(C.IsSearchable = 1) 
		AND 	(P.IsSearchable = 1) 
		AND 	(P.IsLive = 1)
	)

	ORDER BY Content.ContentID
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_List_ById]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Content_SELECT_List_ById    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_List_ById]

	@intContentId_1 int,
	@intContentId_2 int = -1,
	@intContentId_3 int = -1,
	@intContentId_4 int = -1,
	@intContentId_5 int = -1
	

AS

	-- Content_SELECT_List_ById 67
	-- Content_SELECT_List_ById 51, 53, 44, 67, 68
	SET NOCOUNT ON

	SELECT	C.ContentID, 
			C.Note, 
			C.ContentType,
			C.IsLive, 
			C.IsSearchable, 
			C.LastModified, 
			C.LastModifiedBy,
			(SELECT Count(*) FROM dbo.ControlProperties CP WHERE PropertyType = 'CONT' AND PropertyValue = C.ContentID) PageUsageCount

	FROM		dbo.Content C

	WHERE		C.ContentID = @intContentId_1
			OR	C.ContentID = @intContentId_2
			OR	C.ContentID = @intContentId_3
			OR	C.ContentID = @intContentId_4
			OR	C.ContentID = @intContentId_5
	
	ORDER BY 	C.Note,
				C.ContentID
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_List_Search]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Content_SELECT_List_Search    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_List_Search]

	@txtNotes varchar(25),
	@txtContentType char(4) = '____'

AS

	SET NOCOUNT ON
	-- Content_SELECT_List_Search '%a%'
	-- Content_SELECT_List_Search '%a%', 'CONT'

	IF @txtContentType = '____'
	BEGIN

		SELECT	C.ContentID, 
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.LastModified, 
				C.LastModifiedBy,
				(SELECT Count(*) FROM dbo.ControlProperties CP WHERE PropertyType = 'CONT' AND PropertyValue = C.ContentID) PageUsageCount

		FROM		dbo.Content C

		WHERE		C.Note LIKE @txtNotes
		
		ORDER BY 	C.Note,
					C.ContentID

	END
	ELSE
	BEGIN

		SELECT	C.ContentID, 
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.LastModified, 
				C.LastModifiedBy,
				(SELECT Count(*) FROM dbo.ControlProperties CP WHERE PropertyType = 'CONT' AND PropertyValue = C.ContentID) PageUsageCount

		FROM		dbo.Content C

		WHERE		C.Note LIKE @txtNotes
			AND		C.ContentType = @txtContentType
		
		ORDER BY 	C.Note,
					C.ContentID
	END
GO
/****** Object:  StoredProcedure [dbo].[Page_SELECT_ByChildContentItem]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Page_SELECT_ByChildContentItem    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure [dbo].[Page_SELECT_ByChildContentItem]


	@intContentID int
AS

	SET NOCOUNT ON

	SELECT	P.PageID, 
		P.Title, 
		P.Url, 
		P.MetaKeywords, 
		P.MetaDescription, 
		P.LastModified,
		P.LastModifiedBy,
		P.IsSearchable,
		P.IsLive

	FROM	dbo.Page P

	WHERE 	PageID IN 
	(
		SELECT DISTINCT InstanceID FROM dbo.ControlProperties
		WHERE 	PropertyType = 'CONT'
		AND	PropertyValue = @intContentID
	)

	ORDER BY	P.Url, P.PageID
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_ContentItemIdsBYInstanceID]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
--dbo.Content_SELECT_PageByID_ForLivePublishing
CREATE Procedure [dbo].[Content_SELECT_ContentItemIdsBYInstanceID]

-- Content_SELECT_PageByID_ForLivePublishing 4, 'CONT'
-- SELECT * FROM ControlProperties

	@intInstanceID int,
	@txtPropertyType char(4)

AS

	SET NOCOUNT ON

	
	SELECT	PropertyValue

	FROM 	[ControlProperties]

	WHERE 	[InstanceID] = @intInstanceID
	AND	PropertyType = @txtPropertyType

	ORDER BY [ID], PropertyKey
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_List_SearchLiveOnlyLiveOnly]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Content_SELECT_List_SearchLiveOnly    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_List_SearchLiveOnlyLiveOnly]

	@txtNotes varchar(25)

AS

	-- Content_SELECT_List_Search 'Book%'
	-- Content_SELECT_List_SearchLiveOnly 'Book%'

	SET NOCOUNT ON

	SELECT		C.ContentID, 
			C.TextContent, 
			C.Note, 
			C.IsLive, 
			C.IsSearchable, 
			C.LastModified, 
			C.LastModifiedBy,
			(SELECT Count(*) FROM dbo.ControlProperties CP WHERE PropertyType = 'CONT' AND PropertyValue = C.ContentID) PageUsageCount

	FROM		dbo.Content C

	WHERE		C.Note LIKE @txtNotes
	AND		C.IsLive = 1
	
	ORDER BY 	C.Note,
			C.ContentID
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_List]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Content_SELECT_List    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_List]

	@txtContentType char(4) = '____'

AS

	SET NOCOUNT ON

	IF @txtContentType = '____'
	BEGIN

		SELECT	C.ContentID, 
				C.TextContent, 
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.LastModified, 
				C.LastModifiedBy,
				--(SELECT Count(*) FROM dbo.ContentMarshal CM WHERE ContentID = C.ContentID) PageUsageCount,
				(SELECT Count(*) FROM dbo.ControlProperties CP WHERE PropertyType = 'CONT' AND PropertyValue = C.ContentID) PageUsageCount

		FROM	dbo.Content C
		
		ORDER BY 
				C.Note,
				C.ContentID

	END
	ELSE
	BEGIN

		SELECT	C.ContentID, 
				C.TextContent, 
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.LastModified, 
				C.LastModifiedBy,
				--(SELECT Count(*) FROM dbo.ContentMarshal CM WHERE ContentID = C.ContentID) PageUsageCount,
				(SELECT Count(*) FROM dbo.ControlProperties CP WHERE PropertyType = 'CONT' AND PropertyValue = C.ContentID) PageUsageCount

		FROM	dbo.Content C

		WHERE	C.ContentType = @txtContentType
		
		ORDER BY 
				C.Note,
				C.ContentID

	END
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_DELETE_BYInstanceID]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[ControlProperties_DELETE_BYInstanceID]

-- ControlProperties_DELETE_BYInstanceID 1
-- SELECT * FROM ControlProperties

	@intInstanceID int

AS

	SET NOCOUNT ON

	
	DELETE FROM [ControlProperties]
	WHERE InstanceID = @intInstanceID
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_PageByID]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Content_SELECT_PageByID    Script Date: 10/02/2007 8:11:37 p.m. ******/
/****** Object:  Stored Procedure dbo.Content_SELECT_PageByID    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_PageByID]

-- Content_SELECT_PageByID 1

	@intPageInstanceID int

AS

	SET NOCOUNT ON


	SELECT	
		C.ContentID, 
		C.Content, 
		C.TextContent,
		C.Note, 
		C.ContentType,
		C.IsLive, 
		C.IsSearchable,
		C.ContentFilter, 
		C.LastModified, 
		C.LastModifiedBy

	FROM	dbo.Content C

	WHERE	C.ContentID IN 
		(
			SELECT	PropertyValue

			FROM 	[ControlProperties]

			WHERE 	[InstanceID] = @intPageInstanceID
			AND		PropertyType = 'CONT'
		)
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_DELETE_BYID]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[ControlProperties_DELETE_BYID]

-- ControlProperties_DELETE_BYID 2, 'sdaa1', 'asdadas1'
-- SELECT * FROM ControlProperties

	@intID int

AS

	SET NOCOUNT ON

	
	DELETE FROM [ControlProperties]
	WHERE [ID] = @intID
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_DELETE_BYInstanceIDPropertyKey]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[ControlProperties_DELETE_BYInstanceIDPropertyKey]

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
/****** Object:  StoredProcedure [dbo].[ControlProperties_INSERT]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[ControlProperties_INSERT]

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
/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_BYID]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[ControlProperties_SELECT_BYID]

-- ControlProperties_SELECT_BYID 5
-- SELECT * FROM ControlProperties

	@intID int

AS

	SET NOCOUNT ON

	
	SELECT	InstanceID, 
			PropertyKey, 
			PropertyValue

	FROM [ControlProperties]

	WHERE [ID] = @intID
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_BYInstanceID]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[ControlProperties_SELECT_BYInstanceID]

-- ControlProperties_SELECT_BYInstanceID 47
-- ControlProperties_SELECT_BYInstanceID 47, 'CONT'
-- ControlProperties_SELECT_BYInstanceID 47, 'CUST'
-- SELECT * FROM ControlProperties

	@intInstanceID int

AS

	SET NOCOUNT ON


		SELECT	[ID], 
			PropertyType,
			PropertyKey, 
			PropertyValue

		FROM 	[ControlProperties]

		WHERE 	[InstanceID] = @intInstanceID

		ORDER BY PropertyType, PropertyKey, [ID]
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_BYInstanceIDPropertyKey]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[ControlProperties_SELECT_BYInstanceIDPropertyKey]

-- ControlProperties_SELECT_BYInstanceIDPropertyKey 86, 'LayoutWebControlType'
-- SELECT * FROM ControlProperties

	@intInstanceID int,
	@txtPropertyKey varchar(200)

AS

	SET NOCOUNT ON

	
	SELECT	[ID], 
			PropertyType,
			PropertyValue

	FROM [ControlProperties]

	WHERE 	InstanceID = @intInstanceID
	AND		PropertyKey = @txtPropertyKey

	ORDER BY [ID]
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_BYInstanceIDPropertyType]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[ControlProperties_SELECT_BYInstanceIDPropertyType]

-- ControlProperties_SELECT_BYInstanceIDPropertyType 47
-- ControlProperties_SELECT_BYInstanceIDPropertyType 47, 'CONT'
-- ControlProperties_SELECT_BYInstanceIDPropertyType 47, 'CUST'
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
/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_BYPropertyKey]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[ControlProperties_SELECT_BYPropertyKey]


-- ControlProperties_SELECT_BYPropertyKey 'LayoutWebControlType'
-- SELECT * FROM ControlProperties

	@txtPropertyKey varchar(200)

AS

	SET NOCOUNT ON

	
	SELECT	[ID], 
		InstanceId,
		PropertyType,
		PropertyKey,
		PropertyValue

	FROM [ControlProperties]

	WHERE 	PropertyKey = @txtPropertyKey

	ORDER BY InstanceId, [ID]
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_ContentItemIdsBYInstanceID]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[ControlProperties_SELECT_ContentItemIdsBYInstanceID]

-- ControlProperties_SELECT_ContentItemIdsBYInstanceID 2
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
	AND		PropertyType = @txtPropertyType

	ORDER BY [ID], PropertyKey
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_ListAllOrphans]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Content_SELECT_ListAllOrphans    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_ListAllOrphans]



AS

	-- Content_SELECT_ListAllOrphans 58
	-- SELECT * FROM dbo.Page WHERE PageID = 58
	-- SELECT * FROM dbo.ContentMarshal
	
	-- Content_SELECT_ListAllOrphans

	SET NOCOUNT ON

	SELECT	C.ContentID, 
		C.TextContent, 
		C.Note, 
		C.ContentType,
		C.IsLive, 
		C.IsSearchable, 
		C.LastModified, 
		C.LastModifiedBy,
		0 PageUsageCount

	FROM Content C 

	WHERE C.ContentID NOT IN 
	(
		SELECT CAST(PropertyValue AS INT) ContentId FROM dbo.ControlProperties WHERE PropertyType = 'CONT'
	) 

	ORDER BY C.ContentID
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_DELETE_BYInstanceIDPropertyType]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[ControlProperties_DELETE_BYInstanceIDPropertyType]

	-- SELECT * FROM ControlProperties

	@intInstanceID int,
	@txtPropertyType char(4)

AS

	SET NOCOUNT ON

	
	DELETE FROM [ControlProperties]
	WHERE 	InstanceID = @intInstanceID 
	AND		PropertyType = @txtPropertyType
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_ByDateLastModified]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Content_SELECT_ByContentID    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_ByDateLastModified]

	-- Content_SELECT_ByDateLastModified '2009-01-09 00:00:00.000', '2009-04-09 23:59:59.000'


	@startDate datetime,
	@endDate datetime

AS

	SET NOCOUNT ON


	SELECT	C.ContentID, 
			C.Note ContentNote, 
			C.Content,
			C.ContentType,
			C.IsLive ContentIsLive, 
			C.IsSearchable ContentIsSearchable, 
			C.ContentFilter ContentEntryFilter,
			C.LastModified ContentLastModified, 
			C.LastModifiedBy ContentLastModifiedBy,
			P.PageID,
			P.Title PageTitle, 
			P.Url PageUrl, 
			P.MetaKeywords PageKeywords, 
			P.MetaDescription PageDescription, 
			P.LastModified PageLastModified,
			P.LastModifiedBy PageLastModifiedBy,
			P.IsSearchable PageIsSearchable,
			P.IsLive PageIsLive


	FROM	dbo.Content C
		INNER JOIN ControlProperties Props ON C.ContentId = Props.PropertyValue 
		INNER JOIN Page P ON Props.InstanceID = P.PageID

	WHERE 	Props.PropertyKey = 'BlogPost'
	AND		(C.LastModified >= @startDate AND C.LastModified < @endDate)
	AND		P.IsLive = 1
	AND		C.IsLive = 1

	ORDER BY C.LastModified DESC
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_DELETE_BYPropertyTypeAndPropertyValue]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.ControlProperties_DELETE_BYPropertyTypeAndPropertyValue    Script Date: 10/02/2007 8:11:37 p.m. ******/

CREATE Procedure [dbo].[ControlProperties_DELETE_BYPropertyTypeAndPropertyValue]

	-- SELECT * FROM ControlProperties

	@txtPropertyType char(4),
	@txtPropertyValue varchar(2000)

AS

	SET NOCOUNT ON

	
	DELETE FROM [ControlProperties]
	WHERE 	PropertyValue = @txtPropertyValue 
	AND		PropertyType = @txtPropertyType
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_DELETE_BYPropertyKeyAndPropertyValue]    Script Date: 10/28/2009 12:28:51 ******/
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
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_BYPropertyType]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[ControlProperties_SELECT_BYPropertyType]

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
/****** Object:  StoredProcedure [dbo].[Content_SELECT_ListByDateLastModified]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Content_SELECT_ByContentID    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_ListByDateLastModified]

	@startDate datetime,
	@endDate datetime,
	@txtContentType char(4) = 'BPST',
	@intPageId int = -1

AS

	-- Content_SELECT_ListByDateLastModified '2008-04-10 10:46:23.153', '2010-04-10 10:46:23.153'
	-- Content_SELECT_ListByDateLastModified '2009-01-09 00:00:00.000', '2009-04-09 23:59:59.000'
	-- Content_SELECT_ListByDateLastModified '2009-01-09 00:00:00.000', '2009-04-09 23:59:59.000', 'CONT'

	-- Content_SELECT_ListByDateLastModified '2009-01-09 00:00:00.000', '2009-04-09 23:59:59.000', 'BPST', 61
	-- Content_SELECT_ListByDateLastModified '2009-01-09 00:00:00.000', '2009-04-09 23:59:59.000', 'CONT', 53


	SET NOCOUNT ON

	IF @intPageId > -1
	BEGIN

		SELECT	DISTINCT
				--P.PageId,
				C.ContentID, 
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.ContentFilter,
				C.LastModified, 
				C.LastModifiedBy,
				(SELECT Count(*) FROM dbo.ControlProperties CP WHERE PropertyType = 'CONT' AND PropertyValue = C.ContentID) PageUsageCount

		FROM	dbo.Content C
			INNER JOIN ControlProperties Props ON C.ContentId = Props.PropertyValue 
			INNER JOIN Page P ON Props.InstanceID = P.PageID

		WHERE 	Props.PropertyType = @txtContentType
		AND		C.ContentType = @txtContentType
		AND		(C.LastModified >= @startDate AND C.LastModified < @endDate)
		AND		P.IsLive = 1
		AND		C.IsLive = 1
		AND		P.PageId = @intPageId

		ORDER BY C.LastModified DESC

	END
	ELSE
	BEGIN

		SELECT	DISTINCT
				--P.PageId,
				C.ContentID, 
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.ContentFilter,
				C.LastModified, 
				C.LastModifiedBy

		FROM	dbo.Content C
			INNER JOIN ControlProperties Props ON C.ContentId = Props.PropertyValue 
			INNER JOIN Page P ON Props.InstanceID = P.PageID

		WHERE 	Props.PropertyType = @txtContentType
		AND		C.ContentType = @txtContentType
		AND		(C.LastModified >= @startDate AND C.LastModified < @endDate)
		AND		P.IsLive = 1
		AND		C.IsLive = 1

		ORDER BY C.LastModified DESC

	END
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_LatestLiveByPageId]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Content_SELECT_LatestLiveByPageId    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_LatestLiveByPageId]

	-- Content_SELECT_LatestLiveByPageId 62
	-- Content_SELECT_LatestLiveByPageId 14, 'CONT'
	-- Content_SELECT_LatestLiveByPageId 61, 'BPST'

	@intPageID int,
	@txtContentType char(4) = 'BPST'

AS

	SET NOCOUNT ON

	SELECT	TOP 3
			C.ContentID, 
			C.Content, 
			C.TextContent,
			C.Note, 
			C.ContentType,
			C.IsLive, 
			C.IsSearchable, 
			C.ContentFilter,
			C.LastModified, 
			C.LastModifiedBy

	FROM	dbo.Content C
	INNER JOIN dbo.ControlProperties CP ON C.ContentID = CP.PropertyValue
	INNER JOIN dbo.Page P ON CP.InstanceID = P.PageID

	WHERE	P.PageID = @intPageID
		AND	CP.PropertyType = @txtContentType
		AND	P.IsLive = 1
		AND	C.IsLive = 1

	ORDER BY C.LastModified DESC
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_ForBlogRSS]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Content_SELECT_ForBlogRSS    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_ForBlogRSS]

	-- Content_SELECT_ForBlogRSS 62
	-- Content_SELECT_ForBlogRSS 14, 'CONT'
	-- Content_SELECT_ForBlogRSS 61, 'BPST'

	@intPageID int,
	@txtContentType char(4) = 'BPST'

AS

	SET NOCOUNT ON

	SELECT	TOP 25
			C.ContentID, 
			C.Note ContentNote, 
			C.Content,
			C.ContentType,
			C.IsLive ContentIsLive, 
			C.IsSearchable ContentIsSearchable, 
			C.ContentFilter ContentEntryFilter,
			C.LastModified ContentLastModified, 
			C.LastModifiedBy ContentLastModifiedBy,

			P.PageID,
			P.Title PageTitle, 
			P.Url PageUrl, 
			P.MetaKeywords PageKeywords, 
			P.MetaDescription PageDescription, 
			P.LastModified PageLastModified,
			P.LastModifiedBy PageLastModifiedBy,
			P.IsSearchable PageIsSearchable,
			P.IsLive PageIsLive  

/*
,
			(
				SELECT	PropertyValue

				FROM 	[ControlProperties]

				WHERE 	[InstanceID] = C.ContentID
				AND		PropertyType = 'CTAG'

				ORDER BY PropertyValue
			)
*/



	FROM	dbo.Content C
	INNER JOIN dbo.ControlProperties CP ON C.ContentID = CP.PropertyValue
	INNER JOIN dbo.Page P ON CP.InstanceID = P.PageID

	WHERE		P.PageID = @intPageID
		AND		CP.PropertyType = @txtContentType
		AND		P.IsLive = 1
		AND		C.IsLive = 1

	ORDER BY C.LastModified DESC
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_BYInstanceIDPropertyValueAndKey]    Script Date: 10/28/2009 12:28:51 ******/
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
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_ListLatestLiveByPageId]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Content_SELECT_ByContentID    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_ListLatestLiveByPageId]

	@intPageID int,
	@txtContentType char(4) = 'BPST'

AS

	-- Content_SELECT_ListLatestLiveByPageId 61, 'BPST'
	-- Content_SELECT_ListLatestLiveByPageId 62, 'BPST'
	-- Content_SELECT_ListLatestLiveByPageId 53, 'CONT'
	-- Content_SELECT_ListLatestLiveByPageId 53


	SET NOCOUNT ON

	IF @intPageId > -1
	BEGIN

		SELECT	DISTINCT
				--P.PageId,
				C.ContentID, 
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.ContentFilter,
				C.LastModified, 
				C.LastModifiedBy,
				(SELECT Count(*) FROM dbo.ControlProperties CP WHERE PropertyType = 'CONT' AND PropertyValue = C.ContentID) PageUsageCount

		FROM	dbo.Content C
			INNER JOIN ControlProperties Props ON C.ContentId = Props.PropertyValue 
			INNER JOIN Page P ON Props.InstanceID = P.PageID

		WHERE 	Props.PropertyType = @txtContentType
		AND		C.ContentType = @txtContentType
		AND		P.IsLive = 1
		AND		C.IsLive = 1
		AND		P.PageId = @intPageId

		ORDER BY C.LastModified DESC

	END
	ELSE
	BEGIN

		SELECT	DISTINCT
				--P.PageId,
				C.ContentID, 
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.ContentFilter,
				C.LastModified, 
				C.LastModifiedBy,
				(SELECT Count(*) FROM dbo.ControlProperties CP WHERE PropertyType = 'CONT' AND PropertyValue = C.ContentID) PageUsageCount

		FROM	dbo.Content C
			INNER JOIN ControlProperties Props ON C.ContentId = Props.PropertyValue 
			INNER JOIN Page P ON Props.InstanceID = P.PageID

		WHERE 	Props.PropertyType = @txtContentType
		AND		C.ContentType = @txtContentType
		AND		P.IsLive = 1
		AND		C.IsLive = 1

		ORDER BY C.LastModified DESC

	END
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_BlogPostsByCTag]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[ControlProperties_SELECT_BlogPostsByCTag]

-- ControlProperties_SELECT_BlogPostsByCTag 'EASTER'
-- ControlProperties_SELECT_BlogPostsByCTag 'JAZZ'
-- ControlProperties_SELECT_BlogPostsByCTag 'Test'
-- SELECT * FROM ControlProperties

	@txtTag varchar(2000)

AS

	SET NOCOUNT ON

	SELECT DISTINCT P.PageId, 
		P.Title,
		P.Url, 
		P.MetaKeywords,
		P.MetaDescription,
		C.LastModified, 
		C.LastModifiedBy,
		1 Matches, --Count(*),
		C.ContentId, 
		C.Note,
		C.ContentType		
	FROM 	[ControlProperties] CP2 INNER JOIN Page P ON InstanceId = P.PageId
		INNER JOIN [Content] C ON CP2.PropertyValue = C.ContentId
	WHERE	PropertyType = 'BPST'
	AND		P.IsLive = 1
	AND		C.IsLive = 1
	AND		CP2.PropertyValue IN 
	(
		SELECT	CP.InstanceId
		FROM	[ControlProperties] CP INNER JOIN [Content] C ON CP.InstanceId = C.ContentId
		WHERE	CP.PropertyType = 'CTAG'
		AND		CP.PropertyValue = @txtTag
		AND		CP.InstanceId IS NOT NULL
		AND		CP2.PropertyValue = CP.InstanceId 
	)
	ORDER BY C.LastModified DESC
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_CTagsForLiveBlog]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[ControlProperties_SELECT_CTagsForLiveBlog]

-- ControlProperties_SELECT_CTagsForLiveBlog 61
-- ControlProperties_SELECT_CTagsForLiveBlog 61, 1
-- ControlProperties_SELECT_CTagsForLiveBlog 61, 0
-- ControlProperties_SELECT_CTagsForLiveBlog 62, 1
-- ControlProperties_SELECT_CTagsForLiveBlog 62, 0
-- SELECT * FROM ControlProperties

	@intPageID int,
	@bOrderAlphabetically bit = 1

AS

	SET NOCOUNT ON

	IF @bOrderAlphabetically = 1
	BEGIN

		SELECT	CP.PropertyValue, Count(*) TagCount
		FROM	[ControlProperties] CP
			INNER JOIN [Content] C ON InstanceId = C.ContentId
		WHERE	[InstanceID] IN 
		(
			SELECT DISTINCT PropertyValue
			FROM 	[ControlProperties]
				INNER JOIN Page P ON InstanceId = P.PageId
			WHERE	PropertyType = 'BPST'
			AND		P.IsLive = 1
			AND		P.PageID = @intPageID
		)
		AND		CP.PropertyType = 'CTAG'
		AND		C.IsLive = 1
		GROUP BY PropertyValue
		ORDER BY PropertyValue

	END
	ELSE
	BEGIN

		SELECT	CP.PropertyValue, Count(*) TagCount
		FROM	[ControlProperties] CP
			INNER JOIN [Content] C ON InstanceId = C.ContentId
		WHERE	[InstanceID] IN 
		(
			SELECT DISTINCT PropertyValue
			FROM 	[ControlProperties]
				INNER JOIN Page P ON InstanceId = P.PageId
			WHERE	PropertyType = 'BPST'
			AND		P.IsLive = 1
			AND		P.PageID = @intPageID
		)
		AND		CP.PropertyType = 'CTAG'
		AND		C.IsLive = 1
		GROUP BY PropertyValue
		ORDER BY TagCount DESC

	END
GO
/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_CTagsForLiveBlogs]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[ControlProperties_SELECT_CTagsForLiveBlogs]

-- ControlProperties_SELECT_CTagsForLiveBlogs 
-- ControlProperties_SELECT_CTagsForLiveBlogs 1
-- ControlProperties_SELECT_CTagsForLiveBlogs 0
-- SELECT * FROM ControlProperties

	@bOrderAlphabetically bit = 1

AS

	SET NOCOUNT ON

	IF @bOrderAlphabetically = 1
	BEGIN

		SELECT	CP.PropertyValue, Count(*) TagCount
		FROM	[ControlProperties] CP
			INNER JOIN [Content] C ON InstanceId = C.ContentId
		WHERE	[InstanceID] IN 
		(
			SELECT DISTINCT PropertyValue
			FROM 	[ControlProperties]
				INNER JOIN Page P ON InstanceId = P.PageId
			WHERE	PropertyType = 'BPST'
			AND		P.IsLive = 1
		)
		AND		CP.PropertyType = 'CTAG'
		AND		C.IsLive = 1
		GROUP BY PropertyValue
		ORDER BY PropertyValue

	END
	ELSE
	BEGIN

		SELECT	CP.PropertyValue, Count(*) TagCount
		FROM	[ControlProperties] CP
			INNER JOIN [Content] C ON InstanceId = C.ContentId
		WHERE	[InstanceID] IN 
		(
			SELECT DISTINCT PropertyValue
			FROM 	[ControlProperties]
				INNER JOIN Page P ON InstanceId = P.PageId
			WHERE	PropertyType = 'BPST'
			AND		P.IsLive = 1
		)
		AND		CP.PropertyType = 'CTAG'
		AND		C.IsLive = 1
		GROUP BY PropertyValue
		ORDER BY TagCount DESC

	END
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_PageByID_ForLivePublishing]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Content_SELECT_PageByID_ForLivePublishing    Script Date: 13/03/2007 1:50:46 p.m. ******/

--dbo.Content_SELECT_PageByID_ForLivePublishing
CREATE Procedure [dbo].[Content_SELECT_PageByID_ForLivePublishing]

-- Content_SELECT_PageByID_ForLivePublishing 14
-- SELECT * FROM ControlProperties

	@intPageInstanceID int

AS

	SET NOCOUNT ON


	SELECT	
		C.ContentID, 
		C.Content, 
		C.TextContent,
		C.ContentType,
		C.Note, 
		C.IsLive, 
		C.IsSearchable, 
		C.ContentFilter,
		C.LastModified, 
		C.LastModifiedBy

	FROM	dbo.Content C

	WHERE	C.ContentID IN 
		(
			SELECT	PropertyValue

			FROM 	[ControlProperties]

			WHERE 	[InstanceID] = @intPageInstanceID
			AND	(PropertyType = 'CONT' OR PropertyType = 'BPST')
		)
	AND	C.IsLive = 1
GO
/****** Object:  StoredProcedure [dbo].[Image_INSERT]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Image_INSERT    Script Date: 10/02/2007 8:11:37 p.m. ******/
/****** Object:  Stored Procedure dbo.Image_INSERT    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Image_INSERT]

	@txtImageName varchar(500),
	@intWidth int,
	@intHeight int

AS

	SET NOCOUNT ON

	INSERT INTO 	[dbo].[Images] (
		[ImageName], 
		[Width], 
		[Height])
	VALUES (
		@txtImageName, 
		@intWidth, 
		@intHeight)
GO
/****** Object:  StoredProcedure [dbo].[Image_SELECT_ByImageName]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Image_SELECT_ByImageName    Script Date: 10/02/2007 8:11:37 p.m. ******/
/****** Object:  Stored Procedure dbo.Image_SELECT_ByImageName    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Image_SELECT_ByImageName]

-- Image_SELECT_ByImageName 1

	@txtImageName varchar(500)

AS

	SET NOCOUNT ON

	SELECT TOP 1 [ID], ImageName, Width, Height

	FROM	dbo.Images

	WHERE	ImageName = @txtImageName
GO
/****** Object:  StoredProcedure [dbo].[WriteLog]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Stored Procedure dbo.WriteLog    Script Date: 11/12/2007 12:51:10 p.m. ******/




/****** Object:  Stored Procedure dbo.WriteLog    Script Date: 10/1/2004 3:16:36 PM ******/

CREATE PROCEDURE [dbo].[WriteLog]
(
	@EventID int, 
	@Priority int, 
	@Severity nvarchar(32), 
	@Title nvarchar(256), 
	@Timestamp datetime,
	@MachineName nvarchar(32), 
	@AppDomainName nvarchar(512),
	@ProcessID nvarchar(256),
	@ProcessName nvarchar(512),
	@ThreadName nvarchar(512),
	@Win32ThreadId nvarchar(128),
	@Message nvarchar(1500),
	@FormattedMessage ntext,
	@LogId int OUTPUT
)
AS 

	INSERT INTO [Log] (
		EventID,
		Priority,
		Severity,
		Title,
		[Timestamp],
		MachineName,
		AppDomainName,
		ProcessID,
		ProcessName,
		ThreadName,
		Win32ThreadId,
		Message,
		FormattedMessage
	)
	VALUES (
		@EventID, 
		@Priority, 
		@Severity, 
		@Title, 
		@Timestamp,
		@MachineName, 
		@AppDomainName,
		@ProcessID,
		@ProcessName,
		@ThreadName,
		@Win32ThreadId,
		@Message,
		@FormattedMessage)

	SET @LogID = @@IDENTITY
	RETURN @LogID
GO
/****** Object:  StoredProcedure [dbo].[ClearLogs]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Stored Procedure dbo.ClearLogs    Script Date: 11/12/2007 12:51:10 p.m. ******/
CREATE PROCEDURE [dbo].[ClearLogs]
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM CategoryLog
	DELETE FROM [Log]
    DELETE FROM Category
END
GO
/****** Object:  StoredProcedure [dbo].[Page_SELECT_PagesByID]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[Page_SELECT_PagesByID]

	@intPageId1 int,
	@intPageId2 int = 0,
	@intPageId3 int = 0,
	@intPageId4 int = 0,
	@intPageId5 int = 0

AS

	-- Page_SELECT_PagesByID 1
	-- Page_SELECT_PagesByID 1, 2, 3
	-- Page_SELECT_PagesByID 1, 2, 3, 4, 5
	SET NOCOUNT ON

	SELECT	P.PageID, 
			P.Title, 
			P.Url, 
			P.MetaKeywords, 
			P.MetaDescription, 
			P.LastModified,
			P.LastModifiedBy,
			P.IsSearchable,
			P.IsLive

	FROM	dbo.Page P

	WHERE	(
		P.PageID = @intPageId1 OR
		P.PageID = @intPageId2 OR
		P.PageID = @intPageId3 OR
		P.PageID = @intPageId4 OR
		P.PageID = @intPageId5
	)

	ORDER BY
			P.Title, P.PageID
GO
/****** Object:  StoredProcedure [dbo].[Page_SELECT_PageByTitle]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE Procedure [dbo].[Page_SELECT_PageByTitle]

	-- Page_SELECT_PageByTitle 'blogtest001'
	-- SELECT * FROM Page ORDER BY LastModified DESC

	@txtTitle varchar(500)

AS

	SET NOCOUNT ON

	SELECT	P.PageID, 
			P.Title, 
			P.Url, 
			P.MetaKeywords, 
			P.MetaDescription, 
			P.LastModified,
			P.LastModifiedBy,
			P.IsSearchable,
			P.IsLive

	FROM	dbo.Page P

	WHERE	P.Title = @txtTitle

	-- In a sunny day we'll only get one record, 
	-- but we'll order by date LastModified so that the most 
	-- recently saved is returned.
	ORDER BY P.LastModified DESC
GO
/****** Object:  StoredProcedure [dbo].[Page_UPDATE]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Page_UPDATE    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure [dbo].[Page_UPDATE]

-- Page_UPDATE 1

	@intPageID int,
	@txtTitle varchar(500),
	@txtUrl varchar(1000),
	@txtKeywords varchar(2000),
	@txtDescription varchar(2000),
	@dtLastModified DateTime,
	@txtLastModifiedBy varchar(101),
	@bIsSearchable bit,
	@bIsLive bit

AS

	SET NOCOUNT ON

	UPDATE [dbo].[Page]

	SET 
		[Title] = @txtTitle,
		[Url] = @txtUrl, 
		[MetaKeywords] = @txtKeywords, 
		[MetaDescription] = @txtDescription,
		[LastModified] = @dtLastModified, 
		[LastModifiedBy] = @txtLastModifiedBy,
		[IsSearchable] = @bIsSearchable,
		[IsLive] = @bIsLive

	WHERE	[Page].PageID = @intPageID
GO
/****** Object:  StoredProcedure [dbo].[Page_SELECT_ByURLForLivePublishing]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Page_SELECT_ByURLForLivePublishing    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure [dbo].[Page_SELECT_ByURLForLivePublishing]
	
	-- SELECT P.Url FROM dbo.Page P
	-- Page_SELECT_ByURLForLivePublishing 'a/b/default.aspx'

	@txtURL varchar(1000)

AS

	SET NOCOUNT ON

	SELECT	TOP 1 P.PageID, 
			P.Title, 
			P.Url, 
			P.MetaKeywords, 
			P.MetaDescription, 
			P.LastModified,
			P.LastModifiedBy,
			P.IsSearchable,
			P.IsLive

	FROM	dbo.Page P

	WHERE	P.Url = @txtURL
	AND		P.IsLive = 1

	ORDER BY P.LastModified DESC
GO
/****** Object:  StoredProcedure [dbo].[Page_SELECT_UrlSegmentSearch]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Page_SELECT_UrlSegmentSearch    Script Date: 10/02/2007 8:11:37 p.m. ******/

CREATE Procedure [dbo].[Page_SELECT_UrlSegmentSearch]
	
	-- SELECT P.Url FROM dbo.Page P
	-- Page_SELECT_UrlSegmentSearch 'a/b/default.aspx'

	@txtUrlHint varchar(1000)

AS

	SET NOCOUNT ON

	SELECT	DISTINCT P.Url

	FROM	dbo.Page P

	WHERE	P.Url LIKE @txtUrlHint

	ORDER BY P.Url DESC
GO
/****** Object:  StoredProcedure [dbo].[Page_SELECT_PageByID]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Page_SELECT_PageByID    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure [dbo].[Page_SELECT_PageByID]

-- Page_SELECT_PageByID 1

	@intPageID int

AS

	SET NOCOUNT ON

	SELECT	P.PageID, 
			P.Title, 
			P.Url, 
			P.MetaKeywords, 
			P.MetaDescription, 
			P.LastModified,
			P.LastModifiedBy,
			P.IsSearchable,
			P.IsLive

	FROM	dbo.Page P

	WHERE	P.PageID = @intPageID
GO
/****** Object:  StoredProcedure [dbo].[Page_INSERT]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Page_INSERT    Script Date: 10/02/2007 8:11:37 p.m. ******/
/****** Object:  Stored Procedure dbo.Page_INSERT    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Page_INSERT]


	@IDENTITY int OUTPUT,
	@txtTitle varchar(500),
	@txtUrl varchar(1000),
	@txtKeywords varchar(2000),
	@txtDescription varchar(2000),
	@txtLastModifiedBy varchar(101),
	@bIsSearchable bit,
	@bIsLive bit

AS

	SET NOCOUNT ON



	INSERT INTO [dbo].[Page](		
		Title, 
		Url, 
		MetaKeywords, 
		MetaDescription, 
		LastModified, 
		LastModifiedBy, 
		IsSearchable, 
		IsLive
	)
	VALUES (
		@txtTitle,
		@txtUrl,
		@txtKeywords,
		@txtDescription,
		GetDate(), 
		@txtLastModifiedBy,
		@bIsSearchable,
		@bIsLive
	)


	SELECT @IDENTITY = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[Page_SELECT_ByURL]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Page_SELECT_ByURL    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure [dbo].[Page_SELECT_ByURL]
	
	-- SELECT P.Url FROM dbo.Page P
	-- Page_SELECT_ByURL 'a/b/default.aspx'

	@txtURL varchar(1000)

AS

	SET NOCOUNT ON

	SELECT	P.PageID, 
			P.Title, 
			P.Url, 
			P.MetaKeywords, 
			P.MetaDescription, 
			P.LastModified,
			P.LastModifiedBy,
			P.IsSearchable,
			P.IsLive

	FROM	dbo.Page P

	WHERE	P.Url = @txtURL

	ORDER BY P.LastModified DESC
GO
/****** Object:  StoredProcedure [dbo].[Page_SELECT_List]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Page_SELECT_List    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure [dbo].[Page_SELECT_List]



AS

	SET NOCOUNT ON

	SELECT	P.PageID, 
			P.Title, 
			P.Url, 
			P.MetaKeywords, 
			P.MetaDescription, 
			P.LastModified,
			P.LastModifiedBy,
			P.IsSearchable,
			P.IsLive

	FROM	dbo.Page P

	ORDER BY
			P.Url, P.PageID
GO
/****** Object:  StoredProcedure [dbo].[Page_SELECT_ListSearch]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Page_SELECT_ListSearch    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure [dbo].[Page_SELECT_ListSearch]

	@bIsSearchable bit,
	@bIsLive bit

AS

	SET NOCOUNT ON

	SELECT	P.PageID, 
			P.Title, 
			P.Url, 
			P.MetaKeywords, 
			P.MetaDescription, 
			P.LastModified,
			P.LastModifiedBy,
			P.IsSearchable,
			P.IsLive

	FROM	dbo.Page P

	WHERE	P.IsSearchable = @bIsSearchable
	AND		P.IsLive = @bIsLive

	ORDER BY
			P.Url, P.PageID
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_ResetPassword]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_ResetPassword]
    @ApplicationName             nvarchar(256),
    @UserName                    nvarchar(256),
    @NewPassword                 nvarchar(128),
    @MaxInvalidPasswordAttempts  int,
    @PasswordAttemptWindow       int,
    @PasswordSalt                nvarchar(128),
    @CurrentTimeUtc              datetime,
    @PasswordFormat              int = 0,
    @PasswordAnswer              nvarchar(128) = NULL
AS
BEGIN
    DECLARE @IsLockedOut                            bit
    DECLARE @LastLockoutDate                        datetime
    DECLARE @FailedPasswordAttemptCount             int
    DECLARE @FailedPasswordAttemptWindowStart       datetime
    DECLARE @FailedPasswordAnswerAttemptCount       int
    DECLARE @FailedPasswordAnswerAttemptWindowStart datetime

    DECLARE @UserId                                 uniqueidentifier
    SET     @UserId = NULL

    DECLARE @ErrorCode     int
    SET @ErrorCode = 0

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
	    BEGIN TRANSACTION
	    SET @TranStarted = 1
    END
    ELSE
    	SET @TranStarted = 0

    SELECT  @UserId = u.UserId
    FROM    dbo.aspnet_Users u, dbo.aspnet_Applications a, dbo.aspnet_Membership m
    WHERE   LoweredUserName = LOWER(@UserName) AND
            u.ApplicationId = a.ApplicationId  AND
            LOWER(@ApplicationName) = a.LoweredApplicationName AND
            u.UserId = m.UserId

    IF ( @UserId IS NULL )
    BEGIN
        SET @ErrorCode = 1
        GOTO Cleanup
    END

    SELECT @IsLockedOut = IsLockedOut,
           @LastLockoutDate = LastLockoutDate,
           @FailedPasswordAttemptCount = FailedPasswordAttemptCount,
           @FailedPasswordAttemptWindowStart = FailedPasswordAttemptWindowStart,
           @FailedPasswordAnswerAttemptCount = FailedPasswordAnswerAttemptCount,
           @FailedPasswordAnswerAttemptWindowStart = FailedPasswordAnswerAttemptWindowStart
    FROM dbo.aspnet_Membership WITH ( UPDLOCK )
    WHERE @UserId = UserId

    IF( @IsLockedOut = 1 )
    BEGIN
        SET @ErrorCode = 99
        GOTO Cleanup
    END

    UPDATE dbo.aspnet_Membership
    SET    Password = @NewPassword,
           LastPasswordChangedDate = @CurrentTimeUtc,
           PasswordFormat = @PasswordFormat,
           PasswordSalt = @PasswordSalt
    WHERE  @UserId = UserId AND
           ( ( @PasswordAnswer IS NULL ) OR ( LOWER( PasswordAnswer ) = LOWER( @PasswordAnswer ) ) )

    IF ( @@ROWCOUNT = 0 )
        BEGIN
            IF( @CurrentTimeUtc > DATEADD( minute, @PasswordAttemptWindow, @FailedPasswordAnswerAttemptWindowStart ) )
            BEGIN
                SET @FailedPasswordAnswerAttemptWindowStart = @CurrentTimeUtc
                SET @FailedPasswordAnswerAttemptCount = 1
            END
            ELSE
            BEGIN
                SET @FailedPasswordAnswerAttemptWindowStart = @CurrentTimeUtc
                SET @FailedPasswordAnswerAttemptCount = @FailedPasswordAnswerAttemptCount + 1
            END

            BEGIN
                IF( @FailedPasswordAnswerAttemptCount >= @MaxInvalidPasswordAttempts )
                BEGIN
                    SET @IsLockedOut = 1
                    SET @LastLockoutDate = @CurrentTimeUtc
                END
            END

            SET @ErrorCode = 3
        END
    ELSE
        BEGIN
            IF( @FailedPasswordAnswerAttemptCount > 0 )
            BEGIN
                SET @FailedPasswordAnswerAttemptCount = 0
                SET @FailedPasswordAnswerAttemptWindowStart = CONVERT( datetime, '17540101', 112 )
            END
        END

    IF( NOT ( @PasswordAnswer IS NULL ) )
    BEGIN
        UPDATE dbo.aspnet_Membership
        SET IsLockedOut = @IsLockedOut, LastLockoutDate = @LastLockoutDate,
            FailedPasswordAttemptCount = @FailedPasswordAttemptCount,
            FailedPasswordAttemptWindowStart = @FailedPasswordAttemptWindowStart,
            FailedPasswordAnswerAttemptCount = @FailedPasswordAnswerAttemptCount,
            FailedPasswordAnswerAttemptWindowStart = @FailedPasswordAnswerAttemptWindowStart
        WHERE @UserId = UserId

        IF( @@ERROR <> 0 )
        BEGIN
            SET @ErrorCode = -1
            GOTO Cleanup
        END
    END

    IF( @TranStarted = 1 )
    BEGIN
	SET @TranStarted = 0
	COMMIT TRANSACTION
    END

    RETURN @ErrorCode

Cleanup:

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
    	ROLLBACK TRANSACTION
    END

    RETURN @ErrorCode

END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetUserByName]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_GetUserByName]
    @ApplicationName      nvarchar(256),
    @UserName             nvarchar(256),
    @CurrentTimeUtc       datetime,
    @UpdateLastActivity   bit = 0
AS
BEGIN
    DECLARE @UserId uniqueidentifier

    IF (@UpdateLastActivity = 1)
    BEGIN
        SELECT TOP 1 m.Email, m.PasswordQuestion, m.Comment, m.IsApproved,
                m.CreateDate, m.LastLoginDate, @CurrentTimeUtc, m.LastPasswordChangedDate,
                u.UserId, m.IsLockedOut,m.LastLockoutDate
        FROM    dbo.aspnet_Applications a, dbo.aspnet_Users u, dbo.aspnet_Membership m
        WHERE    LOWER(@ApplicationName) = a.LoweredApplicationName AND
                u.ApplicationId = a.ApplicationId    AND
                LOWER(@UserName) = u.LoweredUserName AND u.UserId = m.UserId

        IF (@@ROWCOUNT = 0) -- Username not found
            RETURN -1

        UPDATE   dbo.aspnet_Users
        SET      LastActivityDate = @CurrentTimeUtc
        WHERE    @UserId = UserId
    END
    ELSE
    BEGIN
        SELECT TOP 1 m.Email, m.PasswordQuestion, m.Comment, m.IsApproved,
                m.CreateDate, m.LastLoginDate, u.LastActivityDate, m.LastPasswordChangedDate,
                u.UserId, m.IsLockedOut,m.LastLockoutDate
        FROM    dbo.aspnet_Applications a, dbo.aspnet_Users u, dbo.aspnet_Membership m
        WHERE    LOWER(@ApplicationName) = a.LoweredApplicationName AND
                u.ApplicationId = a.ApplicationId    AND
                LOWER(@UserName) = u.LoweredUserName AND u.UserId = m.UserId

        IF (@@ROWCOUNT = 0) -- Username not found
            RETURN -1
    END

    RETURN 0
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetUserByEmail]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_GetUserByEmail]
    @ApplicationName  nvarchar(256),
    @Email            nvarchar(256)
AS
BEGIN
    IF( @Email IS NULL )
        SELECT  u.UserName
        FROM    dbo.aspnet_Applications a, dbo.aspnet_Users u, dbo.aspnet_Membership m
        WHERE   LOWER(@ApplicationName) = a.LoweredApplicationName AND
                u.ApplicationId = a.ApplicationId    AND
                u.UserId = m.UserId AND
                m.LoweredEmail IS NULL
    ELSE
        SELECT  u.UserName
        FROM    dbo.aspnet_Applications a, dbo.aspnet_Users u, dbo.aspnet_Membership m
        WHERE   LOWER(@ApplicationName) = a.LoweredApplicationName AND
                u.ApplicationId = a.ApplicationId    AND
                u.UserId = m.UserId AND
                LOWER(@Email) = m.LoweredEmail

    IF (@@rowcount = 0)
        RETURN(1)
    RETURN(0)
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_UpdateUser]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_UpdateUser]
    @ApplicationName      nvarchar(256),
    @UserName             nvarchar(256),
    @Email                nvarchar(256),
    @Comment              ntext,
    @IsApproved           bit,
    @LastLoginDate        datetime,
    @LastActivityDate     datetime,
    @UniqueEmail          int,
    @CurrentTimeUtc       datetime
AS
BEGIN
    DECLARE @UserId uniqueidentifier
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @UserId = NULL
    SELECT  @UserId = u.UserId, @ApplicationId = a.ApplicationId
    FROM    dbo.aspnet_Users u, dbo.aspnet_Applications a, dbo.aspnet_Membership m
    WHERE   LoweredUserName = LOWER(@UserName) AND
            u.ApplicationId = a.ApplicationId  AND
            LOWER(@ApplicationName) = a.LoweredApplicationName AND
            u.UserId = m.UserId

    IF (@UserId IS NULL)
        RETURN(1)

    IF (@UniqueEmail = 1)
    BEGIN
        IF (EXISTS (SELECT *
                    FROM  dbo.aspnet_Membership WITH (UPDLOCK, HOLDLOCK)
                    WHERE ApplicationId = @ApplicationId  AND @UserId <> UserId AND LoweredEmail = LOWER(@Email)))
        BEGIN
            RETURN(7)
        END
    END

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
	    BEGIN TRANSACTION
	    SET @TranStarted = 1
    END
    ELSE
	SET @TranStarted = 0

    UPDATE dbo.aspnet_Users WITH (ROWLOCK)
    SET
         LastActivityDate = @LastActivityDate
    WHERE
       @UserId = UserId

    IF( @@ERROR <> 0 )
        GOTO Cleanup

    UPDATE dbo.aspnet_Membership WITH (ROWLOCK)
    SET
         Email            = @Email,
         LoweredEmail     = LOWER(@Email),
         Comment          = @Comment,
         IsApproved       = @IsApproved,
         LastLoginDate    = @LastLoginDate
    WHERE
       @UserId = UserId

    IF( @@ERROR <> 0 )
        GOTO Cleanup

    IF( @TranStarted = 1 )
    BEGIN
	SET @TranStarted = 0
	COMMIT TRANSACTION
    END

    RETURN 0

Cleanup:

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
    	ROLLBACK TRANSACTION
    END

    RETURN -1
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_SetPassword]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_SetPassword]
    @ApplicationName  nvarchar(256),
    @UserName         nvarchar(256),
    @NewPassword      nvarchar(128),
    @PasswordSalt     nvarchar(128),
    @CurrentTimeUtc   datetime,
    @PasswordFormat   int = 0
AS
BEGIN
    DECLARE @UserId uniqueidentifier
    SELECT  @UserId = NULL
    SELECT  @UserId = u.UserId
    FROM    dbo.aspnet_Users u, dbo.aspnet_Applications a, dbo.aspnet_Membership m
    WHERE   LoweredUserName = LOWER(@UserName) AND
            u.ApplicationId = a.ApplicationId  AND
            LOWER(@ApplicationName) = a.LoweredApplicationName AND
            u.UserId = m.UserId

    IF (@UserId IS NULL)
        RETURN(1)

    UPDATE dbo.aspnet_Membership
    SET Password = @NewPassword, PasswordFormat = @PasswordFormat, PasswordSalt = @PasswordSalt,
        LastPasswordChangedDate = @CurrentTimeUtc
    WHERE @UserId = UserId
    RETURN(0)
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_UnlockUser]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_UnlockUser]
    @ApplicationName                         nvarchar(256),
    @UserName                                nvarchar(256)
AS
BEGIN
    DECLARE @UserId uniqueidentifier
    SELECT  @UserId = NULL
    SELECT  @UserId = u.UserId
    FROM    dbo.aspnet_Users u, dbo.aspnet_Applications a, dbo.aspnet_Membership m
    WHERE   LoweredUserName = LOWER(@UserName) AND
            u.ApplicationId = a.ApplicationId  AND
            LOWER(@ApplicationName) = a.LoweredApplicationName AND
            u.UserId = m.UserId

    IF ( @UserId IS NULL )
        RETURN 1

    UPDATE dbo.aspnet_Membership
    SET IsLockedOut = 0,
        FailedPasswordAttemptCount = 0,
        FailedPasswordAttemptWindowStart = CONVERT( datetime, '17540101', 112 ),
        FailedPasswordAnswerAttemptCount = 0,
        FailedPasswordAnswerAttemptWindowStart = CONVERT( datetime, '17540101', 112 ),
        LastLockoutDate = CONVERT( datetime, '17540101', 112 )
    WHERE @UserId = UserId

    RETURN 0
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Profile_GetNumberOfInactiveProfiles]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Profile_GetNumberOfInactiveProfiles]
    @ApplicationName        nvarchar(256),
    @ProfileAuthOptions     int,
    @InactiveSinceDate      datetime
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
    BEGIN
        SELECT 0
        RETURN
    END

    SELECT  COUNT(*)
    FROM    dbo.aspnet_Users u, dbo.aspnet_Profile p
    WHERE   ApplicationId = @ApplicationId
        AND u.UserId = p.UserId
        AND (LastActivityDate <= @InactiveSinceDate)
        AND (
                (@ProfileAuthOptions = 2)
                OR (@ProfileAuthOptions = 0 AND IsAnonymous = 1)
                OR (@ProfileAuthOptions = 1 AND IsAnonymous = 0)
            )
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Personalization_GetApplicationId]    Script Date: 10/28/2009 12:28:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Personalization_GetApplicationId] (
    @ApplicationName NVARCHAR(256),
    @ApplicationId UNIQUEIDENTIFIER OUT)
AS
BEGIN
    SELECT @ApplicationId = ApplicationId FROM dbo.aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Profile_DeleteInactiveProfiles]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Profile_DeleteInactiveProfiles]
    @ApplicationName        nvarchar(256),
    @ProfileAuthOptions     int,
    @InactiveSinceDate      datetime
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
    BEGIN
        SELECT  0
        RETURN
    END

    DELETE
    FROM    dbo.aspnet_Profile
    WHERE   UserId IN
            (   SELECT  UserId
                FROM    dbo.aspnet_Users u
                WHERE   ApplicationId = @ApplicationId
                        AND (LastActivityDate <= @InactiveSinceDate)
                        AND (
                                (@ProfileAuthOptions = 2)
                             OR (@ProfileAuthOptions = 0 AND IsAnonymous = 1)
                             OR (@ProfileAuthOptions = 1 AND IsAnonymous = 0)
                            )
            )

    SELECT  @@ROWCOUNT
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_UpdateUserInfo]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_UpdateUserInfo]
    @ApplicationName                nvarchar(256),
    @UserName                       nvarchar(256),
    @IsPasswordCorrect              bit,
    @UpdateLastLoginActivityDate    bit,
    @MaxInvalidPasswordAttempts     int,
    @PasswordAttemptWindow          int,
    @CurrentTimeUtc                 datetime,
    @LastLoginDate                  datetime,
    @LastActivityDate               datetime
AS
BEGIN
    DECLARE @UserId                                 uniqueidentifier
    DECLARE @IsApproved                             bit
    DECLARE @IsLockedOut                            bit
    DECLARE @LastLockoutDate                        datetime
    DECLARE @FailedPasswordAttemptCount             int
    DECLARE @FailedPasswordAttemptWindowStart       datetime
    DECLARE @FailedPasswordAnswerAttemptCount       int
    DECLARE @FailedPasswordAnswerAttemptWindowStart datetime

    DECLARE @ErrorCode     int
    SET @ErrorCode = 0

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
	    BEGIN TRANSACTION
	    SET @TranStarted = 1
    END
    ELSE
    	SET @TranStarted = 0

    SELECT  @UserId = u.UserId,
            @IsApproved = m.IsApproved,
            @IsLockedOut = m.IsLockedOut,
            @LastLockoutDate = m.LastLockoutDate,
            @FailedPasswordAttemptCount = m.FailedPasswordAttemptCount,
            @FailedPasswordAttemptWindowStart = m.FailedPasswordAttemptWindowStart,
            @FailedPasswordAnswerAttemptCount = m.FailedPasswordAnswerAttemptCount,
            @FailedPasswordAnswerAttemptWindowStart = m.FailedPasswordAnswerAttemptWindowStart
    FROM    dbo.aspnet_Applications a, dbo.aspnet_Users u, dbo.aspnet_Membership m WITH ( UPDLOCK )
    WHERE   LOWER(@ApplicationName) = a.LoweredApplicationName AND
            u.ApplicationId = a.ApplicationId    AND
            u.UserId = m.UserId AND
            LOWER(@UserName) = u.LoweredUserName

    IF ( @@rowcount = 0 )
    BEGIN
        SET @ErrorCode = 1
        GOTO Cleanup
    END

    IF( @IsLockedOut = 1 )
    BEGIN
        GOTO Cleanup
    END

    IF( @IsPasswordCorrect = 0 )
    BEGIN
        IF( @CurrentTimeUtc > DATEADD( minute, @PasswordAttemptWindow, @FailedPasswordAttemptWindowStart ) )
        BEGIN
            SET @FailedPasswordAttemptWindowStart = @CurrentTimeUtc
            SET @FailedPasswordAttemptCount = 1
        END
        ELSE
        BEGIN
            SET @FailedPasswordAttemptWindowStart = @CurrentTimeUtc
            SET @FailedPasswordAttemptCount = @FailedPasswordAttemptCount + 1
        END

        BEGIN
            IF( @FailedPasswordAttemptCount >= @MaxInvalidPasswordAttempts )
            BEGIN
                SET @IsLockedOut = 1
                SET @LastLockoutDate = @CurrentTimeUtc
            END
        END
    END
    ELSE
    BEGIN
        IF( @FailedPasswordAttemptCount > 0 OR @FailedPasswordAnswerAttemptCount > 0 )
        BEGIN
            SET @FailedPasswordAttemptCount = 0
            SET @FailedPasswordAttemptWindowStart = CONVERT( datetime, '17540101', 112 )
            SET @FailedPasswordAnswerAttemptCount = 0
            SET @FailedPasswordAnswerAttemptWindowStart = CONVERT( datetime, '17540101', 112 )
            SET @LastLockoutDate = CONVERT( datetime, '17540101', 112 )
        END
    END

    IF( @UpdateLastLoginActivityDate = 1 )
    BEGIN
        UPDATE  dbo.aspnet_Users
        SET     LastActivityDate = @LastActivityDate
        WHERE   @UserId = UserId

        IF( @@ERROR <> 0 )
        BEGIN
            SET @ErrorCode = -1
            GOTO Cleanup
        END

        UPDATE  dbo.aspnet_Membership
        SET     LastLoginDate = @LastLoginDate
        WHERE   UserId = @UserId

        IF( @@ERROR <> 0 )
        BEGIN
            SET @ErrorCode = -1
            GOTO Cleanup
        END
    END


    UPDATE dbo.aspnet_Membership
    SET IsLockedOut = @IsLockedOut, LastLockoutDate = @LastLockoutDate,
        FailedPasswordAttemptCount = @FailedPasswordAttemptCount,
        FailedPasswordAttemptWindowStart = @FailedPasswordAttemptWindowStart,
        FailedPasswordAnswerAttemptCount = @FailedPasswordAnswerAttemptCount,
        FailedPasswordAnswerAttemptWindowStart = @FailedPasswordAnswerAttemptWindowStart
    WHERE @UserId = UserId

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    IF( @TranStarted = 1 )
    BEGIN
	SET @TranStarted = 0
	COMMIT TRANSACTION
    END

    RETURN @ErrorCode

Cleanup:

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
    	ROLLBACK TRANSACTION
    END

    RETURN @ErrorCode

END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_AnyDataInTables]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_AnyDataInTables]
    @TablesToCheck int
AS
BEGIN
    -- Check Membership table if (@TablesToCheck & 1) is set
    IF ((@TablesToCheck & 1) <> 0 AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_MembershipUsers') AND (type = 'V'))))
    BEGIN
        IF (EXISTS(SELECT TOP 1 UserId FROM dbo.aspnet_Membership))
        BEGIN
            SELECT N'aspnet_Membership'
            RETURN
        END
    END

    -- Check aspnet_Roles table if (@TablesToCheck & 2) is set
    IF ((@TablesToCheck & 2) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_Roles') AND (type = 'V'))) )
    BEGIN
        IF (EXISTS(SELECT TOP 1 RoleId FROM dbo.aspnet_Roles))
        BEGIN
            SELECT N'aspnet_Roles'
            RETURN
        END
    END

    -- Check aspnet_Profile table if (@TablesToCheck & 4) is set
    IF ((@TablesToCheck & 4) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_Profiles') AND (type = 'V'))) )
    BEGIN
        IF (EXISTS(SELECT TOP 1 UserId FROM dbo.aspnet_Profile))
        BEGIN
            SELECT N'aspnet_Profile'
            RETURN
        END
    END

    -- Check aspnet_PersonalizationPerUser table if (@TablesToCheck & 8) is set
    IF ((@TablesToCheck & 8) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_WebPartState_User') AND (type = 'V'))) )
    BEGIN
        IF (EXISTS(SELECT TOP 1 UserId FROM dbo.aspnet_PersonalizationPerUser))
        BEGIN
            SELECT N'aspnet_PersonalizationPerUser'
            RETURN
        END
    END

    -- Check aspnet_PersonalizationPerUser table if (@TablesToCheck & 16) is set
    IF ((@TablesToCheck & 16) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'aspnet_WebEvent_LogEvent') AND (type = 'P'))) )
    BEGIN
        IF (EXISTS(SELECT TOP 1 * FROM dbo.aspnet_WebEvent_Events))
        BEGIN
            SELECT N'aspnet_WebEvent_Events'
            RETURN
        END
    END

    -- Check aspnet_Users table if (@TablesToCheck & 1,2,4 & 8) are all set
    IF ((@TablesToCheck & 1) <> 0 AND
        (@TablesToCheck & 2) <> 0 AND
        (@TablesToCheck & 4) <> 0 AND
        (@TablesToCheck & 8) <> 0 AND
        (@TablesToCheck & 32) <> 0 AND
        (@TablesToCheck & 128) <> 0 AND
        (@TablesToCheck & 256) <> 0 AND
        (@TablesToCheck & 512) <> 0 AND
        (@TablesToCheck & 1024) <> 0)
    BEGIN
        IF (EXISTS(SELECT TOP 1 UserId FROM dbo.aspnet_Users))
        BEGIN
            SELECT N'aspnet_Users'
            RETURN
        END
        IF (EXISTS(SELECT TOP 1 ApplicationId FROM dbo.aspnet_Applications))
        BEGIN
            SELECT N'aspnet_Applications'
            RETURN
        END
    END
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetAllUsers]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_GetAllUsers]
    @ApplicationName       nvarchar(256),
    @PageIndex             int,
    @PageSize              int
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM dbo.aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN 0


    -- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    DECLARE @TotalRecords   int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize - 1 + @PageLowerBound

    -- Create a temp table TO store the select results
    CREATE TABLE #PageIndexForUsers
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        UserId uniqueidentifier
    )

    -- Insert into our temp table
    INSERT INTO #PageIndexForUsers (UserId)
    SELECT u.UserId
    FROM   dbo.aspnet_Membership m, dbo.aspnet_Users u
    WHERE  u.ApplicationId = @ApplicationId AND u.UserId = m.UserId
    ORDER BY u.UserName

    SELECT @TotalRecords = @@ROWCOUNT

    SELECT u.UserName, m.Email, m.PasswordQuestion, m.Comment, m.IsApproved,
            m.CreateDate,
            m.LastLoginDate,
            u.LastActivityDate,
            m.LastPasswordChangedDate,
            u.UserId, m.IsLockedOut,
            m.LastLockoutDate
    FROM   dbo.aspnet_Membership m, dbo.aspnet_Users u, #PageIndexForUsers p
    WHERE  u.UserId = p.UserId AND u.UserId = m.UserId AND
           p.IndexId >= @PageLowerBound AND p.IndexId <= @PageUpperBound
    ORDER BY u.UserName
    RETURN @TotalRecords
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_FindUsersByName]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_FindUsersByName]
    @ApplicationName       nvarchar(256),
    @UserNameToMatch       nvarchar(256),
    @PageIndex             int,
    @PageSize              int
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM dbo.aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN 0

    -- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    DECLARE @TotalRecords   int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize - 1 + @PageLowerBound

    -- Create a temp table TO store the select results
    CREATE TABLE #PageIndexForUsers
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        UserId uniqueidentifier
    )

    -- Insert into our temp table
    INSERT INTO #PageIndexForUsers (UserId)
        SELECT u.UserId
        FROM   dbo.aspnet_Users u, dbo.aspnet_Membership m
        WHERE  u.ApplicationId = @ApplicationId AND m.UserId = u.UserId AND u.LoweredUserName LIKE LOWER(@UserNameToMatch)
        ORDER BY u.UserName


    SELECT  u.UserName, m.Email, m.PasswordQuestion, m.Comment, m.IsApproved,
            m.CreateDate,
            m.LastLoginDate,
            u.LastActivityDate,
            m.LastPasswordChangedDate,
            u.UserId, m.IsLockedOut,
            m.LastLockoutDate
    FROM   dbo.aspnet_Membership m, dbo.aspnet_Users u, #PageIndexForUsers p
    WHERE  u.UserId = p.UserId AND u.UserId = m.UserId AND
           p.IndexId >= @PageLowerBound AND p.IndexId <= @PageUpperBound
    ORDER BY u.UserName

    SELECT  @TotalRecords = COUNT(*)
    FROM    #PageIndexForUsers
    RETURN @TotalRecords
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_FindUsersByEmail]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_FindUsersByEmail]
    @ApplicationName       nvarchar(256),
    @EmailToMatch          nvarchar(256),
    @PageIndex             int,
    @PageSize              int
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM dbo.aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN 0

    -- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    DECLARE @TotalRecords   int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize - 1 + @PageLowerBound

    -- Create a temp table TO store the select results
    CREATE TABLE #PageIndexForUsers
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        UserId uniqueidentifier
    )

    -- Insert into our temp table
    IF( @EmailToMatch IS NULL )
        INSERT INTO #PageIndexForUsers (UserId)
            SELECT u.UserId
            FROM   dbo.aspnet_Users u, dbo.aspnet_Membership m
            WHERE  u.ApplicationId = @ApplicationId AND m.UserId = u.UserId AND m.Email IS NULL
            ORDER BY m.LoweredEmail
    ELSE
        INSERT INTO #PageIndexForUsers (UserId)
            SELECT u.UserId
            FROM   dbo.aspnet_Users u, dbo.aspnet_Membership m
            WHERE  u.ApplicationId = @ApplicationId AND m.UserId = u.UserId AND m.LoweredEmail LIKE LOWER(@EmailToMatch)
            ORDER BY m.LoweredEmail

    SELECT  u.UserName, m.Email, m.PasswordQuestion, m.Comment, m.IsApproved,
            m.CreateDate,
            m.LastLoginDate,
            u.LastActivityDate,
            m.LastPasswordChangedDate,
            u.UserId, m.IsLockedOut,
            m.LastLockoutDate
    FROM   dbo.aspnet_Membership m, dbo.aspnet_Users u, #PageIndexForUsers p
    WHERE  u.UserId = p.UserId AND u.UserId = m.UserId AND
           p.IndexId >= @PageLowerBound AND p.IndexId <= @PageUpperBound
    ORDER BY m.LoweredEmail

    SELECT  @TotalRecords = COUNT(*)
    FROM    #PageIndexForUsers
    RETURN @TotalRecords
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetNumberOfUsersOnline]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_GetNumberOfUsersOnline]
    @ApplicationName            nvarchar(256),
    @MinutesSinceLastInActive   int,
    @CurrentTimeUtc             datetime
AS
BEGIN
    DECLARE @DateActive datetime
    SELECT  @DateActive = DATEADD(minute,  -(@MinutesSinceLastInActive), @CurrentTimeUtc)

    DECLARE @NumOnline int
    SELECT  @NumOnline = COUNT(*)
    FROM    dbo.aspnet_Users u(NOLOCK),
            dbo.aspnet_Applications a(NOLOCK),
            dbo.aspnet_Membership m(NOLOCK)
    WHERE   u.ApplicationId = a.ApplicationId                  AND
            LastActivityDate > @DateActive                     AND
            a.LoweredApplicationName = LOWER(@ApplicationName) AND
            u.UserId = m.UserId
    RETURN(@NumOnline)
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetPassword]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_GetPassword]
    @ApplicationName                nvarchar(256),
    @UserName                       nvarchar(256),
    @MaxInvalidPasswordAttempts     int,
    @PasswordAttemptWindow          int,
    @CurrentTimeUtc                 datetime,
    @PasswordAnswer                 nvarchar(128) = NULL
AS
BEGIN
    DECLARE @UserId                                 uniqueidentifier
    DECLARE @PasswordFormat                         int
    DECLARE @Password                               nvarchar(128)
    DECLARE @passAns                                nvarchar(128)
    DECLARE @IsLockedOut                            bit
    DECLARE @LastLockoutDate                        datetime
    DECLARE @FailedPasswordAttemptCount             int
    DECLARE @FailedPasswordAttemptWindowStart       datetime
    DECLARE @FailedPasswordAnswerAttemptCount       int
    DECLARE @FailedPasswordAnswerAttemptWindowStart datetime

    DECLARE @ErrorCode     int
    SET @ErrorCode = 0

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
	    BEGIN TRANSACTION
	    SET @TranStarted = 1
    END
    ELSE
    	SET @TranStarted = 0

    SELECT  @UserId = u.UserId,
            @Password = m.Password,
            @passAns = m.PasswordAnswer,
            @PasswordFormat = m.PasswordFormat,
            @IsLockedOut = m.IsLockedOut,
            @LastLockoutDate = m.LastLockoutDate,
            @FailedPasswordAttemptCount = m.FailedPasswordAttemptCount,
            @FailedPasswordAttemptWindowStart = m.FailedPasswordAttemptWindowStart,
            @FailedPasswordAnswerAttemptCount = m.FailedPasswordAnswerAttemptCount,
            @FailedPasswordAnswerAttemptWindowStart = m.FailedPasswordAnswerAttemptWindowStart
    FROM    dbo.aspnet_Applications a, dbo.aspnet_Users u, dbo.aspnet_Membership m WITH ( UPDLOCK )
    WHERE   LOWER(@ApplicationName) = a.LoweredApplicationName AND
            u.ApplicationId = a.ApplicationId    AND
            u.UserId = m.UserId AND
            LOWER(@UserName) = u.LoweredUserName

    IF ( @@rowcount = 0 )
    BEGIN
        SET @ErrorCode = 1
        GOTO Cleanup
    END

    IF( @IsLockedOut = 1 )
    BEGIN
        SET @ErrorCode = 99
        GOTO Cleanup
    END

    IF ( NOT( @PasswordAnswer IS NULL ) )
    BEGIN
        IF( ( @passAns IS NULL ) OR ( LOWER( @passAns ) <> LOWER( @PasswordAnswer ) ) )
        BEGIN
            IF( @CurrentTimeUtc > DATEADD( minute, @PasswordAttemptWindow, @FailedPasswordAnswerAttemptWindowStart ) )
            BEGIN
                SET @FailedPasswordAnswerAttemptWindowStart = @CurrentTimeUtc
                SET @FailedPasswordAnswerAttemptCount = 1
            END
            ELSE
            BEGIN
                SET @FailedPasswordAnswerAttemptCount = @FailedPasswordAnswerAttemptCount + 1
                SET @FailedPasswordAnswerAttemptWindowStart = @CurrentTimeUtc
            END

            BEGIN
                IF( @FailedPasswordAnswerAttemptCount >= @MaxInvalidPasswordAttempts )
                BEGIN
                    SET @IsLockedOut = 1
                    SET @LastLockoutDate = @CurrentTimeUtc
                END
            END

            SET @ErrorCode = 3
        END
        ELSE
        BEGIN
            IF( @FailedPasswordAnswerAttemptCount > 0 )
            BEGIN
                SET @FailedPasswordAnswerAttemptCount = 0
                SET @FailedPasswordAnswerAttemptWindowStart = CONVERT( datetime, '17540101', 112 )
            END
        END

        UPDATE dbo.aspnet_Membership
        SET IsLockedOut = @IsLockedOut, LastLockoutDate = @LastLockoutDate,
            FailedPasswordAttemptCount = @FailedPasswordAttemptCount,
            FailedPasswordAttemptWindowStart = @FailedPasswordAttemptWindowStart,
            FailedPasswordAnswerAttemptCount = @FailedPasswordAnswerAttemptCount,
            FailedPasswordAnswerAttemptWindowStart = @FailedPasswordAnswerAttemptWindowStart
        WHERE @UserId = UserId

        IF( @@ERROR <> 0 )
        BEGIN
            SET @ErrorCode = -1
            GOTO Cleanup
        END
    END

    IF( @TranStarted = 1 )
    BEGIN
	SET @TranStarted = 0
	COMMIT TRANSACTION
    END

    IF( @ErrorCode = 0 )
        SELECT @Password, @PasswordFormat

    RETURN @ErrorCode

Cleanup:

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
    	ROLLBACK TRANSACTION
    END

    RETURN @ErrorCode

END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetPasswordWithFormat]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_GetPasswordWithFormat]
    @ApplicationName                nvarchar(256),
    @UserName                       nvarchar(256),
    @UpdateLastLoginActivityDate    bit,
    @CurrentTimeUtc                 datetime
AS
BEGIN
    DECLARE @IsLockedOut                        bit
    DECLARE @UserId                             uniqueidentifier
    DECLARE @Password                           nvarchar(128)
    DECLARE @PasswordSalt                       nvarchar(128)
    DECLARE @PasswordFormat                     int
    DECLARE @FailedPasswordAttemptCount         int
    DECLARE @FailedPasswordAnswerAttemptCount   int
    DECLARE @IsApproved                         bit
    DECLARE @LastActivityDate                   datetime
    DECLARE @LastLoginDate                      datetime

    SELECT  @UserId          = NULL

    SELECT  @UserId = u.UserId, @IsLockedOut = m.IsLockedOut, @Password=Password, @PasswordFormat=PasswordFormat,
            @PasswordSalt=PasswordSalt, @FailedPasswordAttemptCount=FailedPasswordAttemptCount,
		    @FailedPasswordAnswerAttemptCount=FailedPasswordAnswerAttemptCount, @IsApproved=IsApproved,
            @LastActivityDate = LastActivityDate, @LastLoginDate = LastLoginDate
    FROM    dbo.aspnet_Applications a, dbo.aspnet_Users u, dbo.aspnet_Membership m
    WHERE   LOWER(@ApplicationName) = a.LoweredApplicationName AND
            u.ApplicationId = a.ApplicationId    AND
            u.UserId = m.UserId AND
            LOWER(@UserName) = u.LoweredUserName

    IF (@UserId IS NULL)
        RETURN 1

    IF (@IsLockedOut = 1)
        RETURN 99

    SELECT   @Password, @PasswordFormat, @PasswordSalt, @FailedPasswordAttemptCount,
             @FailedPasswordAnswerAttemptCount, @IsApproved, @LastLoginDate, @LastActivityDate

    IF (@UpdateLastLoginActivityDate = 1 AND @IsApproved = 1)
    BEGIN
        UPDATE  dbo.aspnet_Membership
        SET     LastLoginDate = @CurrentTimeUtc
        WHERE   UserId = @UserId

        UPDATE  dbo.aspnet_Users
        SET     LastActivityDate = @CurrentTimeUtc
        WHERE   @UserId = UserId
    END


    RETURN 0
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Applications_CreateApplication]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Applications_CreateApplication]
    @ApplicationName      nvarchar(256),
    @ApplicationId        uniqueidentifier OUTPUT
AS
BEGIN
    SELECT  @ApplicationId = ApplicationId FROM dbo.aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName

    IF(@ApplicationId IS NULL)
    BEGIN
        DECLARE @TranStarted   bit
        SET @TranStarted = 0

        IF( @@TRANCOUNT = 0 )
        BEGIN
	        BEGIN TRANSACTION
	        SET @TranStarted = 1
        END
        ELSE
    	    SET @TranStarted = 0

        SELECT  @ApplicationId = ApplicationId
        FROM dbo.aspnet_Applications WITH (UPDLOCK, HOLDLOCK)
        WHERE LOWER(@ApplicationName) = LoweredApplicationName

        IF(@ApplicationId IS NULL)
        BEGIN
            SELECT  @ApplicationId = NEWID()
            INSERT  dbo.aspnet_Applications (ApplicationId, ApplicationName, LoweredApplicationName)
            VALUES  (@ApplicationId, @ApplicationName, LOWER(@ApplicationName))
        END


        IF( @TranStarted = 1 )
        BEGIN
            IF(@@ERROR = 0)
            BEGIN
	        SET @TranStarted = 0
	        COMMIT TRANSACTION
            END
            ELSE
            BEGIN
                SET @TranStarted = 0
                ROLLBACK TRANSACTION
            END
        END
    END
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_ChangePasswordQuestionAndAnswer]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_ChangePasswordQuestionAndAnswer]
    @ApplicationName       nvarchar(256),
    @UserName              nvarchar(256),
    @NewPasswordQuestion   nvarchar(256),
    @NewPasswordAnswer     nvarchar(128)
AS
BEGIN
    DECLARE @UserId uniqueidentifier
    SELECT  @UserId = NULL
    SELECT  @UserId = u.UserId
    FROM    dbo.aspnet_Membership m, dbo.aspnet_Users u, dbo.aspnet_Applications a
    WHERE   LoweredUserName = LOWER(@UserName) AND
            u.ApplicationId = a.ApplicationId  AND
            LOWER(@ApplicationName) = a.LoweredApplicationName AND
            u.UserId = m.UserId
    IF (@UserId IS NULL)
    BEGIN
        RETURN(1)
    END

    UPDATE dbo.aspnet_Membership
    SET    PasswordQuestion = @NewPasswordQuestion, PasswordAnswer = @NewPasswordAnswer
    WHERE  UserId=@UserId
    RETURN(0)
END
GO
/****** Object:  View [dbo].[vw_aspnet_Applications]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_Applications]
  AS SELECT [dbo].[aspnet_Applications].[ApplicationName], [dbo].[aspnet_Applications].[LoweredApplicationName], [dbo].[aspnet_Applications].[ApplicationId], [dbo].[aspnet_Applications].[Description]
  FROM [dbo].[aspnet_Applications]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Users_DeleteUser]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Users_DeleteUser]
    @ApplicationName  nvarchar(256),
    @UserName         nvarchar(256),
    @TablesToDeleteFrom int,
    @NumTablesDeletedFrom int OUTPUT
AS
BEGIN
    DECLARE @UserId               uniqueidentifier
    SELECT  @UserId               = NULL
    SELECT  @NumTablesDeletedFrom = 0

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
	    BEGIN TRANSACTION
	    SET @TranStarted = 1
    END
    ELSE
	SET @TranStarted = 0

    DECLARE @ErrorCode   int
    DECLARE @RowCount    int

    SET @ErrorCode = 0
    SET @RowCount  = 0

    SELECT  @UserId = u.UserId
    FROM    dbo.aspnet_Users u, dbo.aspnet_Applications a
    WHERE   u.LoweredUserName       = LOWER(@UserName)
        AND u.ApplicationId         = a.ApplicationId
        AND LOWER(@ApplicationName) = a.LoweredApplicationName

    IF (@UserId IS NULL)
    BEGIN
        GOTO Cleanup
    END

    -- Delete from Membership table if (@TablesToDeleteFrom & 1) is set
    IF ((@TablesToDeleteFrom & 1) <> 0 AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_MembershipUsers') AND (type = 'V'))))
    BEGIN
        DELETE FROM dbo.aspnet_Membership WHERE @UserId = UserId

        SELECT @ErrorCode = @@ERROR,
               @RowCount = @@ROWCOUNT

        IF( @ErrorCode <> 0 )
            GOTO Cleanup

        IF (@RowCount <> 0)
            SELECT  @NumTablesDeletedFrom = @NumTablesDeletedFrom + 1
    END

    -- Delete from aspnet_UsersInRoles table if (@TablesToDeleteFrom & 2) is set
    IF ((@TablesToDeleteFrom & 2) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_UsersInRoles') AND (type = 'V'))) )
    BEGIN
        DELETE FROM dbo.aspnet_UsersInRoles WHERE @UserId = UserId

        SELECT @ErrorCode = @@ERROR,
                @RowCount = @@ROWCOUNT

        IF( @ErrorCode <> 0 )
            GOTO Cleanup

        IF (@RowCount <> 0)
            SELECT  @NumTablesDeletedFrom = @NumTablesDeletedFrom + 1
    END

    -- Delete from aspnet_Profile table if (@TablesToDeleteFrom & 4) is set
    IF ((@TablesToDeleteFrom & 4) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_Profiles') AND (type = 'V'))) )
    BEGIN
        DELETE FROM dbo.aspnet_Profile WHERE @UserId = UserId

        SELECT @ErrorCode = @@ERROR,
                @RowCount = @@ROWCOUNT

        IF( @ErrorCode <> 0 )
            GOTO Cleanup

        IF (@RowCount <> 0)
            SELECT  @NumTablesDeletedFrom = @NumTablesDeletedFrom + 1
    END

    -- Delete from aspnet_PersonalizationPerUser table if (@TablesToDeleteFrom & 8) is set
    IF ((@TablesToDeleteFrom & 8) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_WebPartState_User') AND (type = 'V'))) )
    BEGIN
        DELETE FROM dbo.aspnet_PersonalizationPerUser WHERE @UserId = UserId

        SELECT @ErrorCode = @@ERROR,
                @RowCount = @@ROWCOUNT

        IF( @ErrorCode <> 0 )
            GOTO Cleanup

        IF (@RowCount <> 0)
            SELECT  @NumTablesDeletedFrom = @NumTablesDeletedFrom + 1
    END

    -- Delete from aspnet_Users table if (@TablesToDeleteFrom & 1,2,4 & 8) are all set
    IF ((@TablesToDeleteFrom & 1) <> 0 AND
        (@TablesToDeleteFrom & 2) <> 0 AND
        (@TablesToDeleteFrom & 4) <> 0 AND
        (@TablesToDeleteFrom & 8) <> 0 AND
        (EXISTS (SELECT UserId FROM dbo.aspnet_Users WHERE @UserId = UserId)))
    BEGIN
        DELETE FROM dbo.aspnet_Users WHERE @UserId = UserId

        SELECT @ErrorCode = @@ERROR,
                @RowCount = @@ROWCOUNT

        IF( @ErrorCode <> 0 )
            GOTO Cleanup

        IF (@RowCount <> 0)
            SELECT  @NumTablesDeletedFrom = @NumTablesDeletedFrom + 1
    END

    IF( @TranStarted = 1 )
    BEGIN
	    SET @TranStarted = 0
	    COMMIT TRANSACTION
    END

    RETURN 0

Cleanup:
    SET @NumTablesDeletedFrom = 0

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
	    ROLLBACK TRANSACTION
    END

    RETURN @ErrorCode

END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Roles_RoleExists]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Roles_RoleExists]
    @ApplicationName  nvarchar(256),
    @RoleName         nvarchar(256)
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN(0)
    IF (EXISTS (SELECT RoleName FROM dbo.aspnet_Roles WHERE LOWER(@RoleName) = LoweredRoleName AND ApplicationId = @ApplicationId ))
        RETURN(1)
    ELSE
        RETURN(0)
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_UsersInRoles_RemoveUsersFromRoles]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_UsersInRoles_RemoveUsersFromRoles]
	@ApplicationName  nvarchar(256),
	@UserNames		  nvarchar(4000),
	@RoleNames		  nvarchar(4000)
AS
BEGIN
	DECLARE @AppId uniqueidentifier
	SELECT  @AppId = NULL
	SELECT  @AppId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
	IF (@AppId IS NULL)
		RETURN(2)


	DECLARE @TranStarted   bit
	SET @TranStarted = 0

	IF( @@TRANCOUNT = 0 )
	BEGIN
		BEGIN TRANSACTION
		SET @TranStarted = 1
	END

	DECLARE @tbNames  table(Name nvarchar(256) NOT NULL PRIMARY KEY)
	DECLARE @tbRoles  table(RoleId uniqueidentifier NOT NULL PRIMARY KEY)
	DECLARE @tbUsers  table(UserId uniqueidentifier NOT NULL PRIMARY KEY)
	DECLARE @Num	  int
	DECLARE @Pos	  int
	DECLARE @NextPos  int
	DECLARE @Name	  nvarchar(256)
	DECLARE @CountAll int
	DECLARE @CountU	  int
	DECLARE @CountR	  int


	SET @Num = 0
	SET @Pos = 1
	WHILE(@Pos <= LEN(@RoleNames))
	BEGIN
		SELECT @NextPos = CHARINDEX(N',', @RoleNames,  @Pos)
		IF (@NextPos = 0 OR @NextPos IS NULL)
			SELECT @NextPos = LEN(@RoleNames) + 1
		SELECT @Name = RTRIM(LTRIM(SUBSTRING(@RoleNames, @Pos, @NextPos - @Pos)))
		SELECT @Pos = @NextPos+1

		INSERT INTO @tbNames VALUES (@Name)
		SET @Num = @Num + 1
	END

	INSERT INTO @tbRoles
	  SELECT RoleId
	  FROM   dbo.aspnet_Roles ar, @tbNames t
	  WHERE  LOWER(t.Name) = ar.LoweredRoleName AND ar.ApplicationId = @AppId
	SELECT @CountR = @@ROWCOUNT

	IF (@CountR <> @Num)
	BEGIN
		SELECT TOP 1 N'', Name
		FROM   @tbNames
		WHERE  LOWER(Name) NOT IN (SELECT ar.LoweredRoleName FROM dbo.aspnet_Roles ar,  @tbRoles r WHERE r.RoleId = ar.RoleId)
		IF( @TranStarted = 1 )
			ROLLBACK TRANSACTION
		RETURN(2)
	END


	DELETE FROM @tbNames WHERE 1=1
	SET @Num = 0
	SET @Pos = 1


	WHILE(@Pos <= LEN(@UserNames))
	BEGIN
		SELECT @NextPos = CHARINDEX(N',', @UserNames,  @Pos)
		IF (@NextPos = 0 OR @NextPos IS NULL)
			SELECT @NextPos = LEN(@UserNames) + 1
		SELECT @Name = RTRIM(LTRIM(SUBSTRING(@UserNames, @Pos, @NextPos - @Pos)))
		SELECT @Pos = @NextPos+1

		INSERT INTO @tbNames VALUES (@Name)
		SET @Num = @Num + 1
	END

	INSERT INTO @tbUsers
	  SELECT UserId
	  FROM   dbo.aspnet_Users ar, @tbNames t
	  WHERE  LOWER(t.Name) = ar.LoweredUserName AND ar.ApplicationId = @AppId

	SELECT @CountU = @@ROWCOUNT
	IF (@CountU <> @Num)
	BEGIN
		SELECT TOP 1 Name, N''
		FROM   @tbNames
		WHERE  LOWER(Name) NOT IN (SELECT au.LoweredUserName FROM dbo.aspnet_Users au,  @tbUsers u WHERE u.UserId = au.UserId)

		IF( @TranStarted = 1 )
			ROLLBACK TRANSACTION
		RETURN(1)
	END

	SELECT  @CountAll = COUNT(*)
	FROM	dbo.aspnet_UsersInRoles ur, @tbUsers u, @tbRoles r
	WHERE   ur.UserId = u.UserId AND ur.RoleId = r.RoleId

	IF (@CountAll <> @CountU * @CountR)
	BEGIN
		SELECT TOP 1 UserName, RoleName
		FROM		 @tbUsers tu, @tbRoles tr, dbo.aspnet_Users u, dbo.aspnet_Roles r
		WHERE		 u.UserId = tu.UserId AND r.RoleId = tr.RoleId AND
					 tu.UserId NOT IN (SELECT ur.UserId FROM dbo.aspnet_UsersInRoles ur WHERE ur.RoleId = tr.RoleId) AND
					 tr.RoleId NOT IN (SELECT ur.RoleId FROM dbo.aspnet_UsersInRoles ur WHERE ur.UserId = tu.UserId)
		IF( @TranStarted = 1 )
			ROLLBACK TRANSACTION
		RETURN(3)
	END

	DELETE FROM dbo.aspnet_UsersInRoles
	WHERE UserId IN (SELECT UserId FROM @tbUsers)
	  AND RoleId IN (SELECT RoleId FROM @tbRoles)
	IF( @TranStarted = 1 )
		COMMIT TRANSACTION
	RETURN(0)
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_UsersInRoles_IsUserInRole]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_UsersInRoles_IsUserInRole]
    @ApplicationName  nvarchar(256),
    @UserName         nvarchar(256),
    @RoleName         nvarchar(256)
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN(2)
    DECLARE @UserId uniqueidentifier
    SELECT  @UserId = NULL
    DECLARE @RoleId uniqueidentifier
    SELECT  @RoleId = NULL

    SELECT  @UserId = UserId
    FROM    dbo.aspnet_Users
    WHERE   LoweredUserName = LOWER(@UserName) AND ApplicationId = @ApplicationId

    IF (@UserId IS NULL)
        RETURN(2)

    SELECT  @RoleId = RoleId
    FROM    dbo.aspnet_Roles
    WHERE   LoweredRoleName = LOWER(@RoleName) AND ApplicationId = @ApplicationId

    IF (@RoleId IS NULL)
        RETURN(3)

    IF (EXISTS( SELECT * FROM dbo.aspnet_UsersInRoles WHERE  UserId = @UserId AND RoleId = @RoleId))
        RETURN(1)
    ELSE
        RETURN(0)
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_UsersInRoles_GetUsersInRoles]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_UsersInRoles_GetUsersInRoles]
    @ApplicationName  nvarchar(256),
    @RoleName         nvarchar(256)
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN(1)
     DECLARE @RoleId uniqueidentifier
     SELECT  @RoleId = NULL

     SELECT  @RoleId = RoleId
     FROM    dbo.aspnet_Roles
     WHERE   LOWER(@RoleName) = LoweredRoleName AND ApplicationId = @ApplicationId

     IF (@RoleId IS NULL)
         RETURN(1)

    SELECT u.UserName
    FROM   dbo.aspnet_Users u, dbo.aspnet_UsersInRoles ur
    WHERE  u.UserId = ur.UserId AND @RoleId = ur.RoleId AND u.ApplicationId = @ApplicationId
    ORDER BY u.UserName
    RETURN(0)
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_UsersInRoles_GetRolesForUser]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_UsersInRoles_GetRolesForUser]
    @ApplicationName  nvarchar(256),
    @UserName         nvarchar(256)
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN(1)
    DECLARE @UserId uniqueidentifier
    SELECT  @UserId = NULL

    SELECT  @UserId = UserId
    FROM    dbo.aspnet_Users
    WHERE   LoweredUserName = LOWER(@UserName) AND ApplicationId = @ApplicationId

    IF (@UserId IS NULL)
        RETURN(1)

    SELECT r.RoleName
    FROM   dbo.aspnet_Roles r, dbo.aspnet_UsersInRoles ur
    WHERE  r.RoleId = ur.RoleId AND r.ApplicationId = @ApplicationId AND ur.UserId = @UserId
    ORDER BY r.RoleName
    RETURN (0)
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_UsersInRoles_FindUsersInRole]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_UsersInRoles_FindUsersInRole]
    @ApplicationName  nvarchar(256),
    @RoleName         nvarchar(256),
    @UserNameToMatch  nvarchar(256)
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN(1)
     DECLARE @RoleId uniqueidentifier
     SELECT  @RoleId = NULL

     SELECT  @RoleId = RoleId
     FROM    dbo.aspnet_Roles
     WHERE   LOWER(@RoleName) = LoweredRoleName AND ApplicationId = @ApplicationId

     IF (@RoleId IS NULL)
         RETURN(1)

    SELECT u.UserName
    FROM   dbo.aspnet_Users u, dbo.aspnet_UsersInRoles ur
    WHERE  u.UserId = ur.UserId AND @RoleId = ur.RoleId AND u.ApplicationId = @ApplicationId AND LoweredUserName LIKE LOWER(@UserNameToMatch)
    ORDER BY u.UserName
    RETURN(0)
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_UsersInRoles_AddUsersToRoles]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_UsersInRoles_AddUsersToRoles]
	@ApplicationName  nvarchar(256),
	@UserNames		  nvarchar(4000),
	@RoleNames		  nvarchar(4000),
	@CurrentTimeUtc   datetime
AS
BEGIN
	DECLARE @AppId uniqueidentifier
	SELECT  @AppId = NULL
	SELECT  @AppId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
	IF (@AppId IS NULL)
		RETURN(2)
	DECLARE @TranStarted   bit
	SET @TranStarted = 0

	IF( @@TRANCOUNT = 0 )
	BEGIN
		BEGIN TRANSACTION
		SET @TranStarted = 1
	END

	DECLARE @tbNames	table(Name nvarchar(256) NOT NULL PRIMARY KEY)
	DECLARE @tbRoles	table(RoleId uniqueidentifier NOT NULL PRIMARY KEY)
	DECLARE @tbUsers	table(UserId uniqueidentifier NOT NULL PRIMARY KEY)
	DECLARE @Num		int
	DECLARE @Pos		int
	DECLARE @NextPos	int
	DECLARE @Name		nvarchar(256)

	SET @Num = 0
	SET @Pos = 1
	WHILE(@Pos <= LEN(@RoleNames))
	BEGIN
		SELECT @NextPos = CHARINDEX(N',', @RoleNames,  @Pos)
		IF (@NextPos = 0 OR @NextPos IS NULL)
			SELECT @NextPos = LEN(@RoleNames) + 1
		SELECT @Name = RTRIM(LTRIM(SUBSTRING(@RoleNames, @Pos, @NextPos - @Pos)))
		SELECT @Pos = @NextPos+1

		INSERT INTO @tbNames VALUES (@Name)
		SET @Num = @Num + 1
	END

	INSERT INTO @tbRoles
	  SELECT RoleId
	  FROM   dbo.aspnet_Roles ar, @tbNames t
	  WHERE  LOWER(t.Name) = ar.LoweredRoleName AND ar.ApplicationId = @AppId

	IF (@@ROWCOUNT <> @Num)
	BEGIN
		SELECT TOP 1 Name
		FROM   @tbNames
		WHERE  LOWER(Name) NOT IN (SELECT ar.LoweredRoleName FROM dbo.aspnet_Roles ar,  @tbRoles r WHERE r.RoleId = ar.RoleId)
		IF( @TranStarted = 1 )
			ROLLBACK TRANSACTION
		RETURN(2)
	END

	DELETE FROM @tbNames WHERE 1=1
	SET @Num = 0
	SET @Pos = 1

	WHILE(@Pos <= LEN(@UserNames))
	BEGIN
		SELECT @NextPos = CHARINDEX(N',', @UserNames,  @Pos)
		IF (@NextPos = 0 OR @NextPos IS NULL)
			SELECT @NextPos = LEN(@UserNames) + 1
		SELECT @Name = RTRIM(LTRIM(SUBSTRING(@UserNames, @Pos, @NextPos - @Pos)))
		SELECT @Pos = @NextPos+1

		INSERT INTO @tbNames VALUES (@Name)
		SET @Num = @Num + 1
	END

	INSERT INTO @tbUsers
	  SELECT UserId
	  FROM   dbo.aspnet_Users ar, @tbNames t
	  WHERE  LOWER(t.Name) = ar.LoweredUserName AND ar.ApplicationId = @AppId

	IF (@@ROWCOUNT <> @Num)
	BEGIN
		DELETE FROM @tbNames
		WHERE LOWER(Name) IN (SELECT LoweredUserName FROM dbo.aspnet_Users au,  @tbUsers u WHERE au.UserId = u.UserId)

		INSERT dbo.aspnet_Users (ApplicationId, UserId, UserName, LoweredUserName, IsAnonymous, LastActivityDate)
		  SELECT @AppId, NEWID(), Name, LOWER(Name), 0, @CurrentTimeUtc
		  FROM   @tbNames

		INSERT INTO @tbUsers
		  SELECT  UserId
		  FROM	dbo.aspnet_Users au, @tbNames t
		  WHERE   LOWER(t.Name) = au.LoweredUserName AND au.ApplicationId = @AppId
	END

	IF (EXISTS (SELECT * FROM dbo.aspnet_UsersInRoles ur, @tbUsers tu, @tbRoles tr WHERE tu.UserId = ur.UserId AND tr.RoleId = ur.RoleId))
	BEGIN
		SELECT TOP 1 UserName, RoleName
		FROM		 dbo.aspnet_UsersInRoles ur, @tbUsers tu, @tbRoles tr, aspnet_Users u, aspnet_Roles r
		WHERE		u.UserId = tu.UserId AND r.RoleId = tr.RoleId AND tu.UserId = ur.UserId AND tr.RoleId = ur.RoleId

		IF( @TranStarted = 1 )
			ROLLBACK TRANSACTION
		RETURN(3)
	END

	INSERT INTO dbo.aspnet_UsersInRoles (UserId, RoleId)
	SELECT UserId, RoleId
	FROM @tbUsers, @tbRoles

	IF( @TranStarted = 1 )
		COMMIT TRANSACTION
	RETURN(0)
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Roles_GetAllRoles]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Roles_GetAllRoles] (
    @ApplicationName           nvarchar(256))
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN
    SELECT RoleName
    FROM   dbo.aspnet_Roles WHERE ApplicationId = @ApplicationId
    ORDER BY RoleName
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Roles_DeleteRole]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Roles_DeleteRole]
    @ApplicationName            nvarchar(256),
    @RoleName                   nvarchar(256),
    @DeleteOnlyIfRoleIsEmpty    bit
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN(1)

    DECLARE @ErrorCode     int
    SET @ErrorCode = 0

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
        BEGIN TRANSACTION
        SET @TranStarted = 1
    END
    ELSE
        SET @TranStarted = 0

    DECLARE @RoleId   uniqueidentifier
    SELECT  @RoleId = NULL
    SELECT  @RoleId = RoleId FROM dbo.aspnet_Roles WHERE LoweredRoleName = LOWER(@RoleName) AND ApplicationId = @ApplicationId

    IF (@RoleId IS NULL)
    BEGIN
        SELECT @ErrorCode = 1
        GOTO Cleanup
    END
    IF (@DeleteOnlyIfRoleIsEmpty <> 0)
    BEGIN
        IF (EXISTS (SELECT RoleId FROM dbo.aspnet_UsersInRoles  WHERE @RoleId = RoleId))
        BEGIN
            SELECT @ErrorCode = 2
            GOTO Cleanup
        END
    END


    DELETE FROM dbo.aspnet_UsersInRoles  WHERE @RoleId = RoleId

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    DELETE FROM dbo.aspnet_Roles WHERE @RoleId = RoleId  AND ApplicationId = @ApplicationId

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
        COMMIT TRANSACTION
    END

    RETURN(0)

Cleanup:

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
        ROLLBACK TRANSACTION
    END

    RETURN @ErrorCode
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Profile_GetProfiles]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Profile_GetProfiles]
    @ApplicationName        nvarchar(256),
    @ProfileAuthOptions     int,
    @PageIndex              int,
    @PageSize               int,
    @UserNameToMatch        nvarchar(256) = NULL,
    @InactiveSinceDate      datetime      = NULL
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN

    -- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    DECLARE @TotalRecords   int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize - 1 + @PageLowerBound

    -- Create a temp table TO store the select results
    CREATE TABLE #PageIndexForUsers
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        UserId uniqueidentifier
    )

    -- Insert into our temp table
    INSERT INTO #PageIndexForUsers (UserId)
        SELECT  u.UserId
        FROM    dbo.aspnet_Users u, dbo.aspnet_Profile p
        WHERE   ApplicationId = @ApplicationId
            AND u.UserId = p.UserId
            AND (@InactiveSinceDate IS NULL OR LastActivityDate <= @InactiveSinceDate)
            AND (     (@ProfileAuthOptions = 2)
                   OR (@ProfileAuthOptions = 0 AND IsAnonymous = 1)
                   OR (@ProfileAuthOptions = 1 AND IsAnonymous = 0)
                 )
            AND (@UserNameToMatch IS NULL OR LoweredUserName LIKE LOWER(@UserNameToMatch))
        ORDER BY UserName

    SELECT  u.UserName, u.IsAnonymous, u.LastActivityDate, p.LastUpdatedDate,
            DATALENGTH(p.PropertyNames) + DATALENGTH(p.PropertyValuesString) + DATALENGTH(p.PropertyValuesBinary)
    FROM    dbo.aspnet_Users u, dbo.aspnet_Profile p, #PageIndexForUsers i
    WHERE   u.UserId = p.UserId AND p.UserId = i.UserId AND i.IndexId >= @PageLowerBound AND i.IndexId <= @PageUpperBound

    SELECT COUNT(*)
    FROM   #PageIndexForUsers

    DROP TABLE #PageIndexForUsers
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Profile_GetProperties]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Profile_GetProperties]
    @ApplicationName      nvarchar(256),
    @UserName             nvarchar(256),
    @CurrentTimeUtc       datetime
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM dbo.aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN

    DECLARE @UserId uniqueidentifier
    SELECT  @UserId = NULL

    SELECT @UserId = UserId
    FROM   dbo.aspnet_Users
    WHERE  ApplicationId = @ApplicationId AND LoweredUserName = LOWER(@UserName)

    IF (@UserId IS NULL)
        RETURN
    SELECT TOP 1 PropertyNames, PropertyValuesString, PropertyValuesBinary
    FROM         dbo.aspnet_Profile
    WHERE        UserId = @UserId

    IF (@@ROWCOUNT > 0)
    BEGIN
        UPDATE dbo.aspnet_Users
        SET    LastActivityDate=@CurrentTimeUtc
        WHERE  UserId = @UserId
    END
END
GO
/****** Object:  View [dbo].[vw_aspnet_MembershipUsers]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_MembershipUsers]
  AS SELECT [dbo].[aspnet_Membership].[UserId],
            [dbo].[aspnet_Membership].[PasswordFormat],
            [dbo].[aspnet_Membership].[MobilePIN],
            [dbo].[aspnet_Membership].[Email],
            [dbo].[aspnet_Membership].[LoweredEmail],
            [dbo].[aspnet_Membership].[PasswordQuestion],
            [dbo].[aspnet_Membership].[PasswordAnswer],
            [dbo].[aspnet_Membership].[IsApproved],
            [dbo].[aspnet_Membership].[IsLockedOut],
            [dbo].[aspnet_Membership].[CreateDate],
            [dbo].[aspnet_Membership].[LastLoginDate],
            [dbo].[aspnet_Membership].[LastPasswordChangedDate],
            [dbo].[aspnet_Membership].[LastLockoutDate],
            [dbo].[aspnet_Membership].[FailedPasswordAttemptCount],
            [dbo].[aspnet_Membership].[FailedPasswordAttemptWindowStart],
            [dbo].[aspnet_Membership].[FailedPasswordAnswerAttemptCount],
            [dbo].[aspnet_Membership].[FailedPasswordAnswerAttemptWindowStart],
            [dbo].[aspnet_Membership].[Comment],
            [dbo].[aspnet_Users].[ApplicationId],
            [dbo].[aspnet_Users].[UserName],
            [dbo].[aspnet_Users].[MobileAlias],
            [dbo].[aspnet_Users].[IsAnonymous],
            [dbo].[aspnet_Users].[LastActivityDate]
  FROM [dbo].[aspnet_Membership] INNER JOIN [dbo].[aspnet_Users]
      ON [dbo].[aspnet_Membership].[UserId] = [dbo].[aspnet_Users].[UserId]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetUserByUserId]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_GetUserByUserId]
    @UserId               uniqueidentifier,
    @CurrentTimeUtc       datetime,
    @UpdateLastActivity   bit = 0
AS
BEGIN
    IF ( @UpdateLastActivity = 1 )
    BEGIN
        UPDATE   dbo.aspnet_Users
        SET      LastActivityDate = @CurrentTimeUtc
        FROM     dbo.aspnet_Users
        WHERE    @UserId = UserId

        IF ( @@ROWCOUNT = 0 ) -- User ID not found
            RETURN -1
    END

    SELECT  m.Email, m.PasswordQuestion, m.Comment, m.IsApproved,
            m.CreateDate, m.LastLoginDate, u.LastActivityDate,
            m.LastPasswordChangedDate, u.UserName, m.IsLockedOut,
            m.LastLockoutDate
    FROM    dbo.aspnet_Users u, dbo.aspnet_Membership m
    WHERE   @UserId = u.UserId AND u.UserId = m.UserId

    IF ( @@ROWCOUNT = 0 ) -- User ID not found
       RETURN -1

    RETURN 0
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationAdministration_DeleteAllState]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_PersonalizationAdministration_DeleteAllState] (
    @AllUsersScope bit,
    @ApplicationName NVARCHAR(256),
    @Count int OUT)
AS
BEGIN
    DECLARE @ApplicationId UNIQUEIDENTIFIER
    EXEC dbo.aspnet_Personalization_GetApplicationId @ApplicationName, @ApplicationId OUTPUT
    IF (@ApplicationId IS NULL)
        SELECT @Count = 0
    ELSE
    BEGIN
        IF (@AllUsersScope = 1)
            DELETE FROM aspnet_PersonalizationAllUsers
            WHERE PathId IN
               (SELECT Paths.PathId
                FROM dbo.aspnet_Paths Paths
                WHERE Paths.ApplicationId = @ApplicationId)
        ELSE
            DELETE FROM aspnet_PersonalizationPerUser
            WHERE PathId IN
               (SELECT Paths.PathId
                FROM dbo.aspnet_Paths Paths
                WHERE Paths.ApplicationId = @ApplicationId)

        SELECT @Count = @@ROWCOUNT
    END
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationAdministration_ResetSharedState]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_PersonalizationAdministration_ResetSharedState] (
    @Count int OUT,
    @ApplicationName NVARCHAR(256),
    @Path NVARCHAR(256))
AS
BEGIN
    DECLARE @ApplicationId UNIQUEIDENTIFIER
    EXEC dbo.aspnet_Personalization_GetApplicationId @ApplicationName, @ApplicationId OUTPUT
    IF (@ApplicationId IS NULL)
        SELECT @Count = 0
    ELSE
    BEGIN
        DELETE FROM dbo.aspnet_PersonalizationAllUsers
        WHERE PathId IN
            (SELECT AllUsers.PathId
             FROM dbo.aspnet_PersonalizationAllUsers AllUsers, dbo.aspnet_Paths Paths
             WHERE Paths.ApplicationId = @ApplicationId
                   AND AllUsers.PathId = Paths.PathId
                   AND Paths.LoweredPath = LOWER(@Path))

        SELECT @Count = @@ROWCOUNT
    END
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationAdministration_GetCountOfState]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_PersonalizationAdministration_GetCountOfState] (
    @Count int OUT,
    @AllUsersScope bit,
    @ApplicationName NVARCHAR(256),
    @Path NVARCHAR(256) = NULL,
    @UserName NVARCHAR(256) = NULL,
    @InactiveSinceDate DATETIME = NULL)
AS
BEGIN

    DECLARE @ApplicationId UNIQUEIDENTIFIER
    EXEC dbo.aspnet_Personalization_GetApplicationId @ApplicationName, @ApplicationId OUTPUT
    IF (@ApplicationId IS NULL)
        SELECT @Count = 0
    ELSE
        IF (@AllUsersScope = 1)
            SELECT @Count = COUNT(*)
            FROM dbo.aspnet_PersonalizationAllUsers AllUsers, dbo.aspnet_Paths Paths
            WHERE Paths.ApplicationId = @ApplicationId
                  AND AllUsers.PathId = Paths.PathId
                  AND (@Path IS NULL OR Paths.LoweredPath LIKE LOWER(@Path))
        ELSE
            SELECT @Count = COUNT(*)
            FROM dbo.aspnet_PersonalizationPerUser PerUser, dbo.aspnet_Users Users, dbo.aspnet_Paths Paths
            WHERE Paths.ApplicationId = @ApplicationId
                  AND PerUser.UserId = Users.UserId
                  AND PerUser.PathId = Paths.PathId
                  AND (@Path IS NULL OR Paths.LoweredPath LIKE LOWER(@Path))
                  AND (@UserName IS NULL OR Users.LoweredUserName LIKE LOWER(@UserName))
                  AND (@InactiveSinceDate IS NULL OR Users.LastActivityDate <= @InactiveSinceDate)
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationAdministration_ResetUserState]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_PersonalizationAdministration_ResetUserState] (
    @Count                  int                 OUT,
    @ApplicationName        NVARCHAR(256),
    @InactiveSinceDate      DATETIME            = NULL,
    @UserName               NVARCHAR(256)       = NULL,
    @Path                   NVARCHAR(256)       = NULL)
AS
BEGIN
    DECLARE @ApplicationId UNIQUEIDENTIFIER
    EXEC dbo.aspnet_Personalization_GetApplicationId @ApplicationName, @ApplicationId OUTPUT
    IF (@ApplicationId IS NULL)
        SELECT @Count = 0
    ELSE
    BEGIN
        DELETE FROM dbo.aspnet_PersonalizationPerUser
        WHERE Id IN (SELECT PerUser.Id
                     FROM dbo.aspnet_PersonalizationPerUser PerUser, dbo.aspnet_Users Users, dbo.aspnet_Paths Paths
                     WHERE Paths.ApplicationId = @ApplicationId
                           AND PerUser.UserId = Users.UserId
                           AND PerUser.PathId = Paths.PathId
                           AND (@InactiveSinceDate IS NULL OR Users.LastActivityDate <= @InactiveSinceDate)
                           AND (@UserName IS NULL OR Users.LoweredUserName = LOWER(@UserName))
                           AND (@Path IS NULL OR Paths.LoweredPath = LOWER(@Path)))

        SELECT @Count = @@ROWCOUNT
    END
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationAllUsers_GetPageSettings]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_PersonalizationAllUsers_GetPageSettings] (
    @ApplicationName  NVARCHAR(256),
    @Path              NVARCHAR(256))
AS
BEGIN
    DECLARE @ApplicationId UNIQUEIDENTIFIER
    DECLARE @PathId UNIQUEIDENTIFIER

    SELECT @ApplicationId = NULL
    SELECT @PathId = NULL

    EXEC dbo.aspnet_Personalization_GetApplicationId @ApplicationName, @ApplicationId OUTPUT
    IF (@ApplicationId IS NULL)
    BEGIN
        RETURN
    END

    SELECT @PathId = u.PathId FROM dbo.aspnet_Paths u WHERE u.ApplicationId = @ApplicationId AND u.LoweredPath = LOWER(@Path)
    IF (@PathId IS NULL)
    BEGIN
        RETURN
    END

    SELECT p.PageSettings FROM dbo.aspnet_PersonalizationAllUsers p WHERE p.PathId = @PathId
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationAllUsers_ResetPageSettings]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_PersonalizationAllUsers_ResetPageSettings] (
    @ApplicationName  NVARCHAR(256),
    @Path              NVARCHAR(256))
AS
BEGIN
    DECLARE @ApplicationId UNIQUEIDENTIFIER
    DECLARE @PathId UNIQUEIDENTIFIER

    SELECT @ApplicationId = NULL
    SELECT @PathId = NULL

    EXEC dbo.aspnet_Personalization_GetApplicationId @ApplicationName, @ApplicationId OUTPUT
    IF (@ApplicationId IS NULL)
    BEGIN
        RETURN
    END

    SELECT @PathId = u.PathId FROM dbo.aspnet_Paths u WHERE u.ApplicationId = @ApplicationId AND u.LoweredPath = LOWER(@Path)
    IF (@PathId IS NULL)
    BEGIN
        RETURN
    END

    DELETE FROM dbo.aspnet_PersonalizationAllUsers WHERE PathId = @PathId
    RETURN 0
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationPerUser_GetPageSettings]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_PersonalizationPerUser_GetPageSettings] (
    @ApplicationName  NVARCHAR(256),
    @UserName         NVARCHAR(256),
    @Path             NVARCHAR(256),
    @CurrentTimeUtc   DATETIME)
AS
BEGIN
    DECLARE @ApplicationId UNIQUEIDENTIFIER
    DECLARE @PathId UNIQUEIDENTIFIER
    DECLARE @UserId UNIQUEIDENTIFIER

    SELECT @ApplicationId = NULL
    SELECT @PathId = NULL
    SELECT @UserId = NULL

    EXEC dbo.aspnet_Personalization_GetApplicationId @ApplicationName, @ApplicationId OUTPUT
    IF (@ApplicationId IS NULL)
    BEGIN
        RETURN
    END

    SELECT @PathId = u.PathId FROM dbo.aspnet_Paths u WHERE u.ApplicationId = @ApplicationId AND u.LoweredPath = LOWER(@Path)
    IF (@PathId IS NULL)
    BEGIN
        RETURN
    END

    SELECT @UserId = u.UserId FROM dbo.aspnet_Users u WHERE u.ApplicationId = @ApplicationId AND u.LoweredUserName = LOWER(@UserName)
    IF (@UserId IS NULL)
    BEGIN
        RETURN
    END

    UPDATE   dbo.aspnet_Users WITH (ROWLOCK)
    SET      LastActivityDate = @CurrentTimeUtc
    WHERE    UserId = @UserId
    IF (@@ROWCOUNT = 0) -- Username not found
        RETURN

    SELECT p.PageSettings FROM dbo.aspnet_PersonalizationPerUser p WHERE p.PathId = @PathId AND p.UserId = @UserId
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationPerUser_ResetPageSettings]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_PersonalizationPerUser_ResetPageSettings] (
    @ApplicationName  NVARCHAR(256),
    @UserName         NVARCHAR(256),
    @Path             NVARCHAR(256),
    @CurrentTimeUtc   DATETIME)
AS
BEGIN
    DECLARE @ApplicationId UNIQUEIDENTIFIER
    DECLARE @PathId UNIQUEIDENTIFIER
    DECLARE @UserId UNIQUEIDENTIFIER

    SELECT @ApplicationId = NULL
    SELECT @PathId = NULL
    SELECT @UserId = NULL

    EXEC dbo.aspnet_Personalization_GetApplicationId @ApplicationName, @ApplicationId OUTPUT
    IF (@ApplicationId IS NULL)
    BEGIN
        RETURN
    END

    SELECT @PathId = u.PathId FROM dbo.aspnet_Paths u WHERE u.ApplicationId = @ApplicationId AND u.LoweredPath = LOWER(@Path)
    IF (@PathId IS NULL)
    BEGIN
        RETURN
    END

    SELECT @UserId = u.UserId FROM dbo.aspnet_Users u WHERE u.ApplicationId = @ApplicationId AND u.LoweredUserName = LOWER(@UserName)
    IF (@UserId IS NULL)
    BEGIN
        RETURN
    END

    UPDATE   dbo.aspnet_Users WITH (ROWLOCK)
    SET      LastActivityDate = @CurrentTimeUtc
    WHERE    UserId = @UserId
    IF (@@ROWCOUNT = 0) -- Username not found
        RETURN

    DELETE FROM dbo.aspnet_PersonalizationPerUser WHERE PathId = @PathId AND UserId = @UserId
    RETURN 0
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Paths_CreatePath]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Paths_CreatePath]
    @ApplicationId UNIQUEIDENTIFIER,
    @Path           NVARCHAR(256),
    @PathId         UNIQUEIDENTIFIER OUTPUT
AS
BEGIN
    BEGIN TRANSACTION
    IF (NOT EXISTS(SELECT * FROM dbo.aspnet_Paths WHERE LoweredPath = LOWER(@Path) AND ApplicationId = @ApplicationId))
    BEGIN
        INSERT dbo.aspnet_Paths (ApplicationId, Path, LoweredPath) VALUES (@ApplicationId, @Path, LOWER(@Path))
    END
    COMMIT TRANSACTION
    SELECT @PathId = PathId FROM dbo.aspnet_Paths WHERE LOWER(@Path) = LoweredPath AND ApplicationId = @ApplicationId
END
GO
/****** Object:  View [dbo].[vw_aspnet_WebPartState_Paths]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_WebPartState_Paths]
  AS SELECT [dbo].[aspnet_Paths].[ApplicationId], [dbo].[aspnet_Paths].[PathId], [dbo].[aspnet_Paths].[Path], [dbo].[aspnet_Paths].[LoweredPath]
  FROM [dbo].[aspnet_Paths]
GO
/****** Object:  StoredProcedure [dbo].[AuditLog_INSERT]    Script Date: 10/28/2009 12:28:52 ******/
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
GO
/****** Object:  StoredProcedure [dbo].[AuditLog_SELECT_ByIdAndType]    Script Date: 10/28/2009 12:28:52 ******/
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
GO
/****** Object:  StoredProcedure [dbo].[AuditLog_SELECT_Search]    Script Date: 10/28/2009 12:28:52 ******/
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
GO
/****** Object:  View [dbo].[vw_aspnet_WebPartState_Shared]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_WebPartState_Shared]
  AS SELECT [dbo].[aspnet_PersonalizationAllUsers].[PathId], [DataSize]=DATALENGTH([dbo].[aspnet_PersonalizationAllUsers].[PageSettings]), [dbo].[aspnet_PersonalizationAllUsers].[LastUpdatedDate]
  FROM [dbo].[aspnet_PersonalizationAllUsers]
GO
/****** Object:  View [dbo].[vw_aspnet_WebPartState_User]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_WebPartState_User]
  AS SELECT [dbo].[aspnet_PersonalizationPerUser].[PathId], [dbo].[aspnet_PersonalizationPerUser].[UserId], [DataSize]=DATALENGTH([dbo].[aspnet_PersonalizationPerUser].[PageSettings]), [dbo].[aspnet_PersonalizationPerUser].[LastUpdatedDate]
  FROM [dbo].[aspnet_PersonalizationPerUser]
GO
/****** Object:  StoredProcedure [dbo].[HttpLog_SELECT_HistoryByDateRange]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.HttpLog_SELECT_HistoryByDateRange    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[HttpLog_SELECT_HistoryByDateRange]

	@rangeStart datetime,
	@rangeEnd datetime

AS

	SET NOCOUNT ON

	-- HttpLog_SELECT_HistoryByDateRange '2001-1-1', '2009-12-31'

	-- HttpLog_SELECT_HistoryByDateRange '2009-3-3', '2009-3-4'


	SELECT	*
	FROM 	HttpLog 
	WHERE 	TimeLogged >= @rangeStart AND TimeLogged < @rangeEnd
	ORDER BY TimeLogged DESC
GO
/****** Object:  StoredProcedure [dbo].[HttpLog_SELECT]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.HttpLog_SELECT    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[HttpLog_SELECT]

	@rangeStart datetime,
	@rangeEnd datetime,
	@txtUrl varchar(500) = '%', 
	@txtUrlReferrer varchar(500) = '%', 
	@txtUserHostName varchar(50) = '%', 
	@txtSessionId varchar(50) = '%', 
	@txtMiscInfo varchar(500) = '%'

AS

	SET NOCOUNT ON

	-- HttpLog_SELECT '2001-1-1', '2009-12-31'
	-- HttpLog_SELECT '2001-1-1', '2009-12-31', '%?%'
	-- HttpLog_SELECT '2001-1-1', '2009-12-31', '%', '%', '%', '%', 'Browser%'

	-- HttpLog_SELECT '2009-3-3', '2009-3-4'

	SELECT	*
	FROM 	HttpLog 
	WHERE 	(TimeLogged >= @rangeStart AND TimeLogged < @rangeEnd)
	AND		Url LIKE @txtUrl
	AND		UrlReferrer LIKE @txtUrlReferrer
	AND		UserHostName LIKE @txtUserHostName
	AND		SessionId LIKE @txtSessionId
	AND		MiscInfo LIKE @txtMiscInfo
	ORDER BY TimeLogged DESC
GO
/****** Object:  StoredProcedure [dbo].[HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange @txtSearchCriteria = '%acc%'


/****** Object:  Stored Procedure dbo.HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange]

	@visitedUrl varchar(500),
	@visitedUrlOptional varchar(500) = '',
	@rangeStart varchar(10),
	@rangeEnd varchar(10)

AS

	SET NOCOUNT ON

	-- SELECT * FROM HttpLog
	-- HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange '/Morphfolia.Web/default.aspx', '/Morphfolia.Web/', '2007-9-9', '2007-9-10'
	-- HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange '/', '', '2007-9-9', '2007-9-10'
	-- HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange '/Default.aspx', '', '2007-9-9', '2007-9-10'
	-- HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange '/default.aspx', '', '2007-9-9', '2007-9-10'
	-- HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange '/SearchResults.aspx', '', '2007-9-9', '2008-9-10'
	-- HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange 'http://localhost/Morphfolia.Web/SearchResults.aspx', '', '2007-9-9', '2007-9-10'
	
	-- Where did sessions go (destinations) after visiting the url specified?:

	-- HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange '/Morphfolia.Web/default.aspx', '/Morphfolia.Web/', '2008-9-25', '2008-9-26'
	-- HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange '/Morphfolia.Web/default.aspx', '/Morphfolia.Web/', '2008-9-26', '2008-9-27'
	-- HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange '/Morphfolia.Web/default.aspx', '/Morphfolia.Web/', '2008-9-27', '2008-9-28'
	-- HttpLog_SELECT_DestinationUrlsFromVisitedUrlByDateRange '/Morphfolia.Web/default.aspx', '/Morphfolia.Web/', '2008-9-28', '2008-9-29'

	IF @visitedUrlOptional <> ''
	BEGIN

		SELECT	Url, 
			Count(*) NumberOfHitsOnDestination
		FROM 	HttpLog 
		WHERE 	((UrlReferrer LIKE '%' + @visitedUrl) OR (UrlReferrer LIKE '%' + @visitedUrlOptional))
		AND 	(TimeLogged >= @rangeStart AND TimeLogged < @rangeEnd)
		GROUP BY Url
		ORDER BY NumberOfHitsOnDestination DESC

		SELECT	Url, TimeLogged
		FROM 	HttpLog 
		WHERE 	((UrlReferrer LIKE '%' + @visitedUrl) OR (UrlReferrer LIKE '%' + @visitedUrlOptional))
		AND 	(TimeLogged >= @rangeStart AND TimeLogged < @rangeEnd)

	END
	ELSE
	BEGIN

		SELECT	Url, 
			Count(*) NumberOfHitsOnDestination
		FROM 	HttpLog 
		WHERE 	UrlReferrer LIKE '%' + @visitedUrl
		AND 	(TimeLogged >= @rangeStart AND TimeLogged < @rangeEnd)
		GROUP BY Url
		ORDER BY NumberOfHitsOnDestination DESC


		SELECT	Url, TimeLogged
		FROM 	HttpLog 
		WHERE 	UrlReferrer LIKE '%' + @visitedUrl
		AND 	(TimeLogged >= @rangeStart AND TimeLogged < @rangeEnd)

	END
GO
/****** Object:  StoredProcedure [dbo].[HttpLog_SELECT_DestinationUrlsFromVisitedUrlByHours]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.HttpLog_SELECT_DestinationUrlsFromVisitedUrlByHours    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec HttpLog_SELECT_DestinationUrlsFromVisitedUrlByHours @txtSearchCriteria = '%acc%'


/****** Object:  Stored Procedure dbo.HttpLog_SELECT_DestinationUrlsFromVisitedUrlByHours    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[HttpLog_SELECT_DestinationUrlsFromVisitedUrlByHours]

	@visitedUrl varchar(500),
	@visitedUrlOptional varchar(500) = '',
	@numberOfHours int = 24

AS

	SET NOCOUNT ON

	-- SELECT * FROM HttpLog
	-- HttpLog_SELECT_DestinationUrlsFromVisitedUrlByHours '/Morphfolia.Web/default.aspx', '/Morphfolia.Web/', 24
	-- HttpLog_SELECT_DestinationUrlsFromVisitedUrlByHours '/', 12
	-- HttpLog_SELECT_DestinationUrlsFromVisitedUrlByHours '/Default.aspx', 12
	-- HttpLog_SELECT_DestinationUrlsFromVisitedUrlByHours '/default.aspx', 12
	-- HttpLog_SELECT_DestinationUrlsFromVisitedUrlByHours '/SearchResults.aspx', 3000
	-- HttpLog_SELECT_DestinationUrlsFromVisitedUrlByHours 'http://localhost/Morphfolia.Web/SearchResults.aspx', 24
	-- HttpLog_SELECT_DestinationUrlsFromVisitedUrlByHours '/Morphfolia.Web/default.aspx', '/Morphfolia.Web/', 1
	-- HttpLog_SELECT_DestinationUrlsFromVisitedUrlByHours '/Morphfolia.Web/default.aspx', '/Morphfolia.Web/', 1000
	-- HttpLog_SELECT_DestinationUrlsFromVisitedUrlByHours '/Morphfolia.Web/', 1000
	-- HttpLog_SELECT_DestinationUrlsFromVisitedUrlByHours '/Morphfolia.Web/default.aspx', 'wersdf', 1000
	-- HttpLog_SELECT_DestinationUrlsFromVisitedUrlByHours '/Morphfolia.Web/', 'wersdf', 1000

	-- Where did sessions go (destinations) after visiting the url specified?:


	IF @visitedUrlOptional <> ''
	BEGIN

		SELECT	Url, 
			Count(*) NumberOfHitsOnDestination			
		FROM 	HttpLog 
		WHERE 	((UrlReferrer LIKE '%' + @visitedUrl) OR (UrlReferrer LIKE '%' + @visitedUrlOptional))
		AND	DATEDIFF(hour, TimeLogged, getdate()) <= @numberOfHours
		GROUP BY Url
		ORDER BY NumberOfHitsOnDestination DESC

	END
	ELSE
	BEGIN

		SELECT	Url,
			Count(*) NumberOfHitsOnDestination
		FROM 	HttpLog 
		WHERE 	(UrlReferrer LIKE '%' + @visitedUrl)
		AND	DATEDIFF(hour, TimeLogged, getdate()) <= @numberOfHours
		GROUP BY Url
		ORDER BY NumberOfHitsOnDestination DESC

	END
GO
/****** Object:  StoredProcedure [dbo].[HttpLog_SELECT_ReferreringUrlsForVisitedUrlByDateRange]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.HttpLog_SELECT_ReferreringUrlsForVisitedUrlByDateRange    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec HttpLog_SELECT_ReferreringUrlsForVisitedUrlByDateRange @txtSearchCriteria = '%acc%'


/****** Object:  Stored Procedure dbo.HttpLog_SELECT_ReferreringUrlsForVisitedUrlByDateRange    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[HttpLog_SELECT_ReferreringUrlsForVisitedUrlByDateRange]

	@visitedUrl varchar(500),
	@rangeStart varchar(10),
	@rangeEnd varchar(10)

AS

	SET NOCOUNT ON

	-- HttpLog_SELECT_ReferreringUrlsForVisitedUrlByDateRange '/SearchResults.aspx', '2008-9-28', '2008-9-29'
	-- HttpLog_SELECT_ReferreringUrlsForVisitedUrlByDateRange 'http://localhost/Morphfolia.Web/SearchResults.aspx', '2007-9-9', '2008-9-10'
	-- HttpLog_SELECT_ReferreringUrlsForVisitedUrlByDateRange 
	
	-- Where did sessions go (destinations) after visiting the url specified?:
	SELECT	UrlReferrer, 
		Count(*) NumberOfHitsOnDestination
	FROM 	HttpLog 
	WHERE 	(Url LIKE '%' + @visitedUrl)
	AND 	((TimeLogged >= @rangeStart) AND (TimeLogged < @rangeEnd))
	GROUP BY UrlReferrer
	ORDER BY NumberOfHitsOnDestination DESC
GO
/****** Object:  StoredProcedure [dbo].[HttpLog_SELECT_TopTenUrls]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.HttpLog_SELECT_TopTenUrls    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec HttpLog_SELECT_TopTenUrls @txtSearchCriteria = '%acc%'


/****** Object:  Stored Procedure dbo.HttpLog_SELECT_TopTenUrls    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[HttpLog_SELECT_TopTenUrls]

	

AS

	SET NOCOUNT ON

	
	SELECT 	TOP 10
		Url, 
		Count(*) HitCount

	FROM	dbo.HttpLog

	GROUP BY Url

	ORDER BY HitCount DESC
GO
/****** Object:  StoredProcedure [dbo].[HttpLog_SELECT_UrlHistoryForSession]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.HttpLog_SELECT_UrlHistoryForSession    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec HttpLog_SELECT_UrlHistoryForSession @txtSearchCriteria = '%acc%'


/****** Object:  Stored Procedure dbo.HttpLog_SELECT_UrlHistoryForSession    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[HttpLog_SELECT_UrlHistoryForSession]

	@SessionId varchar(50)

AS

	SET NOCOUNT ON

	-- HttpLog_SELECT_UrlHistoryForSession
	-- HttpLog_SELECT_UrlHistoryForSession 'gqxoni5515zvj055yqm5wl45'
	
	-- Where did sessions go (destinations) after visiting the url specified?:
	SELECT 	LogId, SessionId, UserHostName, Url, UrlReferrer, TimeLogged, MiscInfo
	FROM 	HttpLog 
	WHERE 	SessionId = @SessionId	
	ORDER BY TimeLogged DESC
GO
/****** Object:  StoredProcedure [dbo].[HttpLog_INSERT]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.HttpLog_INSERT    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec HttpLog_INSERT @txtSearchCriteria = '%acc%'


/****** Object:  Stored Procedure dbo.HttpLog_INSERT    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[HttpLog_INSERT]

	@SessionId varchar(50),
	@UserHostName varchar(50),
	@Url varchar(500),
	@UrlReferrer varchar(500),
	@MiscInfo varchar(500)

AS

	SET NOCOUNT ON

	INSERT INTO [HttpLog]
	(
		[SessionId], 
		[UserHostName], 
		[Url], 
		[UrlReferrer],
		[MiscInfo]
	)
	VALUES
	(
		@SessionId,
		@UserHostName,
		@Url,
		@UrlReferrer,
		@MiscInfo
	)
GO
/****** Object:  StoredProcedure [dbo].[HttpLog_SELECT_ReferreringUrlsForVisitedUrlByHours]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.HttpLog_SELECT_ReferreringUrlsForVisitedUrlByHours    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec HttpLog_SELECT_ReferreringUrlsForVisitedUrlByHours @txtSearchCriteria = '%acc%'


/****** Object:  Stored Procedure dbo.HttpLog_SELECT_ReferreringUrlsForVisitedUrlByHours    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[HttpLog_SELECT_ReferreringUrlsForVisitedUrlByHours]

	@visitedUrl varchar(500),
	@numberOfHours int = 24

AS

	SET NOCOUNT ON

	-- HttpLog_SELECT_ReferreringUrlsForVisitedUrlByHours '/SearchResults.aspx', 3000
	-- HttpLog_SELECT_ReferreringUrlsForVisitedUrlByHours 'http://localhost/Morphfolia.Web/SearchResults.aspx', 24
	-- HttpLog_SELECT_ReferreringUrlsForVisitedUrlByHours 
	
	-- Where did sessions go (destinations) after visiting the url specified?:
	SELECT	UrlReferrer, 
		Count(*) NumberOfHitsOnDestination
	FROM 	HttpLog 
	WHERE 	(Url LIKE '%' + @visitedUrl)
	AND	(DATEDIFF(hour, TimeLogged, getdate()) <= @numberOfHours)
	GROUP BY UrlReferrer
	ORDER BY NumberOfHitsOnDestination DESC
GO
/****** Object:  StoredProcedure [dbo].[HttpLog_SELECT_ActiveSessionsByDateRange]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.HttpLog_SELECT_ActiveSessionsByDateRange    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec HttpLog_SELECT_ActiveSessionsByDateRange @txtSearchCriteria = '%acc%'


/****** Object:  Stored Procedure dbo.HttpLog_SELECT_ActiveSessionsByDateRange    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[HttpLog_SELECT_ActiveSessionsByDateRange]

	@rangeStart varchar(10),
	@rangeEnd varchar(10)

AS

	SET NOCOUNT ON


	-- SELECT * FROM HttpLog
	-- HttpLog_SELECT_ActiveSessionsByDateRange '2007-9-9', '2007-9-10'
	-- HttpLog_SELECT_ActiveSessionsByDateRange '2007-9-10', '2007-9-11'
	-- HttpLog_SELECT_ActiveSessionsByDateRange '2007-9-11', '2007-9-12'

	-- HttpLog_SELECT_ActiveSessionsByDateRange '2008-9-24', '2008-9-27'
	-- HttpLog_SELECT_ActiveSessionsByDateRange '2008-9-24', '2008-9-25'
	-- HttpLog_SELECT_ActiveSessionsByDateRange '2008-9-27', '2008-9-28'

/*
	SELECT 	H.SessionId, H.TimeLogged
	FROM HttpLog H
	WHERE TimeLogged >= '2008-9-24' AND TimeLogged < '2008-9-27'
*/

	-- Unique sessions within specific timespan:
	SELECT 	H.SessionId, 
			H.UserHostName,
		count(*) TotalPageRequests,
		(
			SELECT 	TOP 1 TimeLogged
			FROM	HttpLog
			WHERE	SessionId = H.SessionId
			ORDER BY TimeLogged ASC

		) 'FirstUrlRequest',
		(
			SELECT 	TOP 1 TimeLogged
			FROM	HttpLog
			WHERE	SessionId = H.SessionId
			ORDER BY TimeLogged DESC

		) 'LastUrlRequest',
		(
			SELECT 	TOP 1 Url
			FROM	HttpLog
			WHERE	SessionId = H.SessionId
			ORDER BY TimeLogged ASC

		) 'FirstUrlRequested',
		(
			SELECT 	TOP 1 Url
			FROM	HttpLog
			WHERE	SessionId = H.SessionId
			ORDER BY TimeLogged DESC

		) 'LastUrlRequested'


		
	FROM HttpLog H
	WHERE (TimeLogged >= @rangeStart) AND (TimeLogged < @rangeEnd)
	GROUP BY H.SessionId, H.UserHostName
	ORDER BY LastUrlRequest DESC
GO
/****** Object:  StoredProcedure [dbo].[HttpLog_SELECT_ActiveSessionsByHours]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.HttpLog_SELECT_ActiveSessionsByHours    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec HttpLog_SELECT_ActiveSessionsByHours @txtSearchCriteria = '%acc%'


/****** Object:  Stored Procedure dbo.HttpLog_SELECT_ActiveSessionsByHours    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[HttpLog_SELECT_ActiveSessionsByHours]

	@numberOfHours int = 24

AS

	SET NOCOUNT ON

	-- HttpLog_SELECT_ActiveSessionsByHours
	-- HttpLog_SELECT_ActiveSessionsByHours 24
	-- HttpLog_SELECT_ActiveSessionsByHours 672 	--( weeks)

	-- SELECT * FROM HttpLog
	-- HttpLog_SELECT_ActiveSessionsByDateRange '2007-9-9', '2007-9-10'

	-- Unique sessions within specific timespan:
	SELECT 	H.SessionId, 
			H.UserHostName,
		count(*) TotalPageRequests,
		(
			SELECT 	TOP 1 TimeLogged
			FROM	HttpLog
			WHERE	SessionId = H.SessionId
			ORDER BY TimeLogged ASC

		) 'FirstUrlRequest',
		(
			SELECT 	TOP 1 TimeLogged
			FROM	HttpLog
			WHERE	SessionId = H.SessionId
			ORDER BY TimeLogged DESC

		) 'LastUrlRequest',
		(
			SELECT 	TOP 1 Url
			FROM	HttpLog
			WHERE	SessionId = H.SessionId
			ORDER BY TimeLogged ASC

		) 'FirstUrlRequested',
		(
			SELECT 	TOP 1 Url
			FROM	HttpLog
			WHERE	SessionId = H.SessionId
			ORDER BY TimeLogged DESC

		) 'LastUrlRequested'
		
	FROM HttpLog H
	WHERE DATEDIFF(hour, TimeLogged, getdate()) <= @numberOfHours
	GROUP BY H.SessionId, H.UserHostName
	ORDER BY LastUrlRequest DESC
GO
/****** Object:  View [dbo].[vw_aspnet_Profiles]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_Profiles]
  AS SELECT [dbo].[aspnet_Profile].[UserId], [dbo].[aspnet_Profile].[LastUpdatedDate],
      [DataSize]=  DATALENGTH([dbo].[aspnet_Profile].[PropertyNames])
                 + DATALENGTH([dbo].[aspnet_Profile].[PropertyValuesString])
                 + DATALENGTH([dbo].[aspnet_Profile].[PropertyValuesBinary])
  FROM [dbo].[aspnet_Profile]
GO
/****** Object:  View [dbo].[vw_aspnet_Roles]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_Roles]
  AS SELECT [dbo].[aspnet_Roles].[ApplicationId], [dbo].[aspnet_Roles].[RoleId], [dbo].[aspnet_Roles].[RoleName], [dbo].[aspnet_Roles].[LoweredRoleName], [dbo].[aspnet_Roles].[Description]
  FROM [dbo].[aspnet_Roles]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_CheckSchemaVersion]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_CheckSchemaVersion]
    @Feature                   nvarchar(128),
    @CompatibleSchemaVersion   nvarchar(128)
AS
BEGIN
    IF (EXISTS( SELECT  *
                FROM    dbo.aspnet_SchemaVersions
                WHERE   Feature = LOWER( @Feature ) AND
                        CompatibleSchemaVersion = @CompatibleSchemaVersion ))
        RETURN 0

    RETURN 1
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_UnRegisterSchemaVersion]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_UnRegisterSchemaVersion]
    @Feature                   nvarchar(128),
    @CompatibleSchemaVersion   nvarchar(128)
AS
BEGIN
    DELETE FROM dbo.aspnet_SchemaVersions
        WHERE   Feature = LOWER(@Feature) AND @CompatibleSchemaVersion = CompatibleSchemaVersion
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_RegisterSchemaVersion]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_RegisterSchemaVersion]
    @Feature                   nvarchar(128),
    @CompatibleSchemaVersion   nvarchar(128),
    @IsCurrentVersion          bit,
    @RemoveIncompatibleSchema  bit
AS
BEGIN
    IF( @RemoveIncompatibleSchema = 1 )
    BEGIN
        DELETE FROM dbo.aspnet_SchemaVersions WHERE Feature = LOWER( @Feature )
    END
    ELSE
    BEGIN
        IF( @IsCurrentVersion = 1 )
        BEGIN
            UPDATE dbo.aspnet_SchemaVersions
            SET IsCurrentVersion = 0
            WHERE Feature = LOWER( @Feature )
        END
    END

    INSERT  dbo.aspnet_SchemaVersions( Feature, CompatibleSchemaVersion, IsCurrentVersion )
    VALUES( LOWER( @Feature ), @CompatibleSchemaVersion, @IsCurrentVersion )
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Users_CreateUser]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Users_CreateUser]
    @ApplicationId    uniqueidentifier,
    @UserName         nvarchar(256),
    @IsUserAnonymous  bit,
    @LastActivityDate DATETIME,
    @UserId           uniqueidentifier OUTPUT
AS
BEGIN
    IF( @UserId IS NULL )
        SELECT @UserId = NEWID()
    ELSE
    BEGIN
        IF( EXISTS( SELECT UserId FROM dbo.aspnet_Users
                    WHERE @UserId = UserId ) )
            RETURN -1
    END

    INSERT dbo.aspnet_Users (ApplicationId, UserId, UserName, LoweredUserName, IsAnonymous, LastActivityDate)
    VALUES (@ApplicationId, @UserId, @UserName, LOWER(@UserName), @IsUserAnonymous, @LastActivityDate)

    RETURN 0
END
GO
/****** Object:  View [dbo].[vw_aspnet_Users]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_Users]
  AS SELECT [dbo].[aspnet_Users].[ApplicationId], [dbo].[aspnet_Users].[UserId], [dbo].[aspnet_Users].[UserName], [dbo].[aspnet_Users].[LoweredUserName], [dbo].[aspnet_Users].[MobileAlias], [dbo].[aspnet_Users].[IsAnonymous], [dbo].[aspnet_Users].[LastActivityDate]
  FROM [dbo].[aspnet_Users]
GO
/****** Object:  View [dbo].[vw_aspnet_UsersInRoles]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_UsersInRoles]
  AS SELECT [dbo].[aspnet_UsersInRoles].[UserId], [dbo].[aspnet_UsersInRoles].[RoleId]
  FROM [dbo].[aspnet_UsersInRoles]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_WebEvent_LogEvent]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_WebEvent_LogEvent]
        @EventId         char(32),
        @EventTimeUtc    datetime,
        @EventTime       datetime,
        @EventType       nvarchar(256),
        @EventSequence   decimal(19,0),
        @EventOccurrence decimal(19,0),
        @EventCode       int,
        @EventDetailCode int,
        @Message         nvarchar(1024),
        @ApplicationPath nvarchar(256),
        @ApplicationVirtualPath nvarchar(256),
        @MachineName    nvarchar(256),
        @RequestUrl      nvarchar(1024),
        @ExceptionType   nvarchar(256),
        @Details         ntext
AS
BEGIN
    INSERT
        dbo.aspnet_WebEvent_Events
        (
            EventId,
            EventTimeUtc,
            EventTime,
            EventType,
            EventSequence,
            EventOccurrence,
            EventCode,
            EventDetailCode,
            Message,
            ApplicationPath,
            ApplicationVirtualPath,
            MachineName,
            RequestUrl,
            ExceptionType,
            Details
        )
    VALUES
    (
        @EventId,
        @EventTimeUtc,
        @EventTime,
        @EventType,
        @EventSequence,
        @EventOccurrence,
        @EventCode,
        @EventDetailCode,
        @Message,
        @ApplicationPath,
        @ApplicationVirtualPath,
        @MachineName,
        @RequestUrl,
        @ExceptionType,
        @Details
    )
END
GO
/****** Object:  StoredProcedure [dbo].[Content_INSERT]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Content_INSERT    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_INSERT]


	@IDENTITY int OUTPUT,
	@txtContent ntext,
	@txtTextContent ntext,
	@txtNote varchar(500),
	@txtContentType char(4),
	@bitIsLive bit,
	@bitIsSearchable bit,
	@txtContentEntryFilter varchar(300),
	@txtLastUpdatedBy varchar(101)

AS

	SET NOCOUNT ON



	INSERT INTO [dbo].[Content](
		[Content], 
		[TextContent], 
		[Note], 
		[ContentType],
		[IsLive], 
		[IsSearchable], 
		[ContentFilter],
		[LastModified], 
		[LastModifiedBy]
	)
	VALUES (
		@txtContent,
		@txtTextContent,
		@txtNote,
		@txtContentType,
		@bitIsLive,
		@bitIsSearchable,
		@txtContentEntryFilter,
		GetDate(), 
		@txtLastUpdatedBy
	)


	SELECT @IDENTITY = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Content_SELECT    Script Date: 10/02/2007 8:11:37 p.m. ******/
/****** Object:  Stored Procedure dbo.Content_SELECT    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT]

	@txtContentType char(4) = '____'

AS

	SET NOCOUNT ON

	IF @txtContentType = '____'
	BEGIN

		SELECT	C.ContentID, 
				C.Content,
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.ContentFilter,
				C.LastModified, 
				C.LastModifiedBy

		FROM	dbo.Content C
		
		ORDER BY C.LastModified DESC

	END
	ELSE
	BEGIN

		SELECT	C.ContentID, 
				C.Content,
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.ContentFilter,
				C.LastModified, 
				C.LastModifiedBy

		FROM	dbo.Content C

		WHERE	C.ContentType = @txtContentType
		
		ORDER BY C.LastModified DESC

	END
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_ByContentID]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Content_SELECT_ByContentID    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_ByContentID]

	-- Content_SELECT_ByContentID 1

	@intContentID int

AS

	SET NOCOUNT ON

	SELECT	C.ContentID, 
			C.Content, 
			C.TextContent,
			C.Note, 
			C.ContentType,
			C.IsLive, 
			C.IsSearchable, 
			C.ContentFilter,
			C.LastModified, 
			C.LastModifiedBy

	FROM	dbo.Content C

	WHERE	C.ContentID = @intContentID
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_ByContentNote]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Content_SELECT_ByContentID    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_ByContentNote]

	-- Content_SELECT_ByContentNote 'zz Test - Not Live, Searchable', 1
	-- Content_SELECT_ByContentNote 'zz Test - Not Live, Searchable', 0
	-- Content_SELECT_ByContentNote 'Wow! This is a blog post', 1
	-- Content_SELECT_ByContentNote 'Wow! This is a blog post', 0


	@txtNote varchar(500),
	@bLiveOnly bit

AS

	SET NOCOUNT ON


	IF @bLiveOnly = 1
	BEGIN

		SELECT	C.ContentID, 
				C.Content, 
				C.TextContent,
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.ContentFilter,
				C.LastModified, 
				C.LastModifiedBy

		FROM	dbo.Content C

		WHERE	C.Note = @txtNote
		AND		C.IsLive = 1

		ORDER BY C.LastModified DESC

	END
	ELSE
	BEGIN

		SELECT	C.ContentID, 
				C.Content, 
				C.TextContent,
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.ContentFilter,
				C.LastModified, 
				C.LastModifiedBy

		FROM	dbo.Content C

		WHERE	C.Note = @txtNote

		ORDER BY C.LastModified DESC

	END
GO
/****** Object:  StoredProcedure [dbo].[Content_SELECT_SearchLiveOnly]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Content_SELECT_SearchLiveOnly    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_SearchLiveOnly]

	@txtNotes varchar(25)

AS

	-- Content_SELECT_List_Search 'Book%'
	-- Content_SELECT_SearchLiveOnly 'Book%'

	SET NOCOUNT ON

	SELECT		C.ContentID, 
			C.Content,
			C.TextContent, 
			C.Note, 
			C.IsLive, 
			C.IsSearchable, 
			C.ContentFilter,
			C.LastModified, 
			C.LastModifiedBy

	FROM		dbo.Content C

	WHERE		C.Note LIKE @txtNotes
	AND		C.IsLive = 1
	
	ORDER BY 	C.Note,
			C.ContentID
GO
/****** Object:  StoredProcedure [dbo].[Content_UPDATE]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.Content_UPDATE    Script Date: 10/02/2007 8:11:37 p.m. ******/
/****** Object:  Stored Procedure dbo.Content_UPDATE    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_UPDATE]

	-- Content_UPDATE 1

	@intContentID int,
	@txtContent ntext,
	@txtTextContent ntext,
	@txtNote varchar(500),
	@bitIsLive bit,
	@bitIsSearchable bit,
	@txtLastUpdatedBy varchar(101)

AS

	SET NOCOUNT ON

	UPDATE	dbo.Content

	SET
		Content = @txtContent,
		TextContent = @txtTextContent,
		Note = @txtNote,
		IsLive = @bitIsLive,
		IsSearchable = @bitIsSearchable,
		LastModified = GetDate(),
		LastModifiedBy = @txtLastUpdatedBy

	WHERE	ContentID = @intContentID
GO
/****** Object:  StoredProcedure [dbo].[AddCategory]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Stored Procedure dbo.AddCategory    Script Date: 11/12/2007 12:51:10 p.m. ******/


CREATE PROCEDURE [dbo].[AddCategory]
	-- Add the parameters for the function here
	@CategoryName nvarchar(64),
	@LogID int
AS
BEGIN
	SET NOCOUNT ON;
    DECLARE @CatID INT
	SELECT @CatID = CategoryID FROM Category WHERE CategoryName = @CategoryName
	IF @CatID IS NULL
	BEGIN
		INSERT INTO Category (CategoryName) VALUES(@CategoryName)
		SELECT @CatID = @@IDENTITY
	END

	EXEC InsertCategoryLog @CatID, @LogID 

	RETURN @CatID
END
GO
/****** Object:  StoredProcedure [dbo].[InsertCategoryLog]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Stored Procedure dbo.InsertCategoryLog    Script Date: 11/12/2007 12:51:10 p.m. ******/
CREATE PROCEDURE [dbo].[InsertCategoryLog]
	@CategoryID INT,
	@LogID INT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @CatLogID INT
	SELECT @CatLogID FROM CategoryLog WHERE CategoryID=@CategoryID and LogID = @LogID
	IF @CatLogID IS NULL
	BEGIN
		INSERT INTO CategoryLog (CategoryID, LogID) VALUES(@CategoryID, @LogID)
		RETURN @@IDENTITY
	END
	ELSE RETURN @CatLogID
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_CreateUser]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_CreateUser]
    @ApplicationName                        nvarchar(256),
    @UserName                               nvarchar(256),
    @Password                               nvarchar(128),
    @PasswordSalt                           nvarchar(128),
    @Email                                  nvarchar(256),
    @PasswordQuestion                       nvarchar(256),
    @PasswordAnswer                         nvarchar(128),
    @IsApproved                             bit,
    @CurrentTimeUtc                         datetime,
    @CreateDate                             datetime = NULL,
    @UniqueEmail                            int      = 0,
    @PasswordFormat                         int      = 0,
    @UserId                                 uniqueidentifier OUTPUT
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL

    DECLARE @NewUserId uniqueidentifier
    SELECT @NewUserId = NULL

    DECLARE @IsLockedOut bit
    SET @IsLockedOut = 0

    DECLARE @LastLockoutDate  datetime
    SET @LastLockoutDate = CONVERT( datetime, '17540101', 112 )

    DECLARE @FailedPasswordAttemptCount int
    SET @FailedPasswordAttemptCount = 0

    DECLARE @FailedPasswordAttemptWindowStart  datetime
    SET @FailedPasswordAttemptWindowStart = CONVERT( datetime, '17540101', 112 )

    DECLARE @FailedPasswordAnswerAttemptCount int
    SET @FailedPasswordAnswerAttemptCount = 0

    DECLARE @FailedPasswordAnswerAttemptWindowStart  datetime
    SET @FailedPasswordAnswerAttemptWindowStart = CONVERT( datetime, '17540101', 112 )

    DECLARE @NewUserCreated bit
    DECLARE @ReturnValue   int
    SET @ReturnValue = 0

    DECLARE @ErrorCode     int
    SET @ErrorCode = 0

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
	    BEGIN TRANSACTION
	    SET @TranStarted = 1
    END
    ELSE
    	SET @TranStarted = 0

    EXEC dbo.aspnet_Applications_CreateApplication @ApplicationName, @ApplicationId OUTPUT

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    SET @CreateDate = @CurrentTimeUtc

    SELECT  @NewUserId = UserId FROM dbo.aspnet_Users WHERE LOWER(@UserName) = LoweredUserName AND @ApplicationId = ApplicationId
    IF ( @NewUserId IS NULL )
    BEGIN
        SET @NewUserId = @UserId
        EXEC @ReturnValue = dbo.aspnet_Users_CreateUser @ApplicationId, @UserName, 0, @CreateDate, @NewUserId OUTPUT
        SET @NewUserCreated = 1
    END
    ELSE
    BEGIN
        SET @NewUserCreated = 0
        IF( @NewUserId <> @UserId AND @UserId IS NOT NULL )
        BEGIN
            SET @ErrorCode = 6
            GOTO Cleanup
        END
    END

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    IF( @ReturnValue = -1 )
    BEGIN
        SET @ErrorCode = 10
        GOTO Cleanup
    END

    IF ( EXISTS ( SELECT UserId
                  FROM   dbo.aspnet_Membership
                  WHERE  @NewUserId = UserId ) )
    BEGIN
        SET @ErrorCode = 6
        GOTO Cleanup
    END

    SET @UserId = @NewUserId

    IF (@UniqueEmail = 1)
    BEGIN
        IF (EXISTS (SELECT *
                    FROM  dbo.aspnet_Membership m WITH ( UPDLOCK, HOLDLOCK )
                    WHERE ApplicationId = @ApplicationId AND LoweredEmail = LOWER(@Email)))
        BEGIN
            SET @ErrorCode = 7
            GOTO Cleanup
        END
    END

    IF (@NewUserCreated = 0)
    BEGIN
        UPDATE dbo.aspnet_Users
        SET    LastActivityDate = @CreateDate
        WHERE  @UserId = UserId
        IF( @@ERROR <> 0 )
        BEGIN
            SET @ErrorCode = -1
            GOTO Cleanup
        END
    END

    INSERT INTO dbo.aspnet_Membership
                ( ApplicationId,
                  UserId,
                  Password,
                  PasswordSalt,
                  Email,
                  LoweredEmail,
                  PasswordQuestion,
                  PasswordAnswer,
                  PasswordFormat,
                  IsApproved,
                  IsLockedOut,
                  CreateDate,
                  LastLoginDate,
                  LastPasswordChangedDate,
                  LastLockoutDate,
                  FailedPasswordAttemptCount,
                  FailedPasswordAttemptWindowStart,
                  FailedPasswordAnswerAttemptCount,
                  FailedPasswordAnswerAttemptWindowStart )
         VALUES ( @ApplicationId,
                  @UserId,
                  @Password,
                  @PasswordSalt,
                  @Email,
                  LOWER(@Email),
                  @PasswordQuestion,
                  @PasswordAnswer,
                  @PasswordFormat,
                  @IsApproved,
                  @IsLockedOut,
                  @CreateDate,
                  @CreateDate,
                  @CreateDate,
                  @LastLockoutDate,
                  @FailedPasswordAttemptCount,
                  @FailedPasswordAttemptWindowStart,
                  @FailedPasswordAnswerAttemptCount,
                  @FailedPasswordAnswerAttemptWindowStart )

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    IF( @TranStarted = 1 )
    BEGIN
	    SET @TranStarted = 0
	    COMMIT TRANSACTION
    END

    RETURN 0

Cleanup:

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
    	ROLLBACK TRANSACTION
    END

    RETURN @ErrorCode

END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationAllUsers_SetPageSettings]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_PersonalizationAllUsers_SetPageSettings] (
    @ApplicationName  NVARCHAR(256),
    @Path             NVARCHAR(256),
    @PageSettings     IMAGE,
    @CurrentTimeUtc   DATETIME)
AS
BEGIN
    DECLARE @ApplicationId UNIQUEIDENTIFIER
    DECLARE @PathId UNIQUEIDENTIFIER

    SELECT @ApplicationId = NULL
    SELECT @PathId = NULL

    EXEC dbo.aspnet_Applications_CreateApplication @ApplicationName, @ApplicationId OUTPUT

    SELECT @PathId = u.PathId FROM dbo.aspnet_Paths u WHERE u.ApplicationId = @ApplicationId AND u.LoweredPath = LOWER(@Path)
    IF (@PathId IS NULL)
    BEGIN
        EXEC dbo.aspnet_Paths_CreatePath @ApplicationId, @Path, @PathId OUTPUT
    END

    IF (EXISTS(SELECT PathId FROM dbo.aspnet_PersonalizationAllUsers WHERE PathId = @PathId))
        UPDATE dbo.aspnet_PersonalizationAllUsers SET PageSettings = @PageSettings, LastUpdatedDate = @CurrentTimeUtc WHERE PathId = @PathId
    ELSE
        INSERT INTO dbo.aspnet_PersonalizationAllUsers(PathId, PageSettings, LastUpdatedDate) VALUES (@PathId, @PageSettings, @CurrentTimeUtc)
    RETURN 0
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationPerUser_SetPageSettings]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_PersonalizationPerUser_SetPageSettings] (
    @ApplicationName  NVARCHAR(256),
    @UserName         NVARCHAR(256),
    @Path             NVARCHAR(256),
    @PageSettings     IMAGE,
    @CurrentTimeUtc   DATETIME)
AS
BEGIN
    DECLARE @ApplicationId UNIQUEIDENTIFIER
    DECLARE @PathId UNIQUEIDENTIFIER
    DECLARE @UserId UNIQUEIDENTIFIER

    SELECT @ApplicationId = NULL
    SELECT @PathId = NULL
    SELECT @UserId = NULL

    EXEC dbo.aspnet_Applications_CreateApplication @ApplicationName, @ApplicationId OUTPUT

    SELECT @PathId = u.PathId FROM dbo.aspnet_Paths u WHERE u.ApplicationId = @ApplicationId AND u.LoweredPath = LOWER(@Path)
    IF (@PathId IS NULL)
    BEGIN
        EXEC dbo.aspnet_Paths_CreatePath @ApplicationId, @Path, @PathId OUTPUT
    END

    SELECT @UserId = u.UserId FROM dbo.aspnet_Users u WHERE u.ApplicationId = @ApplicationId AND u.LoweredUserName = LOWER(@UserName)
    IF (@UserId IS NULL)
    BEGIN
        EXEC dbo.aspnet_Users_CreateUser @ApplicationId, @UserName, 0, @CurrentTimeUtc, @UserId OUTPUT
    END

    UPDATE   dbo.aspnet_Users WITH (ROWLOCK)
    SET      LastActivityDate = @CurrentTimeUtc
    WHERE    UserId = @UserId
    IF (@@ROWCOUNT = 0) -- Username not found
        RETURN

    IF (EXISTS(SELECT PathId FROM dbo.aspnet_PersonalizationPerUser WHERE UserId = @UserId AND PathId = @PathId))
        UPDATE dbo.aspnet_PersonalizationPerUser SET PageSettings = @PageSettings, LastUpdatedDate = @CurrentTimeUtc WHERE UserId = @UserId AND PathId = @PathId
    ELSE
        INSERT INTO dbo.aspnet_PersonalizationPerUser(UserId, PathId, PageSettings, LastUpdatedDate) VALUES (@UserId, @PathId, @PageSettings, @CurrentTimeUtc)
    RETURN 0
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Profile_SetProperties]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Profile_SetProperties]
    @ApplicationName        nvarchar(256),
    @PropertyNames          ntext,
    @PropertyValuesString   ntext,
    @PropertyValuesBinary   image,
    @UserName               nvarchar(256),
    @IsUserAnonymous        bit,
    @CurrentTimeUtc         datetime
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL

    DECLARE @ErrorCode     int
    SET @ErrorCode = 0

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
       BEGIN TRANSACTION
       SET @TranStarted = 1
    END
    ELSE
    	SET @TranStarted = 0

    EXEC dbo.aspnet_Applications_CreateApplication @ApplicationName, @ApplicationId OUTPUT

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    DECLARE @UserId uniqueidentifier
    DECLARE @LastActivityDate datetime
    SELECT  @UserId = NULL
    SELECT  @LastActivityDate = @CurrentTimeUtc

    SELECT @UserId = UserId
    FROM   dbo.aspnet_Users
    WHERE  ApplicationId = @ApplicationId AND LoweredUserName = LOWER(@UserName)
    IF (@UserId IS NULL)
        EXEC dbo.aspnet_Users_CreateUser @ApplicationId, @UserName, @IsUserAnonymous, @LastActivityDate, @UserId OUTPUT

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    UPDATE dbo.aspnet_Users
    SET    LastActivityDate=@CurrentTimeUtc
    WHERE  UserId = @UserId

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    IF (EXISTS( SELECT *
               FROM   dbo.aspnet_Profile
               WHERE  UserId = @UserId))
        UPDATE dbo.aspnet_Profile
        SET    PropertyNames=@PropertyNames, PropertyValuesString = @PropertyValuesString,
               PropertyValuesBinary = @PropertyValuesBinary, LastUpdatedDate=@CurrentTimeUtc
        WHERE  UserId = @UserId
    ELSE
        INSERT INTO dbo.aspnet_Profile(UserId, PropertyNames, PropertyValuesString, PropertyValuesBinary, LastUpdatedDate)
             VALUES (@UserId, @PropertyNames, @PropertyValuesString, @PropertyValuesBinary, @CurrentTimeUtc)

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    IF( @TranStarted = 1 )
    BEGIN
    	SET @TranStarted = 0
    	COMMIT TRANSACTION
    END

    RETURN 0

Cleanup:

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
    	ROLLBACK TRANSACTION
    END

    RETURN @ErrorCode

END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Roles_CreateRole]    Script Date: 10/28/2009 12:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Roles_CreateRole]
    @ApplicationName  nvarchar(256),
    @RoleName         nvarchar(256)
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL

    DECLARE @ErrorCode     int
    SET @ErrorCode = 0

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
        BEGIN TRANSACTION
        SET @TranStarted = 1
    END
    ELSE
        SET @TranStarted = 0

    EXEC dbo.aspnet_Applications_CreateApplication @ApplicationName, @ApplicationId OUTPUT

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    IF (EXISTS(SELECT RoleId FROM dbo.aspnet_Roles WHERE LoweredRoleName = LOWER(@RoleName) AND ApplicationId = @ApplicationId))
    BEGIN
        SET @ErrorCode = 1
        GOTO Cleanup
    END

    INSERT INTO dbo.aspnet_Roles
                (ApplicationId, RoleName, LoweredRoleName)
         VALUES (@ApplicationId, @RoleName, LOWER(@RoleName))

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
        COMMIT TRANSACTION
    END

    RETURN(0)

Cleanup:

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
        ROLLBACK TRANSACTION
    END

    RETURN @ErrorCode

END
GO

-- #### END of: Blank Database creation ############################################################



-- #### Morphfolia System Record Set-up ############################################################

 SELECT * FROM dbo.Page
-- DELETE FROM [Page]

DECLARE @dt datetime, @count int
SET @dt = GetDate()

----------------------------------------------------------------------------------------------
-- Expected Pages
----------------------------------------------------------------------------------------------
SELECT @count = Count(*) FROM [Page] WHERE [Url]='login.aspx'
IF @count = 0
BEGIN
	INSERT INTO [Page] ( [Title], [Url], [MetaKeywords], [MetaDescription], LastModified, LastModifiedBy, [IsSearchable], [IsLive])
	VALUES('Login', 'login.aspx', '', '', @dt, 'Administrator', 0, 1)
END

SELECT @count = Count(*) FROM [Page] WHERE [Url]='sitemap.aspx'
IF @count = 0
BEGIN
	INSERT INTO [Page] ( [Title], [Url], [MetaKeywords], [MetaDescription], LastModified, LastModifiedBy, [IsSearchable], [IsLive])
	VALUES('Site Map', 'sitemap.aspx', '', '', @dt, 'Administrator', 0, 1)
END

SELECT @count = Count(*) FROM [Page] WHERE [Url]='siteindex.aspx'
IF @count = 0
BEGIN
	INSERT INTO [Page] ( [Title], [Url], [MetaKeywords], [MetaDescription], LastModified, LastModifiedBy, [IsSearchable], [IsLive])
	VALUES('Site Index', 'siteindex.aspx', '', '', @dt, 'Administrator', 1, 1)
END

SELECT @count = Count(*) FROM [Page] WHERE [Url]='searchresults.aspx'
IF @count = 0
BEGIN
	INSERT INTO [Page] ( [Title], [Url], [MetaKeywords], [MetaDescription], LastModified, LastModifiedBy, [IsSearchable], [IsLive])
	VALUES('Search Results', 'searchresults.aspx', '', '', @dt, 'Administrator', 0, 1)
END

SELECT @count = Count(*) FROM [Page] WHERE [Url]='register.aspx'
IF @count = 0
BEGIN
	INSERT INTO [Page] ( [Title], [Url], [MetaKeywords], [MetaDescription], LastModified, LastModifiedBy, [IsSearchable], [IsLive])
	VALUES('Register', 'register.aspx', '', '', @dt, 'Administrator', 1, 1)
END

SELECT @count = Count(*) FROM [Page] WHERE [Url]='default.aspx'
IF @count = 0
BEGIN
	INSERT INTO [Page] ( [Title], [Url], [MetaKeywords], [MetaDescription], LastModified, LastModifiedBy, [IsSearchable], [IsLive])
	VALUES('Welcome', 'default.aspx', '', '', @dt, 'Administrator', 1, 1)
END

----------------------------------------------------------------------------------------------
-- Expected "PropertyType" records
----------------------------------------------------------------------------------------------
SELECT @count = Count(*) FROM [PropertyType] WHERE [ID]='CONT'
IF @count = 0
BEGIN
	INSERT INTO [PropertyType]([ID], [PropertyType])VALUES('CONT', 'Content Item Container')
END

SELECT @count = Count(*) FROM [PropertyType] WHERE [ID]='CUST'
IF @count = 0
BEGIN
	INSERT INTO [PropertyType]([ID], [PropertyType])VALUES('CUST', 'Custom Property')
END

SELECT @count = Count(*) FROM [PropertyType] WHERE [ID]='GOBL'
IF @count = 0
BEGIN
	INSERT INTO [PropertyType]([ID], [PropertyType])VALUES('GOBL', 'Site-wide setting')
END

SELECT @count = Count(*) FROM [PropertyType] WHERE [ID]='BPST'
IF @count = 0
BEGIN
	INSERT INTO [PropertyType]([ID], [PropertyType])VALUES('BPST', 'A link between a blog (Page) and a blog-post (Content Item)')
END

SELECT * FROM dbo.PropertyType
/*
CONT	Content Item Container
CUST	Custom Property
GOBL	Golbal, site-wide setting

INSERT INTO [PropertyType]([ID], [PropertyType])VALUES('CONT', 'Content Item Container')
INSERT INTO [PropertyType]([ID], [PropertyType])VALUES('CUST', 'Custom Property')
*/

-- #### END of: Morphfolia System Record Set-up ############################################################



-- #### AspNet Membership Record Setup ############################################################

DECLARE @UserName nvarchar(256), @Password nvarchar(128), @Email nvarchar(256), @PasswordQuestion nvarchar(256), @PasswordAnswer nvarchar(128)
SET @UserName = 'TestUser'
SET @Password = 'TestUser@'
SET @Email = 'TestUser@where.i.am'
SET @PasswordQuestion = 'something'
SET @PasswordAnswer = 'something'

SELECT * FROM dbo.aspnet_Applications
SELECT * FROM dbo.aspnet_Roles
SELECT * FROM dbo.aspnet_Users
SELECT * FROM dbo.aspnet_Membership
SELECT * FROM dbo.aspnet_UsersInRoles
--SELECT * FROM dbo.aspnet_Paths
--SELECT * FROM dbo.aspnet_PersonalizationAllUsers
--SELECT * FROM dbo.aspnet_PersonalizationPerUser
--SELECT * FROM dbo.aspnet_Profile
SELECT * FROM dbo.aspnet_SchemaVersions

--SELECT * FROM dbo.aspnet_WebEvent_Events





---------------------------------------------------------------------------
-- Insert Application Record
---------------------------------------------------------------------------
DECLARE @RC int
DECLARE @ApplicationName nvarchar(256)
DECLARE @ApplicationId uniqueidentifier

SET @ApplicationName = 'Morphfolia'
EXEC @RC = [aspnet_Applications_CreateApplication] @ApplicationName, @ApplicationId OUTPUT 

---------------------------------------------------------------------------
-- Insert Role Records
---------------------------------------------------------------------------
DECLARE @RoleName nvarchar(256)
DECLARE @RoleId uniqueidentifier

SET @RoleName = 'Member'
SELECT @count = Count(*) FROM [aspnet_Roles] WHERE [RoleName]=@RoleName
IF @count = 0
BEGIN
	SET @RoleId = NEWID()
	INSERT INTO aspnet_Roles (ApplicationId, RoleId, RoleName, LoweredRoleName) VALUES (@ApplicationId, @RoleId, @RoleName, LOWER(@RoleName))
END

SET @RoleName = 'Administrator'
SELECT @count = Count(*) FROM [aspnet_Roles] WHERE [RoleName]=@RoleName
IF @count = 0
BEGIN
	SET @RoleId = NEWID()
	INSERT INTO aspnet_Roles (ApplicationId, RoleId, RoleName, LoweredRoleName) VALUES (@ApplicationId, @RoleId, @RoleName, LOWER(@RoleName))
END



---------------------------------------------------------------------------
-- Insert 'Administrator' User Record and associated Membership Records
---------------------------------------------------------------------------
DECLARE @PasswordSalt nvarchar(128)
DECLARE @IsApproved bit
DECLARE @CurrentTimeUtc datetime
DECLARE @CreateDate datetime
DECLARE @UniqueEmail int
DECLARE @PasswordFormat int
DECLARE @UserId uniqueidentifier

SET @UserId = null
SET @PasswordSalt = 'ftl87RM1HKUd5yk2Uz7lLw=='
SET @IsApproved = 1
SET @CurrentTimeUtc = GetDate()
SET @CreateDate = GetDate()
SET @UniqueEmail = 0
SET @PasswordFormat = 0

SELECT @count = Count(*) FROM [aspnet_Users] WHERE [UserName]=@UserName
IF @count = 0
BEGIN
	EXEC @RC = [aspnet_Membership_CreateUser] @ApplicationName, @UserName, @Password, @PasswordSalt, @Email, @PasswordQuestion, @PasswordAnswer, @IsApproved, @CurrentTimeUtc, @CreateDate, @UniqueEmail, @PasswordFormat, @UserId OUTPUT 
END

---------------------------------------------------------------------------
-- Insert 'Administrator' User Record and associated Membership Records
---------------------------------------------------------------------------
DECLARE @Feature nvarchar(128)

SET @Feature = 'common'
SELECT @count = Count(*) FROM [aspnet_SchemaVersions] WHERE [Feature]=@Feature
IF @count = 0
BEGIN
	INSERT INTO [aspnet_SchemaVersions]([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (@Feature, '1', 1)
END

SET @Feature = 'health monitoring'
SELECT @count = Count(*) FROM [aspnet_SchemaVersions] WHERE [Feature]=@Feature
IF @count = 0
BEGIN
	INSERT INTO [aspnet_SchemaVersions]([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (@Feature, '1', 1)
END

SET @Feature = 'membership'
SELECT @count = Count(*) FROM [aspnet_SchemaVersions] WHERE [Feature]=@Feature
IF @count = 0
BEGIN
	INSERT INTO [aspnet_SchemaVersions]([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (@Feature, '1', 1)
END

SET @Feature = 'personalization'
SELECT @count = Count(*) FROM [aspnet_SchemaVersions] WHERE [Feature]=@Feature
IF @count = 0
BEGIN
	INSERT INTO [aspnet_SchemaVersions]([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (@Feature, '1', 1)
END

SET @Feature = 'profile'
SELECT @count = Count(*) FROM [aspnet_SchemaVersions] WHERE [Feature]=@Feature
IF @count = 0
BEGIN
	INSERT INTO [aspnet_SchemaVersions]([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (@Feature, '1', 1)
END

SET @Feature = 'role manager'
SELECT @count = Count(*) FROM [aspnet_SchemaVersions] WHERE [Feature]=@Feature
IF @count = 0
BEGIN
	INSERT INTO [aspnet_SchemaVersions]([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (@Feature, '1', 1)
END

---------------------------------------------------------------------------
-- Insert 'Administrator' User Record and associated Membership Records
---------------------------------------------------------------------------
SELECT @RoleId = RoleId FROM [aspnet_Roles] WHERE [RoleName]=@RoleName
SELECT @UserId = UserId FROM [aspnet_Users] WHERE [UserName]=@UserName

EXEC @RC = [aspnet_UsersInRoles_IsUserInRole] @ApplicationName, @UserName, @RoleName

IF @RC = 0
BEGIN
	EXEC @RC = [aspnet_UsersInRoles_AddUsersToRoles] @ApplicationName, @UserName, @RoleName, @CurrentTimeUtc
END
SELECT * FROM dbo.aspnet_UsersInRoles



exec spGrantExectoAllStoredProcs 'ASPNET'


GRANT SELECT ON dbo.[Log] TO ASPNET
GRANT SELECT ON dbo.[aspnet_Users] TO ASPNET
GRANT SELECT ON dbo.Content TO ASPNET
GRANT SELECT ON dbo.Page TO ASPNET
GRANT SELECT ON dbo.ContentIndex_Default TO ASPNET
GRANT SELECT ON dbo.ContentIndex_A TO ASPNET
GRANT SELECT ON dbo.ContentIndex_B TO ASPNET
GRANT SELECT ON dbo.ContentIndex_C TO ASPNET
GRANT SELECT ON dbo.ContentIndex_D TO ASPNET
GRANT SELECT ON dbo.ContentIndex_E TO ASPNET
GRANT SELECT ON dbo.ContentIndex_F TO ASPNET
GRANT SELECT ON dbo.ContentIndex_G TO ASPNET
GRANT SELECT ON dbo.ContentIndex_H TO ASPNET
GRANT SELECT ON dbo.ContentIndex_I TO ASPNET
GRANT SELECT ON dbo.ContentIndex_J TO ASPNET
GRANT SELECT ON dbo.ContentIndex_K TO ASPNET
GRANT SELECT ON dbo.ContentIndex_L TO ASPNET
GRANT SELECT ON dbo.ContentIndex_M TO ASPNET
GRANT SELECT ON dbo.ContentIndex_N TO ASPNET
GRANT SELECT ON dbo.ContentIndex_O TO ASPNET
GRANT SELECT ON dbo.ContentIndex_P TO ASPNET
GRANT SELECT ON dbo.ContentIndex_Q TO ASPNET
GRANT SELECT ON dbo.ContentIndex_R TO ASPNET
GRANT SELECT ON dbo.ContentIndex_S TO ASPNET
GRANT SELECT ON dbo.ContentIndex_T TO ASPNET
GRANT SELECT ON dbo.ContentIndex_U TO ASPNET
GRANT SELECT ON dbo.ContentIndex_V TO ASPNET
GRANT SELECT ON dbo.ContentIndex_W TO ASPNET
GRANT SELECT ON dbo.ContentIndex_X TO ASPNET
GRANT SELECT ON dbo.ContentIndex_Y TO ASPNET
GRANT SELECT ON dbo.ContentIndex_Z TO ASPNET
GRANT SELECT ON dbo.ControlProperties TO ASPNET
GRANT SELECT ON dbo.PropertyType TO ASPNET
GRANT SELECT ON dbo.HttpLog TO ASPNET

-- #### END of: AspNet Membership Record Setup ############################################################