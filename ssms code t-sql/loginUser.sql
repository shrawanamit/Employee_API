USE [EmployeeDB]
GO
/****** Object:  StoredProcedure [dbo].[spUserlogin]    Script Date: 01-07-2020 16:38:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[spUserlogin]

(

        @UserName nvarchar(50),
        @Password nvarchar(50)
		

)

AS
BEGIN

SET NOCOUNT ON
	DECLARE @Status int
	IF EXISTS(SELECT * FROM dbo.userRegistration WHERE [UserName] = @UserName AND [Password] = @Password )
		SET @Status = 1
	ELSE
		SET @Status = 0
	SELECT @Status
END