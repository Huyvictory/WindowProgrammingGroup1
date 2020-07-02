
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/23/2020 10:38:57
-- Generated from EDMX file: C:\Users\HT\Desktop\New folder (3)\New folder\Another Test2\AnotherTest\Models\ReadingProgramDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DBReadingProgram];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_Documents_dbo_Users_Users_username]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Documents] DROP CONSTRAINT [FK_dbo_Documents_dbo_Users_Users_username];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Notes_dbo_Documents_Document_link]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Notes] DROP CONSTRAINT [FK_dbo_Notes_dbo_Documents_Document_link];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Documents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Documents];
GO
IF OBJECT_ID(N'[dbo].[Notes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Notes];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Documents'
CREATE TABLE [dbo].[Documents] (
    [link] nvarchar(128)  NOT NULL,
    [bookname] nvarchar(max)  NULL,
    [photo] varbinary(max)  NULL,
    [type] nvarchar(max)  NULL,
    [Users_username] nvarchar(128)  NULL
);
GO

-- Creating table 'Notes'
CREATE TABLE [dbo].[Notes] (
    [bookname] nvarchar(128)  NOT NULL,
    [username] nvarchar(max)  NULL,
    [note1] nvarchar(max)  NULL,
    [Document_link] nvarchar(128)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [username] nvarchar(128)  NOT NULL,
    [password] nvarchar(max)  NULL,
    [name] nvarchar(max)  NULL,
    [phone] nvarchar(max)  NULL,
    [birthday] datetime  NULL,
    [email] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [link] in table 'Documents'
ALTER TABLE [dbo].[Documents]
ADD CONSTRAINT [PK_Documents]
    PRIMARY KEY CLUSTERED ([link] ASC);
GO

-- Creating primary key on [bookname] in table 'Notes'
ALTER TABLE [dbo].[Notes]
ADD CONSTRAINT [PK_Notes]
    PRIMARY KEY CLUSTERED ([bookname] ASC);
GO

-- Creating primary key on [username] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([username] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Users_username] in table 'Documents'
ALTER TABLE [dbo].[Documents]
ADD CONSTRAINT [FK_dbo_Documents_dbo_Users_Users_username]
    FOREIGN KEY ([Users_username])
    REFERENCES [dbo].[Users]
        ([username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Documents_dbo_Users_Users_username'
CREATE INDEX [IX_FK_dbo_Documents_dbo_Users_Users_username]
ON [dbo].[Documents]
    ([Users_username]);
GO

-- Creating foreign key on [Document_link] in table 'Notes'
ALTER TABLE [dbo].[Notes]
ADD CONSTRAINT [FK_dbo_Notes_dbo_Documents_Document_link]
    FOREIGN KEY ([Document_link])
    REFERENCES [dbo].[Documents]
        ([link])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Notes_dbo_Documents_Document_link'
CREATE INDEX [IX_FK_dbo_Notes_dbo_Documents_Document_link]
ON [dbo].[Notes]
    ([Document_link]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------