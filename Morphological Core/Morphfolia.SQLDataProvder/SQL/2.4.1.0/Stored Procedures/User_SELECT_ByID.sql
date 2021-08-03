/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[User_SELECT_ByID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[User_SELECT_ByID]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure User_SELECT_ByID

-- User_SELECT_ByID 1

	@intUserID int

AS

	SET NOCOUNT ON

	SELECT	U.UserID,
			U.FirstName, 
			U.LastName, 
			U.[Email], 
			U.[Password], 
			U.Role, 
			U.IsActive

	FROM	dbo.[CMSUser] U

	WHERE	U.[UserID] = @intUserID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

