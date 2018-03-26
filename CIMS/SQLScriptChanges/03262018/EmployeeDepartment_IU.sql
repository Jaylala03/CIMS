SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[EmployeeDepartment_IU](
@id int=0,
@DepartmentType nvarchar(100)=Null
)
as
begin
	if exists(Select * from MasterEmployeeDepartment where id=@id)
	begin
		Update MasterEmployeeDepartment set DepartmentType=@DepartmentType where id=@id
		select @@Rowcount as RESULT
	end
	else
	begin 
		insert into MasterEmployeeDepartment(DepartmentType) values(@DepartmentType)
		select @@Identity as RESULT
	end
end

GO


