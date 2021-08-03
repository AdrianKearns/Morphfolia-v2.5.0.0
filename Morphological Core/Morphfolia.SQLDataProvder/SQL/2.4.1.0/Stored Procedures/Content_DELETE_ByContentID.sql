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

/****** Object:  Stored Procedure dbo.Content_DELETE_ByContentID    Script Date: 21/06/2007 7:45:01 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Content_DELETE_ByContentID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Content_DELETE_ByContentID]
GO




/****** Object:  Stored Procedure dbo.Content_DELETE_ByContentID    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure Content_DELETE_ByContentID

	@intContentID int

AS

	SET NOCOUNT ON

	DELETE FROM dbo.ContentIndex_A WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_B WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_C WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_D WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_E WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_F WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_G WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_H WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_I WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_J WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_K WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_L WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_M WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_N WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_O WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_P WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_Q WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_R WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_S WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_T WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_U WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_V WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_W WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_X WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_Y WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_Z WHERE ContentId = @intContentID
	DELETE FROM dbo.ContentIndex_Default WHERE ContentId = @intContentID

	-- SELECT * FROM dbo.ContentMarshal WHERE ContentID = 1
	DELETE FROM dbo.ContentMarshal WHERE ContentID = @intContentID

	-- SELECT * FROM dbo.ControlProperties WHERE PropertyType = 'CONT' AND PropertyValue = 1
	DELETE FROM dbo.ControlProperties WHERE PropertyType = 'CONT' AND PropertyValue = @intContentID

	-- SELECT * FROM dbo.Content WHERE ContentID = 1
	DELETE FROM dbo.Content WHERE ContentID = @intContentID

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

