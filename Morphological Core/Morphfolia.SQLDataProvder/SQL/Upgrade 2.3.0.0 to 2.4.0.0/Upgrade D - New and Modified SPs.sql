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






SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/****** Object:  Stored Procedure dbo.HttpLog_SELECT_HistoryByDateRange    Script Date: 2/09/2007 3:19:29 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[HttpLog_SELECT_HistoryByDateRange]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[HttpLog_SELECT_HistoryByDateRange]
GO



/****** Object:  Stored Procedure dbo.HttpLog_SELECT_HistoryByDateRange    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure HttpLog_SELECT_HistoryByDateRange

	@rangeStart datetime,
	@rangeEnd datetime

AS

	SET NOCOUNT ON

	-- HttpLog_SELECT_HistoryByDateRange '2001-1-1', '2009-12-31'

	-- HttpLog_SELECT_HistoryByDateRange '2009-3-3', '2009-3-4'


	SELECT	*
	FROM 	HttpLog 
	WHERE 	TimeLogged >= @rangeStart AND TimeLogged < @rangeEnd
	ORDER BY TimeLogged DESC

	





GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO








SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/****** Object:  Stored Procedure dbo.HttpLog_SELECT    Script Date: 2/09/2007 3:19:29 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[HttpLog_SELECT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[HttpLog_SELECT]
GO



/****** Object:  Stored Procedure dbo.HttpLog_SELECT    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure HttpLog_SELECT

	@rangeStart datetime,
	@rangeEnd datetime,
	@txtUrl varchar(500) = '%', 
	@txtUrlReferrer varchar(500) = '%', 
	@txtUserHostName varchar(50) = '%', 
	@txtSessionId varchar(50) = '%', 
	@txtMiscInfo varchar(500) = '%'

AS

	SET NOCOUNT ON

	-- HttpLog_SELECT '2001-1-1', '2009-12-31'
	-- HttpLog_SELECT '2001-1-1', '2009-12-31', '%?%'
	-- HttpLog_SELECT '2001-1-1', '2009-12-31', '%', '%', '%', '%', 'Browser%'

	-- HttpLog_SELECT '2009-3-3', '2009-3-4'

	SELECT	*
	FROM 	HttpLog 
	WHERE 	(TimeLogged >= @rangeStart AND TimeLogged < @rangeEnd)
	AND		Url LIKE @txtUrl
	AND		UrlReferrer LIKE @txtUrlReferrer
	AND		UserHostName LIKE @txtUserHostName
	AND		SessionId LIKE @txtSessionId
	AND		MiscInfo LIKE @txtMiscInfo
	ORDER BY TimeLogged DESC

	





GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO





















/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_CTagsForLiveBlog]    Script Date: 04/17/2009 15:37:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlProperties_SELECT_CTagsForLiveBlog]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ControlProperties_SELECT_CTagsForLiveBlog]



/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_CTagsForLiveBlog]    Script Date: 04/17/2009 14:59:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE Procedure [dbo].[ControlProperties_SELECT_CTagsForLiveBlog]

-- ControlProperties_SELECT_CTagsForLiveBlog 61
-- ControlProperties_SELECT_CTagsForLiveBlog 61, 1
-- ControlProperties_SELECT_CTagsForLiveBlog 61, 0
-- ControlProperties_SELECT_CTagsForLiveBlog 62, 1
-- ControlProperties_SELECT_CTagsForLiveBlog 62, 0
-- SELECT * FROM ControlProperties

	@intPageID int,
	@bOrderAlphabetically bit = 1

AS

	SET NOCOUNT ON

	IF @bOrderAlphabetically = 1
	BEGIN

		SELECT	CP.PropertyValue, Count(*) TagCount
		FROM	[ControlProperties] CP
			INNER JOIN [Content] C ON InstanceId = C.ContentId
		WHERE	[InstanceID] IN 
		(
			SELECT DISTINCT PropertyValue
			FROM 	[ControlProperties]
				INNER JOIN Page P ON InstanceId = P.PageId
			WHERE	PropertyType = 'BPST'
			AND		P.IsLive = 1
			AND		P.PageID = @intPageID
		)
		AND		CP.PropertyType = 'CTAG'
		AND		C.IsLive = 1
		GROUP BY PropertyValue
		ORDER BY PropertyValue

	END
	ELSE
	BEGIN

		SELECT	CP.PropertyValue, Count(*) TagCount
		FROM	[ControlProperties] CP
			INNER JOIN [Content] C ON InstanceId = C.ContentId
		WHERE	[InstanceID] IN 
		(
			SELECT DISTINCT PropertyValue
			FROM 	[ControlProperties]
				INNER JOIN Page P ON InstanceId = P.PageId
			WHERE	PropertyType = 'BPST'
			AND		P.IsLive = 1
			AND		P.PageID = @intPageID
		)
		AND		CP.PropertyType = 'CTAG'
		AND		C.IsLive = 1
		GROUP BY PropertyValue
		ORDER BY TagCount DESC

	END





GO




if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].ControlProperties_SELECT_BYPropertyType') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ControlProperties_SELECT_BYPropertyType
GO



CREATE Procedure ControlProperties_SELECT_BYPropertyType

	-- ControlProperties_SELECT_BYPropertyType 'BPST'
	-- ControlProperties_SELECT_BYPropertyType 'BPST', '109'
	-- SELECT * FROM ControlProperties

	@txtPropertyType char(4),
	@txtPropertyValue varchar(2000) = null

AS

	SET NOCOUNT ON

	IF @txtPropertyValue IS NULL
	BEGIN
		SELECT	[ID], 
			InstanceId,
			PropertyType,
			PropertyKey,
			PropertyValue
		FROM	[ControlProperties]
		WHERE 	PropertyType = @txtPropertyType
		ORDER BY InstanceId, [ID]
	END
	ELSE
	BEGIN
		SELECT	[ID], 
			InstanceId,
			PropertyType,
			PropertyKey,
			PropertyValue
		FROM	[ControlProperties]
		WHERE 	PropertyType = @txtPropertyType
		AND		PropertyValue = @txtPropertyValue
		ORDER BY InstanceId, [ID]
	END

GO











/****** Object:  StoredProcedure [dbo].[ControlProperties_SELECT_BlogPostsByCTag]    Script Date: 04/17/2009 15:37:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlProperties_SELECT_BlogPostsByCTag]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ControlProperties_SELECT_BlogPostsByCTag]

GO




CREATE Procedure [dbo].[ControlProperties_SELECT_BlogPostsByCTag]

-- ControlProperties_SELECT_BlogPostsByCTag 'EASTER'
-- ControlProperties_SELECT_BlogPostsByCTag 'JAZZ'
-- ControlProperties_SELECT_BlogPostsByCTag 'Test'
-- SELECT * FROM ControlProperties

	@txtTag varchar(2000)

AS

	SET NOCOUNT ON

	SELECT DISTINCT P.PageId, 
		P.Title,
		P.Url, 
		P.MetaKeywords,
		P.MetaDescription,
		C.LastModified, 
		C.LastModifiedBy,
		1 Matches, --Count(*),
		C.ContentId, 
		C.Note,
		C.ContentType		
	FROM 	[ControlProperties] CP2 INNER JOIN Page P ON InstanceId = P.PageId
		INNER JOIN [Content] C ON CP2.PropertyValue = C.ContentId
	WHERE	PropertyType = 'BPST'
	AND		P.IsLive = 1
	AND		C.IsLive = 1
	AND		CP2.PropertyValue IN 
	(
		SELECT	CP.InstanceId
		FROM	[ControlProperties] CP INNER JOIN [Content] C ON CP.InstanceId = C.ContentId
		WHERE	CP.PropertyType = 'CTAG'
		AND		CP.PropertyValue = @txtTag
		AND		CP.InstanceId IS NOT NULL
		AND		CP2.PropertyValue = CP.InstanceId 
	)
	ORDER BY C.LastModified DESC
	






GO





/****** Object:  StoredProcedure [dbo].[Content_SELECT_ListLatestLiveByPageId]    Script Date: 05/27/2009 13:10:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Content_SELECT_ListLatestLiveByPageId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Content_SELECT_ListLatestLiveByPageId]

GO





/****** Object:  Stored Procedure dbo.Content_SELECT_ByContentID    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_ListLatestLiveByPageId]

	@intPageID int,
	@txtContentType char(4) = 'BPST'

AS

	-- Content_SELECT_ListLatestLiveByPageId 61, 'BPST'
	-- Content_SELECT_ListLatestLiveByPageId 62, 'BPST'
	-- Content_SELECT_ListLatestLiveByPageId 53, 'CONT'
	-- Content_SELECT_ListLatestLiveByPageId 53


	SET NOCOUNT ON

	IF @intPageId > -1
	BEGIN

		SELECT	DISTINCT
				--P.PageId,
				C.ContentID, 
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.ContentFilter,
				C.LastModified, 
				C.LastModifiedBy,
				(SELECT Count(*) FROM dbo.ControlProperties CP WHERE PropertyType = 'CONT' AND PropertyValue = C.ContentID) PageUsageCount

		FROM	dbo.Content C
			INNER JOIN ControlProperties Props ON C.ContentId = Props.PropertyValue 
			INNER JOIN Page P ON Props.InstanceID = P.PageID

		WHERE 	Props.PropertyType = @txtContentType
		AND		C.ContentType = @txtContentType
		AND		P.IsLive = 1
		AND		C.IsLive = 1
		AND		P.PageId = @intPageId

		ORDER BY C.LastModified DESC

	END
	ELSE
	BEGIN

		SELECT	DISTINCT
				--P.PageId,
				C.ContentID, 
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.ContentFilter,
				C.LastModified, 
				C.LastModifiedBy,
				(SELECT Count(*) FROM dbo.ControlProperties CP WHERE PropertyType = 'CONT' AND PropertyValue = C.ContentID) PageUsageCount

		FROM	dbo.Content C
			INNER JOIN ControlProperties Props ON C.ContentId = Props.PropertyValue 
			INNER JOIN Page P ON Props.InstanceID = P.PageID

		WHERE 	Props.PropertyType = @txtContentType
		AND		C.ContentType = @txtContentType
		AND		P.IsLive = 1
		AND		C.IsLive = 1

		ORDER BY C.LastModified DESC

	END






GO


/****** Object:  StoredProcedure [dbo].[Content_SELECT_ListByDateLastModified]    Script Date: 05/27/2009 13:10:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Content_SELECT_ListByDateLastModified]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Content_SELECT_ListByDateLastModified]



GO




/****** Object:  Stored Procedure dbo.Content_SELECT_ByContentID    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_ListByDateLastModified]

	@startDate datetime,
	@endDate datetime,
	@txtContentType char(4) = 'BPST',
	@intPageId int = -1

AS

	-- Content_SELECT_ListByDateLastModified '2008-04-10 10:46:23.153', '2010-04-10 10:46:23.153'
	-- Content_SELECT_ListByDateLastModified '2009-01-09 00:00:00.000', '2009-04-09 23:59:59.000'
	-- Content_SELECT_ListByDateLastModified '2009-01-09 00:00:00.000', '2009-04-09 23:59:59.000', 'CONT'

	-- Content_SELECT_ListByDateLastModified '2009-01-09 00:00:00.000', '2009-04-09 23:59:59.000', 'BPST', 61
	-- Content_SELECT_ListByDateLastModified '2009-01-09 00:00:00.000', '2009-04-09 23:59:59.000', 'CONT', 53


	SET NOCOUNT ON

	IF @intPageId > -1
	BEGIN

		SELECT	DISTINCT
				--P.PageId,
				C.ContentID, 
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.ContentFilter,
				C.LastModified, 
				C.LastModifiedBy,
				(SELECT Count(*) FROM dbo.ControlProperties CP WHERE PropertyType = 'CONT' AND PropertyValue = C.ContentID) PageUsageCount

		FROM	dbo.Content C
			INNER JOIN ControlProperties Props ON C.ContentId = Props.PropertyValue 
			INNER JOIN Page P ON Props.InstanceID = P.PageID

		WHERE 	Props.PropertyType = @txtContentType
		AND		C.ContentType = @txtContentType
		AND		(C.LastModified >= @startDate AND C.LastModified < @endDate)
		AND		P.IsLive = 1
		AND		C.IsLive = 1
		AND		P.PageId = @intPageId

		ORDER BY C.LastModified DESC

	END
	ELSE
	BEGIN

		SELECT	DISTINCT
				--P.PageId,
				C.ContentID, 
				C.Note, 
				C.ContentType,
				C.IsLive, 
				C.IsSearchable, 
				C.ContentFilter,
				C.LastModified, 
				C.LastModifiedBy

		FROM	dbo.Content C
			INNER JOIN ControlProperties Props ON C.ContentId = Props.PropertyValue 
			INNER JOIN Page P ON Props.InstanceID = P.PageID

		WHERE 	Props.PropertyType = @txtContentType
		AND		C.ContentType = @txtContentType
		AND		(C.LastModified >= @startDate AND C.LastModified < @endDate)
		AND		P.IsLive = 1
		AND		C.IsLive = 1

		ORDER BY C.LastModified DESC

	END






GO



/****** Object:  StoredProcedure [dbo].[Content_SELECT_LatestLiveByPageId]    Script Date: 04/17/2009 15:37:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Content_SELECT_LatestLiveByPageId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Content_SELECT_LatestLiveByPageId]

GO






/****** Object:  Stored Procedure dbo.Content_SELECT_LatestLiveByPageId    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_LatestLiveByPageId]

	-- Content_SELECT_LatestLiveByPageId 62
	-- Content_SELECT_LatestLiveByPageId 14, 'CONT'
	-- Content_SELECT_LatestLiveByPageId 61, 'BPST'

	@intPageID int,
	@txtContentType char(4) = 'BPST'

AS

	SET NOCOUNT ON

	SELECT	TOP 3
			C.ContentID, 
			C.Content, 
			C.TextContent,
			C.Note, 
			C.ContentType,
			C.IsLive, 
			C.IsSearchable, 
			C.ContentFilter,
			C.LastModified, 
			C.LastModifiedBy

	FROM	dbo.Content C
	INNER JOIN dbo.ControlProperties CP ON C.ContentID = CP.PropertyValue
	INNER JOIN dbo.Page P ON CP.InstanceID = P.PageID

	WHERE	P.PageID = @intPageID
		AND	CP.PropertyType = @txtContentType
		AND	P.IsLive = 1
		AND	C.IsLive = 1

	ORDER BY C.LastModified DESC







GO



/****** Object:  StoredProcedure [dbo].[Content_SELECT_ForBlogRSS]    Script Date: 05/27/2009 13:10:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Content_SELECT_ForBlogRSS]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Content_SELECT_ForBlogRSS]



GO



/****** Object:  Stored Procedure dbo.Content_SELECT_ForBlogRSS    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure [dbo].[Content_SELECT_ForBlogRSS]

	-- Content_SELECT_ForBlogRSS 62
	-- Content_SELECT_ForBlogRSS 14, 'CONT'
	-- Content_SELECT_ForBlogRSS 61, 'BPST'

	@intPageID int,
	@txtContentType char(4) = 'BPST'

AS

	SET NOCOUNT ON

	SELECT	TOP 25
			C.ContentID, 
			C.Note ContentNote, 
			C.Content,
			C.ContentType,
			C.IsLive ContentIsLive, 
			C.IsSearchable ContentIsSearchable, 
			C.ContentFilter ContentEntryFilter,
			C.LastModified ContentLastModified, 
			C.LastModifiedBy ContentLastModifiedBy,

			P.PageID,
			P.Title PageTitle, 
			P.Url PageUrl, 
			P.MetaKeywords PageKeywords, 
			P.MetaDescription PageDescription, 
			P.LastModified PageLastModified,
			P.LastModifiedBy PageLastModifiedBy,
			P.IsSearchable PageIsSearchable,
			P.IsLive PageIsLive  

/*
,
			(
				SELECT	PropertyValue

				FROM 	[ControlProperties]

				WHERE 	[InstanceID] = C.ContentID
				AND		PropertyType = 'CTAG'

				ORDER BY PropertyValue
			)
*/



	FROM	dbo.Content C
	INNER JOIN dbo.ControlProperties CP ON C.ContentID = CP.PropertyValue
	INNER JOIN dbo.Page P ON CP.InstanceID = P.PageID

	WHERE		P.PageID = @intPageID
		AND		CP.PropertyType = @txtContentType
		AND		P.IsLive = 1
		AND		C.IsLive = 1

	ORDER BY C.LastModified DESC


