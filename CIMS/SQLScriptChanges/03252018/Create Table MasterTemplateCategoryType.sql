SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MasterTemplateCategoryType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NULL,
	[TemplateName] [nvarchar](100) NULL,
	[Content] [ntext] NULL, 	
	[CreatedBy] [int] NULL,
	[createddate] [datetime] NULL DEFAULT (getdate())
) ON [PRIMARY]

GO


