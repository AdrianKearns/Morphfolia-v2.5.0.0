/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Page_SELECT_ListSearch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Page_SELECT_ListSearch]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure Page_SELECT_ListSearch

	@bIsSearchable bit,
	@bIsLive bit

AS

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

	WHERE	P.IsSearchable = @bIsSearchable
	AND		P.IsLive = @bIsLive

	ORDER BY
			P.Url, P.PageID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

