USE [CIMS]
GO
/****** Object:  StoredProcedure [dbo].[CheckDuplicateUser]    Script Date: 02/11/2018 1:46:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[CheckDuplicateUser] --'naina@nextolive.com',123456      
(      
    @UserName nvarchar(100) = null,
    @ID int = null
)      
AS       
BEGIN      
  
 Begin Try      
  Begin Transaction      
  begin      
   if(Exists (select * from Users where UserName = @UserName AND  (@ID <> ID OR ISNULL(@ID,0) = 0)))      
    Begin       
     select 1     
     end      
    end 
  COMMIT TRANSACTION              
 End try      
 Begin Catch      
  IF @@TRANCOUNT >0                    
   rollback Transaction      
 End Catch      
END