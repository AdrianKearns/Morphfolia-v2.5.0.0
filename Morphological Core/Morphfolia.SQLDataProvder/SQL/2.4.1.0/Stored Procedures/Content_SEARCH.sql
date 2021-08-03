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

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

