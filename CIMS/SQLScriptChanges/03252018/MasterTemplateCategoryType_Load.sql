SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[MasterTemplateCategoryType_Load]

AS             
BEGIN   
  Begin Try            
   Begin Transaction 
    Begin 
		SELECT MasterTemplateCategoryType.id, MasterTemplateCategory.id AS MasterTemplateCategoryid, MasterTemplateCategory.CategoryName, MasterTemplateCategoryType.TemplateName,
		MasterTemplateCategoryType.Content AS Content  FROM MasterTemplateCategoryType
		INNER JOIN MasterTemplateCategory ON MasterTemplateCategoryType.CategoryID = MasterTemplateCategory.id
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


