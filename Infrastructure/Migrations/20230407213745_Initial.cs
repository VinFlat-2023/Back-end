﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    AreaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.AreaId);
                });

            migrationBuilder.CreateTable(
                name: "FeedbackTypes",
                columns: table => new
                {
                    FeedbackTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackTypes", x => x.FeedbackTypeId);
                });

            migrationBuilder.CreateTable(
                name: "FlatTypes",
                columns: table => new
                {
                    FlatTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlatTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomCapacity = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlatTypes", x => x.FlatTypeId);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceTypes",
                columns: table => new
                {
                    InvoiceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceTypeIdWildCard = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceTypes", x => x.InvoiceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "NotificationType",
                columns: table => new
                {
                    NotificationTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationTypeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationType", x => x.NotificationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "PlaceholderForFee",
                columns: table => new
                {
                    PlaceholderForFeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceholderForFee", x => x.PlaceholderForFeeId);
                });

            migrationBuilder.CreateTable(
                name: "Renters",
                columns: table => new
                {
                    RenterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RenterAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CitizenNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CitizenImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceToken = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renters", x => x.RenterId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    RoomTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfSlots = table.Column<int>(type: "int", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.RoomTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.ServiceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TicketTypes",
                columns: table => new
                {
                    TicketTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTypes", x => x.TicketTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Utility",
                columns: table => new
                {
                    UtilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilitiesName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl4 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utility", x => x.UtilityId);
                });

            migrationBuilder.CreateTable(
                name: "WalletType",
                columns: table => new
                {
                    WalletTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WalletTypeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletType", x => x.WalletTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    NotificationTypeId = table.Column<int>(type: "int", nullable: false),
                    ActionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionStatusColor = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Notificat__Notif__10216507",
                        column: x => x.NotificationTypeId,
                        principalTable: "NotificationType",
                        principalColumn: "NotificationTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    WalletID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Balance = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    WalletTypeID = table.Column<int>(type: "int", nullable: false),
                    RenterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.WalletID);
                    table.ForeignKey(
                        name: "FK_Wallet_Renters_RenterId",
                        column: x => x.RenterId,
                        principalTable: "Renters",
                        principalColumn: "RenterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wallet_WalletType_WalletTypeID",
                        column: x => x.WalletTypeID,
                        principalTable: "WalletType",
                        principalColumn: "WalletTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalFlats = table.Column<int>(type: "int", nullable: false),
                    CoordinateX = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CoordinateY = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BuildingPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AveragePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.BuildingId);
                    table.ForeignKey(
                        name: "FK_Buildings_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Buildings_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RenterId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    InvoiceTypeId = table.Column<int>(type: "int", nullable: false),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoices_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_InvoiceTypes_InvoiceTypeId",
                        column: x => x.InvoiceTypeId,
                        principalTable: "InvoiceTypes",
                        principalColumn: "InvoiceTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Renters_RenterId",
                        column: x => x.RenterId,
                        principalTable: "Renters",
                        principalColumn: "RenterId");
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "InvoicesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.CreateTable(
                name: "UserDevice",
                columns: table => new
                {
                    UserDeviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeviceToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    RenterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDevice", x => x.UserDeviceId);
                    table.ForeignKey(
                        name: "FK_UserDevice_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_UserDevice_Renters_RenterId",
                        column: x => x.RenterId,
                        principalTable: "Renters",
                        principalColumn: "RenterId");
                });

            migrationBuilder.CreateTable(
                name: "Flats",
                columns: table => new
                {
                    FlatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WaterMeterBefore = table.Column<int>(type: "int", nullable: true),
                    ElectricityMeterBefore = table.Column<int>(type: "int", nullable: true),
                    WaterMeterAfter = table.Column<int>(type: "int", nullable: true),
                    ElectricityMeterAfter = table.Column<int>(type: "int", nullable: true),
                    MaxRoom = table.Column<int>(type: "int", nullable: false),
                    AvailableRoom = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlatTypeId = table.Column<int>(type: "int", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flats", x => x.FlatId);
                    table.ForeignKey(
                        name: "FK_Flats_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flats_FlatTypes_FlatTypeId",
                        column: x => x.FlatTypeId,
                        principalTable: "FlatTypes",
                        principalColumn: "FlatTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Services_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Services_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "ServiceTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TpTransId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    ContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSigned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceForRent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceForWater = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceForElectricity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceForService = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    RenterId = table.Column<int>(type: "int", nullable: false),
                    FlatId = table.Column<int>(type: "int", nullable: false),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_Contracts_Flats_FlatId",
                        column: x => x.FlatId,
                        principalTable: "Flats",
                        principalColumn: "FlatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Renters_RenterId",
                        column: x => x.RenterId,
                        principalTable: "Renters",
                        principalColumn: "RenterId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ContractsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedbackTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlatId = table.Column<int>(type: "int", nullable: false),
                    RenterId = table.Column<int>(type: "int", nullable: false),
                    FeedbackTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedbacks_FeedbackTypes_FeedbackTypeId",
                        column: x => x.FeedbackTypeId,
                        principalTable: "FeedbackTypes",
                        principalColumn: "FeedbackTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Flats_FlatId",
                        column: x => x.FlatId,
                        principalTable: "Flats",
                        principalColumn: "FlatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Renters_RenterId",
                        column: x => x.RenterId,
                        principalTable: "Renters",
                        principalColumn: "RenterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableSlots = table.Column<int>(type: "int", nullable: false),
                    ElectricityAttribute = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WaterAttribute = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlatId = table.Column<int>(type: "int", nullable: false),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Rooms_Flats_FlatId",
                        column: x => x.FlatId,
                        principalTable: "Flats",
                        principalColumn: "FlatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "RoomTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UtilitiesFlat",
                columns: table => new
                {
                    UtilitiesFlatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlatId = table.Column<int>(type: "int", nullable: false),
                    UtilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilitiesFlat", x => x.UtilitiesFlatId);
                    table.ForeignKey(
                        name: "FK_UtilitiesFlat_Flats_FlatId",
                        column: x => x.FlatId,
                        principalTable: "Flats",
                        principalColumn: "FlatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UtilitiesFlat_Utility_UtilityId",
                        column: x => x.UtilityId,
                        principalTable: "Utility",
                        principalColumn: "UtilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    InvoiceDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    WildcardIdForFee = table.Column<int>(type: "int", nullable: true),
                    PlaceholderForFeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.InvoiceDetailId);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_PlaceholderForFee_PlaceholderForFeeId",
                        column: x => x.PlaceholderForFeeId,
                        principalTable: "PlaceholderForFee",
                        principalColumn: "PlaceholderForFeeId");
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SolveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    TicketTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "ContractId");
                    table.ForeignKey(
                        name: "FK_Tickets_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Tickets_TicketTypes_TicketTypeId",
                        column: x => x.TicketTypeId,
                        principalTable: "TicketTypes",
                        principalColumn: "TicketTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "AreaId", "ImageUrl", "ImageUrl2", "ImageUrl3", "ImageUrl4", "Location", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "https://upload.wikimedia.org/wikipedia/commons/thumb/2/24/PANO0002-Pano.jpg/1200px-PANO0002-Pano.jpg", null, null, null, "HCM", "Quận 1", true },
                    { 2, "https://i1-vnexpress.vnecdn.net/2022/11/17/Ve-may-bay-di-sai-gon-600x399-4356-2813-1668672299.jpg?w=0&h=0&q=100&dpr=2&fit=crop&s=8All1Mq-so56XkVbZXvdFA", null, null, null, "HCM", "Quận 2", true },
                    { 3, "https://images.pexels.com/photos/11742806/pexels-photo-11742806.jpeg?cs=srgb&dl=pexels-th%E1%BB%8Bnh-la-11742806.jpg&fm=jpg", null, null, null, "HCM", "Quận 3", true },
                    { 4, "", null, null, null, "HCM", "Quận 9", true },
                    { 5, "", null, null, null, "HCM", "Quận Phú Nhuận", true },
                    { 6, "", null, null, null, "HCM", "Quận 7", true },
                    { 7, "", null, null, null, "HCM", "Quận 8", true },
                    { 8, "", null, null, null, "HCM", "Quận 1", true }
                });

            migrationBuilder.InsertData(
                table: "FeedbackTypes",
                columns: new[] { "FeedbackTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Rating" },
                    { 2, "Suggestion" },
                    { 3, "Other" }
                });

            migrationBuilder.InsertData(
                table: "FlatTypes",
                columns: new[] { "FlatTypeId", "BuildingId", "FlatTypeName", "RoomCapacity", "Status" },
                values: new object[,]
                {
                    { 1, 5, "AAAAAAAA", 10, true },
                    { 2, 5, "AAAAAAAA", 2, true },
                    { 3, 5, "AAAAAAAA", 4, true },
                    { 4, 5, "AAAAAAAA", 5, true },
                    { 5, 5, "AAAAAAAA", 6, true }
                });

            migrationBuilder.InsertData(
                table: "InvoiceTypes",
                columns: new[] { "InvoiceTypeId", "InvoiceTypeIdWildCard", "InvoiceTypeName", "Status" },
                values: new object[,]
                {
                    { 1, 1, "Thu", true },
                    { 2, 2, "Chi", true }
                });

            migrationBuilder.InsertData(
                table: "Renters",
                columns: new[] { "RenterId", "Address", "BirthDate", "CitizenImageUrl", "CitizenNumber", "DeviceToken", "Email", "FullName", "Gender", "ImageUrl", "Password", "Phone", "RenterAddress", "Status", "Username" },
                values: new object[,]
                {
                    { 1, "HCM", new DateTime(2023, 7, 4, 21, 37, 45, 0, DateTimeKind.Unspecified), null, "3214324523", "12321fdsg45adsa", "renter1@mail.com", "Nguyen Van A", "Male", null, "renter1", "0123543125", null, true, "renter1" },
                    { 2, "Hue", new DateTime(2023, 7, 4, 21, 37, 45, 0, DateTimeKind.Unspecified), null, "3214324523", "dsavvf", "renter2@mail.com", "Nguyen Van B", "Male", null, "renter2", "0123543125", null, true, "renter2" },
                    { 3, "DN", new DateTime(2023, 7, 4, 21, 37, 45, 0, DateTimeKind.Unspecified), null, "3214324523", "123221ad145ad423sa", "renter3@mail.com", "Nguyen Van C", "Female", null, "renter3", "0123543125", null, true, "renter3" },
                    { 4, "HN", new DateTime(2023, 7, 4, 21, 37, 45, 0, DateTimeKind.Unspecified), null, "3214324523", "ewasdv12344", "renter4@mail.com", "Nguyen Van D", "Female", null, "renter4", "0123543125", null, true, "renter4" },
                    { 5, "HCM", new DateTime(2023, 7, 4, 21, 37, 45, 0, DateTimeKind.Unspecified), null, "3214324523", "ewasdv12344", "trankhaimnhkhoi10a3@mail.com", "Tran Minh Khoi", "Male", null, "123456789", "0123543125", null, true, "minhkhoi10a3" },
                    { 6, "HCM", new DateTime(2023, 7, 4, 21, 37, 45, 0, DateTimeKind.Unspecified), null, "3214324523", "ewasdv12344", "trankhaimnhkhoi@mail.com", "Tran Minh Khoi", "Male", null, "123456789", "0123543125", null, true, "minhkhoi" },
                    { 7, "HCM", new DateTime(2023, 7, 4, 21, 37, 45, 0, DateTimeKind.Unspecified), null, "3214324523", "ewasdv12344", "khoitkmse150850@fpt", "Tran Minh Khoi", "Male", null, "123456789", "0123543125", null, true, "minhkhoitkm" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName", "Status" },
                values: new object[,]
                {
                    { 1, "SuperAdmin", true },
                    { 2, "Admin", true },
                    { 3, "Supervisor", true },
                    { 4, "Employee", true }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "RoomTypeId", "BuildingId", "Description", "NumberOfSlots", "RoomTypeName" },
                values: new object[,]
                {
                    { 1, 5, "Room type id 1 : 2 slots", 2, "Room type id 1 : 2 slots" },
                    { 2, 5, "Room type id 2 : 2 slots", 2, "Room type id 2 : 2 slots" },
                    { 3, 5, "Room type id 3 : 2 slots", 2, "Room type id 3 : 2 slots" }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "ServiceTypeId", "BuildingId", "Name", "Status" },
                values: new object[,]
                {
                    { 1, 3, "Nước", "Active" },
                    { 2, 3, "Gas", "Active" },
                    { 3, 2, "Điện", "Active" },
                    { 4, 2, "Còn lại", "Active" }
                });

            migrationBuilder.InsertData(
                table: "TicketTypes",
                columns: new[] { "TicketTypeId", "Description", "Status", "TicketTypeName" },
                values: new object[,]
                {
                    { 1, "Sự cố", true, "Sự cố" },
                    { 2, "Bảo trì", true, "Bảo trì" },
                    { 3, "Phàn nàn", true, "Phàn nàn" },
                    { 4, "Khác", true, "Khác" }
                });

            migrationBuilder.InsertData(
                table: "Utility",
                columns: new[] { "UtilityId", "Description", "ImageUrl", "ImageUrl2", "ImageUrl3", "ImageUrl4", "UtilitiesName" },
                values: new object[,]
                {
                    { 1, null, null, null, null, null, "Air Conditioner" },
                    { 2, null, null, null, null, null, "Water Heater" }
                });

            migrationBuilder.InsertData(
                table: "Utility",
                columns: new[] { "UtilityId", "Description", "ImageUrl", "ImageUrl2", "ImageUrl3", "ImageUrl4", "UtilitiesName" },
                values: new object[] { 3, null, null, null, null, null, "Wifi" });

            migrationBuilder.InsertData(
                table: "Utility",
                columns: new[] { "UtilityId", "Description", "ImageUrl", "ImageUrl2", "ImageUrl3", "ImageUrl4", "UtilitiesName" },
                values: new object[] { 4, null, null, null, null, null, "Kitchen" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "Email", "FullName", "ImageUrl", "Password", "Phone", "RoleId", "Status", "Username" },
                values: new object[,]
                {
                    { 1, "Admin address", "superadmin@mail", "Super admin employee", null, "superadmin", "0123543125", 1, true, "superadmin" },
                    { 2, "Admin address", "admin@mail", "Admin employee", null, "admin", "0123543532", 2, true, "admin" },
                    { 3, "Supervisor address", "supervisor@mail", "Supervisor employee", null, "supervisor", "0123543554", 3, true, "supervisor" },
                    { 4, "Employee address", "employee1@mail", "Employee employee 1", null, "employee1", "0123543235", 4, true, "employee1" },
                    { 5, "Employee address", "employee2@mail", "Employee employee 2", null, "employee2", "0123123235", 4, true, "employee2" }
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "BuildingId", "AreaId", "AveragePrice", "BuildingAddress", "BuildingName", "BuildingPhoneNumber", "CoordinateX", "CoordinateY", "Description", "EmployeeId", "ImageUrl", "ImageUrl2", "ImageUrl3", "ImageUrl4", "Status", "TotalFlats" },
                values: new object[,]
                {
                    { 1, 1, 0m, "Quajan 9", "Building 1a", "012323123", 231m, 324m, "Building 1a", 5, "", null, null, null, true, 0 },
                    { 2, 1, 0m, "Quận 9", "Building 1b", "012323123", 21233m, 334m, "Building 1b", 2, "", null, null, null, true, 0 },
                    { 3, 2, 0m, "Quận 2", "Building 1c", "012323123", 423m, 3214m, "Building 1c", 2, "", null, null, null, true, 0 },
                    { 4, 2, 0m, "Quận 3", "Building 1d", "012323123", 2323m, 314m, "Building 1d", 4, "", null, null, null, true, 0 },
                    { 5, 2, 0m, "Quận 4", "Building 1e", "012323123", 23431m, 3245m, "Building 1e", 3, "", null, null, null, true, 0 },
                    { 6, 3, 0m, "Quận 7", "Building 1f", "012323123", 21233m, 334m, "Building 1f", 4, "", null, null, null, true, 0 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceId", "Amount", "CreatedTime", "Detail", "DueDate", "EmployeeId", "ImageUrl", "InvoiceTypeId", "Name", "PaymentTime", "RenterId", "Status" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2023, 7, 4, 21, 37, 45, 0, DateTimeKind.Unspecified), "Detail for invoice 1", null, 2, null, 1, "Hoá đơn điện tử cho renter 1", null, 1, true },
                    { 2, 0, new DateTime(2023, 7, 4, 21, 37, 45, 0, DateTimeKind.Unspecified), "Detail for invoice 2", null, 3, null, 1, "Hoá đơn điện tử cho renter 2", null, 2, true },
                    { 3, 0, new DateTime(2023, 7, 4, 21, 37, 45, 0, DateTimeKind.Unspecified), "Detail for invoice 3", null, 4, null, 1, "Hoá đơn điện tử cho renter 3", null, 3, false },
                    { 4, 0, new DateTime(2023, 7, 4, 21, 37, 45, 0, DateTimeKind.Unspecified), "Detail for invoice 3 (2)", null, 2, null, 1, "Hoá đơn điện tử cho renter 3 (2)", null, 3, false },
                    { 5, 0, new DateTime(2023, 7, 4, 21, 37, 45, 0, DateTimeKind.Unspecified), "Detail for invoice 3 (3)", null, 2, null, 1, "Hoá đơn điện tử cho renter 3 (3)", null, 3, false },
                    { 6, 0, new DateTime(2023, 7, 4, 21, 37, 45, 0, DateTimeKind.Unspecified), "Detail for invoice 3 (4)", null, 2, null, 1, "Hoá đơn điện tử cho renter 3 (4)", null, 3, true },
                    { 7, 0, new DateTime(2023, 7, 4, 21, 37, 45, 0, DateTimeKind.Unspecified), "Detail for invoice 3 (5)", null, 2, null, 1, "Hoá đơn điện tử cho renter 3 (5)", null, 3, true }
                });

            migrationBuilder.InsertData(
                table: "Flats",
                columns: new[] { "FlatId", "AvailableRoom", "BuildingId", "Description", "ElectricityMeterAfter", "ElectricityMeterBefore", "FlatTypeId", "ImageUrl", "ImageUrl2", "ImageUrl3", "ImageUrl4", "MaxRoom", "Name", "Status", "WaterMeterAfter", "WaterMeterBefore" },
                values: new object[,]
                {
                    { 1, 0, 1, "Flat 1", 0, 0, 1, null, null, null, null, 0, "Flat 1", "Active", 0, 0 },
                    { 2, 0, 3, "Flat 2", 0, 0, 3, null, null, null, null, 0, "Flat 2", "Active", 0, 0 },
                    { 3, 0, 2, "Flat 3", 0, 0, 2, null, null, null, null, 0, "Flat 3", "Active", 0, 0 },
                    { 4, 0, 2, "Flat 4", 0, 0, 5, null, null, null, null, 0, "Flat 4", "NonActive", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "InvoiceDetails",
                columns: new[] { "InvoiceDetailId", "Amount", "InvoiceId", "PlaceholderForFeeId", "ServiceId", "WildcardIdForFee" },
                values: new object[,]
                {
                    { 3, 0m, 1, null, null, null },
                    { 4, 0m, 2, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "Amount", "BuildingId", "Description", "ImageUrl", "ImageUrl2", "ImageUrl3", "ImageUrl4", "Name", "ServiceTypeId", "Status" },
                values: new object[,]
                {
                    { 1, 0m, 2, "Cung cấp nước 1", null, null, null, null, "Cung cấp nước 1", 1, true },
                    { 2, 0m, 1, "Cung cấp nước 2 ", null, null, null, null, "Cung cấp nước 2", 1, true },
                    { 3, 0m, 3, "Cung cấp nước 3", null, null, null, null, "Cung cấp nước 3", 3, true },
                    { 4, 0m, 3, "Cung cấp 4 cho toa nha 3", null, null, null, null, "Cung cấp 4 cho toa nha 3", 2, true },
                    { 5, 0m, 3, "Cung cấp 5 cho toa nha 3", null, null, null, null, "Cung cấp 5 cho toa nha 3", 2, true },
                    { 6, 0m, 3, "Cung cấp 6 cho toa nha 3", null, null, null, null, "Cung cấp 6 cho toa nha 3", 2, true }
                });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "ContractId", "BuildingId", "ContractName", "ContractStatus", "CreatedDate", "DateSigned", "Description", "EndDate", "FlatId", "ImageUrl", "ImageUrl2", "ImageUrl3", "ImageUrl4", "LastUpdated", "PriceForElectricity", "PriceForRent", "PriceForService", "PriceForWater", "RenterId", "RoomId", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, "Contract for renter 1", "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 4, 21, 37, 45, 0, DateTimeKind.Unspecified), "Contract description for renter 1", null, 2, "No image", null, null, null, new DateTime(2023, 7, 4, 21, 37, 45, 0, DateTimeKind.Unspecified), 0m, 1800000m, 0m, 0m, 1, 1, new DateTime(2023, 6, 9, 21, 37, 45, 0, DateTimeKind.Unspecified) },
                    { 2, 2, "Contract for renter 2", "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 5, 21, 37, 45, 0, DateTimeKind.Unspecified), "Contract description for renter 2", null, 3, "No image", null, null, null, new DateTime(2023, 7, 4, 21, 37, 45, 0, DateTimeKind.Unspecified), 0m, 2800000m, 0m, 0m, 2, 1, new DateTime(2023, 6, 7, 21, 37, 45, 0, DateTimeKind.Unspecified) },
                    { 3, 3, "Contract for renter 3", "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 5, 21, 37, 45, 0, DateTimeKind.Unspecified), "Contract description for renter 3", null, 3, "No image", null, null, null, new DateTime(2023, 7, 4, 21, 37, 45, 0, DateTimeKind.Unspecified), 120m, 2800000m, 10000m, 1000m, 3, 2, new DateTime(2023, 6, 7, 21, 37, 45, 0, DateTimeKind.Unspecified) },
                    { 4, 3, "Contract for renter 3 (2)", "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 5, 21, 37, 45, 0, DateTimeKind.Unspecified), "Contract description for renter 3", null, 4, "No image", null, null, null, new DateTime(2023, 7, 4, 21, 37, 45, 0, DateTimeKind.Unspecified), 120m, 2800000m, 10000m, 1000m, 3, 1, new DateTime(2023, 6, 7, 21, 37, 45, 0, DateTimeKind.Unspecified) },
                    { 5, 3, "Contract for renter 3 (3)", "Inactive", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 5, 21, 37, 45, 0, DateTimeKind.Unspecified), "Contract description for renter 3", null, 3, "No image", null, null, null, new DateTime(2023, 7, 4, 21, 37, 45, 0, DateTimeKind.Unspecified), 120m, 2800000m, 10000m, 1000m, 3, 2, new DateTime(2023, 6, 7, 21, 37, 45, 0, DateTimeKind.Unspecified) },
                    { 6, 3, "Contract for renter 3 (4)", "Inactive", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 5, 21, 37, 45, 0, DateTimeKind.Unspecified), "Contract description for renter 3", null, 3, "No image", null, null, null, new DateTime(2023, 7, 4, 21, 37, 45, 0, DateTimeKind.Unspecified), 120m, 2800000m, 10000m, 1000m, 3, 2, new DateTime(2023, 6, 7, 21, 37, 45, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "InvoiceDetails",
                columns: new[] { "InvoiceDetailId", "Amount", "InvoiceId", "PlaceholderForFeeId", "ServiceId", "WildcardIdForFee" },
                values: new object[,]
                {
                    { 1, 0m, 1, null, 1, null },
                    { 2, 0m, 1, null, 2, null },
                    { 5, 0m, 4, null, 4, null },
                    { 6, 0m, 4, null, 4, null },
                    { 7, 0m, 5, null, 4, null },
                    { 8, 0m, 5, null, 5, null },
                    { 9, 0m, 5, null, 5, null },
                    { 10, 0m, 6, null, 6, null },
                    { 11, 0m, 6, null, 5, null },
                    { 12, 0m, 6, null, 6, null },
                    { 13, 0m, 7, null, 3, null },
                    { 14, 0m, 7, null, 3, null },
                    { 15, 0m, 7, null, 4, null },
                    { 16, 0m, 7, null, 5, null }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "AvailableSlots", "ElectricityAttribute", "FlatId", "ImageUrl", "ImageUrl2", "ImageUrl3", "ImageUrl4", "RoomName", "RoomTypeId", "WaterAttribute" },
                values: new object[,]
                {
                    { 1, 2, 0m, 1, null, null, null, null, "Room 1 for flat 1", 1, 0m },
                    { 2, 1, 0m, 3, null, null, null, null, "Room 1 for flat 3", 1, 0m },
                    { 3, 2, 0m, 3, null, null, null, null, "Room 2 for flat 3", 2, 0m },
                    { 4, 2, 0m, 3, null, null, null, null, "Room 3 for flat 3", 3, 0m }
                });

            migrationBuilder.InsertData(
                table: "UtilitiesFlat",
                columns: new[] { "UtilitiesFlatId", "FlatId", "UtilityId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "Amount", "ContractId", "CreateDate", "Description", "EmployeeId", "ImageUrl", "ImageUrl2", "ImageUrl3", "SolveDate", "Status", "TicketTypeId" },
                values: new object[,]
                {
                    { 1, null, 3, new DateTime(2023, 7, 4, 21, 37, 45, 0, DateTimeKind.Unspecified), "Sự cố 1", 2, null, null, null, null, "Active", 1 },
                    { 2, null, 3, new DateTime(2023, 7, 4, 21, 37, 45, 0, DateTimeKind.Unspecified), "Sự cố 2", 2, null, null, null, null, "Processing", 2 },
                    { 3, null, 3, new DateTime(2023, 7, 4, 21, 37, 45, 0, DateTimeKind.Unspecified), "Sự cố 3", 2, null, null, null, null, "Completed", 3 },
                    { 4, null, 3, new DateTime(2023, 7, 4, 21, 37, 45, 0, DateTimeKind.Unspecified), "Sự cố 4", 2, null, null, null, null, "Active", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_AreaId",
                table: "Buildings",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_EmployeeId",
                table: "Buildings",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_FlatId",
                table: "Contracts",
                column: "FlatId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_RenterId",
                table: "Contracts",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                table: "Employees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleId",
                table: "Employees",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Username",
                table: "Employees",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_FeedbackTypeId",
                table: "Feedbacks",
                column: "FeedbackTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_FlatId",
                table: "Feedbacks",
                column: "FlatId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_RenterId",
                table: "Feedbacks",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Flats_BuildingId",
                table: "Flats",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Flats_FlatTypeId",
                table: "Flats",
                column: "FlatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceId",
                table: "InvoiceDetails",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_PlaceholderForFeeId",
                table: "InvoiceDetails",
                column: "PlaceholderForFeeId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_ServiceId",
                table: "InvoiceDetails",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_EmployeeId",
                table: "Invoices",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceTypeId",
                table: "Invoices",
                column: "InvoiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_RenterId",
                table: "Invoices",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_NotificationTypeId",
                table: "Notification",
                column: "NotificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Renters_Email",
                table: "Renters",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Renters_Username",
                table: "Renters",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_FlatId",
                table: "Rooms",
                column: "FlatId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_BuildingId",
                table: "Services",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceTypeId",
                table: "Services",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ContractId",
                table: "Tickets",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EmployeeId",
                table: "Tickets",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketTypeId",
                table: "Tickets",
                column: "TicketTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_InvoiceId",
                table: "Transactions",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDevice_EmployeeId",
                table: "UserDevice",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDevice_RenterId",
                table: "UserDevice",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_UtilitiesFlat_FlatId",
                table: "UtilitiesFlat",
                column: "FlatId");

            migrationBuilder.CreateIndex(
                name: "IX_UtilitiesFlat_UtilityId",
                table: "UtilitiesFlat",
                column: "UtilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_RenterId",
                table: "Wallet",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_WalletTypeID",
                table: "Wallet",
                column: "WalletTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "UserDevice");

            migrationBuilder.DropTable(
                name: "UtilitiesFlat");

            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropTable(
                name: "FeedbackTypes");

            migrationBuilder.DropTable(
                name: "PlaceholderForFee");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "NotificationType");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropTable(
                name: "Contracts")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ContractsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropTable(
                name: "TicketTypes");

            migrationBuilder.DropTable(
                name: "Invoices")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "InvoicesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropTable(
                name: "Utility");

            migrationBuilder.DropTable(
                name: "WalletType");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.DropTable(
                name: "Flats");

            migrationBuilder.DropTable(
                name: "InvoiceTypes");

            migrationBuilder.DropTable(
                name: "Renters");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "FlatTypes");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}