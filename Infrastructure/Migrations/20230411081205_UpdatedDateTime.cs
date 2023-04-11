using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdatedDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
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
                values: new object[] { new DateTime(2023, 10, 5, 8, 12, 4, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 4, 8, 12, 4, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 10, 8, 12, 4, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 6, 8, 12, 4, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 4, 8, 12, 4, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 8, 8, 12, 4, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 6, 8, 12, 4, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 4, 8, 12, 4, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 8, 8, 12, 4, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 6, 8, 12, 4, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 4, 8, 12, 4, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 8, 8, 12, 4, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 6, 8, 12, 4, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 4, 8, 12, 4, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 8, 8, 12, 4, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 6, 8, 12, 4, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 4, 8, 12, 4, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 8, 8, 12, 4, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 11, 4, 8, 12, 4, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 11, 4, 8, 12, 4, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2023, 11, 4, 8, 12, 4, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2023, 11, 4, 8, 12, 4, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2023, 11, 4, 8, 12, 4, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2023, 11, 4, 8, 12, 4, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                column: "CreatedTime",
                value: new DateTime(2023, 11, 4, 8, 12, 4, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 11, 4, 8, 12, 4, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 11, 4, 8, 12, 4, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 11, 4, 8, 12, 4, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 11, 4, 8, 12, 4, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 11, 4, 8, 12, 4, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 11, 4, 8, 12, 4, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 11, 4, 8, 12, 4, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 11, 4, 8, 12, 4, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 11, 4, 8, 12, 4, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 11, 4, 8, 12, 4, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 11, 4, 8, 12, 4, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
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
                values: new object[] { new DateTime(2023, 8, 5, 18, 17, 19, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 18, 17, 19, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 10, 18, 17, 19, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 8, 6, 18, 17, 19, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 18, 17, 19, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 8, 18, 17, 19, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 8, 6, 18, 17, 19, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 18, 17, 19, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 8, 18, 17, 19, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 8, 6, 18, 17, 19, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 18, 17, 19, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 8, 18, 17, 19, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 8, 6, 18, 17, 19, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 18, 17, 19, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 8, 18, 17, 19, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 8, 6, 18, 17, 19, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 18, 17, 19, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 8, 18, 17, 19, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 9, 4, 18, 17, 19, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 9, 4, 18, 17, 19, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2023, 9, 4, 18, 17, 19, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2023, 9, 4, 18, 17, 19, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2023, 9, 4, 18, 17, 19, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2023, 9, 4, 18, 17, 19, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                column: "CreatedTime",
                value: new DateTime(2023, 9, 4, 18, 17, 19, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 9, 4, 18, 17, 19, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 9, 4, 18, 17, 19, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 9, 4, 18, 17, 19, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 9, 4, 18, 17, 19, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 9, 4, 18, 17, 19, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 9, 4, 18, 17, 19, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 9, 4, 18, 17, 19, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 9, 4, 18, 17, 19, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 9, 4, 18, 17, 19, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 9, 4, 18, 17, 19, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 9, 4, 18, 17, 19, 0, DateTimeKind.Unspecified));
        }
    }
}
