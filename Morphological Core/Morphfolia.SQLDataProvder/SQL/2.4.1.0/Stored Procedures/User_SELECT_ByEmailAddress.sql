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

/****** Object:  Stored Procedure dbo.User_SELECT_ByEmailAddress    Script Date: 22/05/2006 9:35:14 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[User_SELECT_ByEmailAddress]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[User_SELECT_ByEmailAddress]
GO

CREATE Procedure User_SELECT_ByEmailAddress

-- User_SELECT_ByEmailAddress 1

	@txtEmail varchar(500)

AS

	SET NOCOUNT ON

	SELECT	TOP 1
			U.UserID,
			U.FirstName, 
			U.LastName, 
			U.[Email], 
			U.[Password], 
			U.Role, 
			U.IsActive

	FROM	dbo.[CMSUser] U
	WHERE	U.[Email] = @txtEmail
	AND		U.IsActive = 1

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

