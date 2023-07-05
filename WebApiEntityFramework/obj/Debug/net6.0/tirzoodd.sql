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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621160442_Genres')
BEGIN
    CREATE TABLE [Genres] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(100) NULL,
        CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621160442_Genres')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230621160442_Genres', N'7.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621161323_Actors')
BEGIN
    CREATE TABLE [Actors] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(100) NOT NULL,
        [BioGraphy] text NOT NULL,
        [DateOfBirth] date NOT NULL,
        CONSTRAINT [PK_Actors] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621161323_Actors')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230621161323_Actors', N'7.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621162032_Cinemas')
BEGIN
    CREATE TABLE [Cinemas] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(100) NOT NULL,
        [Price] decimal(9,2) NOT NULL,
        [Location] geography NOT NULL,
        CONSTRAINT [PK_Cinemas] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621162032_Cinemas')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230621162032_Cinemas', N'7.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621170024_CinemaOffers')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Genres]') AND [c].[name] = N'Name');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Genres] DROP CONSTRAINT [' + @var0 + '];');
    EXEC(N'UPDATE [Genres] SET [Name] = N'''' WHERE [Name] IS NULL');
    ALTER TABLE [Genres] ALTER COLUMN [Name] nvarchar(100) NOT NULL;
    ALTER TABLE [Genres] ADD DEFAULT N'' FOR [Name];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621170024_CinemaOffers')
BEGIN
    CREATE TABLE [CinemaOffers] (
        [Id] int NOT NULL IDENTITY,
        [Begin] datetime2 NOT NULL,
        [End] datetime2 NOT NULL,
        [DiscountPercentage] decimal(5,2) NOT NULL,
        [CinemaId] int NOT NULL,
        CONSTRAINT [PK_CinemaOffers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_CinemaOffers_Cinemas_CinemaId] FOREIGN KEY ([CinemaId]) REFERENCES [Cinemas] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621170024_CinemaOffers')
BEGIN
    CREATE TABLE [Movie] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(250) NOT NULL,
        [InCinemas] bit NOT NULL,
        [ReleaseDate] date NOT NULL,
        [PosterURL] varchar(450) NOT NULL,
        CONSTRAINT [PK_Movie] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621170024_CinemaOffers')
BEGIN
    CREATE UNIQUE INDEX [IX_CinemaOffers_CinemaId] ON [CinemaOffers] ([CinemaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621170024_CinemaOffers')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230621170024_CinemaOffers', N'7.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621172231_CinemaHalls')
BEGIN
    CREATE TABLE [CinemaHall] (
        [Id] int NOT NULL IDENTITY,
        [Cost] decimal(9,2) NOT NULL,
        [CinemaId] int NOT NULL,
        CONSTRAINT [PK_CinemaHall] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_CinemaHall_Cinemas_CinemaId] FOREIGN KEY ([CinemaId]) REFERENCES [Cinemas] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621172231_CinemaHalls')
BEGIN
    CREATE INDEX [IX_CinemaHall_CinemaId] ON [CinemaHall] ([CinemaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621172231_CinemaHalls')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230621172231_CinemaHalls', N'7.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621174059_CinemaHallTypes')
BEGIN
    ALTER TABLE [CinemaHall] DROP CONSTRAINT [FK_CinemaHall_Cinemas_CinemaId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621174059_CinemaHallTypes')
BEGIN
    ALTER TABLE [CinemaHall] DROP CONSTRAINT [PK_CinemaHall];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621174059_CinemaHallTypes')
BEGIN
    EXEC sp_rename N'[CinemaHall]', N'CinemaHalls';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621174059_CinemaHallTypes')
BEGIN
    EXEC sp_rename N'[CinemaHalls].[IX_CinemaHall_CinemaId]', N'IX_CinemaHalls_CinemaId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621174059_CinemaHallTypes')
BEGIN
    ALTER TABLE [CinemaHalls] ADD [Type] int NOT NULL DEFAULT 1;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621174059_CinemaHallTypes')
BEGIN
    ALTER TABLE [CinemaHalls] ADD CONSTRAINT [PK_CinemaHalls] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621174059_CinemaHallTypes')
BEGIN
    ALTER TABLE [CinemaHalls] ADD CONSTRAINT [FK_CinemaHalls_Cinemas_CinemaId] FOREIGN KEY ([CinemaId]) REFERENCES [Cinemas] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621174059_CinemaHallTypes')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230621174059_CinemaHallTypes', N'7.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621181122_MovieGenres')
BEGIN
    CREATE TABLE [GenreMovie] (
        [GenresId] int NOT NULL,
        [MoviesId] int NOT NULL,
        CONSTRAINT [PK_GenreMovie] PRIMARY KEY ([GenresId], [MoviesId]),
        CONSTRAINT [FK_GenreMovie_Genres_GenresId] FOREIGN KEY ([GenresId]) REFERENCES [Genres] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_GenreMovie_Movie_MoviesId] FOREIGN KEY ([MoviesId]) REFERENCES [Movie] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621181122_MovieGenres')
BEGIN
    CREATE INDEX [IX_GenreMovie_MoviesId] ON [GenreMovie] ([MoviesId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621181122_MovieGenres')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230621181122_MovieGenres', N'7.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621183049_MovieActors')
BEGIN
    CREATE TABLE [MovieActors] (
        [MovieId] int NOT NULL,
        [ActorId] int NOT NULL,
        [Character] nvarchar(100) NOT NULL,
        [Order] int NOT NULL,
        CONSTRAINT [PK_MovieActors] PRIMARY KEY ([MovieId], [ActorId]),
        CONSTRAINT [FK_MovieActors_Actors_ActorId] FOREIGN KEY ([ActorId]) REFERENCES [Actors] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_MovieActors_Movie_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movie] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621183049_MovieActors')
BEGIN
    CREATE INDEX [IX_MovieActors_ActorId] ON [MovieActors] ([ActorId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230621183049_MovieActors')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230621183049_MovieActors', N'7.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230622095813_CinemaHallMovies')
BEGIN
    EXEC sp_rename N'[Actors].[BioGraphy]', N'Biography', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230622095813_CinemaHallMovies')
BEGIN
    CREATE TABLE [CinemaHallMovie] (
        [CinemaHallsId] int NOT NULL,
        [MoviesId] int NOT NULL,
        CONSTRAINT [PK_CinemaHallMovie] PRIMARY KEY ([CinemaHallsId], [MoviesId]),
        CONSTRAINT [FK_CinemaHallMovie_CinemaHalls_CinemaHallsId] FOREIGN KEY ([CinemaHallsId]) REFERENCES [CinemaHalls] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_CinemaHallMovie_Movie_MoviesId] FOREIGN KEY ([MoviesId]) REFERENCES [Movie] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230622095813_CinemaHallMovies')
BEGIN
    CREATE INDEX [IX_CinemaHallMovie_MoviesId] ON [CinemaHallMovie] ([MoviesId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230622095813_CinemaHallMovies')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230622095813_CinemaHallMovies', N'7.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230622100005_ModelSeeding')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Actors]') AND [c].[name] = N'Biography');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Actors] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Actors] ALTER COLUMN [Biography] text NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230622100005_ModelSeeding')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Biography', N'DateOfBirth', N'Name') AND [object_id] = OBJECT_ID(N'[Actors]'))
        SET IDENTITY_INSERT [Actors] ON;
    EXEC(N'INSERT INTO [Actors] ([Id], [Biography], [DateOfBirth], [Name])
    VALUES (1, ''Thomas Stanley Holland (born 1 June 1996) is an English actor. He is recipient of several accolades, including the 2017 BAFTA Rising Star Award. Holland began his acting career as a child actor on the West End stage in Billy Elliot the Musical at the Victoria Palace Theatre in 2008, playing a supporting part'', ''1996-06-01'', N''Tom Holland''),
    (2, ''Samuel Leroy Jackson (born December 21, 1948) is an American actor and producer. One of the most widely recognized actors of his generation, the films in which he has appeared have collectively grossed over $27 billion worldwide, making him the highest-grossing actor of all time (excluding cameo appearances and voice roles).'', ''1948-12-21'', N''Samuel L. Jackson''),
    (3, ''Robert John Downey Jr. (born April 4, 1965) is an American actor and producer. His career has been characterized by critical and popular success in his youth, followed by a period of substance abuse and legal troubles, before a resurgence of commercial success later in his career.'', ''1965-04-04'', N''Robert Downey Jr.''),
    (4, NULL, ''1981-06-13'', N''Chris Evans''),
    (5, NULL, ''1972-05-02'', N''Dwayne Johnson''),
    (6, NULL, ''2000-11-22'', N''Auli''''i Cravalho''),
    (7, NULL, ''1984-11-22'', N''Scarlett Johansson''),
    (8, NULL, ''1964-09-02'', N''Keanu Reeves'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Biography', N'DateOfBirth', N'Name') AND [object_id] = OBJECT_ID(N'[Actors]'))
        SET IDENTITY_INSERT [Actors] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230622100005_ModelSeeding')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Location', N'Name', N'Price') AND [object_id] = OBJECT_ID(N'[Cinemas]'))
        SET IDENTITY_INSERT [Cinemas] ON;
    EXEC(N'INSERT INTO [Cinemas] ([Id], [Location], [Name], [Price])
    VALUES (1, geography::Parse(''POINT (-69.9388777 18.4839233)''), N''Agora Mall'', 0.0),
    (2, geography::Parse(''POINT (-69.911582 18.482455)''), N''Sambil'', 0.0),
    (3, geography::Parse(''POINT (-69.856309 18.506662)''), N''Megacentro'', 0.0),
    (4, geography::Parse(''POINT (-69.939248 18.469649)''), N''Acropolis'', 0.0)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Location', N'Name', N'Price') AND [object_id] = OBJECT_ID(N'[Cinemas]'))
        SET IDENTITY_INSERT [Cinemas] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230622100005_ModelSeeding')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Genres]'))
        SET IDENTITY_INSERT [Genres] ON;
    EXEC(N'INSERT INTO [Genres] ([Id], [Name])
    VALUES (1, N''Action''),
    (2, N''Animation''),
    (3, N''Comedy''),
    (4, N''Science Fiction''),
    (5, N''Drama'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Genres]'))
        SET IDENTITY_INSERT [Genres] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230622100005_ModelSeeding')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'InCinemas', N'PosterURL', N'ReleaseDate', N'Title') AND [object_id] = OBJECT_ID(N'[Movie]'))
        SET IDENTITY_INSERT [Movie] ON;
    EXEC(N'INSERT INTO [Movie] ([Id], [InCinemas], [PosterURL], [ReleaseDate], [Title])
    VALUES (1, CAST(0 AS bit), ''https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg'', ''2012-04-11'', N''Avengers''),
    (2, CAST(0 AS bit), ''https://upload.wikimedia.org/wikipedia/en/9/98/Coco_%282017_film%29_poster.jpg'', ''2017-11-22'', N''Coco''),
    (3, CAST(0 AS bit), ''https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg'', ''2022-12-17'', N''Spider-Man: No way home''),
    (4, CAST(0 AS bit), ''https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg'', ''2019-07-02'', N''Spider-Man: Far From Home''),
    (5, CAST(1 AS bit), ''https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg'', ''2023-01-01'', N''The Matrix Resurrections'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'InCinemas', N'PosterURL', N'ReleaseDate', N'Title') AND [object_id] = OBJECT_ID(N'[Movie]'))
        SET IDENTITY_INSERT [Movie] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230622100005_ModelSeeding')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CinemaId', N'Cost', N'Type') AND [object_id] = OBJECT_ID(N'[CinemaHalls]'))
        SET IDENTITY_INSERT [CinemaHalls] ON;
    EXEC(N'INSERT INTO [CinemaHalls] ([Id], [CinemaId], [Cost], [Type])
    VALUES (1, 1, 220.0, 1),
    (2, 1, 320.0, 2),
    (3, 2, 200.0, 1),
    (4, 2, 290.0, 2),
    (5, 3, 250.0, 1),
    (6, 3, 330.0, 2),
    (7, 3, 450.0, 3),
    (8, 4, 250.0, 1)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CinemaId', N'Cost', N'Type') AND [object_id] = OBJECT_ID(N'[CinemaHalls]'))
        SET IDENTITY_INSERT [CinemaHalls] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230622100005_ModelSeeding')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Begin', N'CinemaId', N'DiscountPercentage', N'End') AND [object_id] = OBJECT_ID(N'[CinemaOffers]'))
        SET IDENTITY_INSERT [CinemaOffers] ON;
    EXEC(N'INSERT INTO [CinemaOffers] ([Id], [Begin], [CinemaId], [DiscountPercentage], [End])
    VALUES (1, ''2022-02-22T00:00:00.0000000'', 1, 10.0, ''2022-04-22T00:00:00.0000000''),
    (2, ''2022-02-15T00:00:00.0000000'', 4, 15.0, ''2022-02-22T00:00:00.0000000'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Begin', N'CinemaId', N'DiscountPercentage', N'End') AND [object_id] = OBJECT_ID(N'[CinemaOffers]'))
        SET IDENTITY_INSERT [CinemaOffers] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230622100005_ModelSeeding')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'GenresId', N'MoviesId') AND [object_id] = OBJECT_ID(N'[GenreMovie]'))
        SET IDENTITY_INSERT [GenreMovie] ON;
    EXEC(N'INSERT INTO [GenreMovie] ([GenresId], [MoviesId])
    VALUES (1, 1),
    (1, 3),
    (1, 4),
    (1, 5),
    (2, 2),
    (3, 3),
    (3, 4),
    (4, 1),
    (4, 3),
    (4, 4),
    (4, 5),
    (5, 5)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'GenresId', N'MoviesId') AND [object_id] = OBJECT_ID(N'[GenreMovie]'))
        SET IDENTITY_INSERT [GenreMovie] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230622100005_ModelSeeding')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ActorId', N'MovieId', N'Character', N'Order') AND [object_id] = OBJECT_ID(N'[MovieActors]'))
        SET IDENTITY_INSERT [MovieActors] ON;
    EXEC(N'INSERT INTO [MovieActors] ([ActorId], [MovieId], [Character], [Order])
    VALUES (3, 1, N''Iron Man'', 2),
    (4, 1, N''Capitán América'', 1),
    (7, 1, N''Black Widow'', 3),
    (1, 3, N''Peter Parker'', 1),
    (1, 4, N''Peter Parker'', 1),
    (2, 4, N''Samuel L. Jackson'', 2),
    (8, 5, N''Neo'', 1)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ActorId', N'MovieId', N'Character', N'Order') AND [object_id] = OBJECT_ID(N'[MovieActors]'))
        SET IDENTITY_INSERT [MovieActors] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230622100005_ModelSeeding')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CinemaHallsId', N'MoviesId') AND [object_id] = OBJECT_ID(N'[CinemaHallMovie]'))
        SET IDENTITY_INSERT [CinemaHallMovie] ON;
    EXEC(N'INSERT INTO [CinemaHallMovie] ([CinemaHallsId], [MoviesId])
    VALUES (1, 5),
    (2, 5),
    (3, 5),
    (4, 5),
    (5, 5),
    (6, 5),
    (7, 5)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CinemaHallsId', N'MoviesId') AND [object_id] = OBJECT_ID(N'[CinemaHallMovie]'))
        SET IDENTITY_INSERT [CinemaHallMovie] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230622100005_ModelSeeding')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230622100005_ModelSeeding', N'7.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230622152727_ChangeMovietoMovies')