GO






/****** Object:  Stored Procedure dbo.ContentIndex_SELECT_WordIndexList    Script Date: 20/05/2007 9:23:12 a.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ContentIndex_SELECT_WordIndexList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ContentIndex_SELECT_WordIndexList]
GO



/****** Object:  Stored Procedure dbo.ContentIndex_SELECT_WordIndexList    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec ContentIndex_SELECT_WordIndexList @txtSearchCriteria = '%acc%'


/****** Object:  Stored Procedure dbo.ContentIndex_SELECT_WordIndexList    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure ContentIndex_SELECT_WordIndexList

	-- ContentIndex_SELECT_WordIndexList 'a'
	-- ContentIndex_SELECT_WordIndexList 'A'
	-- ContentIndex_SELECT_WordIndexList 'T'
	-- ContentIndex_SELECT_WordIndexList 'z'
	-- ContentIndex_SELECT_WordIndexList '%'

	@txtLetter char(1)

AS

	SET NOCOUNT ON


	DECLARE @bLetterFound bit
	SET @bLetterFound = 0


	IF @txtLetter = 'A'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_A Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'B'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_B Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'C'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_C Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'D'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_D Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'E'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_E Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'F'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_F Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'G'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_G Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'H'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_H Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'I'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_I Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'J'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_J Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'K'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_K Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'L'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_L Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'M'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_M Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'N'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_N Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'O'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_O Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'P'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_P Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'Q'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_Q Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'R'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_R Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'S'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_S Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'T'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_T Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'U'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_U Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'V'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_V Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'W'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_W Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'X'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_X Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'Y'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_Y Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END

	IF @txtLetter = 'Z'
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_Z Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
                SET @bLetterFound = 1
	END


	IF @bLetterFound = 0
	BEGIN
		SELECT DISTINCT Indx.WORD, Indx.PageId, Indx.ContentId, P.Url, P.Title, C.ContentType, C.Note
		FROM dbo.ContentIndex_Default Indx
			INNER JOIN dbo.Page P ON Indx.PageId = P.PageID
			INNER JOIN dbo.Content C ON Indx.ContentId = C.ContentId
		ORDER BY WORD
	END
GO





/****** Object:  Stored Procedure dbo.Content_SELECT_SearchLiveOnly    Script Date: 27/11/2005 4:05:16 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Content_SELECT_SearchLiveOnly]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Content_SELECT_SearchLiveOnly]
GO



/****** Object:  Stored Procedure dbo.Content_SELECT_SearchLiveOnly    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure Content_SELECT_SearchLiveOnly

	@txtNotes varchar(25)

AS

	-- Content_SELECT_List_Search 'Book%'
	-- Content_SELECT_SearchLiveOnly 'Book%'

	SET NOCOUNT ON

	SELECT		C.ContentID, 
			C.Content,
			C.TextContent, 
			C.Note, 
			C.IsLive, 
			C.IsSearchable, 
			C.ContentFilter,
			C.LastModified, 
			C.LastModifiedBy

	FROM		dbo.Content C

	WHERE		C.Note LIKE @txtNotes
	AND		C.IsLive = 1
	
	ORDER BY 	C.Note,
			C.ContentID


GO







/****** Object:  Stored Procedure dbo.Content_SEARCH    Script Date: 14/02/2006 10:06:32 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Content_SEARCH]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Content_SEARCH]
GO


/****** Object:  Stored Procedure dbo.Content_SEARCH    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec Content_SEARCH @txtSearchCriteria = '%acc%'


/****** Object:  Stored Procedure dbo.Content_SEARCH    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure Content_SEARCH

	-- Content_SEARCH '%SQL%'
	-- Content_SEARCH '%brian%'
	-- Content_SEARCH '%frodo%'
	-- Content_SEARCH '%fool%'

	@txtSearchCriteria varchar(100)

AS

	SET NOCOUNT ON

	SELECT	DISTINCT TOP 100			 
			P.PageID, 
			P.Title, 
			P.Url, 
			P.MetaKeywords, 
			P.MetaDescription, 
			P.LastModified LastModified, 
			P.LastModifiedBy LastModifiedBy,
			(
				SELECT 
				(
					SELECT Count(*) FROM dbo.ContentIndex_A AIndex
					WHERE AIndex.Word LIKE @txtSearchCriteria AND AIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_B BIndex
					WHERE BIndex.Word LIKE @txtSearchCriteria AND BIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_C CIndex
					WHERE CIndex.Word LIKE @txtSearchCriteria AND CIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_D DIndex
					WHERE DIndex.Word LIKE @txtSearchCriteria AND DIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_E EIndex
					WHERE EIndex.Word LIKE @txtSearchCriteria AND EIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_F FIndex
					WHERE FIndex.Word LIKE @txtSearchCriteria AND FIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_G GIndex
					WHERE GIndex.Word LIKE @txtSearchCriteria AND GIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_H HIndex
					WHERE HIndex.Word LIKE @txtSearchCriteria AND HIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_I IIndex
					WHERE IIndex.Word LIKE @txtSearchCriteria AND IIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_J JIndex
					WHERE JIndex.Word LIKE @txtSearchCriteria AND JIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_K KIndex
					WHERE KIndex.Word LIKE @txtSearchCriteria AND KIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_L LIndex
					WHERE LIndex.Word LIKE @txtSearchCriteria AND LIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_M MIndex
					WHERE MIndex.Word LIKE @txtSearchCriteria AND MIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_N NIndex
					WHERE NIndex.Word LIKE @txtSearchCriteria AND NIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_O OIndex
					WHERE OIndex.Word LIKE @txtSearchCriteria AND OIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_P PIndex
					WHERE PIndex.Word LIKE @txtSearchCriteria AND PIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_Q QIndex
					WHERE QIndex.Word LIKE @txtSearchCriteria AND QIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_R RIndex
					WHERE RIndex.Word LIKE @txtSearchCriteria AND RIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_S SIndex
					WHERE SIndex.Word LIKE @txtSearchCriteria AND SIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_T TIndex
					WHERE TIndex.Word LIKE @txtSearchCriteria AND TIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_U UIndex
					WHERE UIndex.Word LIKE @txtSearchCriteria AND UIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_V VIndex
					WHERE VIndex.Word LIKE @txtSearchCriteria AND VIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_W WIndex
					WHERE WIndex.Word LIKE @txtSearchCriteria AND WIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_X XIndex
					WHERE XIndex.Word LIKE @txtSearchCriteria AND XIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_Y YIndex
					WHERE YIndex.Word LIKE @txtSearchCriteria AND YIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_Z ZIndex
					WHERE ZIndex.Word LIKE @txtSearchCriteria AND ZIndex.PageId = P.PageID
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_Default DefaultIndex
					WHERE DefaultIndex.Word LIKE @txtSearchCriteria AND DefaultIndex.PageId = P.PageID
				)
			) Matches, --PageMatches

			0 ContentID,
			'CONT' ContentType,
			'' Note


		

	FROM	Content C 
		INNER JOIN dbo.ControlProperties CP ON C.ContentID = CP.PropertyValue
		INNER JOIN Page P ON CP.InstanceID = P.PageID

	WHERE	(C.TextContent LIKE @txtSearchCriteria) 
	AND 	(C.IsLive = 1) AND (C.IsSearchable = 1) 
	AND 	(P.IsLive = 1) AND (P.IsSearchable = 1)
	AND		CP.PropertyType = 'CONT'


	UNION


	SELECT	DISTINCT TOP 100			 
			P.PageID, 
			P.Title, 
			P.Url, 
			P.MetaKeywords, 
			P.MetaDescription, 
			P.LastModified LastModified, 
			P.LastModifiedBy LastModifiedBy,
/*
			(
				SELECT LastModified FROM [Content] C
				
				WHERE 
				ORDER BY LastModified DESC
			) XXX,
*/
			(
				SELECT 
				(
					SELECT Count(*) FROM dbo.ContentIndex_A AIndex
					WHERE AIndex.Word LIKE @txtSearchCriteria AND AIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_B BIndex
					WHERE BIndex.Word LIKE @txtSearchCriteria AND BIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_C CIndex
					WHERE CIndex.Word LIKE @txtSearchCriteria AND CIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_D DIndex
					WHERE DIndex.Word LIKE @txtSearchCriteria AND DIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_E EIndex
					WHERE EIndex.Word LIKE @txtSearchCriteria AND EIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_F FIndex
					WHERE FIndex.Word LIKE @txtSearchCriteria AND FIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_G GIndex
					WHERE GIndex.Word LIKE @txtSearchCriteria AND GIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_H HIndex
					WHERE HIndex.Word LIKE @txtSearchCriteria AND HIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_I IIndex
					WHERE IIndex.Word LIKE @txtSearchCriteria AND IIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_J JIndex
					WHERE JIndex.Word LIKE @txtSearchCriteria AND JIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_K KIndex
					WHERE KIndex.Word LIKE @txtSearchCriteria AND KIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_L LIndex
					WHERE LIndex.Word LIKE @txtSearchCriteria AND LIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_M MIndex
					WHERE MIndex.Word LIKE @txtSearchCriteria AND MIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_N NIndex
					WHERE NIndex.Word LIKE @txtSearchCriteria AND NIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_O OIndex
					WHERE OIndex.Word LIKE @txtSearchCriteria AND OIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_P PIndex
					WHERE PIndex.Word LIKE @txtSearchCriteria AND PIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_Q QIndex
					WHERE QIndex.Word LIKE @txtSearchCriteria AND QIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_R RIndex
					WHERE RIndex.Word LIKE @txtSearchCriteria AND RIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_S SIndex
					WHERE SIndex.Word LIKE @txtSearchCriteria AND SIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_T TIndex
					WHERE TIndex.Word LIKE @txtSearchCriteria AND TIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_U UIndex
					WHERE UIndex.Word LIKE @txtSearchCriteria AND UIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_V VIndex
					WHERE VIndex.Word LIKE @txtSearchCriteria AND VIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_W WIndex
					WHERE WIndex.Word LIKE @txtSearchCriteria AND WIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_X XIndex
					WHERE XIndex.Word LIKE @txtSearchCriteria AND XIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_Y YIndex
					WHERE YIndex.Word LIKE @txtSearchCriteria AND YIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_Z ZIndex
					WHERE ZIndex.Word LIKE @txtSearchCriteria AND ZIndex.ContentId = C.ContentId
				) + (
					SELECT Count(*) FROM dbo.ContentIndex_Default DefaultIndex
					WHERE DefaultIndex.Word LIKE @txtSearchCriteria AND DefaultIndex.ContentId = C.ContentId
				)
			) Matches, --ContentMatches


			C.ContentId,
			C.ContentType,
			C.Note

	FROM	Content C 
		INNER JOIN dbo.ControlProperties CP ON C.ContentID = CP.PropertyValue
		INNER JOIN Page P ON CP.InstanceID = P.PageID

	WHERE	(C.TextContent LIKE @txtSearchCriteria) 
	AND 	(C.IsLive = 1) AND (C.IsSearchable = 1) 
	AND 	(P.IsLive = 1) AND (P.IsSearchable = 1)
	AND		CP.PropertyType = 'BPST'



	--ORDER BY PageMatches DESC, ContentMatches DESC, P.LastModified DESC, P.PageID DESC	--, C.ContentID
	ORDER BY Matches DESC, LastModified DESC

	-- Content_SEARCH '%SQL%'
	-- Content_SEARCH '%fool%'
	-- Content_SEARCH '%frodo%'
	-- Content_SEARCH '%because%'

