SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER Procedure [dbo].[Employees_Insert]
(   @UserID int,
	@EmpNumber nvarchar(25)=NULL,
	@Age float =NULL,
	@Sex nvarchar(10)= NULL,
	@Race nvarchar(25)= NULL,
	@LastName nvarchar(25) =NULL,
	@FirstName nvarchar(25)= NULL,
	@MiddleName nvarchar(20)= NULL,
	@Height nvarchar(25)= NULL,
	@Weight nvarchar(25)= NULL,
	@DateOfBirth datetime= NULL,
	@StaffPosition nvarchar(50)= NULL,
	@Eyes nvarchar(10)=NULL,
	@Complexion nvarchar(15)=NULL,
	@Build nvarchar(15) =NULL,
	@Glasses nvarchar(10) =NULL,
	@Restricted bit,
	@Status nvarchar(50)=NULL,
	@RoleName nvarchar(50) =NULL,
	@UD9 nvarchar(50)= NULL,
	@Department nvarchar(50) =NULL,
	@EmployeeNumber nvarchar(25) =NULL,
	@SubjectStatus nvarchar(25) =NULL
	)
as
begin
INSERT INTO Employees (UserID, EmpNumber, Age, Sex, Race, LastName, FirstName, MiddleName, Height, Weight,DateOfBirth, StaffPosition, Eyes, Complexion, Build, Glasses, Restricted, RoleName, UD9,Department, EmployeeNumber, SubjectStatusID ,CreatedDate)
values (@UserID,@EmpNumber, @Age, @Sex, @Race, @LastName, @FirstName, @MiddleName, @Height, @Weight,@DateOfBirth, @StaffPosition, @Eyes, @Complexion, @Build, @Glasses, @Restricted, @RoleName, @UD9, @Department, @EmployeeNumber, @SubjectStatus ,getdate())
Select @@IDENTITY as Result
End




GO


