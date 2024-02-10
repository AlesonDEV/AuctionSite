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
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    CREATE TABLE [bid] (
        [id] int NOT NULL IDENTITY,
        [bid_amount] decimal(16,2) NOT NULL,
        [bid_time] datetime NOT NULL,
        CONSTRAINT [PK_bid] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    CREATE TABLE [category] (
        [id] int NOT NULL IDENTITY,
        [name] varchar NOT NULL,
        CONSTRAINT [PK_category] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    CREATE TABLE [condition] (
        [id] int NOT NULL IDENTITY,
        [name] varchar(255) NOT NULL,
        CONSTRAINT [PK_condition] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    CREATE TABLE [contact_type] (
        [id] int NOT NULL IDENTITY,
        [name] varchar(100) NOT NULL,
        CONSTRAINT [PK_contact_type] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    CREATE TABLE [region] (
        [id] int NOT NULL IDENTITY,
        [name] varchar(100) NOT NULL,
        CONSTRAINT [PK_region] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    CREATE TABLE [status] (
        [id] int NOT NULL IDENTITY,
        [name] varchar NOT NULL,
        CONSTRAINT [PK_status] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    CREATE TABLE [person] (
        [id] int NOT NULL IDENTITY,
        [first_name] varchar NOT NULL,
        [last_name] varchar NOT NULL,
        [region_id] int NOT NULL,
        [settlement] varchar NOT NULL,
        [hashed_password] varchar NOT NULL,
        [hashed_reserved_password] varchar NOT NULL,
        CONSTRAINT [PK_person] PRIMARY KEY ([id]),
        CONSTRAINT [FK_person_region_region_id] FOREIGN KEY ([region_id]) REFERENCES [region] ([id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    CREATE TABLE [auction] (
        [id] int NOT NULL IDENTITY,
        [title] varchar NOT NULL,
        [categoty_id] int NOT NULL,
        [status_id] int NOT NULL,
        CONSTRAINT [PK_auction] PRIMARY KEY ([id]),
        CONSTRAINT [FK_auction_category_categoty_id] FOREIGN KEY ([categoty_id]) REFERENCES [category] ([id]) ON DELETE CASCADE,
        CONSTRAINT [FK_auction_status_status_id] FOREIGN KEY ([status_id]) REFERENCES [status] ([id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    CREATE TABLE [person_contact] (
        [id] int NOT NULL IDENTITY,
        [person_id] int NOT NULL,
        [contact_type_id] int NOT NULL,
        [contact_value] varchar(100) NOT NULL,
        CONSTRAINT [PK_person_contact] PRIMARY KEY ([id]),
        CONSTRAINT [FK_person_contact_contact_type_contact_type_id] FOREIGN KEY ([contact_type_id]) REFERENCES [contact_type] ([id]) ON DELETE CASCADE,
        CONSTRAINT [FK_person_contact_person_person_id] FOREIGN KEY ([person_id]) REFERENCES [person] ([id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    CREATE TABLE [user] (
        [person_id] int NOT NULL,
        [card_number] varchar(25) NOT NULL,
        [count_of_bids] int NOT NULL,
        CONSTRAINT [PK_user] PRIMARY KEY ([person_id]),
        CONSTRAINT [FK_user_person_person_id] FOREIGN KEY ([person_id]) REFERENCES [person] ([id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    CREATE TABLE [bid_auction] (
        [bid_id] int NOT NULL,
        [auction_id] int NOT NULL,
        CONSTRAINT [PK_bid_auction] PRIMARY KEY ([bid_id], [auction_id]),
        CONSTRAINT [FK_bid_auction_auction_auction_id] FOREIGN KEY ([auction_id]) REFERENCES [auction] ([id]) ON DELETE CASCADE,
        CONSTRAINT [FK_bid_auction_bid_bid_id] FOREIGN KEY ([bid_id]) REFERENCES [bid] ([id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    CREATE TABLE [auction_details] (
        [auction_id] int NOT NULL,
        [current_buyer_id] int NOT NULL,
        [description] varchar NOT NULL,
        [start_time] datetime NOT NULL,
        [end_time] datetime NOT NULL,
        [starting_price] decimal(16,2) NOT NULL,
        [current_price] decimal(16,2) NOT NULL,
        CONSTRAINT [PK_auction_details] PRIMARY KEY ([auction_id]),
        CONSTRAINT [FK_auction_details_auction_auction_id] FOREIGN KEY ([auction_id]) REFERENCES [auction] ([id]) ON DELETE CASCADE,
        CONSTRAINT [FK_auction_details_user_current_buyer_id] FOREIGN KEY ([current_buyer_id]) REFERENCES [user] ([person_id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    CREATE TABLE [auction_user] (
        [auction_id] int NOT NULL,
        [user_id] int NOT NULL,
        CONSTRAINT [PK_auction_user] PRIMARY KEY ([auction_id], [user_id]),
        CONSTRAINT [FK_auction_user_auction_auction_id] FOREIGN KEY ([auction_id]) REFERENCES [auction] ([id]) ON DELETE CASCADE,
        CONSTRAINT [FK_auction_user_user_user_id] FOREIGN KEY ([user_id]) REFERENCES [user] ([person_id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    CREATE TABLE [bid_user] (
        [user_id] int NOT NULL,
        [bid_id] int NOT NULL,
        CONSTRAINT [PK_bid_user] PRIMARY KEY ([bid_id], [user_id]),
        CONSTRAINT [FK_bid_user_bid_bid_id] FOREIGN KEY ([bid_id]) REFERENCES [bid] ([id]) ON DELETE CASCADE,
        CONSTRAINT [FK_bid_user_user_user_id] FOREIGN KEY ([user_id]) REFERENCES [user] ([person_id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    CREATE TABLE [item_details] (
        [auction_details_id] int NOT NULL,
        [condition_id] int NOT NULL,
        CONSTRAINT [PK_item_details] PRIMARY KEY ([auction_details_id]),
        CONSTRAINT [FK_item_details_auction_details_auction_details_id] FOREIGN KEY ([auction_details_id]) REFERENCES [auction_details] ([auction_id]) ON DELETE CASCADE,
        CONSTRAINT [FK_item_details_condition_condition_id] FOREIGN KEY ([condition_id]) REFERENCES [condition] ([id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    CREATE TABLE [photo] (
        [Id] int NOT NULL IDENTITY,
        [file_path] varchar NOT NULL,
        [binary_data] varchar NOT NULL,
        [item_id] int NOT NULL,
        CONSTRAINT [PK_photo] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_photo_item_details_item_id] FOREIGN KEY ([item_id]) REFERENCES [item_details] ([auction_details_id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    CREATE INDEX [IX_auction_categoty_id] ON [auction] ([categoty_id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    CREATE INDEX [IX_auction_status_id] ON [auction] ([status_id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    CREATE INDEX [IX_auction_details_current_buyer_id] ON [auction_details] ([current_buyer_id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    CREATE INDEX [IX_auction_user_user_id] ON [auction_user] ([user_id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    CREATE INDEX [IX_bid_auction_auction_id] ON [bid_auction] ([auction_id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    CREATE INDEX [IX_bid_user_user_id] ON [bid_user] ([user_id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    CREATE INDEX [IX_item_details_condition_id] ON [item_details] ([condition_id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    CREATE INDEX [IX_person_region_id] ON [person] ([region_id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    CREATE INDEX [IX_person_contact_contact_type_id] ON [person_contact] ([contact_type_id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    CREATE INDEX [IX_person_contact_person_id] ON [person_contact] ([person_id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    CREATE INDEX [IX_photo_item_id] ON [photo] ([item_id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240207193124_Init'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240207193124_Init', N'8.0.1');
END;
GO

COMMIT;
GO

