

ALTER TABLE Subjects
ALTER COLUMN SubjectStatusID int
GO
--------------------------------------------------------------------------------------------
ALTER TABLE Employees
ALTER COLUMN EmployeeStatusID int
GO
--------------------------------------------------------------------------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MasterEmployeeStatus](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](100) NULL
) ON [PRIMARY]

GO
--------------------------------------------------------------------------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[Subject_IU]-- 1,'68',5,'Female' ,'Asian','verma','naina','singh',5,87,null,'Balck','','','','','Bald' ,'true','false',null,null,'false',0  
@SubjectID int =0,  
@VIP nvarchar(200) = null,
@Age float = 0,
@Sex nvarchar(200) = null,
@Race nvarchar(200) = null,
@LastName nvarchar(200) = null,
@FirstName nvarchar(200) = null,
@MiddleName nvarchar(200) = null,
@Height nvarchar(200) = null,
@Weight nvarchar(200) = null,
@DateOfBirth datetime =null,
@HairColor nvarchar(200)= null,
@Eyes nvarchar(200)= null,
@Complexion nvarchar(200)= null,
@Build nvarchar(200)= null,
@FacialHair nvarchar(200)= null,
@HairLength nvarchar(200)= null,
@Glasses nvarchar(200)= null,
@Restricted bit ='false',
@Status nvarchar(200)= null,
@RoleName nvarchar(200)= null,
@CIDSubject bit ='false',
@CIDPersonID int = 0,
@CreatedBy int=0 ,
@AgeRange nvarchar(200) = null,
@SubjectNumber nvarchar(25) = null,
@SubjectStatusID int=0
AS             
BEGIN   
  Begin Try            
   Begin Transaction 
   If(@SubjectID > 0)
    Begin 
	 -- If(Not Exists(Select * from Subjects where FirstName=@FirstName and ID != @ID))  
     -- Begin  
			update Subjects set
			VIP = @VIP,
			Age =@Age,
			Sex = @Sex,
			Race = @Race,
			LastName = @LastName,
			FirstName =  @FirstName,
			MiddleName = @MiddleName,
			Height = @Height,
			Weight = @Weight,
			DateOfBirth = @DateOfBirth ,
			HairColor = @HairColor,
			Eyes =@Eyes,
			Complexion = @Complexion,
			Build = @Build,
			FacialHair = @FacialHair,
			HairLength =  @HairLength,
			Glasses = @Glasses,
			Restricted = @Restricted,
			Status = @Status,
			RoleName = @RoleName,
			CIDSubject = @CIDSubject,
			CIDPersonID = @CIDPersonID,
			ModifiedDate = getdate(),
			AgeRange=@AgeRange,
			SubjectNumber = @SubjectNumber,
			SubjectStatusID = @SubjectStatusID
			 where SubjectID = @SubjectID 
			select 1  
     --End            
     -- Else  
	 --Begin            
       -- Select -10            
     --End            
	End 
    Else
	Begin
		-- If(Not Exists(Select * from Subjects where FirstName = @FirstName))            
		--Begin 
			Insert into Subjects(VIP ,Sex ,Race ,LastName,FirstName ,MiddleName ,Height,	
									Weight,	Age,DateOfBirth  ,HairColor ,Eyes,	Complexion ,
									Build ,FacialHair ,HairLength ,Glasses ,Restricted ,
									Status ,RoleName ,CIDSubject ,CIDPersonID ,ModifiedDate,CreatedBy,AgeRange,SubjectNumber,SubjectStatusID) 
			values (@VIP,@Sex ,@Race ,@LastName,@FirstName ,@MiddleName ,@Height,	
									@Weight,	@Age,@DateOfBirth, @HairColor ,@Eyes,	@Complexion ,
									@Build ,@FacialHair ,@HairLength ,@Glasses ,@Restricted ,
									@Status ,@RoleName ,@CIDSubject ,@CIDPersonID ,getdate(),@CreatedBy,@AgeRange,@SubjectNumber,@SubjectStatusID) 
			select @@IDENTITY
		--End
		--Else
		--Begin
			--Select -10         
		--End
	End 
  COMMIT TRANSACTION 
 End try    
 Begin Catch         
  IF @@TRANCOUNT >0         
          Select ERROR_MESSAGE()
    Rollback Transaction  
    EXECUTE [uspLogError]           
 End Catch            
END

