IF DB_ID('UserAuthDB') IS NULL
    CREATE DATABASE UserAuthDB;
GO
USE UserAuthDB;
GO

IF OBJECT_ID('dbo.Users','U') IS NULL
BEGIN
    CREATE TABLE dbo.Users(
        UserId   INT IDENTITY(1,1) PRIMARY KEY,
        Username NVARCHAR(50)  NOT NULL UNIQUE,
        Email    NVARCHAR(100) NULL UNIQUE,
        Phone NVARCHAR(20) NULL UNIQUE,
        Password NVARCHAR(64) NOT NULL,           
        FullName NVARCHAR(150) NULL,
        Birthday DATE          NULL
    );
END