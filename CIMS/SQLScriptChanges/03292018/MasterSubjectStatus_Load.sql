SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[MasterSubjectStatus_Load]      
as                     
BEGIN             
  Begin Try                      
   Begin Transaction           
    Begin           
   Select * from MasterSubjectStatus      
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