GO
--------------------------------------------------------------------------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[Subjects_AdvancedSearch]                   
(
 @VIP nvarchar(100)=null,       
 @FirstName nvarchar(250)=null,                      
 @MiddleName nvarchar(250)=null,
 @LastName nvarchar(250)=null,                      
 @Sex nvarchar(250)=null,                      
 @Race nvarchar(250)=null, 
 @Eyes nvarchar(10)=null,
 @Build nvarchar(15)=null,
 @Complexion nvarchar(15)=null,                        
 @DateOfBirth datetime =null,   
 @HairLength nvarchar(25)=null,
 @HairColor nvarchar(15)=null,
 @FacialHair nvarchar(25)=null,
 @FromAge int = null,
 @ToAge	int = null,
 @AgeRange nvarchar(250)=null,
 @SubjectNumber nvarchar(25)=null,
 @SubjectStatusID nvarchar(25)=null
)                    
AS                    
BEGIN                    
    Declare @SQL nvarchar(max)    
	Set @SQL='SELECT SubjectID, FirstName, MiddleName,LastName,VIP,ms.sex as sex,(select Top(1) PV.FilePath from SubjectPicturesVideos SPV
		left join PicturesVideos PV on SPV.MediaID = PV.MediaID where SubjectID = Subjects.SubjectID) as FilePath,ModifiedDate FROM Subjects 
		left Outer join MasterSex ms on ms.id = Subjects.Sex
		where SubjectID<>0 '       
   if(@FirstName<>'')          
    begin          
     set @SQL=@SQL + ' and FirstName like '''+@FirstName+'%'''           
    end          
   if(@LastName<>'')          
    begin          
     set @SQL=@SQL+' and LastName like '''+@LastName+'%'''          
    end
   if(@MiddleName<>'')          
    begin          
     set @SQL=@SQL+' and MiddleName like '''+@MiddleName+'%'''          
    end          
   if(@VIP<>'')          
    begin          
     set @SQL=@SQL+' and VIP = '''+@VIP +''''         
    end          
   if(@Sex<>'')          
    begin          
     set @SQL=@SQL+' and Subjects.Sex = '''+@Sex+''''          
    end  
   if(@Race<>'')          
    begin          
     set @SQL=@SQL+' and Race = '''+@Race+''''          
    end 
   if(@Eyes<>'')          
    begin          
     set @SQL=@SQL+' and Eyes = '''+@Eyes+''''          
    end 
   if(@Build<>'')          
    begin          
     set @SQL=@SQL+' and Build = '''+@Build+''''          
    end 
   if(@DateOfBirth<>'')          
    begin          
     set @SQL=@SQL+' and DateOfBirth = '''+@DateOfBirth+''''          
    end 
   if(@HairLength <> '' )          
    begin          
     set @SQL=@SQL+' and HairLength = '''+@HairLength+''''          
    end 
    --if(@HairLength IS NULL)          
    --begin          
    -- set @SQL=@SQL+' and HairLength IS NULL '          
    --end 
   if(@HairColor<>'')          
    begin          
     set @SQL=@SQL+' and DateOfBirth = '''+@HairColor+''''          
    end 
   if(@FacialHair<>'')          
    begin          
     set @SQL=@SQL+' and HairLength = '''+@FacialHair+''''          
    end  
    -- if(@FromAge IS NOT NULL AND @ToAge IS NOT NULL)          
    --begin          
    -- set @SQL=@SQL+' AND Age BETWEEN ' + CAST (@FromAge AS Varchar) + ' AND ' +   CAST (@ToAge AS Varchar)       
    --end  
     if(@AgeRange<>'')          
    begin          
     set @SQL=@SQL + ' and AgeRange like '''+ @AgeRange +'%'''           
    end  
	if(@SubjectNumber<>'')          
    begin          
     set @SQL=@SQL+' and SubjectNumber = '''+@SubjectNumber+''''          
    end 
	if(@SubjectStatusID<>0)          
    begin          
     set @SQL=@SQL+' and SubjectStatusID = '''+@SubjectStatusID+''''          
    end  
        print(@SQL)    
      execute(@SQL)                  
END 
GO
--------------------------------------------------------------------------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  
Create Procedure [dbo].[MasterEmployeeStatus_IU](      
@Id int,      
@Status nvarchar(200)      
)      
as                     
BEGIN             
  Begin Try                      
   Begin Transaction           
    Begin           
  if exists(SELECT *  FROM MasterEmployeeStatus  where Id=@Id)        
   begin        
   update MasterEmployeeStatus set [Status]=@Status where Id=@Id        
   select @@RowCount as RESULT    
   end        
  ELSE        
  begin        
   insert into MasterEmployeeStatus([Status]) values(@Status)        
   select @@Identity as RESULT      
  end        
 End           
   COMMIT TRANSACTION           
  End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END     
GO
--------------------------------------------------------------------------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[MasterEmployeeStatus_Delete](      
@Id int      
)      
as                     
BEGIN             
  Begin Try                      
   Begin Transaction           
    Begin           
   Delete from MasterEmployeeStatus where Id=@Id       
   Select @@RowCount as RESULT       
 End           
   COMMIT TRANSACTION           
  End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END     
GO
--------------------------------------------------------------------------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[MasterEmployeeStatus_Load]      
as                     
BEGIN             
  Begin Try                      
   Begin Transaction           
    Begin           
   Select * from MasterEmployeeStatus      
   Select @@RowCount as RESULT      
  End           
   COMMIT TRANSACTION           
  End try              
 Begin Catch                   
  IF @@TRANCOUNT >0                   
          Select ERROR_MESSAGE()          
    Rollback Transaction            
    EXECUTE [uspLogError]                     
 End Catch                      
END     
GO
--------------------------------------------------------------------------------------------
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
	@EmployeeStatusID int =0
	)
as
begin
INSERT INTO Employees (UserID, EmpNumber, Age, Sex, Race, LastName, FirstName, MiddleName, Height, Weight,DateOfBirth, StaffPosition, Eyes, Complexion, Build, Glasses, Restricted, RoleName, UD9,Department, EmployeeNumber, EmployeeStatusID ,CreatedDate)
values (@UserID,@EmpNumber, @Age, @Sex, @Race, @LastName, @FirstName, @MiddleName, @Height, @Weight,@DateOfBirth, @StaffPosition, @Eyes, @Complexion, @Build, @Glasses, @Restricted, @RoleName, @UD9, @Department, @EmployeeNumber, @EmployeeStatusID ,getdate())
Select @@IDENTITY as Result
End
GO
--------------------------------------------------------------------------------------------
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
	@EmployeeNumber nvarchar(25) =NULL,
	@EmployeeStatusID int=0
	)
as
begin
UPDATE Employees Set  UserID=@UserID, EmpNumber =@EmpNumber, Age = @Age, Sex = @Sex, Race = @Race, LastName = @LastName, FirstName = @FirstName,
 MiddleName = @MiddleName, Height = @Height, Weight = @Weight,DateOfBirth =@DateOfBirth, StaffPosition = @StaffPosition, Eyes = @Eyes, Complexion = @Complexion,
 Build = @Build, Glasses = @Glasses, UD9 = @UD9, Department = @Department, EmployeeNumber = @EmployeeNumber, EmployeeStatusID = @EmployeeStatusID  WHERE EmployeeID = @empID
Select @@ROWCOUNT  as Result
End
GO
--------------------------------------------------------------------------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[AdvancedSearchEmployees]
(  
@EmpNumber nvarchar(25)=null,
@FirstName nvarchar(25)=null,  
@MiddleName nvarchar(25)=null,
@LastName nvarchar(25)=null,  
@Sex nvarchar(10)=null,  
@Race nvarchar(25)=null,  
@Complexion nvarchar(15)=null,
@Eyes nvarchar(10)=null,
@Build nvarchar(15)=null,
@Glasses nvarchar(10)=null ,
@Height nvarchar(10)=null ,
@StaffPosition nvarchar(10)=null ,
@Weight nvarchar(10)=null ,
@EmployeeNumber nvarchar(25)=null,
@EmployeeStatusID nvarchar(10)=null 
)  
AS  
BEGIN  
Declare @SQL nvarchar(max)  
Set @SQL='Select FirstName,LastName,EmployeeID,MiddleName,EmpNumber,EmployeeNumber,ms.sex as sex,(select Top(1) PV.FilePath from EmployeePicturesVideos EPV    
 left join PicturesVideos PV on EPV.MediaID = PV.MediaID     
 where EPV.MediaType=''Employee'' and EmployeeID = Employees.EmployeeID) as FilePath,CreatedDate  from Employees  
  left Outer join MasterSex ms on ms.id = Employees.sex
 where 1=1 '  
   
 if(@EmpNumber is not null)  
  Set @SQL=@SQL+'and EmpNumber like '''+@EmpNumber+'%'''  
  
 if(@FirstName is not null)  
  Set @SQL=@SQL+'and FirstName like '''+@FirstName+'%'''  
    
  if(@LastName is not null)  
  Set @SQL=@SQL+'and LastName like '''+@LastName+'%'''  
    
  if(@Sex is not null)  
  Set @SQL=@SQL+'and Employees.Sex = '''+@Sex+''''
    
  if(@Race is not null)  
  Set @SQL=@SQL+'and Race = '''+@Race+''''
  
  if(@Complexion is not null)  
  Set @SQL=@SQL+'and Complexion = '''+@Complexion+'''' 
      
  if(@Eyes is not null)  
  Set @SQL=@SQL+'and Eyes = '''+@Eyes+''''  
    
   if(@Build is not null)  
  Set @SQL=@SQL+'and Build = '''+@Build+'''' 
    
   if(@Glasses is not null)  
  Set @SQL=@SQL+'and Glasses = '''+@Glasses+'''' 
    
   if(@MiddleName is not null)  
  Set @SQL=@SQL+'and MiddleName like ''%'+@MiddleName+'%''' 

   if(@Height is not null)  
  Set @SQL=@SQL+'and Height = '''+@Height+'''' 

  if(@Weight is not null)  
  Set @SQL=@SQL+'and Weight = '''+@Weight+'''' 

  if(@StaffPosition is not null)  
  Set @SQL=@SQL+'and StaffPosition = '''+@StaffPosition+'''' 

  if(@EmployeeNumber is not null)  
  Set @SQL=@SQL+'and EmployeeNumber = '''+@EmployeeNumber+'''' 

  if(@EmployeeNumber is not null)  
  Set @SQL=@SQL+'and EmployeeNumber = '''+@EmployeeNumber+'''' 

  if(@EmployeeStatusID is not null)  
  Set @SQL=@SQL+'and EmployeeStatusID = '''+@EmployeeStatusID+'''' 
    
 --print(@SQL)  
  execute(@SQL)  
 END
GO
--------------------------------------------------------------------------------------------