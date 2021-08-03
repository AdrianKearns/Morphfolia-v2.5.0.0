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

/****** Object:  Stored Procedure dbo.ContentIndex_DELETE_UnwantedWords    Script Date: 23/05/2007 10:26:43 a.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ContentIndex_DELETE_UnwantedWords]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ContentIndex_DELETE_UnwantedWords]
GO



/****** Object:  Stored Procedure dbo.ContentIndex_DELETE_UnwantedWords    Script Date: 10/02/2007 8:11:37 p.m. ******/
CREATE Procedure ContentIndex_DELETE_UnwantedWords

	@txtFirstCharacter char(1),
	@txtWord varchar(256)

AS

	SET NOCOUNT ON


	DECLARE @done bit
	SET @done = 0





	IF (@txtFirstCharacter = 'A')
	BEGIN
		DELETE FROM dbo.ContentIndex_A WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'B')
	BEGIN
		DELETE FROM dbo.ContentIndex_B WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'C')
	BEGIN
		DELETE FROM dbo.ContentIndex_C WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'D')
	BEGIN
		DELETE FROM dbo.ContentIndex_D WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'E')
	BEGIN
		DELETE FROM dbo.ContentIndex_E WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'F')
	BEGIN
		DELETE FROM dbo.ContentIndex_F WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'G')
	BEGIN
		DELETE FROM dbo.ContentIndex_G WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'H')
	BEGIN
		DELETE FROM dbo.ContentIndex_H WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'I')
	BEGIN
		DELETE FROM dbo.ContentIndex_I WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'J')
	BEGIN
		DELETE FROM dbo.ContentIndex_J WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'K')
	BEGIN
		DELETE FROM dbo.ContentIndex_K WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'L')
	BEGIN
		DELETE FROM dbo.ContentIndex_L WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'M')
	BEGIN
		DELETE FROM dbo.ContentIndex_M WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'N')
	BEGIN
		DELETE FROM dbo.ContentIndex_N WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'O')
	BEGIN
		DELETE FROM dbo.ContentIndex_O WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'P')
	BEGIN
		DELETE FROM dbo.ContentIndex_P WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'Q')
	BEGIN
		DELETE FROM dbo.ContentIndex_Q WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'R')
	BEGIN
		DELETE FROM dbo.ContentIndex_R WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'S')
	BEGIN
		DELETE FROM dbo.ContentIndex_S WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'T')
	BEGIN
		DELETE FROM dbo.ContentIndex_T WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'U')
	BEGIN
		DELETE FROM dbo.ContentIndex_U WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'V')
	BEGIN
		DELETE FROM dbo.ContentIndex_V WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'W')
	BEGIN
		DELETE FROM dbo.ContentIndex_W WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'X')
	BEGIN
		DELETE FROM dbo.ContentIndex_X WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'Y')
	BEGIN
		DELETE FROM dbo.ContentIndex_Y WHERE [Word] = @txtWord	
		SET @done = 1
	END

	IF (@txtFirstCharacter = 'Z')
	BEGIN
		DELETE FROM dbo.ContentIndex_Z WHERE [Word] = @txtWord	
		SET @done = 1
	END






	if (@done = 0)
	BEGIN
		DELETE FROM dbo.ContentIndex_Default WHERE [Word] = @txtWord
	END







GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

