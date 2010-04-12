/****** Object:  Table [dbo].[UploadStatus]    Script Date: 01/30/2007 20:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UploadStatus](
	[UploadId] [char](36) COLLATE Latin1_General_CI_AI NOT NULL,
	[UploadStatus] [varchar](max) COLLATE Latin1_General_CI_AI NOT NULL,
	[LastUpdated] [smalldatetime] NOT NULL CONSTRAINT [DF_UploadStatus_LastUpdated]  DEFAULT (getdate()),
 CONSTRAINT [PK_UploadStatus] PRIMARY KEY CLUSTERED 
(
	[UploadId] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF