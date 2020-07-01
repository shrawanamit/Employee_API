USE [EmployeeDB]
-- Create a new table called 'Employee' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Employee', 'U') IS NOT NULL
DROP TABLE dbo.Employee
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Employee
(
   EmployeeId        INT    IDENTITY(1,1) NOT NULL   PRIMARY KEY, -- primary key column
   FirstName      [NVARCHAR](50)  NOT NULL,
   LastName      [NVARCHAR](50)  NOT NULL,
   MobNO     [NVARCHAR](15)  NOT NULL,
   Email      [NVARCHAR](50) UNIQUE NOT NULL,
   Password      [NVARCHAR](50)  NOT NULL,
   Address    [NVARCHAR](50)  NOT NULL,
   Department      [NVARCHAR](50)  NOT NULL,
   Salary    int  NOT NULL
);
GO