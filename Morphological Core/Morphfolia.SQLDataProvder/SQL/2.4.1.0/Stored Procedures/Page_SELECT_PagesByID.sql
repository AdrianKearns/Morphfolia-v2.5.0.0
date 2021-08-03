/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Page_SELECT_PagesByID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Page_SELECT_PagesByID]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure Page_SELECT_PagesByID

	@intPageId1 int,
	@intPageId2 int = 0,
	@intPageId3 int = 0,
	@intPageId4 int = 0,
	@intPageId5 int = 0

AS

	-- Page_SELECT_PagesByID 1
	-- Page_SELECT_PagesByID 1, 2, 3
	-- Page_SELECT_PagesByID 1, 2, 3, 4, 5
	SET NOCOUNT ON

	SELECT	P.PageID, 
			P.Title, 
			P.Url, 
			P.MetaKeywords, 
			P.MetaDescription, 
			P.LastModified,
			P.LastModifiedBy,
			P.IsSearchable,
			P.IsLive

	FROM	dbo.Page P

	WHERE	(
		P.PageID = @intPageId1 OR
		P.PageID = @intPageId2 OR
		P.PageID = @intPageId3 OR
		P.PageID = @intPageId4 OR
		P.PageID = @intPageId5
	)

	ORDER BY
			P.Title, P.PageID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

