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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.AreaId);
                });

            migrationBuilder.CreateTable(
                name: "DatabaseExceptions",
                columns: table => new
                {
                    ExceptionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MachineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsProtected = table.Column<bool>(type: "bit", nullable: true),
                    Host = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HttpMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ipaddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusCode = table.Column<int>(type: "int", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FullJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorHash = table.Column<int>(type: "int", nullable: true),
                    DuplicateCount = table.Column<int>(type: "int", nullable: false),
                    LastLogDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatabaseExceptions", x => x.ExceptionId);
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
                    RoomCapacity = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfSlots = table.Column<int>(type: "int", nullable: false)
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
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "University",
                columns: table => new
                {
                    UniversityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniversityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_University", x => x.UniversityId);
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
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "Majors",
                columns: table => new
                {
                    MajorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniversityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.MajorId);
                    table.ForeignKey(
                        name: "FK_Majors_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "UniversityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalRooms = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoordinateX = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CoordinateY = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.BuildingId);
                    table.ForeignKey(
                        name: "FK_Buildings_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Buildings_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Renters",
                columns: table => new
                {
                    RenterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UniversityId = table.Column<int>(type: "int", nullable: true),
                    MajorId = table.Column<int>(type: "int", nullable: true),
                    DeviceToken = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renters", x => x.RenterId);
                    table.ForeignKey(
                        name: "FK_Renters_Majors_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Majors",
                        principalColumn: "MajorId");
                    table.ForeignKey(
                        name: "FK_Renters_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "UniversityId");
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
                    RenterId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Invoices_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
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
                        principalColumn: "RenterId",
                        onDelete: ReferentialAction.Cascade);
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
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    RenterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDevice", x => x.UserDeviceId);
                    table.ForeignKey(
                        name: "FK_UserDevice_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId");
                    table.ForeignKey(
                        name: "FK_UserDevice_Renters_RenterId",
                        column: x => x.RenterId,
                        principalTable: "Renters",
                        principalColumn: "RenterId");
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
                name: "Contracts",
                columns: table => new
                {
                    ContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSigned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceForRent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceForWater = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceForElectricity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceForService = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    AvailableSlots = table.Column<int>(type: "int", nullable: false),
                    FlatId = table.Column<int>(type: "int", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    InvoiceDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_InvoiceDetails_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId");
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
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SolveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    TicketTypeId = table.Column<int>(type: "int", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "ContractId");
                    table.ForeignKey(
                        name: "FK_Tickets_TicketTypes_TicketTypeId",
                        column: x => x.TicketTypeId,
                        principalTable: "TicketTypes",
                        principalColumn: "TicketTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "AreaId", "Location", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "HCM", "HCM", true },
                    { 2, "HN", "HN", true },
                    { 3, "DN", "DN", true },
                    { 4, "Hue", "Hue", true },
                    { 5, "TH", "Thanh Hoa", true },
                    { 6, "HP", "Hai Phong", true },
                    { 7, "DN", "Dong Nai", true },
                    { 8, "HN", "Hoa Lac", true }
                });

            migrationBuilder.InsertData(
                table: "FeedbackTypes",
                columns: new[] { "FeedbackTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Complaint" },
                    { 2, "Suggestion" },
                    { 3, "Other" }
                });

            migrationBuilder.InsertData(
                table: "FlatTypes",
                columns: new[] { "FlatTypeId", "RoomCapacity", "Status" },
                values: new object[,]
                {
                    { 1, 10, "Active" },
                    { 2, 2, "Active" },
                    { 3, 4, "Active" },
                    { 4, 5, "Active" },
                    { 5, 6, "NonActive" }
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
                columns: new[] { "RenterId", "Address", "BirthDate", "CitizenImageUrl", "CitizenNumber", "DeviceToken", "Email", "FullName", "Gender", "ImageUrl", "MajorId", "Password", "Phone", "Status", "UniversityId", "Username" },
                values: new object[,]
                {
                    { 1, "HCM", new DateTime(2023, 3, 2, 13, 55, 18, 827, DateTimeKind.Utc).AddTicks(4686), null, "3214324523", "12321fdsg45adsa", "renter1@mail.com", "Nguyen Van A", "Male", null, null, "renter1", "0123543125", true, null, "renter1" },
                    { 2, "Hue", new DateTime(2023, 3, 2, 13, 55, 18, 827, DateTimeKind.Utc).AddTicks(4691), null, "3214324523", "dsavvf", "renter2@mail.com", "Nguyen Van B", "Male", null, null, "renter2", "0123543125", true, null, "renter2" }
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
                table: "ServiceTypes",
                columns: new[] { "ServiceTypeId", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "Nước", "Active" },
                    { 2, "Gas", "Active" },
                    { 3, "Điện", "Active" },
                    { 4, "Còn lại", "Active" }
                });

            migrationBuilder.InsertData(
                table: "TicketTypes",
                columns: new[] { "TicketTypeId", "Description", "Status", "TicketTypeName" },
                values: new object[,]
                {
                    { 1, "Repair", true, "Repair" },
                    { 2, "Bảo trì", true, "Bảo trì" },
                    { 3, "Khác", true, "Khác" },
                    { 4, "Phàn nàn", true, "Phàn nàn" }
                });

            migrationBuilder.InsertData(
                table: "University",
                columns: new[] { "UniversityId", "Address", "Description", "Status", "UniversityName" },
                values: new object[,]
                {
                    { 1, "HCM", "HCM University of Technology", "Active", "HCM University of Technology" },
                    { 2, "HCM", "HCM University of Science", "Active", "HCM University of Science" },
                    { 3, "HCM", "HCM University of Pedagogy", "Active", "HCM University of Pedagogy" },
                    { 4, "HCM", "HCM University of Physical", "Active", "HCM University of Physical" },
                    { 5, "HCM", "HCM University of Math", "Active", "HCM University of Math" },
                    { 6, "HCM", "HCM University of History", "Active", "HCM University of History" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "Email", "FullName", "Password", "Phone", "RoleId", "Status", "Username" },
                values: new object[,]
                {
                    { 1, "superadmin@mail", "Super admin account", "superadmin", "0123543125", 1, true, "superadmin" },
                    { 2, "admin@mail", "Admin account", "admin", "0123543532", 2, true, "admin" },
                    { 3, "supervisor@mail", "Supervisor account", "supervisor", "0123543554", 3, true, "supervisor" },
                    { 4, "employee1@mail", "Employee account 1", "employee1", "0123543235", 4, true, "employee1" },
                    { 5, "employee2@mail", "Employee account 2", "employee2", "0123123235", 4, true, "employee2" }
                });

            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "MajorId", "Name", "UniversityId" },
                values: new object[,]
                {
                    { 1, "Computer Science", 1 },
                    { 2, "Information Technology", 1 },
                    { 3, "Software Engineering", 2 },
                    { 4, "Information Technology", 2 },
                    { 5, "Information Technology", 3 }
                });

            migrationBuilder.InsertData(
                table: "Renters",
                columns: new[] { "RenterId", "Address", "BirthDate", "CitizenImageUrl", "CitizenNumber", "DeviceToken", "Email", "FullName", "Gender", "ImageUrl", "MajorId", "Password", "Phone", "Status", "UniversityId", "Username" },
                values: new object[,]
                {
                    { 4, "HN", new DateTime(2023, 3, 2, 13, 55, 18, 827, DateTimeKind.Utc).AddTicks(4695), null, "3214324523", "ewasdv12344", "renter4@mail.com", "Nguyen Van D", "Female", null, null, "renter4", "0123543125", true, 1, "renter4" },
                    { 5, "HCM", new DateTime(2023, 3, 2, 13, 55, 18, 827, DateTimeKind.Utc).AddTicks(4698), null, "3214324523", "ewasdv12344", "trankhaimnhkhoi10a3@mail.com", "Tran Minh Khoi", "Male", null, null, "123456789", "0123543125", true, 1, "minhkhoi10a3" },
                    { 6, "HCM", new DateTime(2023, 3, 2, 13, 55, 18, 827, DateTimeKind.Utc).AddTicks(4699), null, "3214324523", "ewasdv12344", "trankhaimnhkhoi@mail.com", "Tran Minh Khoi", "Male", null, null, "123456789", "0123543125", true, 1, "minhkhoi" }
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "BuildingId", "AccountId", "AreaId", "BuildingName", "CoordinateX", "CoordinateY", "Description", "ImageUrl", "Status", "TotalRooms" },
                values: new object[,]
                {
                    { 1, 5, 1, "Building 1a", 231m, 324m, "Building 1a", "", true, 0 },
                    { 2, 2, 1, "Building 1b", 21233m, 334m, "Building 1b", "", true, 0 },
                    { 3, 2, 2, "Building 1c", 423m, 3214m, "Building 1c", "", true, 0 },
                    { 4, 4, 2, "Building 1d", 2323m, 314m, "Building 1d", "", true, 0 },
                    { 5, 3, 3, "Building 1e", 23431m, 3245m, "Building 1e", "", true, 0 },
                    { 6, 3, 3, "Building 1f", 21233m, 334m, "Building 1f", "", true, 0 },
                    { 7, 3, 4, "Building 1g", 423m, 3214m, "Building 1g", "", true, 0 },
                    { 8, 3, 4, "Building 1h", 2323m, 31454m, "Building 1h", "", true, 0 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceId", "AccountId", "Amount", "CreatedTime", "Detail", "DueDate", "ImageUrl", "InvoiceTypeId", "Name", "PaymentTime", "RenterId", "Status" },
                values: new object[,]
                {
                    { 1, 2, 0, new DateTime(2023, 3, 2, 13, 55, 18, 827, DateTimeKind.Utc).AddTicks(5008), "Detail for invoice 1", null, null, 1, "Hoá đơn điện tử cho renter 1", null, 1, true },
                    { 2, 3, 0, new DateTime(2023, 3, 2, 13, 55, 18, 827, DateTimeKind.Utc).AddTicks(5043), "Detail for invoice 2", null, null, 1, "Hoá đơn điện tử cho renter 2", null, 2, true }
                });

            migrationBuilder.InsertData(
                table: "Renters",
                columns: new[] { "RenterId", "Address", "BirthDate", "CitizenImageUrl", "CitizenNumber", "DeviceToken", "Email", "FullName", "Gender", "ImageUrl", "MajorId", "Password", "Phone", "Status", "UniversityId", "Username" },
                values: new object[,]
                {
                    { 3, "DN", new DateTime(2023, 3, 2, 13, 55, 18, 827, DateTimeKind.Utc).AddTicks(4693), null, "3214324523", "123221ad145ad423sa", "renter3@mail.com", "Nguyen Van C", "Female", null, 2, "renter3", "0123543125", true, 1, "renter3" },
                    { 7, "HCM", new DateTime(2023, 3, 2, 13, 55, 18, 827, DateTimeKind.Utc).AddTicks(4701), null, "3214324523", "ewasdv12344", "khoitkmse150850@fpt", "Tran Minh Khoi", "Male", null, 1, "123456789", "0123543125", true, 1, "minhkhoitkm" }
                });

            migrationBuilder.InsertData(
                table: "Flats",
                columns: new[] { "FlatId", "AvailableRoom", "BuildingId", "Description", "ElectricityMeterAfter", "ElectricityMeterBefore", "FlatTypeId", "MaxRoom", "Name", "Status", "WaterMeterAfter", "WaterMeterBefore" },
                values: new object[,]
                {
                    { 1, 0, 1, "Flat 1", 0, 0, 1, 0, "Flat 1", "Active", 0, 0 },
                    { 2, 0, 3, "Flat 2", 0, 0, 3, 0, "Flat 2", "Active", 0, 0 },
                    { 3, 0, 2, "Flat 3", 0, 0, 2, 0, "Flat 3", "Active", 0, 0 },
                    { 4, 0, 2, "Flat 4", 0, 0, 5, 0, "Flat 4", "NonActive", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "InvoiceDetails",
                columns: new[] { "InvoiceDetailId", "Amount", "InvoiceId", "ServiceId" },
                values: new object[,]
                {
                    { 3, 0m, 1, null },
                    { 4, 0m, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceId", "AccountId", "Amount", "CreatedTime", "Detail", "DueDate", "ImageUrl", "InvoiceTypeId", "Name", "PaymentTime", "RenterId", "Status" },
                values: new object[] { 3, 4, 0, new DateTime(2023, 3, 2, 13, 55, 18, 827, DateTimeKind.Utc).AddTicks(5045), "Detail for invoice 3", null, null, 1, "Hoá đơn điện tử cho renter 3", null, 3, true });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "Amount", "BuildingId", "Description", "Name", "ServiceTypeId", "Status" },
                values: new object[,]
                {
                    { 1, 0m, 2, "Cung cấp nước 1", "Cung cấp nước 1", 1, true },
                    { 2, 0m, 1, "Cung cấp nước 2 ", "Cung cấp nước 2", 1, true },
                    { 3, 0m, 3, "Cung cấp nước 3", "Cung cấp nước 3", 3, true },
                    { 4, 0m, 4, "Cung cấp nước 4", "Cung cấp nước 4", 2, true }
                });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "ContractId", "ContractName", "ContractStatus", "CreatedDate", "DateSigned", "Description", "EndDate", "FlatId", "ImageUrl", "LastUpdated", "PriceForElectricity", "PriceForRent", "PriceForService", "PriceForWater", "RenterId", "StartDate" },
                values: new object[,]
                {
                    { 1, "Contract for renter 1", "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 31, 13, 55, 18, 827, DateTimeKind.Utc).AddTicks(5080), "Contract description for renter 1", null, 2, "No image", new DateTime(2023, 3, 2, 13, 55, 18, 827, DateTimeKind.Utc).AddTicks(5087), 0m, 1800000m, 0m, 0m, 1, new DateTime(2023, 2, 5, 13, 55, 18, 827, DateTimeKind.Utc).AddTicks(5086) },
                    { 2, "Contract for renter 2", "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 1, 13, 55, 18, 827, DateTimeKind.Utc).AddTicks(5089), "Contract description for renter 2", null, 3, "No image", new DateTime(2023, 3, 2, 13, 55, 18, 827, DateTimeKind.Utc).AddTicks(5091), 0m, 2800000m, 0m, 0m, 2, new DateTime(2023, 2, 3, 13, 55, 18, 827, DateTimeKind.Utc).AddTicks(5090) },
                    { 3, "Contract for renter 3", "Active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 1, 13, 55, 18, 827, DateTimeKind.Utc).AddTicks(5092), "Contract description for renter 3", null, 3, "No image", new DateTime(2023, 3, 2, 13, 55, 18, 827, DateTimeKind.Utc).AddTicks(5093), 120m, 2800000m, 10000m, 1000m, 3, new DateTime(2023, 2, 3, 13, 55, 18, 827, DateTimeKind.Utc).AddTicks(5093) }
                });

            migrationBuilder.InsertData(
                table: "InvoiceDetails",
                columns: new[] { "InvoiceDetailId", "Amount", "InvoiceId", "ServiceId" },
                values: new object[,]
                {
                    { 1, 0m, 1, 1 },
                    { 2, 0m, 1, 2 },
                    { 5, 0m, 2, 3 },
                    { 6, 0m, 2, 3 },
                    { 7, 0m, 3, null },
                    { 8, 0m, 3, null },
                    { 9, 0m, 3, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Email",
                table: "Accounts",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RoleId",
                table: "Accounts",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Username",
                table: "Accounts",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_AccountId",
                table: "Buildings",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_AreaId",
                table: "Buildings",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_FlatId",
                table: "Contracts",
                column: "FlatId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_RenterId",
                table: "Contracts",
                column: "RenterId");

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
                name: "IX_InvoiceDetails_ServiceId",
                table: "InvoiceDetails",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_AccountId",
                table: "Invoices",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceTypeId",
                table: "Invoices",
                column: "InvoiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_RenterId",
                table: "Invoices",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Majors_UniversityId",
                table: "Majors",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_NotificationTypeId",
                table: "Notification",
                column: "NotificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Renters_Email",
                table: "Renters",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Renters_MajorId",
                table: "Renters",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_Renters_UniversityId",
                table: "Renters",
                column: "UniversityId");

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
                name: "IX_Services_BuildingId",
                table: "Services",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceTypeId",
                table: "Services",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AccountId",
                table: "Tickets",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ContractId",
                table: "Tickets",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketTypeId",
                table: "Tickets",
                column: "TicketTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_InvoiceId",
                table: "Transactions",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDevice_AccountId",
                table: "UserDevice",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDevice_RenterId",
                table: "UserDevice",
                column: "RenterId");

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
                name: "DatabaseExceptions");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "UserDevice");

            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropTable(
                name: "FeedbackTypes");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "NotificationType");

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
                name: "Majors");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "University");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