GO






/****** Object:  Stored Procedure dbo.HttpLog_SELECT_ActiveSessionsByHours    Script Date: 2/09/2007 3:19:29 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[HttpLog_SELECT_ActiveSessionsByHours]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[HttpLog_SELECT_ActiveSessionsByHours]
GO




/****** Object:  Stored Procedure dbo.HttpLog_SELECT_ActiveSessionsByHours    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec HttpLog_SELECT_ActiveSessionsByHours @txtSearchCriteria = '%acc%'


/****** Object:  Stored Procedure dbo.HttpLog_SELECT_ActiveSessionsByHours    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure HttpLog_SELECT_ActiveSessionsByHours

	@numberOfHours int = 24

AS

	SET NOCOUNT ON

	-- HttpLog_SELECT_ActiveSessionsByHours
	-- HttpLog_SELECT_ActiveSessionsByHours 24
	-- HttpLog_SELECT_ActiveSessionsByHours 672 	--( weeks)

	-- SELECT * FROM HttpLog
	-- HttpLog_SELECT_ActiveSessionsByDateRange '2007-9-9', '2007-9-10'

	-- Unique sessions within specific timespan:
	SELECT 	H.SessionId, 
			H.UserHostName,
		count(*) TotalPageRequests,
		(
			SELECT 	TOP 1 TimeLogged
			FROM	HttpLog
			WHERE	SessionId = H.SessionId
			ORDER BY TimeLogged ASC

		) 'FirstUrlRequest',
		(
			SELECT 	TOP 1 TimeLogged
			FROM	HttpLog
			WHERE	SessionId = H.SessionId
			ORDER BY TimeLogged DESC

		) 'LastUrlRequest',
		(
			SELECT 	TOP 1 Url
			FROM	HttpLog
			WHERE	SessionId = H.SessionId
			ORDER BY TimeLogged ASC

		) 'FirstUrlRequested',
		(
			SELECT 	TOP 1 Url
			FROM	HttpLog
			WHERE	SessionId = H.SessionId
			ORDER BY TimeLogged DESC

		) 'LastUrlRequested'
		
	FROM HttpLog H
	WHERE DATEDIFF(hour, TimeLogged, getdate()) <= @numberOfHours
	GROUP BY H.SessionId, H.UserHostName
	ORDER BY LastUrlRequest DESC

GO





exec spGrantExectoAllStoredProcs 'ASPNET'






