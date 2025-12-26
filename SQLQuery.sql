IF DB_ID('QuizDB') IS NULL
    CREATE DATABASE QuizDB;
GO
USE QuizDB;
GO

IF OBJECT_ID('dbo.Users','U') IS NULL
BEGIN
    CREATE TABLE dbo.Users(
        UserId INT IDENTITY(1,1) PRIMARY KEY,
        Username NVARCHAR(50) NOT NULL UNIQUE,
        Email NVARCHAR(100) NULL UNIQUE,
        Phone NVARCHAR(20) NULL UNIQUE,
        Password NVARCHAR(64) NOT NULL,           
        FullName NVARCHAR(150) NULL,
        Birthday DATE NULL
    );
END
GO

IF OBJECT_ID('dbo.Question','U') IS NULL
BEGIN
    CREATE TABLE dbo.Question(
        Id INT IDENTITY(1,1) PRIMARY KEY,
        NoiDung NVARCHAR(500) NOT NULL,
        DapAnDung NVARCHAR(200) NOT NULL,
        DapAnSai1 NVARCHAR(200) NOT NULL,
        DapAnSai2 NVARCHAR(200) NOT NULL,
        DapAnSai3 NVARCHAR(200) NOT NULL,
        UserId INT NOT NULL,
        FOREIGN KEY (UserId) REFERENCES dbo.Users(UserId)
    );
END
GO

IF OBJECT_ID('dbo.DeThi','U') IS NULL
BEGIN
    CREATE TABLE dbo.DeThi(
        IdDeThi INT IDENTITY(1,1) PRIMARY KEY,
        TenDeThi NVARCHAR(200) NOT NULL,
        SoCau INT NOT NULL,
        NgayTao DATETIME DEFAULT GETDATE(),
        UserId INT NOT NULL,
        FOREIGN KEY (UserId) REFERENCES dbo.Users(UserId)
    );
END
GO

IF OBJECT_ID('dbo.DeThi_CauHoi','U') IS NULL
BEGIN
    CREATE TABLE dbo.DeThi_CauHoi(
        IdDeThi INT NOT NULL,
        IdCauHoi INT NOT NULL,
        PRIMARY KEY (IdDeThi, IdCauHoi),
        FOREIGN KEY (IdDeThi) REFERENCES dbo.DeThi(IdDeThi) ON DELETE CASCADE,
        FOREIGN KEY (IdCauHoi) REFERENCES dbo.Question(Id) ON DELETE CASCADE
    );
END
GO

