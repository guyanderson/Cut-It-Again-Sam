USE [hair_salon_test]
GO
/****** Object:  Table [dbo].[stylists]    Script Date: 6/9/2017 9:17:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stylists](
	[name] [varchar](255) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
