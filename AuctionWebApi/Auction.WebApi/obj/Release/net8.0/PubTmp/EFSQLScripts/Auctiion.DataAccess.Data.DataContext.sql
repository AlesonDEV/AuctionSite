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

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
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
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE TABLE [Bids] (
        [id] int NOT NULL IDENTITY,
        [bid_amount] decimal(16,2) NOT NULL,
        [bid_time] datetime NOT NULL,
        CONSTRAINT [PK_Bids] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE TABLE [Categories] (
        [id] int NOT NULL IDENTITY,
        [name] varchar(255) NOT NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE TABLE [Conditions] (
        [id] int NOT NULL IDENTITY,
        [name] varchar(255) NOT NULL,
        CONSTRAINT [PK_Conditions] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE TABLE [Contact_Type] (
        [id] int NOT NULL IDENTITY,
        [name] varchar(100) NOT NULL,
        CONSTRAINT [PK_Contact_Type] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE TABLE [Regions] (
        [id] int NOT NULL IDENTITY,
        [name] varchar(100) NOT NULL,
        CONSTRAINT [PK_Regions] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE TABLE [Statuses] (
        [id] int NOT NULL IDENTITY,
        [name] varchar(255) NOT NULL,
        CONSTRAINT [PK_Statuses] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE TABLE [Persons] (
        [id] int NOT NULL IDENTITY,
        [first_name] varchar(255) NOT NULL,
        [last_name] varchar(255) NOT NULL,
        [region_id] int NOT NULL,
        [settlement] varchar(255) NOT NULL,
        CONSTRAINT [PK_Persons] PRIMARY KEY ([id]),
        CONSTRAINT [FK_Persons_Regions_region_id] FOREIGN KEY ([region_id]) REFERENCES [Regions] ([id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE TABLE [Auctions] (
        [id] int NOT NULL IDENTITY,
        [title] varchar(255) NOT NULL,
        [category_id] int NOT NULL,
        [status_id] int NOT NULL,
        CONSTRAINT [PK_Auctions] PRIMARY KEY ([id]),
        CONSTRAINT [FK_Auctions_Categories_category_id] FOREIGN KEY ([category_id]) REFERENCES [Categories] ([id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Auctions_Statuses_status_id] FOREIGN KEY ([status_id]) REFERENCES [Statuses] ([id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE TABLE [Customers] (
        [person_id] int NOT NULL,
        [count_of_bids] int NOT NULL,
        [user_id] nvarchar(450) NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY ([person_id]),
        CONSTRAINT [FK_Customers_AspNetUsers_user_id] FOREIGN KEY ([user_id]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_Customers_Persons_person_id] FOREIGN KEY ([person_id]) REFERENCES [Persons] ([id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE TABLE [Person_Contact] (
        [id] int NOT NULL IDENTITY,
        [person_id] int NOT NULL,
        [contact_type_id] int NOT NULL,
        [contact_value] varchar(100) NOT NULL,
        CONSTRAINT [PK_Person_Contact] PRIMARY KEY ([id]),
        CONSTRAINT [FK_Person_Contact_Contact_Type_contact_type_id] FOREIGN KEY ([contact_type_id]) REFERENCES [Contact_Type] ([id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Person_Contact_Persons_person_id] FOREIGN KEY ([person_id]) REFERENCES [Persons] ([id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE TABLE [Bid_Auction] (
        [bid_id] int NOT NULL,
        [auction_id] int NOT NULL,
        CONSTRAINT [PK_Bid_Auction] PRIMARY KEY ([bid_id], [auction_id]),
        CONSTRAINT [FK_Bid_Auction_Auctions_auction_id] FOREIGN KEY ([auction_id]) REFERENCES [Auctions] ([id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Bid_Auction_Bids_bid_id] FOREIGN KEY ([bid_id]) REFERENCES [Bids] ([id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE TABLE [Auction_Details] (
        [auction_id] int NOT NULL,
        [current_buyer_id] int NOT NULL,
        [description] varchar(2000) NOT NULL,
        [start_time] datetime NOT NULL,
        [end_time] datetime NOT NULL,
        [starting_price] decimal(16,2) NOT NULL,
        [current_price] decimal(16,2) NOT NULL,
        CONSTRAINT [PK_Auction_Details] PRIMARY KEY ([auction_id]),
        CONSTRAINT [FK_Auction_Details_Auctions_auction_id] FOREIGN KEY ([auction_id]) REFERENCES [Auctions] ([id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Auction_Details_Customers_current_buyer_id] FOREIGN KEY ([current_buyer_id]) REFERENCES [Customers] ([person_id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE TABLE [Auction_User] (
        [auction_id] int NOT NULL,
        [user_id] int NOT NULL,
        CONSTRAINT [PK_Auction_User] PRIMARY KEY ([auction_id], [user_id]),
        CONSTRAINT [FK_Auction_User_Auctions_auction_id] FOREIGN KEY ([auction_id]) REFERENCES [Auctions] ([id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Auction_User_Customers_user_id] FOREIGN KEY ([user_id]) REFERENCES [Customers] ([person_id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE TABLE [Bid_User] (
        [user_id] int NOT NULL,
        [bid_id] int NOT NULL,
        CONSTRAINT [PK_Bid_User] PRIMARY KEY ([bid_id], [user_id]),
        CONSTRAINT [FK_Bid_User_Bids_bid_id] FOREIGN KEY ([bid_id]) REFERENCES [Bids] ([id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Bid_User_Customers_user_id] FOREIGN KEY ([user_id]) REFERENCES [Customers] ([person_id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE TABLE [Item_Details] (
        [auction_details_id] int NOT NULL,
        [condition_id] int NOT NULL,
        CONSTRAINT [PK_Item_Details] PRIMARY KEY ([auction_details_id]),
        CONSTRAINT [FK_Item_Details_Auction_Details_auction_details_id] FOREIGN KEY ([auction_details_id]) REFERENCES [Auction_Details] ([auction_id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Item_Details_Conditions_condition_id] FOREIGN KEY ([condition_id]) REFERENCES [Conditions] ([id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE TABLE [Photos] (
        [Id] int NOT NULL IDENTITY,
        [file_path] varchar(255) NOT NULL,
        [binary_data] varchar(500) NOT NULL,
        [item_id] int NOT NULL,
        CONSTRAINT [PK_Photos] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Photos_Item_Details_item_id] FOREIGN KEY ([item_id]) REFERENCES [Item_Details] ([auction_details_id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE INDEX [IX_Auction_Details_current_buyer_id] ON [Auction_Details] ([current_buyer_id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE INDEX [IX_Auction_User_user_id] ON [Auction_User] ([user_id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE INDEX [IX_Auctions_category_id] ON [Auctions] ([category_id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE INDEX [IX_Auctions_status_id] ON [Auctions] ([status_id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE INDEX [IX_Bid_Auction_auction_id] ON [Bid_Auction] ([auction_id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE INDEX [IX_Bid_User_user_id] ON [Bid_User] ([user_id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE INDEX [IX_Customers_user_id] ON [Customers] ([user_id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE INDEX [IX_Item_Details_condition_id] ON [Item_Details] ([condition_id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE INDEX [IX_Person_Contact_contact_type_id] ON [Person_Contact] ([contact_type_id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE INDEX [IX_Person_Contact_person_id] ON [Person_Contact] ([person_id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE INDEX [IX_Persons_region_id] ON [Persons] ([region_id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    CREATE INDEX [IX_Photos_item_id] ON [Photos] ([item_id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240209204057_Init'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240209204057_Init', N'8.0.1');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240210163843_Second'
)
BEGIN
    ALTER TABLE [Auction_Details] DROP CONSTRAINT [FK_Auction_Details_Customers_current_buyer_id];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240210163843_Second'
)
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Auction_Details]') AND [c].[name] = N'current_buyer_id');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Auction_Details] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Auction_Details] ALTER COLUMN [current_buyer_id] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240210163843_Second'
)
BEGIN
    ALTER TABLE [Auction_Details] ADD CONSTRAINT [FK_Auction_Details_Customers_current_buyer_id] FOREIGN KEY ([current_buyer_id]) REFERENCES [Customers] ([person_id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240210163843_Second'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240210163843_Second', N'8.0.1');
END;
GO

COMMIT;
GO

