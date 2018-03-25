SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[MasterTemplateCategory_Load]

AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		SELECT *  FROM MasterTemplateCategory
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


