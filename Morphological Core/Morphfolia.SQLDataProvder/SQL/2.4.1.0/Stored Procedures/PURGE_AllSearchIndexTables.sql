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

/****** Object:  Stored Procedure dbo.PURGE_AllSearchIndexTables    Script Date: 27/11/2005 4:05:16 p.m. ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PURGE_AllSearchIndexTables]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[PURGE_AllSearchIndexTables]
GO



/****** Object:  Stored Procedure dbo.PURGE_AllSearchIndexTables    Script Date: 14/07/2005 10:12:49 p.m. ******/
CREATE Procedure PURGE_AllSearchIndexTables


AS

	SET NOCOUNT ON

	DELETE FROM dbo.SearchIndex_Numbers
	DELETE FROM dbo.SearchIndex_A
	DELETE FROM dbo.SearchIndex_B
	DELETE FROM dbo.SearchIndex_C
	DELETE FROM dbo.SearchIndex_D
	DELETE FROM dbo.SearchIndex_E
	DELETE FROM dbo.SearchIndex_F
	DELETE FROM dbo.SearchIndex_G
	DELETE FROM dbo.SearchIndex_H
	DELETE FROM dbo.SearchIndex_I
	DELETE FROM dbo.SearchIndex_J
	DELETE FROM dbo.SearchIndex_K
	DELETE FROM dbo.SearchIndex_L
	DELETE FROM dbo.SearchIndex_M
	DELETE FROM dbo.SearchIndex_N
	DELETE FROM dbo.SearchIndex_O
	DELETE FROM dbo.SearchIndex_P
	DELETE FROM dbo.SearchIndex_Q
	DELETE FROM dbo.SearchIndex_R
	DELETE FROM dbo.SearchIndex_S
	DELETE FROM dbo.SearchIndex_T
	DELETE FROM dbo.SearchIndex_U
	DELETE FROM dbo.SearchIndex_V
	DELETE FROM dbo.SearchIndex_W
	DELETE FROM dbo.SearchIndex_X
	DELETE FROM dbo.SearchIndex_Y
	DELETE FROM dbo.SearchIndex_Z


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

