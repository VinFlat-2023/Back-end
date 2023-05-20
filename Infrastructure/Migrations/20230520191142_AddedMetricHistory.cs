using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddedMetricHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MetricHistories",
                columns: table => new
                {
                    MetricHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WaterMeterBefore = table.Column<int>(type: "int", nullable: true),
                    WaterMeterAfter = table.Column<int>(type: "int", nullable: true),
                    ElectricityMeterBefore = table.Column<int>(type: "int", nullable: true),
                    ElectricityMeterAfter = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecordedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetricHistories", x => x.MetricHistoryId);
                });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1503), new DateTime(2023, 5, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1505), new DateTime(2023, 4, 25, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1505) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 21, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1508), new DateTime(2023, 5, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1509), new DateTime(2023, 4, 23, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1509) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 21, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1511), new DateTime(2023, 5, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1512), new DateTime(2023, 4, 23, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1511) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 21, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1513), new DateTime(2023, 5, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1514), new DateTime(2023, 4, 23, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1514) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 21, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1553), new DateTime(2023, 5, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1564), new DateTime(2023, 4, 23, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1554) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 21, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1566), new DateTime(2023, 5, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1569), new DateTime(2023, 4, 23, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1568) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1448));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1452));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1453), new DateTime(2023, 6, 19, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1453) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1456), new DateTime(2023, 2, 17, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1457), new DateTime(2023, 2, 15, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1458) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1459), new DateTime(2023, 3, 9, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1460), new DateTime(2023, 3, 7, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1461) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1462), new DateTime(2023, 5, 8, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1463), new DateTime(2023, 5, 6, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1463) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1464), new DateTime(2023, 4, 8, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1465), new DateTime(2023, 4, 6, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1465) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(970));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(973));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(975));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(976));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(978));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(979));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(980));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1296));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1299));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1300));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1301));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1301));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1302));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1303));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 20, 19, 11, 40, 493, DateTimeKind.Utc).AddTicks(1304), new DateTime(2023, 5, 14, 2, 11, 40, 493, DateTimeKind.Local).AddTicks(1307) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MetricHistories");

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2848), new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2854), new DateTime(2023, 4, 22, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2852) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 18, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2860), new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2862), new DateTime(2023, 4, 20, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2860) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 18, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2864), new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2866), new DateTime(2023, 4, 20, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2865) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 18, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2869), new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2870), new DateTime(2023, 4, 20, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2870) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 18, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2876), new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2893), new DateTime(2023, 4, 20, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2877) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 18, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2896), new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2903), new DateTime(2023, 4, 20, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2902) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2664));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2671), new DateTime(2023, 6, 16, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2672) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2676), new DateTime(2023, 2, 14, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2680), new DateTime(2023, 2, 12, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2681) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2686), new DateTime(2023, 3, 6, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2688), new DateTime(2023, 3, 4, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2690) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2698), new DateTime(2023, 5, 5, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2699), new DateTime(2023, 5, 3, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2700) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2751), new DateTime(2023, 4, 5, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2753), new DateTime(2023, 4, 3, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2754) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(1619));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(1627));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(1680));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(1682));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(1684));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(1686));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(1689));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2363));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2367));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2369));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2372));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2376));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2377));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2379));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2382), new DateTime(2023, 5, 11, 3, 39, 1, 399, DateTimeKind.Local).AddTicks(2387) });
        }
    }
}
