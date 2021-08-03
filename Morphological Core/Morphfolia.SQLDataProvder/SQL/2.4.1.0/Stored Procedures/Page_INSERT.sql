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

/****** Object:  Stored Procedure dbo.Page_INSERT    Script Date: 27/11/2005 4:05:16 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Page_INSERT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Page_INSERT]
GO



/****** Object:  Stored Procedure dbo.Page_INSERT    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure Page_INSERT


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

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

