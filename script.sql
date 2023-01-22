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

CREATE TABLE [Areas] (
    [AreaId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Address] nvarchar(max) NOT NULL,
    [Status] bit NOT NULL,
    CONSTRAINT [PK_Areas] PRIMARY KEY ([AreaId])
);
GO

CREATE TABLE [ExpenseTypes] (
    [ExpenseTypeId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Price] real NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_ExpenseTypes] PRIMARY KEY ([ExpenseTypeId])
);
GO

CREATE TABLE [FeedbackTypes] (
    [FeedbackTypeId] int NOT NULL IDENTITY,
    [Name] int NOT NULL,
    CONSTRAINT [PK_FeedbackTypes] PRIMARY KEY ([FeedbackTypeId])
);
GO

CREATE TABLE [FlatTypes] (
    [FlatTypeId] int NOT NULL IDENTITY,
    [Capacity] int NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_FlatTypes] PRIMARY KEY ([FlatTypeId])
);
GO

CREATE TABLE [Majors] (
    [MajorId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Majors] PRIMARY KEY ([MajorId])
);
GO

CREATE TABLE [PaymentType] (
    [PaymentTypeId] int NOT NULL IDENTITY,
    [PaymentName] nvarchar(max) NOT NULL,
    [PaymentStatus] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_PaymentType] PRIMARY KEY ([PaymentTypeId])
);
GO

CREATE TABLE [RequestTypes] (
    [RequestTypeId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [Status] bit NOT NULL,
    CONSTRAINT [PK_RequestTypes] PRIMARY KEY ([RequestTypeId])
);
GO

CREATE TABLE [Roles] (
    [RoleId] int NOT NULL IDENTITY,
    [RoleName] nvarchar(max) NOT NULL,
    [Status] bit NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([RoleId])
);
GO

CREATE TABLE [ServiceTypes] (
    [ServiceTypeId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_ServiceTypes] PRIMARY KEY ([ServiceTypeId])
);
GO

CREATE TABLE [University] (
    [UniversityId] int NOT NULL IDENTITY,
    [UniversityName] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [Image] nvarchar(max) NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    [Address] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_University] PRIMARY KEY ([UniversityId])
);
GO

