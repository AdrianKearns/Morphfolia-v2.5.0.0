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

/****** Object:  Stored Procedure dbo.Page_DELETE_ByPageID    Script Date: 21/06/2007 7:45:01 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Page_DELETE_ByPageID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Page_DELETE_ByPageID]
GO




/****** Object:  Stored Procedure dbo.Page_DELETE_ByPageID    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure Page_DELETE_ByPageID

	@intPageID int

AS

	-- Page_DELETE_ByPageID 58
	-- SELECT * FROM dbo.Page WHERE PageID = 58
	-- SELECT * FROM dbo.Page

	SET NOCOUNT ON


	DELETE FROM dbo.ContentIndex_A WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_B WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_C WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_D WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_E WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_F WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_G WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_H WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_I WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_J WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_K WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_L WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_M WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_N WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_O WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_P WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_Q WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_R WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_S WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_T WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_U WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_V WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_W WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_X WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_Y WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_Z WHERE PageID = @intPageID
	DELETE FROM dbo.ContentIndex_Default WHERE PageID = @intPageID


	DELETE FROM dbo.ContentMarshal WHERE PageID = @intPageID

	DELETE FROM dbo.ControlProperties WHERE InstanceID = @intPageID

	DELETE FROM dbo.Page WHERE PageID = @intPageID

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

