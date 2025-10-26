IF DB_ID('UserAuthDB') IS NULL
    CREATE DATABASE UserAuthDB;
GO
USE UserAuthDB;
GO
IF OBJECT_ID('dbo.Users','U') IS NULL
BEGIN
    CREATE TABLE dbo.Users(
        Id INT IDENTITY PRIMARY KEY,
        Username NVARCHAR(50) NOT NULL,
        Email NVARCHAR(100) NULL,
        Phone NVARCHAR(20) NULL,
        Password NVARCHAR(64) NOT NULL
    );
END
GO
