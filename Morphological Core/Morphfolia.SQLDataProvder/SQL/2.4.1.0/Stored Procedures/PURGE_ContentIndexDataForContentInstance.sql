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

/****** Object:  Stored Procedure dbo.PURGE_ContentIndexDataForContentInstance    Script Date: 10/02/2007 8:11:37 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PURGE_ContentIndexDataForContentInstance]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[PURGE_ContentIndexDataForContentInstance]
GO

/****** Object:  Stored Procedure dbo.PURGE_ContentIndexDataForContentInstance    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure PURGE_ContentIndexDataForContentInstance

	@txtFirstCharacter char(1),
	@intPageId int,
	@intContentId int

AS

	-- PURGE_ContentIndexDataForContentInstance 28

	SET NOCOUNT ON

	DECLARE @done bit
	SET @done = 0

	--DELETE FROM dbo.Page WHERE PageID = @intPageID

	IF (@txtFirstCharacter = 'A')
	BEGIN
		DELETE FROM  dbo.ContentIndex_A
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'B')
	BEGIN
		DELETE FROM dbo.ContentIndex_B 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'C')
	BEGIN
		DELETE FROM dbo.ContentIndex_C 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'D')
	BEGIN
		DELETE FROM dbo.ContentIndex_D 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'E')
	BEGIN
		DELETE FROM dbo.ContentIndex_E 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'F')
	BEGIN
		DELETE FROM dbo.ContentIndex_F 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'G')
	BEGIN
		DELETE FROM dbo.ContentIndex_G 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'H')
	BEGIN
		DELETE FROM dbo.ContentIndex_H 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'I')
	BEGIN
		DELETE FROM dbo.ContentIndex_I 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'J')
	BEGIN
		DELETE FROM dbo.ContentIndex_J 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'K')
	BEGIN
		DELETE FROM dbo.ContentIndex_K 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'L')
	BEGIN
		DELETE FROM dbo.ContentIndex_L 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'M')
	BEGIN
		DELETE FROM dbo.ContentIndex_M 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'N')
	BEGIN
		DELETE FROM dbo.ContentIndex_N 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'O')
	BEGIN
		DELETE FROM dbo.ContentIndex_O 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'P')
	BEGIN
		DELETE FROM dbo.ContentIndex_P 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'Q')
	BEGIN
		DELETE FROM dbo.ContentIndex_Q 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'R')
	BEGIN
		DELETE FROM dbo.ContentIndex_R 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'S')
	BEGIN
		DELETE FROM dbo.ContentIndex_S 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'T')
	BEGIN
		DELETE FROM dbo.ContentIndex_T 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'U')
	BEGIN
		DELETE FROM dbo.ContentIndex_U 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'V')
	BEGIN
		DELETE FROM dbo.ContentIndex_V 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'W')
	BEGIN
		DELETE FROM dbo.ContentIndex_W 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'X')
	BEGIN
		DELETE FROM dbo.ContentIndex_X 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'Y')
	BEGIN
		DELETE FROM dbo.ContentIndex_Y 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'Z')
	BEGIN
		DELETE FROM dbo.ContentIndex_Z 
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
		SET @done = 1
	END


	if (@done = 0)
	BEGIN
		DELETE FROM dbo.ContentIndex_Default
		WHERE 	PageId = @intPageId
		AND	ContentId = @intContentId
	END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

