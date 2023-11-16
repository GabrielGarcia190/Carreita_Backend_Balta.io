CREATE DATABASE [DapperCrud]
GO

USE [DapperCrud]
GO

CREATE TABLE [Category] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [Title] NVARCHAR(80) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,
    [Description] TEXT
)
Basta 