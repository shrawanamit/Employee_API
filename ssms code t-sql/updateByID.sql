USE [EmployeeDB]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateEmployees]    Script Date: 29-06-2020 14:46:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spUpdateEmployees]  
@EmployeeID int,
@FirstName nvarchar(50),
@LastName nvarchar(50),
@MobNO bigint,
@Email nvarchar(50),
@Password nvarchar(50),
@Address nvarchar(50),
@Department nvarchar(50),
@Salery bigint
  
AS  
BEGIN  
    -- SET NOCOUNT ON added to prevent extra result sets from  
    -- interfering with SELECT statements.  
    SET NOCOUNT ON;  
  
    UPDATE dbo.Employee  
    Set FirstName = @FirstName,  
        LastName = @LastName,  
        MobNO = @MobNO,  
		Email = @Email,  
        Password = @Password,  
        Address = @Address,  
		Department = @Department,  
        Salary = @Salery  
    Where EmployeeID = @EmployeeID 
END  