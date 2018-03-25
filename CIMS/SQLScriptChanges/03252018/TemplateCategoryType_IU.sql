SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[TemplateCategoryType_IU](
@id int=0,
@CategoryID int=0,
@TemplateName nvarchar(100)=null,
@Content ntext=null, 	
@CreatedBy int=0
)
as
begin
	if exists(Select * from MasterTemplateCategoryType where id=@id)
	begin
		Update MasterTemplateCategoryType set CategoryID=@CategoryID, TemplateName = @TemplateName,
		Content=@Content where id=@id
		select @@Rowcount as RESULT
	end
	else
	begin 
		insert into MasterTemplateCategoryType(CategoryID,TemplateName,Content,CreatedBy,createddate) 
		values(@CategoryID,@TemplateName,@Content,@CreatedBy,getdate())
		select @@Identity as RESULT
	end
end

GO


