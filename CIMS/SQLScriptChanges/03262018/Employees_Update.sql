SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER Procedure [dbo].[Employees_Update]
(   @UserID int,
    @empID int,
	@EmpNumber nvarchar(25)=NULL,
	@Age float =NULL,
	@Sex nvarchar(10)= NULL,
	@Race nvarchar(25)= NULL,
	@LastName nvarchar(25) =NULL,
	@FirstName nvarchar(25)= NULL,
	@MiddleName nvarchar(20)= NULL,
	@Height nvarchar(25)= NULL,
	@Weight nvarchar(25)= NULL,
	@DateOfBirth datetime =null,
	@StaffPosition nvarchar(50)= NULL,
	@Eyes nvarchar(10)=NULL,
	@Complexion nvarchar(15)=NULL,
	@Build nvarchar(15) =NULL,
	@Glasses nvarchar(10) =NULL,	
	@UD9 nvarchar(50) =NULL,
	@Department nvarchar(50) =NULL,
	@EmployeeNumber nvarchar(25) =NULL
	)
as
begin
UPDATE Employees Set  UserID=@UserID, EmpNumber =@EmpNumber, Age = @Age, Sex = @Sex, Race = @Race, LastName = @LastName, FirstName = @FirstName,
 MiddleName = @MiddleName, Height = @Height, Weight = @Weight,DateOfBirth =@DateOfBirth, StaffPosition = @StaffPosition, Eyes = @Eyes, Complexion = @Complexion,
 Build = @Build, Glasses = @Glasses, UD9 = @UD9, Department = @Department, EmployeeNumber = @EmployeeNumber WHERE EmployeeID = @empID
Select @@ROWCOUNT  as Result
End


GO


