using System;
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
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    TechnicianBuildingId = table.Column<int>(type: "int", nullable: true)
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
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    { 4, "", null, null, null, "HCM", "Quận 4", true },
                    { 5, "", null, null, null, "HCM", "Quận 5", true },
                    { 6, "", null, null, null, "HCM", "Quận 6", true },
                    { 7, "", null, null, null, "HCM", "Quận 7", true },
                    { 8, "", null, null, null, "HCM", "Quận 8", true },
                    { 9, "", null, null, null, "HCM", "Quận 9", true },
                    { 10, "", null, null, null, "HCM", "Quận 10", true },
                    { 11, "", null, null, null, "HCM", "Quận 11", true },
                    { 12, "", null, null, null, "HCM", "Quận 12", true },
                    { 13, "", null, null, null, "HCM", "Quận Bình Thạnh", true },
                    { 14, "", null, null, null, "HCM", "Quận Gò Vấp", true },
                    { 15, "", null, null, null, "HCM", "Quận Phú Nhuận", true },
                    { 16, "", null, null, null, "HCM", "Quận Tân Bình", true },
                    { 17, "", null, null, null, "HCM", "Quận Tân Phú", true },
                    { 18, "", null, null, null, "HCM", "Quận Bình Tân", true },
                    { 19, "", null, null, null, "HCM", "Quận Nhà Bè", true },
                    { 20, "", null, null, null, "HCM", "Quận Hóc Môn", true },
                    { 21, "", null, null, null, "HCM", "Quận Củ Chi", true },
                    { 22, "", null, null, null, "HCM", "Quận Cần Giờ", true },
                    { 23, "", null, null, null, "HCM", "Quận Bình Chánh", true },
                    { 24, "", null, null, null, "HCM", "Quận Thủ Đức", true }
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
                columns: new[] { "RenterId", "Address", "BirthDate", "CitizenImageUrl", "CitizenNumber", "DeviceToken", "Email", "FullName", "Gender", "ImageUrl", "Password", "Phone", "Status", "Username" },
                values: new object[,]
                {
                    { 1, "HCM", new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(321), null, "3214324523", "12321fdsg45adsa", "renter1@mail.com", "Nguyen Van A", "Male", null, "renter1", "0123543125", true, "renter1" },
                    { 2, "Hue", new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(325), null, "3214324523", "dsavvf", "renter2@mail.com", "Nguyen Van B", "Male", null, "renter2", "0123543125", true, "renter2" },
                    { 3, "DN", new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(327), null, "3214324523", "123221ad145ad423sa", "renter3@mail.com", "Nguyen Van C", "Female", null, "renter3", "0123543125", true, "renter3" },
                    { 4, "HN", new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(328), null, "3214324523", "ewasdv12344", "renter4@mail.com", "Nguyen Van D", "Female", null, "renter4", "0123543125", true, "renter4" },
                    { 5, "HCM", new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(329), null, "3214324523", "ewasdv12344", "trankhaimnhkhoi10a3@mail.com", "Tran Minh Khoi", "Male", null, "123456789", "0123543125", true, "minhkhoi10a3" },
                    { 6, "HCM", new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(330), null, "3214324523", "ewasdv12344", "trankhaimnhkhoi@mail.com", "Tran Minh Khoi", "Male", null, "123456789", "0123543125", true, "minhkhoi" },
                    { 7, "HCM", new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(332), null, "3214324523", "ewasdv12344", "khoitkmse150850@fpt", "Tran Minh Khoi", "Male", null, "123456789", "0123543125", true, "minhkhoitkm" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName", "Status" },
                values: new object[] { 1, "Admin", true });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName", "Status" },
                values: new object[,]
                {
                    { 2, "Supervisor", true },
                    { 3, "Technician", true }
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
                    { 2, null, null, null, null, null, "Water Heater" },
                    { 3, null, null, null, null, null, "Wifi" },
                    { 4, null, null, null, null, null, "Kitchen" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "Email", "FullName", "ImageUrl", "Password", "Phone", "RoleId", "Status", "TechnicianBuildingId", "Username" },
                values: new object[,]
                {
                    { 1, "Sup1 address", "binhlinh@mail", "Bình Linh", null, "123456", "0912345678", 2, true, null, "sup1" },
                    { 2, "Sup2 address", "thoahy@mail", "Thoa Hy", null, "123456", "0923456789", 2, true, null, "sup2" },
                    { 3, "Sup3 address", "khoihuy@mail", "sup3", null, "123456", "0812345678", 2, true, null, "Khôi Huy" },
                    { 4, "Sup4 address", "ngachau@mail", "Nga Châu", null, "123456", "0823456789", 2, true, null, "sup4" },
                    { 5, "Sup5 address", "ngochuy@mail", "Ngọc Huy", null, "123456", "0834567890", 2, true, null, "sup5" },
                    { 6, "Employee address", "ngason@mail", "Ngà Sơn", null, "123", "0712345678", 2, true, null, "sup6" },
                    { 7, "Admin address", "thuminh@mail", "Thư Minh", null, "123456", "0723456789", 1, true, null, "admin" },
                    { 8, "Employee address", "minhanh123@mail", "Minh Anh", null, "123456", "0723567890", 2, true, null, "sup7" },
                    { 9, "Employee address", "minhngon@mail", "Minh Ngọc", null, "123456", "0913456324", 2, true, null, "sup8" },
                    { 10, "Employee address", "manhkhoa@mail", "Mạnh Khoa", null, "123456", "0942184853", 2, true, null, "sup9" },
                    { 11, "Employee address", "khangngoc@mail", "Khang Ngọc", null, "123456", "0234328589", 2, true, null, "sup10" },
                    { 12, "Employee address", "hoangminh@mail", "Hoàng Minh", null, "123456", "0482138128", 2, true, null, "sup11" },
                    { 13, "Employee address", "ankhang@mail", "An Khang", null, "123456", "0763125422", 2, true, null, "sup12" },
                    { 14, "Employee address", "tranghoa@mail", "Trang Hoà", null, "123456", "0358438539", 2, true, null, "sup13" },
                    { 15, "Employee address", "minhtinh@mail", "Minh Tính", null, "123456", "0429215737", 2, true, null, "sup14" },
                    { 16, "Employee address", "tienhoang@mail", "Tiên Hoàng", null, "123456", "0582021245", 2, true, null, "sup15" },
                    { 17, "Employee address", "thanhhoa032@mail", "Thanh Hoa", null, "123456", "0984271626", 2, true, null, "sup16" },
                    { 18, "Employee address", "ngason234@mail", "Ngà Sơn", null, "123", "012312323235", 2, true, null, "sup17" },
                    { 19, "Employee address", "hoangthao@mail", "Hoàng Thoa", null, "123", "0932441829", 2, true, null, "sup18" },
                    { 20, "Employee address", "minhnghi@mail", "Minh Nghi", null, "123456", "0490238588", 2, true, null, "sup19" },
                    { 21, "Employee address", "manhhung@mail", "Mạnh Hùng", null, "123456", "0943573182", 2, true, null, "sup20" },
                    { 22, "Employee address", "huongtram@mail", "Hương Tràm", null, "123456", "0984372814", 2, true, null, "sup21" },
                    { 23, "Employee address", "minhhoang@mail", "Minh Hoàng", null, "123456", "0958214539", 2, true, null, "sup24" },
                    { 24, "Employee address", "hoangthanh12@mail", "Hoàng Thanh", null, "123456", "012312323235", 2, true, null, "sup25" },
                    { 25, "Employee address", "anhtu@mail", "Anh Tú", null, "123456", "0943783365", 2, true, null, "sup26" },
                    { 26, "Employee address", "anhhung@mail", "Anh Hùng", null, "123456", "0913683923", 2, true, null, "sup27" },
                    { 27, "Employee address", "khanhhuy32@mail", "Khánh Huy", null, "123456", "0942812643", 2, true, null, "sup28" },
                    { 28, "Employee address", "vinhhung@mail", "Vinh Hưng", null, "123456", "012312323235", 2, true, null, "sup29" },
                    { 29, "Employee address", "khangtrung@mail", "Khang Trung", null, "123456", "0918238483", 2, true, null, "sup30" },
                    { 30, "Employee address", "tranghuyen123@mail", "Trang Huyền", null, "123456", "0984271544", 2, true, null, "sup31" },
                    { 31, "Employee address", "hatrang4@mail", "Hà Trang", null, "123456", "0384943481", 2, true, null, "sup32" },
                    { 32, "Employee address", "sonha3@mail", "Sơn Hà", null, "123456", "0938772581", 2, true, null, "sup33" },
                    { 33, "Employee address", "nguuson32@mail", "Ngưu Sơn", null, "123456", "0485245513", 2, true, null, "sup34" },
                    { 34, "Employee address", "thuyson32@mail", "Thúy Sơn", null, "123456", "0947327121", 2, true, null, "sup35" },
                    { 35, "Employee address", "thanhho13@mail", "Thanh Hồ", null, "123456", "0942837429", 2, true, null, "sup36" },
                    { 36, "Employee address", "quanghuy29@mail", "Quang Huy", null, "123456", "0947291723", 2, true, null, "sup37" },
                    { 37, "Employee address", "khanhtram32@mail", "Khánh Trâm", null, "123456", "0938271525", 2, true, null, "sup38" },
                    { 38, "Employee address", "sontrang12@mail", "Sơn Trang", null, "123456", "0948271626", 2, true, null, "sup39" },
                    { 39, "Employee address", "minhlam23@mail", "Minh Lâm", null, "123456", "0942647123", 2, true, null, "sup40" },
                    { 40, "Employee address", "hangsuong23@mail", "Hằng Sương", null, "123456", "0928367325", 2, true, null, "sup41" },
                    { 41, "Employee address", "uyenchi47@mail", "Uyên Chi", null, "123456", "0975383282", 2, true, null, "sup42" },
                    { 42, "Employee address", "lamtoan12@mail", "Lâm Toàn", null, "123456", "0942537435", 2, true, null, "sup43" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "Email", "FullName", "ImageUrl", "Password", "Phone", "RoleId", "Status", "TechnicianBuildingId", "Username" },
                values: new object[,]
                {
                    { 43, "Employee address", "minhtoan@mail", "Minh Toàn", null, "123456", "0938243827", 2, true, null, "sup44" },
                    { 44, "Employee address", "nhamson@mail", "Nhâm Sơn", null, "123456", "0837243827", 2, true, null, "sup45" },
                    { 45, "Employee address", "sonkim432@mail", "Sơn Kim", null, "123456", "0947348292", 2, true, null, "sup46" },
                    { 46, "Employee address", "kimtien32@mail", "Kim Tiền", null, "123456", "0847342789", 2, true, null, "sup47" },
                    { 47, "Employee address", "tienkim384@mail", "Tiến Kim", null, "123456", "012312323235", 2, true, null, "sup48" },
                    { 48, "Employee address", "manhson292@mail", "Mạnh Sơn", null, "123456", "0485838261", 2, true, null, "sup49" },
                    { 49, "Employee address", "longhuong12@mail", "Long Hương", null, "123456", "0749274839", 2, true, null, "sup50" },
                    { 50, "Employee address", "nhantrong25@mail", "Nhân Trọng", null, "123456", "0984028345", 2, true, null, "sup51" }
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "BuildingId", "AreaId", "AveragePrice", "BuildingAddress", "BuildingName", "BuildingPhoneNumber", "CoordinateX", "CoordinateY", "Description", "EmployeeId", "ImageUrl", "ImageUrl2", "ImageUrl3", "ImageUrl4", "Status", "TotalFlats" },
                values: new object[,]
                {
                    { 1, 1, 2500000m, "Quận 1", "Building 1 quận 1", "012323123", 231m, 324m, "Building 1 quận 1", 1, "https://vinflat.blob.core.windows.net/building-image/6716250e-8169-446d-a54e-37094c30ae70thumbnail-202303031027054744.jpg", null, null, null, true, 0 },
                    { 2, 1, 2600000m, "Quận 1", "Building 2 quận 1", "012323123", 21233m, 334m, "Building 2 quận 1", 2, "https://vinflat.blob.core.windows.net/building-image/be39f244-45d1-48cc-94dc-7e1b138caa3athumbnail-202302251636284394.jpg", null, null, null, true, 0 },
                    { 3, 2, 3500000m, "Quận 2", "Building 1 quận 2", "012323123", 423m, 3214m, "Building 1 quận 2", 3, "https://vinflat.blob.core.windows.net/building-image/8a8ea225-ea25-422c-a20d-299c7ed42456thumbnail-202302041627581789.jpg", null, null, null, true, 0 },
                    { 4, 2, 4500000m, "Quận 2", "Building 2 quận 2", "012323123", 2323m, 314m, "Building 2 quận 2", 4, "https://vinflat.blob.core.windows.net/building-image/69d0767f-ff29-49dc-88fc-c3bc87cba986thumbnail-202212291740189478.jpg", null, null, null, true, 0 },
                    { 5, 3, 4600000m, "Quận 3", "Building 1 quận 3", "012323123", 23431m, 3245m, "Building 1 quận 3", 5, "https://vinflat.blob.core.windows.net/building-image/a3f9897c-800e-4d5e-92b7-e388eefdf64bthumbnail-202212151636139810.jpg", null, null, null, true, 0 },
                    { 6, 3, 5300000m, "Quận 3", "Building 2 quận 3", "012323123", 21233m, 334m, "Building 2 quận 3", 6, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 7, 4, 5300000m, "Quận 4", "Building 1 quận 4", "012323123", 212333m, 3344m, "Building 1 quận 4", 8, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 8, 4, 5300000m, "Quận 4", "Building 2 quận 4", "012323123", 212333m, 3344m, "Building 2 quận 4", 9, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 9, 5, 5300000m, "Quận 5", "Building 1 quận 5", "012323123", 212333m, 3344m, "Building 1 quận 5", 10, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 10, 5, 5300000m, "Quận 5", "Building 2 quận 5", "012323123", 212333m, 3344m, "Building 2 quận 5", 11, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 11, 6, 5300000m, "Quận 6", "Building 1 quận 6", "012323123", 212333m, 3344m, "Building 1 quận 6", 12, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 12, 6, 5300000m, "Quận 6", "Building 2 quận 6", "012323123", 212333m, 3344m, "Building 2 quận 6", 13, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 13, 7, 5300000m, "Quận 7", "Building 1 quận 7", "012323123", 212333m, 3344m, "Building 1 quận 7", 14, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 14, 7, 5300000m, "Quận 7", "Building 2 quận 7", "012323123", 212333m, 3344m, "Building 2 quận 7", 15, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 15, 8, 5300000m, "Quận 8", "Building 1 quận 8", "012323123", 212333m, 3344m, "Building 1 quận 8", 16, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 16, 8, 5300000m, "Quận 8", "Building 2 quận 8", "012323123", 212333m, 3344m, "Building 2 quận 8", 17, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 17, 9, 5300000m, "Quận 9", "Building 1 quận 9", "012323123", 212333m, 3344m, "Building 1 quận 9", 18, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 18, 9, 5300000m, "Quận 9", "Building 2 quận 9", "012323123", 212333m, 3344m, "Building 2 quận 9", 19, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 19, 10, 5300000m, "Quận 9", "Building 1 quận 10", "012323123", 212333m, 3344m, "Building 1 quận 10", 20, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 20, 10, 5300000m, "Quận 10", "Building 2 quận 10", "012323123", 212333m, 3344m, "Building 2 quận 10", 21, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 21, 11, 5300000m, "Quận 10", "Building 1 quận 11", "012323123", 212333m, 3344m, "Building 1 quận 11", 22, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 22, 11, 5300000m, "Quận 11", "Building 2 quận 11", "012323123", 212333m, 3344m, "Building 2 quận 11", 23, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 23, 12, 5300000m, "Quận 12", "Building 1 quận 12", "012323123", 212333m, 3344m, "Building 1 quận 12", 24, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 24, 12, 5300000m, "Quận 12", "Building 2 quận 12", "012323123", 212333m, 3344m, "Building 2 quận 12", 25, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 25, 13, 5300000m, "Quận Bình Thạnh", "Building 1 quận Bình Thạnh", "012323123", 212333m, 3344m, "Building 1 quận Bình Thạnh", 26, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 26, 13, 5300000m, "Quận Bình Thanh", "Building 2 quận Bình Thanh", "012323123", 212333m, 3344m, "Building 2 quận Bình Thanh", 27, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 27, 14, 5300000m, "Quận 3", "Building 1 quận Gò Vấp", "012323123", 212333m, 3344m, "Building 1 quận Gò Vấp", 28, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 28, 14, 5300000m, "Quận 3", "Building 1 quận Gò Vấp", "012323123", 212333m, 3344m, "Building 1 quận Gò Vấp", 29, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 29, 15, 5300000m, "Quận Phú Nhuận", "Building 1 quận Phú Nhuận", "012323123", 212333m, 3344m, "Building 1 quận Phú Nhuận", 30, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 30, 15, 5300000m, "Quận Phú Nhuận", "Building 2 quận Phú Nhuận", "012323123", 212333m, 3344m, "Building 2 quận Phú Nhuận", 31, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 31, 16, 5300000m, "Quận Tân Bình", "Building 1 quận Tân Bình", "012323123", 212333m, 3344m, "Building 1 quận Tân Bình", 32, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 32, 16, 5300000m, "Quận Tân Bình", "Building 2 quận Tân Bình", "012323123", 212333m, 3344m, "Building 2 quận Tân Bình", 33, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 33, 17, 5300000m, "Quận Tân Phú", "Building 1 quận Tân Phú", "012323123", 212333m, 3344m, "Building 1 quận Tân Phú", 34, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 34, 17, 5300000m, "Quận Tân Phú", "Building 2 quận Tân Phú", "012323123", 212333m, 3344m, "Building 2 quận Tân Phú", 35, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 35, 18, 5300000m, "Quận Bình Tân", "Building 1 quận Bình Tân", "012323123", 212333m, 3344m, "Building 1 quận Bình Tân", 36, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 36, 18, 5300000m, "Quận Bình Tân", "Building 2 quận Bình Tân", "012323123", 212333m, 3344m, "Building 2 quận Bình Tân", 37, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 37, 19, 5300000m, "Quận 3", "Building 1 quận Nhà Bè", "012323123", 212333m, 3344m, "Building 1 quận Nhà Bè", 38, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 38, 19, 5300000m, "Quận Nhà Bè", "Building 2 quận Nhà Bè", "012323123", 212333m, 3344m, "Building 2 quận Nhà Bè", 39, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 39, 20, 5300000m, "Quận Hóc Môn", "Building 1 quận Hóc Môn", "012323123", 212333m, 3344m, "Building 1 quận Hóc Môn", 40, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 40, 20, 5300000m, "Quận Hóc Môn", "Building 2 quận Hóc Môn", "012323123", 212333m, 3344m, "Building 2 quận Hóc Môn", 41, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 41, 21, 5300000m, "Quận Củ Chi", "Building 1 quận Củ Chi", "012323123", 212333m, 3344m, "Building 1 quận Củ Chi", 42, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 42, 21, 5300000m, "Quận Củ Chi", "Building 2 quận Củ Chi", "012323123", 212333m, 3344m, "Building 2 quận Củ Chi", 43, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 }
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "BuildingId", "AreaId", "AveragePrice", "BuildingAddress", "BuildingName", "BuildingPhoneNumber", "CoordinateX", "CoordinateY", "Description", "EmployeeId", "ImageUrl", "ImageUrl2", "ImageUrl3", "ImageUrl4", "Status", "TotalFlats" },
                values: new object[,]
                {
                    { 43, 22, 5300000m, "Quận Cần Giờ", "Building 1 quận Cần Giờ", "012323123", 212333m, 3344m, "Building 1 quận Cần Giờ", 44, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 44, 22, 5300000m, "Quận Cần Giờ", "Building 2 quận Cần Giờ", "012323123", 212333m, 3344m, "Building 2 quận Cần Giờ", 45, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 45, 23, 5300000m, "Quận Bình Chánh", "Building 1 quận Bình Chánh", "012323123", 212333m, 3344m, "Building 1 quận Bình Chánh", 46, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 46, 23, 5300000m, "Quận Bình Chánh", "Building 2 quận Bình Chánh", "012323123", 212333m, 3344m, "Building 2 quận Bình Chánh", 47, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 47, 24, 5300000m, "Quận Thủ Đức", "Building 1 quận Thủ Đức", "012323123", 212333m, 3344m, "Building 1 quận Thủ Đức", 46, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 },
                    { 48, 24, 5300000m, "Quận Thủ Đức", "Building 2 quận Thủ Đức", "012323123", 212333m, 3344m, "Building 2 quận Thủ Đức", 47, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg", null, null, null, true, 0 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceId", "Amount", "CreatedTime", "Detail", "DueDate", "EmployeeId", "ImageUrl", "InvoiceTypeId", "Name", "PaymentTime", "RenterId", "Status" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(755), "Detail for invoice 1", null, 2, null, 1, "Hoá đơn điện tử cho renter 1", null, 1, true },
                    { 2, 0, new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(757), "Detail for invoice 2", null, 3, null, 1, "Hoá đơn điện tử cho renter 2", null, 2, true },
                    { 3, 0, new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(758), "Detail for invoice 3", null, 4, null, 1, "Hoá đơn điện tử cho renter 3", null, 3, false },
                    { 4, 0, new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(759), "Detail for invoice 3 (2)", null, 2, null, 1, "Hoá đơn điện tử cho renter 3 (2)", null, 3, false },
                    { 5, 0, new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(760), "Detail for invoice 3 (3)", null, 2, null, 1, "Hoá đơn điện tử cho renter 3 (3)", null, 3, false },
                    { 6, 0, new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(760), "Detail for invoice 3 (4)", null, 2, null, 1, "Hoá đơn điện tử cho renter 3 (4)", null, 3, true },
                    { 7, 0, new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(761), "Detail for invoice 3 (5)", null, 2, null, 1, "Hoá đơn điện tử cho renter 3 (5)", null, 3, true }
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
                    { 1, 1, "Contract for renter 1", "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 14, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(814), "Contract description for renter 1", null, 2, "No image", null, null, null, new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(820), 0m, 1800000m, 0m, 0m, 1, 1, new DateTime(2023, 3, 19, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(820) },
                    { 2, 2, "Contract for renter 2", "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 15, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(823), "Contract description for renter 2", null, 3, "No image", null, null, null, new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(824), 0m, 2800000m, 0m, 0m, 2, 1, new DateTime(2023, 3, 17, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(823) },
                    { 3, 3, "Contract for renter 3", "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 15, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(825), "Contract description for renter 3", null, 3, "No image", null, null, null, new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(826), 120m, 2800000m, 10000m, 1000m, 3, 2, new DateTime(2023, 3, 17, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(825) },
                    { 4, 3, "Contract for renter 3 (2)", "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 15, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(831), "Contract description for renter 3", null, 4, "No image", null, null, null, new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(832), 120m, 2800000m, 10000m, 1000m, 3, 1, new DateTime(2023, 3, 17, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(831) },
                    { 5, 3, "Contract for renter 3 (3)", "Inactive", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 15, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(833), "Contract description for renter 3", null, 3, "No image", null, null, null, new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(834), 120m, 2800000m, 10000m, 1000m, 3, 2, new DateTime(2023, 3, 17, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(833) },
                    { 6, 3, "Contract for renter 3 (4)", "Inactive", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 15, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(835), "Contract description for renter 3", null, 3, "No image", null, null, null, new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(836), 120m, 2800000m, 10000m, 1000m, 3, 2, new DateTime(2023, 3, 17, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(835) }
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
                    { 1, null, 3, new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(690), "Sự cố 1", 2, null, null, null, null, "Active", 1 },
                    { 2, null, 3, new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(691), "Sự cố 2", 2, null, null, null, null, "Processing", 2 },
                    { 3, null, 3, new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(692), "Sự cố 3", 2, null, null, null, null, "Completed", 3 },
                    { 4, null, 3, new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(693), "Sự cố 4", 2, null, null, null, null, "Active", 1 }
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
