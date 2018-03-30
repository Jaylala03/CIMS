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
@SubjectStatus nvarchar(10)=null 
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

  if(@SubjectStatus is not null)  
  Set @SQL=@SQL+'and SubjectStatusID = '''+@SubjectStatus+'''' 
    
 --print(@SQL)  
  execute(@SQL)  
 END



GO


