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

