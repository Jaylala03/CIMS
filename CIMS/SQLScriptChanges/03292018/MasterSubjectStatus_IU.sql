SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  
Create Procedure [dbo].[MasterSubjectStatus_IU](      
@Id int,      
@Status nvarchar(200)      
)      
as                     
BEGIN             
  Begin Try                      
   Begin Transaction           
    Begin           
  if exists(SELECT *  FROM MasterSubjectStatus  where Id=@Id)        
   begin        
   update MasterSubjectStatus set [Status]=@Status where Id=@Id        
   select @@RowCount as RESULT    
   end        
  ELSE        
  begin        
   insert into MasterSubjectStatus([Status]) values(@Status)        
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


