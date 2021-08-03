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

/****** Object:  Stored Procedure dbo.Content_INSERT    Script Date: 27/11/2005 4:05:16 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Content_INSERT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Content_INSERT]
GO



/****** Object:  Stored Procedure dbo.Content_INSERT    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure Content_INSERT


	@IDENTITY int OUTPUT,
	@txtContent ntext,
	@txtTextContent ntext,
	@txtNote varchar(500),
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
		@bitIsLive,
		@bitIsSearchable,
		@txtContentEntryFilter,
		GetDate(), 
		@txtLastUpdatedBy
	)


	SELECT @IDENTITY = SCOPE_IDENTITY()


 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

