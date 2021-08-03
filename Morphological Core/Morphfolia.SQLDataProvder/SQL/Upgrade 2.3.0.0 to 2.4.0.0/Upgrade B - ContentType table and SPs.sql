/* Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
You can redistribute this software and/or modify it under the terms of the 
Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
See Licence.txt for more details.  */




/****** Object:  Table [dbo].[ContentType]    Script Date: 05/14/2009 16:42:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContentType]') AND type in (N'U'))
DROP TABLE [dbo].[ContentType]



/****** Object:  Table [dbo].[ContentType]    Script Date: 05/14/2009 16:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentType](
	[Id] [char](4) NOT NULL,
	[ContentType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ContentType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF


INSERT INTO [ContentType]([Id],[ContentType]) VALUES ('BPST','Blog Post')
INSERT INTO [ContentType]([Id],[ContentType]) VALUES ('CONT','Content Item')

select * FROM ContentType


