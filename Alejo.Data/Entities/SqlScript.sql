IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [AppUser] (
    [Id] nvarchar(450) NOT NULL,
    [UserName] nvarchar(max) NULL,
    [NormalizedUserName] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [NormalizedEmail] nvarchar(max) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_AppUser] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AspNetRole] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(max) NULL,
    [NormalizedName] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [Discriminator] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_AspNetRole] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AspNetRoleClaim] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(max) NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaim] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AspNetUserClaim] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(max) NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaim] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AspNetUserLogin] (
    [LoginProvider] nvarchar(max) NULL,
    [ProviderKey] nvarchar(max) NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogin] PRIMARY KEY ([UserId])
);

GO

CREATE TABLE [AspNetUserRole] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRole] PRIMARY KEY ([RoleId], [UserId])
);

GO

CREATE TABLE [AspNetUserToken] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserToken] PRIMARY KEY ([UserId])
);

GO

CREATE TABLE [Schedules] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    [AccessCode] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Phone] nvarchar(max) NULL,
    [Address] nvarchar(max) NULL,
    [Date] datetime2 NOT NULL,
    [Purpose] nvarchar(max) NULL,
    [FromWhere] nvarchar(max) NULL,
    [ToWhom] nvarchar(max) NULL,
    [CompanyName] nvarchar(max) NULL,
    [EventName] nvarchar(max) NULL,
    [Details] nvarchar(max) NULL,
    [AppUserId] nvarchar(450) NULL,
    CONSTRAINT [PK_Schedules] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Schedules_AppUser_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AppUser] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Schedules_AppUserId] ON [Schedules] ([AppUserId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180823072023_InitialSetup', N'2.1.1-rtm-30846');

GO

