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

/****** Object:  Stored Procedure dbo.Image_INSERT    Script Date: 23/05/2006 8:31:32 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Image_INSERT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Image_INSERT]
GO

/****** Object:  Stored Procedure dbo.Image_INSERT    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure Image_INSERT

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

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

