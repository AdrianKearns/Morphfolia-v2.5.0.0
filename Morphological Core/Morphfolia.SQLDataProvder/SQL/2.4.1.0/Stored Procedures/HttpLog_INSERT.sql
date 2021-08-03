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

/****** Object:  Stored Procedure dbo.HttpLog_INSERT    Script Date: 25/05/2008 7:24:21 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[HttpLog_INSERT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[HttpLog_INSERT]
GO




/****** Object:  Stored Procedure dbo.HttpLog_INSERT    Script Date: 14/02/2006 1:42:34 p.m. ******/
-- exec HttpLog_INSERT @txtSearchCriteria = '%acc%'


/****** Object:  Stored Procedure dbo.HttpLog_INSERT    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure HttpLog_INSERT

	@SessionId varchar(50),
	@UserHostName varchar(50),
	@Url varchar(500),
	@UrlReferrer varchar(500),
	@MiscInfo varchar(500)

AS

	SET NOCOUNT ON

	-- HttpLog_INSERT 'testing', '---', 'http://testing', 'http://testing', '---'
	-- SELECT * FROM HttpLog

	INSERT INTO [HttpLog]
	(
		[SessionId], 
		[UserHostName], 
		[Url], 
		[UrlReferrer],
		[MiscInfo]
	)
	VALUES
	(
		@SessionId,
		@UserHostName,
		@Url,
		@UrlReferrer,
		@MiscInfo
	)




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

