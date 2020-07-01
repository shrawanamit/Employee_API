SET ANSI_NULLS ON  
GO  
SET QUOTED_IDENTIFIER ON  
GO  
-- =============================================  
-- Author:      Amit 
-- Create date: 28-6-2020  
-- Description: Delete a Member by Email  
-- =============================================  
CREATE PROCEDURE spDeleteEmployeesByEmail   
   @Email nvarchar(50)
AS  
BEGIN  
    -- SET NOCOUNT ON added to prevent extra result sets from  
    -- interfering with SELECT statements.  
    SET NOCOUNT ON;  
  
    Delete from dbo.Employee  
    where Email = @Email  
      
END  
GO  