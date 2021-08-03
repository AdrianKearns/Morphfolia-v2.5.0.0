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

/****** Object:  Stored Procedure dbo.Page_SELECT_ByChildContentItem    Script Date: 21/06/2007 8:20:28 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Page_SELECT_ByChildContentItem]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Page_SELECT_ByChildContentItem]
GO


/****** Object:  Stored Procedure dbo.Page_SELECT_ByChildContentItem    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure Page_SELECT_ByChildContentItem


	@intContentID int
AS

	-- Page_SELECT_ByChildContentItem 1

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

	WHERE 	PageID IN 
	(
		SELECT DISTINCT InstanceID FROM dbo.ControlProperties
		WHERE 	PropertyType = 'CONT'
		AND	PropertyValue = @intContentID
	)

	ORDER BY	P.Url, P.PageID

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

