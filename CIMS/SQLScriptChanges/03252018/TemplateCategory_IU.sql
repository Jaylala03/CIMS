SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[TemplateCategory_IU](
@id int=0,
@CategoryName nvarchar(100)=Null
)
as
begin
	if exists(Select * from MasterTemplateCategory where id=@id)
	begin
		Update MasterTemplateCategory set CategoryName=@CategoryName where id=@id
		select @@Rowcount as RESULT
	end
	else
	begin 
		insert into MasterTemplateCategory(CategoryName) values(@CategoryName)
		select @@Identity as RESULT
	end
end

GO


