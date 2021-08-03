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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Content_DELETE_ByContentID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Content_DELETE_ByContentID]
GO


CREATE Procedure ContentIndex_DELETE_OrphanRecords

AS

	SET NOCOUNT ON

	
	
	DELETE FROM ContentIndex_A WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_B WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_C WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_D WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_E WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_F WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_G WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_H WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_I WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_J WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_K WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_L WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_M WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_N WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_O WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_P WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_Q WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_R WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_S WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_T WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_U WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_V WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_W WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_X WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_Y WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_Z WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
	DELETE FROM ContentIndex_Default WHERE ContentId NOT IN (SELECT DISTINCT ContentId FROM Content)
		
	
	DELETE FROM ContentIndex_A WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_B WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_C WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_D WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_E WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_F WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_G WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_H WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_I WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_J WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_K WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_L WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_M WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_N WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_O WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_P WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_Q WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_R WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_S WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_T WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_U WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_V WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_W WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_X WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_Y WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_Z WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)
	DELETE FROM ContentIndex_Default WHERE PageId NOT IN (SELECT DISTINCT PageId FROM Page)

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
