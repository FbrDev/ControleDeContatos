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
GO

CREATE TABLE [Contatos] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Celular] nvarchar(max) NULL,
    CONSTRAINT [PK_Contatos] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220627220957_CriandoTabelaContatos', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Contatos]') AND [c].[name] = N'Nome');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Contatos] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Contatos] ALTER COLUMN [Nome] nvarchar(max) NOT NULL;
ALTER TABLE [Contatos] ADD DEFAULT N'' FOR [Nome];
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Contatos]') AND [c].[name] = N'Email');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Contatos] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Contatos] ALTER COLUMN [Email] nvarchar(max) NOT NULL;
ALTER TABLE [Contatos] ADD DEFAULT N'' FOR [Email];
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Contatos]') AND [c].[name] = N'Celular');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Contatos] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Contatos] ALTER COLUMN [Celular] nvarchar(max) NOT NULL;
ALTER TABLE [Contatos] ADD DEFAULT N'' FOR [Celular];
GO

ALTER TABLE [Contatos] ADD [DataAlteracao] datetime2 NULL;
GO

ALTER TABLE [Contatos] ADD [DataCadastro] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
GO

CREATE TABLE [Usuarios] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(max) NULL,
    [Login] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Perfil] int NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    [DataAlteracao] datetime2 NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220629195834_AdicionandoTabelaUsuario', N'5.0.17');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Usuarios]') AND [c].[name] = N'Nome');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Usuarios] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Usuarios] ALTER COLUMN [Nome] nvarchar(max) NOT NULL;
ALTER TABLE [Usuarios] ADD DEFAULT N'' FOR [Nome];
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Usuarios]') AND [c].[name] = N'Login');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Usuarios] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Usuarios] ALTER COLUMN [Login] nvarchar(max) NOT NULL;
ALTER TABLE [Usuarios] ADD DEFAULT N'' FOR [Login];
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Usuarios]') AND [c].[name] = N'Email');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Usuarios] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Usuarios] ALTER COLUMN [Email] nvarchar(max) NOT NULL;
ALTER TABLE [Usuarios] ADD DEFAULT N'' FOR [Email];
GO

ALTER TABLE [Usuarios] ADD [Senha] nvarchar(max) NOT NULL DEFAULT N'';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220629204140_AdicionandoCampoSenha', N'5.0.17');
GO

COMMIT;
GO

