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

/****** Object:  Stored Procedure dbo.HttpLog_SELECT_TopTenUrls    Script Date: 2/09/2007 3:19:29 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[HttpLog_SELECT_TopTenUrls]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[HttpLog_SELECT_TopTenUrls]
GO




/****** Object:  Stored Procedure dbo.HttpLog_SELECT_TopTenUrls    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec HttpLog_SELECT_TopTenUrls @txtSearchCriteria = '%acc%'


/****** Object:  Stored Procedure dbo.HttpLog_SELECT_TopTenUrls    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure HttpLog_SELECT_TopTenUrls

	@dtRangeStart DateTime = '1900-01-01 00:00:00',
    @dtRangeEnd DateTime = '1900-01-01 00:00:00'

AS

	-- SELECT * FROM HttpLog ORDER BY LogId DESC
	-- HttpLog_SELECT_TopTenUrls
	-- HttpLog_SELECT_TopTenUrls '2010-04-01 00:00:00', '2010-04-10 00:00:00'
	-- HttpLog_SELECT_TopTenUrls '2010-04-12 12:21:10', '2010-04-10 17:00:00'

	IF @dtRangeStart = @dtRangeEnd
	BEGIN

		SET NOCOUNT ON

		SELECT TOP 10 Url, Count(*) HitCount
		FROM	dbo.HttpLog
		GROUP BY Url
		ORDER BY HitCount DESC

	END
	ELSE
	BEGIN

		SET NOCOUNT ON

		SELECT TOP 10 Url, Count(*) HitCount
		FROM	dbo.HttpLog
		WHERE	TimeLogged > @dtRangeStart AND TimeLogged <= @dtRangeEnd
		GROUP BY Url
		ORDER BY HitCount DESC

	END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

