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

/****** Object:  Stored Procedure dbo.Content_SELECT    Script Date: 13/03/2007 2:01:04 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Content_SELECT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Content_SELECT]
GO


/****** Object:  Stored Procedure dbo.Content_SELECT    Script Date: 10/02/2007 8:11:37 p.m. ******/
/****** Object:  Stored Procedure dbo.Content_SELECT    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure Content_SELECT

	@txtContentType char(4) = '____'

AS

	SET NOCOUNT ON

	IF @txtContentType = '____'
	BEGIN

		SELECT	C.ContentID, 
				C.Content,
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.ContentFilter,
				C.LastModified, 
				C.LastModifiedBy

		FROM	dbo.Content C
		
		ORDER BY C.LastModified

	END
	ELSE
	BEGIN

		SELECT	C.ContentID, 
				C.Content,
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.ContentFilter,
				C.LastModified, 
				C.LastModifiedBy

		FROM	dbo.Content C

		WHERE	C.ContentType = @txtContentType
		
		ORDER BY C.LastModified

	END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

