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

/****** Object:  Stored Procedure dbo.User_UPDATE    Script Date: 27/11/2005 7:09:00 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[User_UPDATE]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[User_UPDATE]
GO



/****** Object:  Stored Procedure dbo.User_UPDATE    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure User_UPDATE

	-- User_UPDATE 1

	--UserID, FirstName, LastName, Email, Password, Role, IsActive

	@intUserID int,
	@txtFirstName varchar(50),
	@txtLastName varchar(50),
	@txtEmail varchar(500),
	@txtPassword varchar(20),
	@txtRole char(4),
	@bitIsActive bit

AS

	SET NOCOUNT ON

	UPDATE	dbo.[CMSUser]

	SET
		FirstName = @txtFirstName, 
		LastName = @txtLastName, 
		Email = @txtEmail, 
		[Password] = @txtPassword, 
		Role = @txtRole, 
		IsActive = @bitIsActive

	WHERE	UserID = @intUserID


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

