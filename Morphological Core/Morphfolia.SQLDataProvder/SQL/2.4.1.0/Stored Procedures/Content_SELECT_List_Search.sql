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

/****** Object:  Stored Procedure dbo.Content_SELECT_List_Search    Script Date: 27/11/2005 4:05:16 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Content_SELECT_List_Search]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Content_SELECT_List_Search]
GO



/****** Object:  Stored Procedure dbo.Content_SELECT_List_Search    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure Content_SELECT_List_Search

	@txtNotes varchar(25),
	@txtContentType char(4) = '____'

AS

	SET NOCOUNT ON
	-- Content_SELECT_List_Search '%a%'
	-- Content_SELECT_List_Search '%a%', 'CONT'

	IF @txtContentType = '____'
	BEGIN

		SELECT	C.ContentID, 
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.LastModified, 
				C.LastModifiedBy,
				(SELECT Count(*) FROM dbo.ControlProperties CP WHERE PropertyType = 'CONT' AND PropertyValue = C.ContentID) PageUsageCount

		FROM		dbo.Content C

		WHERE		C.Note LIKE @txtNotes
		
		ORDER BY 	C.Note,
					C.ContentID

	END
	ELSE
	BEGIN

		SELECT	C.ContentID, 
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.LastModified, 
				C.LastModifiedBy,
				(SELECT Count(*) FROM dbo.ControlProperties CP WHERE PropertyType = 'CONT' AND PropertyValue = C.ContentID) PageUsageCount

		FROM		dbo.Content C

		WHERE		C.Note LIKE @txtNotes
			AND		C.ContentType = @txtContentType
		
		ORDER BY 	C.Note,
					C.ContentID
	END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

