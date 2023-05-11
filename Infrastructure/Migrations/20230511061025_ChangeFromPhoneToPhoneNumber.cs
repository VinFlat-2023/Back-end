using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ChangeFromPhoneToPhoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2206), new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2209), new DateTime(2023, 4, 16, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2208) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 12, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2212), new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2213), new DateTime(2023, 4, 14, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2213) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 12, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2215), new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2216), new DateTime(2023, 4, 14, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2216) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 12, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2218), new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2228), new DateTime(2023, 4, 14, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2218) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 12, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2230), new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2233), new DateTime(2023, 4, 14, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2232) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 12, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2235), new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2235), new DateTime(2023, 4, 14, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2235) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2133));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2135));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2136), new DateTime(2023, 6, 10, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2136) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2138), new DateTime(2023, 2, 8, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2140), new DateTime(2023, 2, 6, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2141) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2142), new DateTime(2023, 2, 28, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2143), new DateTime(2023, 2, 26, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2143) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2145), new DateTime(2023, 4, 29, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2146), new DateTime(2023, 4, 27, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2146) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2147), new DateTime(2023, 3, 30, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2148), new DateTime(2023, 3, 28, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(1661));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(1664));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(1667));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(1668));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(1669));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(1670));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(1671));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(1984));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(1986));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(1987));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2012));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2013));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2014));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2015));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2016), new DateTime(2023, 5, 4, 13, 10, 23, 671, DateTimeKind.Local).AddTicks(2020) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5186), new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5189), new DateTime(2023, 4, 15, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5188) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 11, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5192), new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5193), new DateTime(2023, 4, 13, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5193) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 11, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5196), new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5197), new DateTime(2023, 4, 13, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5196) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 11, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5199), new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5199), new DateTime(2023, 4, 13, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5199) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 11, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5201), new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5208), new DateTime(2023, 4, 13, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5201) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 11, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5210), new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5213), new DateTime(2023, 4, 13, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5212) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5137));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5139));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5140), new DateTime(2023, 6, 9, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5140) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5142), new DateTime(2023, 2, 7, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5144), new DateTime(2023, 2, 5, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5145) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5146), new DateTime(2023, 2, 27, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5146), new DateTime(2023, 2, 25, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5147) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5148), new DateTime(2023, 4, 28, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5149), new DateTime(2023, 4, 26, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5149) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5150), new DateTime(2023, 3, 29, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5151), new DateTime(2023, 3, 27, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5151) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(4681));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(4685));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(4687));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(4688));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(4689));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(4692));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(4995));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(4996));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(4997));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(4998));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(4999));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5000));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5000));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5001), new DateTime(2023, 5, 3, 14, 32, 48, 138, DateTimeKind.Local).AddTicks(5004) });
        }
    }
}
