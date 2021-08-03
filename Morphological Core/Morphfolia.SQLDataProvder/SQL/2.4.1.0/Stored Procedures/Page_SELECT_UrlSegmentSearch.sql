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

/****** Object:  Stored Procedure dbo.Page_SELECT_UrlSegmentSearch    Script Date: 7/08/2006 7:38:09 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Page_SELECT_UrlSegmentSearch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Page_SELECT_UrlSegmentSearch]
GO

CREATE Procedure Page_SELECT_UrlSegmentSearch
	
	-- SELECT P.Url FROM dbo.Page P
	-- Page_SELECT_UrlSegmentSearch 'a/b/default.aspx'

	@txtUrlHint varchar(1000)

AS

	SET NOCOUNT ON

	SELECT	DISTINCT P.Url

	FROM	dbo.Page P

	WHERE	P.Url LIKE @txtUrlHint

	ORDER BY P.Url DESC
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

