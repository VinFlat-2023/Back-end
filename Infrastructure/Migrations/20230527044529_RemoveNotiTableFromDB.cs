using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class RemoveNotiTableFromDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Invoices",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 27, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7587), new DateTime(2023, 5, 27, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7589), new DateTime(2023, 5, 2, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7589) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 28, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7595), new DateTime(2023, 5, 27, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7596), new DateTime(2023, 4, 30, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7596) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 28, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7598), new DateTime(2023, 5, 27, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7599), new DateTime(2023, 4, 30, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7598) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 28, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7600), new DateTime(2023, 5, 27, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7601), new DateTime(2023, 4, 30, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7601) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 28, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7603), new DateTime(2023, 5, 27, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7615), new DateTime(2023, 4, 30, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7603) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 28, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7616), new DateTime(2023, 5, 27, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7620), new DateTime(2023, 4, 30, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7620) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 27, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7509), null });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 27, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7511), null });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 27, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7512), new DateTime(2023, 6, 26, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 27, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7515), new DateTime(2023, 2, 24, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7517), new DateTime(2023, 2, 22, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7517) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 27, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7518), new DateTime(2023, 3, 16, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7519), new DateTime(2023, 3, 14, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7519) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 27, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7520), new DateTime(2023, 5, 15, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7521), new DateTime(2023, 5, 13, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7521) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 27, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7523), new DateTime(2023, 4, 15, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7523), new DateTime(2023, 4, 13, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7524) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 4, 45, 27, 877, DateTimeKind.Utc).AddTicks(2349));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 4, 45, 27, 877, DateTimeKind.Utc).AddTicks(2353));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 4, 45, 27, 877, DateTimeKind.Utc).AddTicks(2354));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 4, 45, 27, 877, DateTimeKind.Utc).AddTicks(2356));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 4, 45, 27, 877, DateTimeKind.Utc).AddTicks(2357));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 4, 45, 27, 877, DateTimeKind.Utc).AddTicks(2358));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 4, 45, 27, 877, DateTimeKind.Utc).AddTicks(2359));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7311));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7313));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7315));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7315));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7316));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7317));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7318));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 27, 4, 45, 27, 879, DateTimeKind.Utc).AddTicks(7363), new DateTime(2023, 5, 20, 11, 45, 27, 879, DateTimeKind.Local).AddTicks(7366) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7265), new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7268), new DateTime(2023, 5, 2, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7267) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 28, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7272), new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7273), new DateTime(2023, 4, 30, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7272) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 28, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7299), new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7300), new DateTime(2023, 4, 30, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7299) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 28, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7302), new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7303), new DateTime(2023, 4, 30, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7303) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 28, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7306), new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7319), new DateTime(2023, 4, 30, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7306) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 28, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7321), new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7324), new DateTime(2023, 4, 30, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7324) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7201), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7203), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7204), new DateTime(2023, 6, 26, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7204) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7207), new DateTime(2023, 2, 24, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7209), new DateTime(2023, 2, 22, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7209) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7211), new DateTime(2023, 3, 16, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7212), new DateTime(2023, 3, 14, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7212) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7214), new DateTime(2023, 5, 15, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7214), new DateTime(2023, 5, 13, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7219) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7220), new DateTime(2023, 4, 15, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7222), new DateTime(2023, 4, 13, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7222) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 279, DateTimeKind.Utc).AddTicks(9746));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 279, DateTimeKind.Utc).AddTicks(9751));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 279, DateTimeKind.Utc).AddTicks(9752));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 279, DateTimeKind.Utc).AddTicks(9754));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 279, DateTimeKind.Utc).AddTicks(9756));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 279, DateTimeKind.Utc).AddTicks(9757));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 279, DateTimeKind.Utc).AddTicks(9758));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(6980));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(6982));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(6984));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(6988));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(6988));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(6989));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(6990));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(6991), new DateTime(2023, 5, 20, 11, 36, 13, 282, DateTimeKind.Local).AddTicks(6994) });
        }
    }
}
