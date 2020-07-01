USE [EmployeeDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE spUserRegistration
@FirstName nvarchar(50),
@LastName nvarchar(50),
@UserName nvarchar(50),
@MobNO nvarchar(15),
@Email nvarchar(50),
@Password nvarchar(50),
@Address nvarchar(50),
@Department nvarchar(50)
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON; 

	INSERT INTO userRegistration(FirstName,Lastname,UserName,MobNO,Email,Password,Address,Department)
		VALUES(@FirstName,@Lastname,@UserName,@MobNO,@Email,@Password,@Address,@Department);
END