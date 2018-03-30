SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[TemplateCategory_Delete](  
@id int=0
)  
as  
begin  
	Delete from MasterTemplateCategory where id=@id
	select @@RowCount as Result
end

GO


