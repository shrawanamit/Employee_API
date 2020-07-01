SET ANSI_NULLS ON  
GO  
SET QUOTED_IDENTIFIER ON  
GO  
CREATE PROCEDURE spGetAllEmployees  
AS  
BEGIN  
      
    SET NOCOUNT ON;  
    Select * from dbo.Employee  
END  
GO  