CREATE TABLE [Apartments] (
    [ApartmentId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [AreaId] int NOT NULL,
    CONSTRAINT [PK_Apartments] PRIMARY KEY ([ApartmentId]),
    CONSTRAINT [FK_Apartments_Areas_AreaId] FOREIGN KEY ([AreaId]) REFERENCES [Areas] ([AreaId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Requests] (
    [RequestId] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NOT NULL,
    [CreateDate] datetime2 NOT NULL,
    [SolveDate] datetime2 NOT NULL,
    [RequestTypeId] int NOT NULL,
    CONSTRAINT [PK_Requests] PRIMARY KEY ([RequestId]),
    CONSTRAINT [FK_Requests_RequestTypes_RequestTypeId] FOREIGN KEY ([RequestTypeId]) REFERENCES [RequestTypes] ([RequestTypeId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Accounts] (
    [AccountId] int NOT NULL IDENTITY,
    [Username] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Phone] nvarchar(max) NOT NULL,
    [Status] bit NOT NULL,
    [RoleId] int NOT NULL,
    CONSTRAINT [PK_Accounts] PRIMARY KEY ([AccountId]),
    CONSTRAINT [FK_Accounts_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([RoleId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Services] (
    [ServiceId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    [ServiceTypeId] int NOT NULL,
    CONSTRAINT [PK_Services] PRIMARY KEY ([ServiceId]),
    CONSTRAINT [FK_Services_ServiceTypes_ServiceTypeId] FOREIGN KEY ([ServiceTypeId]) REFERENCES [ServiceTypes] ([ServiceTypeId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Renters] (
    [RenterId] int NOT NULL IDENTITY,
    [Email] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [Phone] int NOT NULL,
    [FullName] nvarchar(max) NOT NULL,
    [BirthDate] datetime2 NOT NULL,
    [Status] bit NOT NULL,
    [RoleId] int NOT NULL,
    [Image] nvarchar(max) NOT NULL,
    [Address] nvarchar(max) NOT NULL,
    [Gender] nvarchar(max) NOT NULL,
    [UniversityId] int NOT NULL,
    [MajorId] int NOT NULL,
    CONSTRAINT [PK_Renters] PRIMARY KEY ([RenterId]),
    CONSTRAINT [FK_Renters_Majors_MajorId] FOREIGN KEY ([MajorId]) REFERENCES [Majors] ([MajorId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Renters_University_UniversityId] FOREIGN KEY ([UniversityId]) REFERENCES [University] ([UniversityId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Buildings] (
    [BuildingId] int NOT NULL IDENTITY,
    [BuildingName] nvarchar(max) NOT NULL,
    [ImageUrl] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [TotalFloor] int NULL,
    [TotalRooms] int NULL,
    [CoordinateX] int NULL,
    [CoordinateY] int NULL,
    [Status] bit NOT NULL,
    [ApartmentId] int NOT NULL,
    CONSTRAINT [PK_Buildings] PRIMARY KEY ([BuildingId]),
    CONSTRAINT [FK_Buildings_Apartments_ApartmentId] FOREIGN KEY ([ApartmentId]) REFERENCES [Apartments] ([ApartmentId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Expenses] (
    [ExpenseId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [SupervisorId] int NOT NULL,
    [ExpenseTypeId] int NOT NULL,
    CONSTRAINT [PK_Expenses] PRIMARY KEY ([ExpenseId]),
    CONSTRAINT [FK_Expenses_Accounts_SupervisorId] FOREIGN KEY ([SupervisorId]) REFERENCES [Accounts] ([AccountId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Expenses_ExpenseTypes_ExpenseTypeId] FOREIGN KEY ([ExpenseTypeId]) REFERENCES [ExpenseTypes] ([ExpenseTypeId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Orders] (
    [OrderId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    [RenterId] int NOT NULL,
    [RequestId] int NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderId]),
    CONSTRAINT [FK_Orders_Renters_RenterId] FOREIGN KEY ([RenterId]) REFERENCES [Renters] ([RenterId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Orders_Requests_RequestId] FOREIGN KEY ([RequestId]) REFERENCES [Requests] ([RequestId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Payments] (
    [PaymentId] int NOT NULL IDENTITY,
    [Detail] nvarchar(max) NOT NULL,
    [Amount] real NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    [PaymentTime] datetime2 NOT NULL,
    [PaymentPeriod] time NOT NULL,
    [CreatedTime] datetime2 NOT NULL,
    [RenterId] int NOT NULL,
    [PaymentTypeId] int NOT NULL,
    CONSTRAINT [PK_Payments] PRIMARY KEY ([PaymentId]),
    CONSTRAINT [FK_Payments_PaymentType_PaymentTypeId] FOREIGN KEY ([PaymentTypeId]) REFERENCES [PaymentType] ([PaymentTypeId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Payments_Renters_RenterId] FOREIGN KEY ([RenterId]) REFERENCES [Renters] ([RenterId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Flats] (
    [FlatId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    [FlatTypeId] int NOT NULL,
    [BuildingId] int NOT NULL,
    CONSTRAINT [PK_Flats] PRIMARY KEY ([FlatId]),
    CONSTRAINT [FK_Flats_Buildings_BuildingId] FOREIGN KEY ([BuildingId]) REFERENCES [Buildings] ([BuildingId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Flats_FlatTypes_FlatTypeId] FOREIGN KEY ([FlatTypeId]) REFERENCES [FlatTypes] ([FlatTypeId]) ON DELETE CASCADE
);
GO

CREATE TABLE [ExpenseHistories] (
    [ExpenseHistoryId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Date] datetime2 NOT NULL,
    [ExpenseId] int NULL,
    CONSTRAINT [PK_ExpenseHistories] PRIMARY KEY ([ExpenseHistoryId]),
    CONSTRAINT [FK_ExpenseHistories_Expenses_ExpenseId] FOREIGN KEY ([ExpenseId]) REFERENCES [Expenses] ([ExpenseId])
);
GO

CREATE TABLE [OrderDetails] (
    [OrderDetailId] int NOT NULL IDENTITY,
    [Amount] real NOT NULL,
    [OrderId] int NOT NULL,
    [ServiceEntityId] int NOT NULL,
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY ([OrderDetailId]),
    CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([OrderId]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderDetails_Services_ServiceEntityId] FOREIGN KEY ([ServiceEntityId]) REFERENCES [Services] ([ServiceId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Contracts] (
    [ContractId] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [DateSigned] datetime2 NOT NULL,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NOT NULL,
    [LastUpdated] datetime2 NOT NULL,
    [ContractStatus] nvarchar(max) NOT NULL,
    [Price] real NOT NULL,
    [FlatId] int NOT NULL,
    [RenterId] int NOT NULL,
    CONSTRAINT [PK_Contracts] PRIMARY KEY ([ContractId]),
    CONSTRAINT [FK_Contracts_Flats_FlatId] FOREIGN KEY ([FlatId]) REFERENCES [Flats] ([FlatId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Contracts_Renters_RenterId] FOREIGN KEY ([RenterId]) REFERENCES [Renters] ([RenterId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Feedbacks] (
    [FeedbackId] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    [CreateDate] datetime2 NOT NULL,
    [FlatId] int NOT NULL,
    [FeedbackTypeId] int NOT NULL,
    [RenterId] int NOT NULL,
    CONSTRAINT [PK_Feedbacks] PRIMARY KEY ([FeedbackId]),
    CONSTRAINT [FK_Feedbacks_FeedbackTypes_FeedbackTypeId] FOREIGN KEY ([FeedbackTypeId]) REFERENCES [FeedbackTypes] ([FeedbackTypeId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Feedbacks_Flats_FlatId] FOREIGN KEY ([FlatId]) REFERENCES [Flats] ([FlatId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Feedbacks_Renters_RenterId] FOREIGN KEY ([RenterId]) REFERENCES [Renters] ([RenterId]) ON DELETE CASCADE
);
GO

CREATE TABLE [ContractHistories] (
    [ContractHistoryId] int NOT NULL IDENTITY,
    [Price] real NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [ContractHistoryStatus] nvarchar(max) NOT NULL,
    [ContractExpiredDate] datetime2 NOT NULL,
    [ContractId] int NOT NULL,
    CONSTRAINT [PK_ContractHistories] PRIMARY KEY ([ContractHistoryId]),
    CONSTRAINT [FK_ContractHistories_Contracts_ContractId] FOREIGN KEY ([ContractId]) REFERENCES [Contracts] ([ContractId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Invoices] (
    [InvoiceId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Detail] nvarchar(max) NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    [ContractId] int NOT NULL,
    [SenderId] int NOT NULL,
    CONSTRAINT [PK_Invoices] PRIMARY KEY ([InvoiceId]),
    CONSTRAINT [FK_Invoices_Accounts_SenderId] FOREIGN KEY ([SenderId]) REFERENCES [Accounts] ([AccountId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Invoices_Contracts_ContractId] FOREIGN KEY ([ContractId]) REFERENCES [Contracts] ([ContractId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Bills] (
    [BillId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Detail] nvarchar(max) NOT NULL,
    [DueDate] datetime2 NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    [InvoiceId] int NOT NULL,
    [PaymentId] int NULL,
    CONSTRAINT [PK_Bills] PRIMARY KEY ([BillId]),
    CONSTRAINT [FK_Bills_Invoices_InvoiceId] FOREIGN KEY ([InvoiceId]) REFERENCES [Invoices] ([InvoiceId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Bills_Payments_PaymentId] FOREIGN KEY ([PaymentId]) REFERENCES [Payments] ([PaymentId])
);
GO

CREATE TABLE [InvoiceHistories] (
    [InvoiceHistoryId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Detail] nvarchar(max) NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    [SendDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NOT NULL,
    [Image] nvarchar(max) NOT NULL,
    [InvoiceId] int NOT NULL,
    CONSTRAINT [PK_InvoiceHistories] PRIMARY KEY ([InvoiceHistoryId]),
    CONSTRAINT [FK_InvoiceHistories_Invoices_InvoiceId] FOREIGN KEY ([InvoiceId]) REFERENCES [Invoices] ([InvoiceId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Accounts_RoleId] ON [Accounts] ([RoleId]);
GO

CREATE INDEX [IX_Apartments_AreaId] ON [Apartments] ([AreaId]);
GO

CREATE INDEX [IX_Bills_InvoiceId] ON [Bills] ([InvoiceId]);
GO

CREATE INDEX [IX_Bills_PaymentId] ON [Bills] ([PaymentId]);
GO

CREATE INDEX [IX_Buildings_ApartmentId] ON [Buildings] ([ApartmentId]);
GO

CREATE INDEX [IX_ContractHistories_ContractId] ON [ContractHistories] ([ContractId]);
GO

CREATE INDEX [IX_Contracts_FlatId] ON [Contracts] ([FlatId]);
GO

CREATE INDEX [IX_Contracts_RenterId] ON [Contracts] ([RenterId]);
GO

CREATE INDEX [IX_ExpenseHistories_ExpenseId] ON [ExpenseHistories] ([ExpenseId]);
GO

CREATE INDEX [IX_Expenses_ExpenseTypeId] ON [Expenses] ([ExpenseTypeId]);
GO

CREATE INDEX [IX_Expenses_SupervisorId] ON [Expenses] ([SupervisorId]);
GO

CREATE INDEX [IX_Feedbacks_FeedbackTypeId] ON [Feedbacks] ([FeedbackTypeId]);
GO

CREATE INDEX [IX_Feedbacks_FlatId] ON [Feedbacks] ([FlatId]);
GO

CREATE INDEX [IX_Feedbacks_RenterId] ON [Feedbacks] ([RenterId]);
GO

CREATE INDEX [IX_Flats_BuildingId] ON [Flats] ([BuildingId]);
GO

CREATE INDEX [IX_Flats_FlatTypeId] ON [Flats] ([FlatTypeId]);
GO

CREATE INDEX [IX_InvoiceHistories_InvoiceId] ON [InvoiceHistories] ([InvoiceId]);
GO

CREATE INDEX [IX_Invoices_ContractId] ON [Invoices] ([ContractId]);
GO

CREATE INDEX [IX_Invoices_SenderId] ON [Invoices] ([SenderId]);
GO

CREATE INDEX [IX_OrderDetails_OrderId] ON [OrderDetails] ([OrderId]);
GO

CREATE INDEX [IX_OrderDetails_ServiceEntityId] ON [OrderDetails] ([ServiceEntityId]);
GO

CREATE INDEX [IX_Orders_RenterId] ON [Orders] ([RenterId]);
GO

CREATE INDEX [IX_Orders_RequestId] ON [Orders] ([RequestId]);
GO

CREATE INDEX [IX_Payments_PaymentTypeId] ON [Payments] ([PaymentTypeId]);
GO

CREATE INDEX [IX_Payments_RenterId] ON [Payments] ([RenterId]);
GO

CREATE INDEX [IX_Renters_MajorId] ON [Renters] ([MajorId]);
GO

CREATE INDEX [IX_Renters_UniversityId] ON [Renters] ([UniversityId]);
GO

CREATE INDEX [IX_Requests_RequestTypeId] ON [Requests] ([RequestTypeId]);
GO

CREATE INDEX [IX_Services_ServiceTypeId] ON [Services] ([ServiceTypeId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221006015213_Initial', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Bills] DROP CONSTRAINT [FK_Bills_Payments_PaymentId];
GO

ALTER TABLE [OrderDetails] DROP CONSTRAINT [FK_OrderDetails_Services_ServiceEntityId];
GO

ALTER TABLE [Payments] DROP CONSTRAINT [FK_Payments_Renters_RenterId];
GO

DROP INDEX [IX_OrderDetails_ServiceEntityId] ON [OrderDetails];
GO

DROP INDEX [IX_Bills_PaymentId] ON [Bills];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bills]') AND [c].[name] = N'PaymentId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Bills] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Bills] DROP COLUMN [PaymentId];
GO

EXEC sp_rename N'[Payments].[RenterId]', N'OrderId', N'COLUMN';
GO

EXEC sp_rename N'[Payments].[IX_Payments_RenterId]', N'IX_Payments_OrderId', N'INDEX';
GO

EXEC sp_rename N'[OrderDetails].[ServiceEntityId]', N'ServiceId', N'COLUMN';
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Renters]') AND [c].[name] = N'Phone');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Renters] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Renters] ALTER COLUMN [Phone] nvarchar(max) NOT NULL;
GO

ALTER TABLE [Renters] ADD [Username] nvarchar(max) NOT NULL DEFAULT N'';
GO

ALTER TABLE [OrderDetails] ADD [ServiceEntityServiceId] int NOT NULL DEFAULT 0;
GO

CREATE INDEX [IX_OrderDetails_ServiceEntityServiceId] ON [OrderDetails] ([ServiceEntityServiceId]);
GO

ALTER TABLE [OrderDetails] ADD CONSTRAINT [FK_OrderDetails_Services_ServiceEntityServiceId] FOREIGN KEY ([ServiceEntityServiceId]) REFERENCES [Services] ([ServiceId]) ON DELETE CASCADE;
GO

ALTER TABLE [Payments] ADD CONSTRAINT [FK_Payments_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([OrderId]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221006133506_Fix', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Renters]') AND [c].[name] = N'RoleId');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Renters] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Renters] DROP COLUMN [RoleId];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221006142023_RemoveRenterRoleId', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [ExpenseHistories] DROP CONSTRAINT [FK_ExpenseHistories_Expenses_ExpenseId];
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Contracts]') AND [c].[name] = N'UserId');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Contracts] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Contracts] DROP COLUMN [UserId];
GO

EXEC sp_rename N'[PaymentType].[PaymentStatus]', N'Status', N'COLUMN';
GO

EXEC sp_rename N'[PaymentType].[PaymentName]', N'Name', N'COLUMN';
GO

DROP INDEX [IX_ExpenseHistories_ExpenseId] ON [ExpenseHistories];
DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ExpenseHistories]') AND [c].[name] = N'ExpenseId');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [ExpenseHistories] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [ExpenseHistories] ALTER COLUMN [ExpenseId] int NOT NULL;
ALTER TABLE [ExpenseHistories] ADD DEFAULT 0 FOR [ExpenseId];
CREATE INDEX [IX_ExpenseHistories_ExpenseId] ON [ExpenseHistories] ([ExpenseId]);
GO

ALTER TABLE [ExpenseHistories] ADD CONSTRAINT [FK_ExpenseHistories_Expenses_ExpenseId] FOREIGN KEY ([ExpenseId]) REFERENCES [Expenses] ([ExpenseId]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221007155745_FixRelationship', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[University]') AND [c].[name] = N'Status');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [University] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [University] ALTER COLUMN [Status] nvarchar(max) NULL;
GO

ALTER TABLE [ServiceTypes] ADD [Status] nvarchar(max) NULL;
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PaymentType]') AND [c].[name] = N'Status');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [PaymentType] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [PaymentType] ALTER COLUMN [Status] nvarchar(max) NULL;
GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Payments]') AND [c].[name] = N'Status');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Payments] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Payments] ALTER COLUMN [Status] nvarchar(max) NULL;
GO

ALTER TABLE [Invoices] ADD [Image] nvarchar(max) NOT NULL DEFAULT N'';
GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[FlatTypes]') AND [c].[name] = N'Status');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [FlatTypes] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [FlatTypes] ALTER COLUMN [Status] nvarchar(max) NULL;
GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Flats]') AND [c].[name] = N'Status');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Flats] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [Flats] ALTER COLUMN [Status] nvarchar(max) NULL;
GO

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[FeedbackTypes]') AND [c].[name] = N'Name');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [FeedbackTypes] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [FeedbackTypes] ALTER COLUMN [Name] nvarchar(max) NOT NULL;
GO

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Feedbacks]') AND [c].[name] = N'Status');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Feedbacks] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [Feedbacks] ALTER COLUMN [Status] nvarchar(max) NULL;
GO

ALTER TABLE [Contracts] ADD [Description] nvarchar(max) NOT NULL DEFAULT N'';
GO

DECLARE @var12 sysname;
SELECT @var12 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bills]') AND [c].[name] = N'Status');
IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Bills] DROP CONSTRAINT [' + @var12 + '];');
ALTER TABLE [Bills] ALTER COLUMN [Status] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221010160407_UpdateToSomeTable', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [OrderDetails] DROP CONSTRAINT [FK_OrderDetails_Services_ServiceEntityServiceId];
GO

DROP INDEX [IX_OrderDetails_ServiceEntityServiceId] ON [OrderDetails];
GO

DECLARE @var13 sysname;
SELECT @var13 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OrderDetails]') AND [c].[name] = N'ServiceEntityServiceId');
IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [OrderDetails] DROP CONSTRAINT [' + @var13 + '];');
ALTER TABLE [OrderDetails] DROP COLUMN [ServiceEntityServiceId];
GO

CREATE INDEX [IX_OrderDetails_ServiceId] ON [OrderDetails] ([ServiceId]);
GO

ALTER TABLE [OrderDetails] ADD CONSTRAINT [FK_OrderDetails_Services_ServiceId] FOREIGN KEY ([ServiceId]) REFERENCES [Services] ([ServiceId]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221016054812_FixOrderDetailRelationship', N'6.0.9');
GO

COMMIT;
GO

