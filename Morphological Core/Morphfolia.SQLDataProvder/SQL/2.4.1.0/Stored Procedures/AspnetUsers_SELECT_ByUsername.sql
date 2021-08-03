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

/****** Object:  Stored Procedure AspnetUsers_SELECT_ByUsername    Script Date: 23/03/2008 4:17:34 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AspnetUsers_SELECT_ByUsername]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AspnetUsers_SELECT_ByUsername]
GO

/****** Object:  Stored Procedure AspnetUsers_SELECT_ByUsername    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure AspnetUsers_SELECT_ByUsername

	@txtUserName nvarchar(256)

AS

	-- AspnetUsers_SELECT_ByUsername '%'
	-- AspnetUsers_SELECT_ByUsername 'A%'

	SET NOCOUNT ON

	SELECT	*
	FROM	dbo.aspnet_Users
	
	WHERE	UserName LIKE @txtUserName

	ORDER BY UserName

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

