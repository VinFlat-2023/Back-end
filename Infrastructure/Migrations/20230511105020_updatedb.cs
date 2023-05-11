using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6576), new DateTime(2023, 5, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6579), new DateTime(2023, 4, 16, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6578) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 12, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6582), new DateTime(2023, 5, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6584), new DateTime(2023, 4, 14, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6583) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 12, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6586), new DateTime(2023, 5, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6588), new DateTime(2023, 4, 14, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6587) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 12, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6590), new DateTime(2023, 5, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6592), new DateTime(2023, 4, 14, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6591) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 12, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6594), new DateTime(2023, 5, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6607), new DateTime(2023, 4, 14, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6595) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 12, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6609), new DateTime(2023, 5, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6613), new DateTime(2023, 4, 14, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6612) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6515));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6517));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6519), new DateTime(2023, 6, 10, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6519) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6524), new DateTime(2023, 2, 8, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6526), new DateTime(2023, 2, 6, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6526) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6528), new DateTime(2023, 2, 28, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6529), new DateTime(2023, 2, 26, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6530) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6531), new DateTime(2023, 4, 29, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6532), new DateTime(2023, 4, 27, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6533) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6534), new DateTime(2023, 3, 30, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6535), new DateTime(2023, 3, 28, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6536) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(5671));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(5680));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(5681));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(5683));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(5684));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(5686));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(5689));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6359));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6361));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6362));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6363));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6364));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6365));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6366));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 11, 10, 50, 19, 566, DateTimeKind.Utc).AddTicks(6367), new DateTime(2023, 5, 4, 17, 50, 19, 566, DateTimeKind.Local).AddTicks(6370) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
