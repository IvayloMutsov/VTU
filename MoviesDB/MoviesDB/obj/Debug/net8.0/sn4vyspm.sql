IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Actors] (
    [ID] int NOT NULL IDENTITY,
    [Name] nvarchar(30) NOT NULL,
    CONSTRAINT [PK_Actors] PRIMARY KEY ([ID])
);

CREATE TABLE [Directors] (
    [ID] int NOT NULL IDENTITY,
    [Name] nvarchar(30) NOT NULL,
    CONSTRAINT [PK_Directors] PRIMARY KEY ([ID])
);

CREATE TABLE [Genres] (
    [ID] int NOT NULL IDENTITY,
    [Type] nvarchar(30) NOT NULL,
    CONSTRAINT [PK_Genres] PRIMARY KEY ([ID])
);

CREATE TABLE [Movies] (
    [ID] int NOT NULL IDENTITY,
    [Name] nvarchar(30) NOT NULL,
    [ReleaseYear] int NOT NULL,
    [Duration] int NOT NULL,
    [Rating] float NOT NULL,
    [Metascore] float NOT NULL,
    [Votes] int NOT NULL,
    [GenreID] int NOT NULL,
    [DirectorID] int NOT NULL,
    [CastID] int NOT NULL,
    [Gross] int NOT NULL,
    CONSTRAINT [PK_Movies] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Movies_Actors_CastID] FOREIGN KEY ([CastID]) REFERENCES [Actors] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Movies_Directors_DirectorID] FOREIGN KEY ([DirectorID]) REFERENCES [Directors] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Movies_Genres_GenreID] FOREIGN KEY ([GenreID]) REFERENCES [Genres] ([ID]) ON DELETE CASCADE
);

CREATE INDEX [IX_Movies_CastID] ON [Movies] ([CastID]);

CREATE INDEX [IX_Movies_DirectorID] ON [Movies] ([DirectorID]);

CREATE INDEX [IX_Movies_GenreID] ON [Movies] ([GenreID]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250519094417_InitialCreate', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250519095654_SecondTry', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250519102110_ThirdAtempt', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250519103549_Fourth', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250519103628_Five', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250519104029_six', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250519105926_LuckySeven', N'9.0.5');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250519110133_LuckyEight', N'9.0.5');

DECLARE @var sysname;
SELECT @var = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Movies]') AND [c].[name] = N'Name');
IF @var IS NOT NULL EXEC(N'ALTER TABLE [Movies] DROP CONSTRAINT [' + @var + '];');
ALTER TABLE [Movies] ALTER COLUMN [Name] nvarchar(50) NOT NULL;

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Genres]') AND [c].[name] = N'Type');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Genres] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Genres] ALTER COLUMN [Type] nvarchar(50) NOT NULL;

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Directors]') AND [c].[name] = N'Name');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Directors] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Directors] ALTER COLUMN [Name] nvarchar(50) NOT NULL;

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Actors]') AND [c].[name] = N'Name');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Actors] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Actors] ALTER COLUMN [Name] nvarchar(50) NOT NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250519162526_ChangeMaxLenght', N'9.0.5');

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Movies]') AND [c].[name] = N'Name');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Movies] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Movies] ALTER COLUMN [Name] nvarchar(70) NOT NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250519165836_ChangeMaxLenghtOnMovies', N'9.0.5');

COMMIT;
GO

