using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdateInvoiceDetailAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "InvoiceDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 25, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2257), new DateTime(2023, 5, 25, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2260), new DateTime(2023, 4, 30, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2260) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 26, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2265), new DateTime(2023, 5, 25, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2266), new DateTime(2023, 4, 28, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2265) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 26, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2268), new DateTime(2023, 5, 25, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2269), new DateTime(2023, 4, 28, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2268) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 26, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2271), new DateTime(2023, 5, 25, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2272), new DateTime(2023, 4, 28, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2271) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 26, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2274), new DateTime(2023, 5, 25, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2275), new DateTime(2023, 4, 28, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2274) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 26, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2276), new DateTime(2023, 5, 25, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2277), new DateTime(2023, 4, 28, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2277) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 25, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2151));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 25, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2153));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 25, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2154), new DateTime(2023, 6, 24, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2155) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 25, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2163), new DateTime(2023, 2, 22, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2165), new DateTime(2023, 2, 20, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2166) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 25, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2167), new DateTime(2023, 3, 14, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2169), new DateTime(2023, 3, 12, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2170) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 25, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2171), new DateTime(2023, 5, 13, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2171), new DateTime(2023, 5, 11, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2172) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 25, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2173), new DateTime(2023, 4, 13, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2198), new DateTime(2023, 4, 11, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(2198) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 25, 7, 13, 7, 713, DateTimeKind.Utc).AddTicks(6044));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 25, 7, 13, 7, 713, DateTimeKind.Utc).AddTicks(6049));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 25, 7, 13, 7, 713, DateTimeKind.Utc).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 25, 7, 13, 7, 713, DateTimeKind.Utc).AddTicks(6051));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 25, 7, 13, 7, 713, DateTimeKind.Utc).AddTicks(6053));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 25, 7, 13, 7, 713, DateTimeKind.Utc).AddTicks(6055));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 25, 7, 13, 7, 713, DateTimeKind.Utc).AddTicks(6056));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 25, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(1932));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 25, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(1935));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 25, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(1937));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 25, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(1938));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 25, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(1939));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 25, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(1941));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 25, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(1941));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 25, 7, 13, 7, 716, DateTimeKind.Utc).AddTicks(1942), new DateTime(2023, 5, 18, 14, 13, 7, 716, DateTimeKind.Local).AddTicks(1946) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "InvoiceDetails");

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8397), new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8400), new DateTime(2023, 4, 29, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8399) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 25, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8404), new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8405), new DateTime(2023, 4, 27, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8405) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 25, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8407), new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8408), new DateTime(2023, 4, 27, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8407) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 25, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8410), new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8410), new DateTime(2023, 4, 27, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8410) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 25, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8412), new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8422), new DateTime(2023, 4, 27, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8413) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 25, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8423), new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8427), new DateTime(2023, 4, 27, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8426) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8283));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8285));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8286), new DateTime(2023, 6, 23, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8286) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8289), new DateTime(2023, 2, 21, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8291), new DateTime(2023, 2, 19, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8293) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8294), new DateTime(2023, 3, 13, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8295), new DateTime(2023, 3, 11, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8295) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8338), new DateTime(2023, 5, 12, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8339), new DateTime(2023, 5, 10, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8339) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8341), new DateTime(2023, 4, 12, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8341), new DateTime(2023, 4, 10, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 710, DateTimeKind.Utc).AddTicks(2180));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 710, DateTimeKind.Utc).AddTicks(2184));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 710, DateTimeKind.Utc).AddTicks(2232));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 710, DateTimeKind.Utc).AddTicks(2233));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 710, DateTimeKind.Utc).AddTicks(2235));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 710, DateTimeKind.Utc).AddTicks(2237));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 710, DateTimeKind.Utc).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8112));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8116));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8117));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8119));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8119));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8120));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8121));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8122), new DateTime(2023, 5, 17, 14, 58, 36, 712, DateTimeKind.Local).AddTicks(8126) });
        }
    }
}
