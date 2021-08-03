/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Page_UPDATE]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Page_UPDATE]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure Page_UPDATE

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
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

