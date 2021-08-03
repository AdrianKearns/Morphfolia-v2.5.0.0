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

/****** Object:  Stored Procedure dbo.ContentMarshal_INSERT_ContentItemForPage    Script Date: 19/11/2005 4:20:34 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ContentMarshal_INSERT_ContentItemForPage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ContentMarshal_INSERT_ContentItemForPage]
GO


CREATE Procedure ContentMarshal_INSERT_ContentItemForPage

	@intPageID int,
	@intContentID int,
	@intSortOrder int

AS

	SET NOCOUNT ON

	INSERT INTO [dbo].[ContentMarshal]([PageID], [ContentID], [SortOrder])
	VALUES (
		@intPageID,
		@intContentID,
		@intSortOrder
	)

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