BEGIN
    ALTER TABLE [CinemaHallMovie] DROP CONSTRAINT [FK_CinemaHallMovie_Movie_MoviesId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230622152727_ChangeMovietoMovies')
BEGIN
    ALTER TABLE [GenreMovie] DROP CONSTRAINT [FK_GenreMovie_Movie_MoviesId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230622152727_ChangeMovietoMovies')
BEGIN
    ALTER TABLE [MovieActors] DROP CONSTRAINT [FK_MovieActors_Movie_MovieId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230622152727_ChangeMovietoMovies')
BEGIN
    ALTER TABLE [Movie] DROP CONSTRAINT [PK_Movie];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230622152727_ChangeMovietoMovies')
BEGIN
    EXEC sp_rename N'[Movie]', N'Movies';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230622152727_ChangeMovietoMovies')
BEGIN
    ALTER TABLE [Movies] ADD CONSTRAINT [PK_Movies] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230622152727_ChangeMovietoMovies')
BEGIN
    ALTER TABLE [CinemaHallMovie] ADD CONSTRAINT [FK_CinemaHallMovie_Movies_MoviesId] FOREIGN KEY ([MoviesId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230622152727_ChangeMovietoMovies')
BEGIN
    ALTER TABLE [GenreMovie] ADD CONSTRAINT [FK_GenreMovie_Movies_MoviesId] FOREIGN KEY ([MoviesId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230622152727_ChangeMovietoMovies')
BEGIN
    ALTER TABLE [MovieActors] ADD CONSTRAINT [FK_MovieActors_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230622152727_ChangeMovietoMovies')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230622152727_ChangeMovietoMovies', N'7.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230623183858_addingIsDeletedColumnToGenre')
BEGIN
    ALTER TABLE [Genres] ADD [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230623183858_addingIsDeletedColumnToGenre')
BEGIN
    EXEC(N'UPDATE [Genres] SET [IsDeleted] = CAST(0 AS bit)
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230623183858_addingIsDeletedColumnToGenre')
BEGIN
    EXEC(N'UPDATE [Genres] SET [IsDeleted] = CAST(0 AS bit)
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230623183858_addingIsDeletedColumnToGenre')
BEGIN
    EXEC(N'UPDATE [Genres] SET [IsDeleted] = CAST(0 AS bit)
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230623183858_addingIsDeletedColumnToGenre')
BEGIN
    EXEC(N'UPDATE [Genres] SET [IsDeleted] = CAST(0 AS bit)
    WHERE [Id] = 4;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230623183858_addingIsDeletedColumnToGenre')
BEGIN
    EXEC(N'UPDATE [Genres] SET [IsDeleted] = CAST(0 AS bit)
    WHERE [Id] = 5;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230623183858_addingIsDeletedColumnToGenre')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230623183858_addingIsDeletedColumnToGenre', N'7.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702120055_Logs')
BEGIN
    CREATE TABLE [Logs] (
        [Id] uniqueidentifier NOT NULL,
        [Message] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Logs] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702120055_Logs')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230702120055_Logs', N'7.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702130826_AddingGenreIndexes')
BEGIN
    CREATE INDEX [IX_Genres_IsDeleted] ON [Genres] ([IsDeleted]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702130826_AddingGenreIndexes')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_Genres_Name] ON [Genres] ([Name]) WHERE isDeleted = ''false''');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702130826_AddingGenreIndexes')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230702130826_AddingGenreIndexes', N'7.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702135450_addingConversionToCinemaHall')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CinemaHalls]') AND [c].[name] = N'Type');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [CinemaHalls] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [CinemaHalls] ALTER COLUMN [Type] nvarchar(max) NOT NULL;
    ALTER TABLE [CinemaHalls] ADD DEFAULT N'TwoDimensions' FOR [Type];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702135450_addingConversionToCinemaHall')
BEGIN
    EXEC(N'UPDATE [CinemaHalls] SET [Type] = N''TwoDimensions''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702135450_addingConversionToCinemaHall')
BEGIN
    EXEC(N'UPDATE [CinemaHalls] SET [Type] = N''ThreeDimensions''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702135450_addingConversionToCinemaHall')
BEGIN
    EXEC(N'UPDATE [CinemaHalls] SET [Type] = N''TwoDimensions''
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702135450_addingConversionToCinemaHall')
BEGIN
    EXEC(N'UPDATE [CinemaHalls] SET [Type] = N''ThreeDimensions''
    WHERE [Id] = 4;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702135450_addingConversionToCinemaHall')
BEGIN
    EXEC(N'UPDATE [CinemaHalls] SET [Type] = N''TwoDimensions''
    WHERE [Id] = 5;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702135450_addingConversionToCinemaHall')
BEGIN
    EXEC(N'UPDATE [CinemaHalls] SET [Type] = N''ThreeDimensions''
    WHERE [Id] = 6;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702135450_addingConversionToCinemaHall')
BEGIN
    EXEC(N'UPDATE [CinemaHalls] SET [Type] = N''CXC''
    WHERE [Id] = 7;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702135450_addingConversionToCinemaHall')
BEGIN
    EXEC(N'UPDATE [CinemaHalls] SET [Type] = N''TwoDimensions''
    WHERE [Id] = 8;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702135450_addingConversionToCinemaHall')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230702135450_addingConversionToCinemaHall', N'7.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702141344_AddingConverters')
BEGIN
    ALTER TABLE [CinemaHalls] ADD [Currency] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702141344_AddingConverters')
BEGIN
    EXEC(N'UPDATE [CinemaHalls] SET [Currency] = N''''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702141344_AddingConverters')
BEGIN
    EXEC(N'UPDATE [CinemaHalls] SET [Currency] = N''''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702141344_AddingConverters')
BEGIN
    EXEC(N'UPDATE [CinemaHalls] SET [Currency] = N''''
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702141344_AddingConverters')
BEGIN
    EXEC(N'UPDATE [CinemaHalls] SET [Currency] = N''''
    WHERE [Id] = 4;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702141344_AddingConverters')
BEGIN
    EXEC(N'UPDATE [CinemaHalls] SET [Currency] = N''''
    WHERE [Id] = 5;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702141344_AddingConverters')
BEGIN
    EXEC(N'UPDATE [CinemaHalls] SET [Currency] = N''''
    WHERE [Id] = 6;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702141344_AddingConverters')
BEGIN
    EXEC(N'UPDATE [CinemaHalls] SET [Currency] = N''''
    WHERE [Id] = 7;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702141344_AddingConverters')
BEGIN
    EXEC(N'UPDATE [CinemaHalls] SET [Currency] = N''''
    WHERE [Id] = 8;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702141344_AddingConverters')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230702141344_AddingConverters', N'7.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702153842_AddingViewMovieCount')
BEGIN
    CREATE VIEW dbo.MoviesWithCounts
                                        as
                                        Select Id, Title,
                                        (Select count(*) FROM GenreMovie where MoviesId = movies.Id) as AmountGenres,
                                        (Select count(distinct moviesId) from CinemaHallMovie
                                        	INNER JOIN CinemaHalls
                                        	ON CinemaHalls.Id = CinemaHallMovie.CinemaHallsId
                                        	where MoviesId = movies.Id) as AmountCinemas,
                                        (Select count(*) from MovieActors where MovieId = movies.Id) as AmountActors
                                        FROM Movies
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702153842_AddingViewMovieCount')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230702153842_AddingViewMovieCount', N'7.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702183401_ChangingCinemaToOptionsRelationship')
BEGIN
    ALTER TABLE [CinemaHalls] DROP CONSTRAINT [FK_CinemaHalls_Cinemas_CinemaId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702183401_ChangingCinemaToOptionsRelationship')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CinemaHalls]') AND [c].[name] = N'CinemaId');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [CinemaHalls] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [CinemaHalls] ALTER COLUMN [CinemaId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702183401_ChangingCinemaToOptionsRelationship')
BEGIN
    ALTER TABLE [CinemaHalls] ADD CONSTRAINT [FK_CinemaHalls_Cinemas_CinemaId] FOREIGN KEY ([CinemaId]) REFERENCES [Cinemas] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702183401_ChangingCinemaToOptionsRelationship')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230702183401_ChangingCinemaToOptionsRelationship', N'7.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702192215_PersonsWithMessages')
BEGIN
    CREATE TABLE [Persons] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Persons] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702192215_PersonsWithMessages')
BEGIN
    CREATE TABLE [Messages] (
        [Id] int NOT NULL IDENTITY,
        [Content] nvarchar(max) NOT NULL,
        [SenderId] int NOT NULL,
        [ReceiverId] int NOT NULL,
        CONSTRAINT [PK_Messages] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Messages_Persons_ReceiverId] FOREIGN KEY ([ReceiverId]) REFERENCES [Persons] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Messages_Persons_SenderId] FOREIGN KEY ([SenderId]) REFERENCES [Persons] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702192215_PersonsWithMessages')
BEGIN
    CREATE INDEX [IX_Messages_ReceiverId] ON [Messages] ([ReceiverId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702192215_PersonsWithMessages')
BEGIN
    CREATE INDEX [IX_Messages_SenderId] ON [Messages] ([SenderId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702192215_PersonsWithMessages')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230702192215_PersonsWithMessages', N'7.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702192409_PersonsMessagesSeeding')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Persons]'))
        SET IDENTITY_INSERT [Persons] ON;
    EXEC(N'INSERT INTO [Persons] ([Id], [Name])
    VALUES (1, N''Felipe''),
    (2, N''Claudia'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Persons]'))
        SET IDENTITY_INSERT [Persons] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702192409_PersonsMessagesSeeding')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Content', N'ReceiverId', N'SenderId') AND [object_id] = OBJECT_ID(N'[Messages]'))
        SET IDENTITY_INSERT [Messages] ON;
    EXEC(N'INSERT INTO [Messages] ([Id], [Content], [ReceiverId], [SenderId])
    VALUES (1, N''Hello, Claudia!'', 2, 1),
    (2, N''Hello, Felipe, how are you?'', 1, 2),
    (3, N''All good, and you?'', 2, 1),
    (4, N''Very good :)'', 1, 2)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Content', N'ReceiverId', N'SenderId') AND [object_id] = OBJECT_ID(N'[Messages]'))
        SET IDENTITY_INSERT [Messages] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702192409_PersonsMessagesSeeding')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230702192409_PersonsMessagesSeeding', N'7.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702210312_AddingCinemaDetail')
BEGIN
    CREATE TABLE [CinemaDeatails] (
        [Id] int NOT NULL,
        [History] nvarchar(max) NOT NULL,
        [Values] nvarchar(max) NOT NULL,
        [Missions] nvarchar(max) NOT NULL,
        [CodeOfCoduct] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_CinemaDeatails] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_CinemaDeatails_Cinemas_Id] FOREIGN KEY ([Id]) REFERENCES [Cinemas] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702210312_AddingCinemaDetail')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230702210312_AddingCinemaDetail', N'7.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702213001_AddingAddressColumns')
BEGIN
    ALTER TABLE [Cinemas] ADD [Country] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702213001_AddingAddressColumns')
BEGIN
    ALTER TABLE [Cinemas] ADD [Street] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702213001_AddingAddressColumns')
BEGIN
    ALTER TABLE [Actors] ADD [BillingAddress_Country] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702213001_AddingAddressColumns')
BEGIN
    ALTER TABLE [Actors] ADD [BillingAddress_Street] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702213001_AddingAddressColumns')
BEGIN
    ALTER TABLE [Actors] ADD [HomeAddress_Country] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702213001_AddingAddressColumns')
BEGIN
    ALTER TABLE [Actors] ADD [HomeAddress_Street] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702213001_AddingAddressColumns')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230702213001_AddingAddressColumns', N'7.0.7');
END;
GO

COMMIT;
GO

