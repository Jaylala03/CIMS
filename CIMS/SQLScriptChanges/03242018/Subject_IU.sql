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
@SubjectNumber nvarchar(25) = null
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
			SubjectNumber = @SubjectNumber
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
									Status ,RoleName ,CIDSubject ,CIDPersonID ,ModifiedDate,CreatedBy,AgeRange,SubjectNumber) 
			values (@VIP,@Sex ,@Race ,@LastName,@FirstName ,@MiddleName ,@Height,	
									@Weight,	@Age,@DateOfBirth, @HairColor ,@Eyes,	@Complexion ,
									@Build ,@FacialHair ,@HairLength ,@Glasses ,@Restricted ,
									@Status ,@RoleName ,@CIDSubject ,@CIDPersonID ,getdate(),@CreatedBy,@AgeRange,@SubjectNumber) 
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


