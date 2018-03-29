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
 @SubjectStatus nvarchar(25)=null
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
	if(@SubjectStatus<>'')          
    begin          
     set @SQL=@SQL+' and SubjectStatusID = '''+@SubjectStatus+''''          
    end  
        print(@SQL)    
      execute(@SQL)                  
END 



GO


