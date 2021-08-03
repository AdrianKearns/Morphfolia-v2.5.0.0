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

/****** Object:  Stored Procedure dbo.SearchIndex_INSERT_Word    Script Date: 19/11/2005 4:20:34 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SearchIndex_INSERT_Word]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SearchIndex_INSERT_Word]
GO


CREATE Procedure SearchIndex_INSERT_Word

	@txtLetter char(1),
	@txtWord varchar(100)

AS

	SET NOCOUNT ON

	IF @txtLetter = '1'  -- Handles: 0-9
		INSERT INTO dbo.SearchIndex_Numbers ([Word]) VALUES (@txtWord)

	IF @txtLetter = 'A'
		INSERT INTO [dbo].[SearchIndex_A] ([Word]) VALUES (@txtWord)

	IF @txtLetter = 'E'
		INSERT INTO [dbo].[SearchIndex_E] ([Word]) VALUES (@txtWord)

	IF @txtLetter = 'I'
		INSERT INTO [dbo].[SearchIndex_I] ([Word]) VALUES (@txtWord)

	IF @txtLetter = 'O'
		INSERT INTO [dbo].[SearchIndex_O] ([Word]) VALUES (@txtWord)

	IF @txtLetter = 'U'
		INSERT INTO [dbo].[SearchIndex_U] ([Word]) VALUES (@txtWord)


	IF @txtLetter = 'R'
		INSERT INTO [dbo].[SearchIndex_R] ([Word]) VALUES (@txtWord)

	IF @txtLetter = 'S'
		INSERT INTO [dbo].[SearchIndex_S] ([Word]) VALUES (@txtWord)

	IF @txtLetter = 'T'
		INSERT INTO [dbo].[SearchIndex_T] ([Word]) VALUES (@txtWord)


	IF @txtLetter = 'M'
		INSERT INTO [dbo].[SearchIndex_M] ([Word]) VALUES (@txtWord)

	IF @txtLetter = 'N'
		INSERT INTO [dbo].[SearchIndex_N] ([Word]) VALUES (@txtWord)

	IF @txtLetter = 'P'
		INSERT INTO [dbo].[SearchIndex_P] ([Word]) VALUES (@txtWord)
	

	IF @txtLetter = 'B'
		INSERT INTO [dbo].[SearchIndex_B] ([Word]) VALUES (@txtWord)

	IF @txtLetter = 'C'
		INSERT INTO [dbo].[SearchIndex_C] ([Word]) VALUES (@txtWord)

	IF @txtLetter = 'D'
		INSERT INTO [dbo].[SearchIndex_D] ([Word]) VALUES (@txtWord)

	IF @txtLetter = 'F'
		INSERT INTO [dbo].[SearchIndex_F] ([Word]) VALUES (@txtWord)

	IF @txtLetter = 'G'
		INSERT INTO [dbo].[SearchIndex_G] ([Word]) VALUES (@txtWord)

	IF @txtLetter = 'H'
		INSERT INTO [dbo].[SearchIndex_H] ([Word]) VALUES (@txtWord)

	IF @txtLetter = 'J'
		INSERT INTO [dbo].[SearchIndex_J] ([Word]) VALUES (@txtWord)

	IF @txtLetter = 'K'
		INSERT INTO [dbo].[SearchIndex_K] ([Word]) VALUES (@txtWord)

	IF @txtLetter = 'L'
		INSERT INTO [dbo].[SearchIndex_L] ([Word]) VALUES (@txtWord)

	IF @txtLetter = 'Q'
		INSERT INTO [dbo].[SearchIndex_Q] ([Word]) VALUES (@txtWord)

	IF @txtLetter = 'V'
		INSERT INTO [dbo].[SearchIndex_V] ([Word]) VALUES (@txtWord)

	IF @txtLetter = 'W'
		INSERT INTO [dbo].[SearchIndex_W] ([Word]) VALUES (@txtWord)

	IF @txtLetter = 'X'
		INSERT INTO [dbo].[SearchIndex_X] ([Word]) VALUES (@txtWord)

	IF @txtLetter = 'Y'
		INSERT INTO [dbo].[SearchIndex_Y] ([Word]) VALUES (@txtWord)

	IF @txtLetter = 'Z'
		INSERT INTO [dbo].[SearchIndex_Z] ([Word]) VALUES (@txtWord)


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

