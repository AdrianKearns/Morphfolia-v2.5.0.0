/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/****** Object:  Stored Procedure dbo.User_INSERT    Script Date: 27/11/2005 7:09:00 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[User_INSERT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[User_INSERT]
GO



/****** Object:  Stored Procedure dbo.User_INSERT    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure User_INSERT

	-- User_INSERT 1

	--UserID, FirstName, LastName, Email, Password, Role, IsActive

	@IDENTITY int OUTPUT,
	@txtFirstName varchar(50),
	@txtLastName varchar(50),
	@txtEmail varchar(500),
	@txtPassword varchar(20),
	@txtRole char(4),
	@bitIsActive bit

AS

	SET NOCOUNT ON
	
	INSERT INTO [dbo].[CMSUser] (
		[FirstName], 
		[LastName], 
		[Email], 
		[Password], 
		[Role], 
		[IsActive])
	VALUES (
			@txtFirstName,
			@txtLastName,
			@txtEmail,
			@txtPassword,
			@txtRole,
			@bitIsActive
			)

	SELECT @IDENTITY = SCOPE_IDENTITY()


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

