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

/****** Object:  Stored Procedure dbo.Content_UPDATE    Script Date: 27/11/2005 7:09:00 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Content_UPDATE]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Content_UPDATE]
GO



/****** Object:  Stored Procedure dbo.Content_UPDATE    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure Content_UPDATE

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

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

