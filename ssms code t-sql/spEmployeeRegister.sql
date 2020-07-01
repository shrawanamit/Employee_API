USE [EmployeeDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE spEmployeeRegistration
@EmployeeId int,
@FirstName nvarchar(50),
@LastName nvarchar(50),
@MobNO int,
@Email nvarchar(50),
@Password nvarchar(50),
@Address nvarchar(50),
@Department nvarchar(50),
@Salery int
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON; 

	INSERT INTO Employee(EmployeeId,FirstName,Lastname,MobNO,Email,Password,Address,Department,Salery)
		VALUES(@EmployeeId,@FirstName,@Lastname,@MobNO,@Email,@Password,@Address,@Department,@Salery);
END