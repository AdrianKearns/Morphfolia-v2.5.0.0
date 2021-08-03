/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */



/****** Object:  StoredProcedure [dbo].[GetUsageSummary]    Script Date: 03/17/2009 12:15:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetUsageSummary]') AND type in (N'P', N'PC'))
DROP PROCEDURE [GetUsageSummary]



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [GetUsageSummary]

AS
BEGIN
	    

	exec sp_spaceused

	exec sp_spaceused aspnet_Users
	exec sp_spaceused AuditLog
	exec sp_spaceused [Content]
	exec sp_spaceused Page
	exec sp_spaceused ContentIndex_Default
	exec sp_spaceused ContentIndex_A
	exec sp_spaceused ContentIndex_B
	exec sp_spaceused ContentIndex_C
	exec sp_spaceused ContentIndex_D
	exec sp_spaceused ContentIndex_E
	exec sp_spaceused ContentIndex_F
	exec sp_spaceused ContentIndex_G
	exec sp_spaceused ContentIndex_H
	exec sp_spaceused ContentIndex_I
	exec sp_spaceused ContentIndex_J
	exec sp_spaceused ContentIndex_K
	exec sp_spaceused ContentIndex_L
	exec sp_spaceused ContentIndex_M
	exec sp_spaceused ContentIndex_N
	exec sp_spaceused ContentIndex_O
	exec sp_spaceused ContentIndex_P
	exec sp_spaceused ContentIndex_Q
	exec sp_spaceused ContentIndex_R
	exec sp_spaceused ContentIndex_S
	exec sp_spaceused ContentIndex_T
	exec sp_spaceused ContentIndex_U
	exec sp_spaceused ContentIndex_V
	exec sp_spaceused ContentIndex_W
	exec sp_spaceused ContentIndex_X
	exec sp_spaceused ContentIndex_Y
	exec sp_spaceused ContentIndex_Z
	exec sp_spaceused ControlProperties
	exec sp_spaceused PropertyType
	exec sp_spaceused HttpLog
	exec sp_spaceused [Log]



END
