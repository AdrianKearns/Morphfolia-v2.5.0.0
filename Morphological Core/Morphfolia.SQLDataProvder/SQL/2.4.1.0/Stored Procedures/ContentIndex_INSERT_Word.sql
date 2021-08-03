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

/****** Object:  Stored Procedure dbo.ContentIndex_INSERT_Word    Script Date: 13/03/2007 8:48:12 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ContentIndex_INSERT_Word]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ContentIndex_INSERT_Word]
GO


/****** Object:  Stored Procedure dbo.ContentIndex_INSERT_Word    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure ContentIndex_INSERT_Word

	@txtFirstCharacter char(1),
	@txtWord varchar(256),
	@intPageId int,
	@intContentId int

AS

	SET NOCOUNT ON


	DECLARE @done bit
	SET @done = 0


	IF (@txtFirstCharacter = 'A')
	BEGIN
		INSERT INTO  dbo.ContentIndex_A
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)		
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'B')
	BEGIN
		INSERT INTO dbo.ContentIndex_B 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'C')
	BEGIN
		INSERT INTO dbo.ContentIndex_C 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'D')
	BEGIN
		INSERT INTO dbo.ContentIndex_D 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'E')
	BEGIN
		INSERT INTO dbo.ContentIndex_E 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'F')
	BEGIN
		INSERT INTO dbo.ContentIndex_F 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'G')
	BEGIN
		INSERT INTO dbo.ContentIndex_G 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'H')
	BEGIN
		INSERT INTO dbo.ContentIndex_H 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'I')
	BEGIN
		INSERT INTO dbo.ContentIndex_I 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'J')
	BEGIN
		INSERT INTO dbo.ContentIndex_J 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'K')
	BEGIN
		INSERT INTO dbo.ContentIndex_K 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'L')
	BEGIN
		INSERT INTO dbo.ContentIndex_L 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'M')
	BEGIN
		INSERT INTO dbo.ContentIndex_M 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'N')
	BEGIN
		INSERT INTO dbo.ContentIndex_N 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'O')
	BEGIN
		INSERT INTO dbo.ContentIndex_O 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'P')
	BEGIN
		INSERT INTO dbo.ContentIndex_P 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'Q')
	BEGIN
		INSERT INTO dbo.ContentIndex_Q 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'R')
	BEGIN
		INSERT INTO dbo.ContentIndex_R 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'S')
	BEGIN
		INSERT INTO dbo.ContentIndex_S 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'T')
	BEGIN
		INSERT INTO dbo.ContentIndex_T 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'U')
	BEGIN
		INSERT INTO dbo.ContentIndex_U 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'V')
	BEGIN
		INSERT INTO dbo.ContentIndex_V 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'W')
	BEGIN
		INSERT INTO dbo.ContentIndex_W 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'X')
	BEGIN
		INSERT INTO dbo.ContentIndex_X 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'Y')
	BEGIN
		INSERT INTO dbo.ContentIndex_Y 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'Z')
	BEGIN
		INSERT INTO dbo.ContentIndex_Z 
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
		SET @done = 1
	END


	if (@done = 0)
	BEGIN
		INSERT INTO dbo.ContentIndex_Default
		([Word], PageId, ContentId) VALUES (@txtWord, @intPageId, @intContentId)
	END






GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

