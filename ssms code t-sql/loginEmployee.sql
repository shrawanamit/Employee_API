USE [EmployeeDB]
GO
/****** Object:  StoredProcedure [dbo].[splogin]    Script Date: 30-06-2020 08:05:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[splogin]

(

        @Email nvarchar(50),
        @Password nvarchar(50)
		

)

AS
BEGIN

SET NOCOUNT ON
	DECLARE @Status int
	IF EXISTS(SELECT * FROM dbo.Employee WHERE [Email] = @Email AND [Password] = @Password )
		SET @Status = 1
	ELSE
		SET @Status = 0
	SELECT @Status
END