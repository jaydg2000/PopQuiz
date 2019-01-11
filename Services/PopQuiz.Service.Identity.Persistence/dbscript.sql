IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Roles] (
    [id] int NOT NULL IDENTITY,
    [RoleType] nvarchar(max) NOT NULL,
    [description] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([id])
);

GO

CREATE TABLE [Users] (
    [id] int NOT NULL IDENTITY,
    [user_id] nvarchar(50) NOT NULL,
    [first_name] nvarchar(50) NOT NULL,
    [last_name] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([id])
);

GO

CREATE TABLE [UserRole] (
    [UserId] int NOT NULL,
    [RoleId] int NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_UserRole_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserRole_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([id]) ON DELETE CASCADE
);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'description', N'RoleType') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] ON;
INSERT INTO [Roles] ([id], [description], [RoleType])
VALUES (1, N'Guest', N'Guest'),
(2, N'Administrator', N'Admin'),
(3, N'Quiz Creator', N'QuizCreator'),
(4, N'Quiz Taker', N'QuizTaker');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'id', N'description', N'RoleType') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] OFF;

GO

CREATE INDEX [IX_UserRole_RoleId] ON [UserRole] ([RoleId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190111222833_Initial', N'2.2.1-servicing-10028');

GO

