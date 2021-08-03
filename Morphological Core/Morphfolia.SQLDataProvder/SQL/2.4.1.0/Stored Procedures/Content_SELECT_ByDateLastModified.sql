/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */



/****** Object:  StoredProcedure [dbo].[Content_SELECT_ByDateLastModified]    Script Date: 05/27/2009 13:10:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Content_SELECT_ByDateLastModified]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Content_SELECT_ByDateLastModified]



/****** Object:  StoredProcedure [dbo].[Content_SELECT_ByDateLastModified]    Script Date: 05/27/2009 13:10:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO




/****** Object:  Stored Procedure dbo.Content_SELECT_ByContentID    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_ByDateLastModified]

	-- Content_SELECT_ByDateLastModified '2009-01-09 00:00:00.000', '2009-04-09 23:59:59.000'


	@startDate datetime,
	@endDate datetime

AS

	-- Content_SELECT_ByDateLastModified '2008-04-10 10:46:23.153', '2010-04-10 10:46:23.153'

	SET NOCOUNT ON


	SELECT	C.ContentID, 
			C.Note ContentNote, 
			C.Content,
			C.ContentType,
			C.IsLive ContentIsLive, 
			C.IsSearchable ContentIsSearchable, 
			C.ContentFilter ContentEntryFilter,
			C.LastModified ContentLastModified, 
			C.LastModifiedBy ContentLastModifiedBy

			--P.PageID,
			--P.Title PageTitle, 
			--P.Url PageUrl, 
			--P.MetaKeywords PageKeywords, 
			--P.MetaDescription PageDescription, 
			--P.LastModified PageLastModified,
			--P.LastModifiedBy PageLastModifiedBy,
			--P.IsSearchable PageIsSearchable,
			--P.IsLive PageIsLive

	FROM	dbo.Content C
		INNER JOIN ControlProperties Props ON C.ContentId = Props.PropertyValue 
		INNER JOIN Page P ON Props.InstanceID = P.PageID

	WHERE 	Props.PropertyKey = 'BlogPost'
	AND		(C.LastModified >= @startDate AND C.LastModified < @endDate)
	AND		P.IsLive = 1
	AND		C.IsLive = 1

	ORDER BY C.LastModified DESC
