using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AAAA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 2, 22, 15, 9, 246, DateTimeKind.Utc).AddTicks(9704), new DateTime(2023, 3, 4, 22, 15, 9, 246, DateTimeKind.Utc).AddTicks(9711), new DateTime(2023, 2, 7, 22, 15, 9, 246, DateTimeKind.Utc).AddTicks(9710) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 3, 22, 15, 9, 246, DateTimeKind.Utc).AddTicks(9713), new DateTime(2023, 3, 4, 22, 15, 9, 246, DateTimeKind.Utc).AddTicks(9715), new DateTime(2023, 2, 5, 22, 15, 9, 246, DateTimeKind.Utc).AddTicks(9714) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 3, 22, 15, 9, 246, DateTimeKind.Utc).AddTicks(9718), new DateTime(2023, 3, 4, 22, 15, 9, 246, DateTimeKind.Utc).AddTicks(9718), new DateTime(2023, 2, 5, 22, 15, 9, 246, DateTimeKind.Utc).AddTicks(9718) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 3, 4, 22, 15, 9, 246, DateTimeKind.Utc).AddTicks(9668));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 3, 4, 22, 15, 9, 246, DateTimeKind.Utc).AddTicks(9671));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2023, 3, 4, 22, 15, 9, 246, DateTimeKind.Utc).AddTicks(9673));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 3, 4, 22, 15, 9, 246, DateTimeKind.Utc).AddTicks(2934));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 3, 4, 22, 15, 9, 246, DateTimeKind.Utc).AddTicks(2940));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 3, 4, 22, 15, 9, 246, DateTimeKind.Utc).AddTicks(2943));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 3, 4, 22, 15, 9, 246, DateTimeKind.Utc).AddTicks(2976));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 3, 4, 22, 15, 9, 246, DateTimeKind.Utc).AddTicks(2978));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 3, 4, 22, 15, 9, 246, DateTimeKind.Utc).AddTicks(2979));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 3, 4, 22, 15, 9, 246, DateTimeKind.Utc).AddTicks(2981));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 1, 7, 14, 54, 872, DateTimeKind.Utc).AddTicks(3956), new DateTime(2023, 3, 3, 7, 14, 54, 872, DateTimeKind.Utc).AddTicks(3966), new DateTime(2023, 2, 6, 7, 14, 54, 872, DateTimeKind.Utc).AddTicks(3963) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 2, 7, 14, 54, 872, DateTimeKind.Utc).AddTicks(3971), new DateTime(2023, 3, 3, 7, 14, 54, 872, DateTimeKind.Utc).AddTicks(3973), new DateTime(2023, 2, 4, 7, 14, 54, 872, DateTimeKind.Utc).AddTicks(3972) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 2, 7, 14, 54, 872, DateTimeKind.Utc).AddTicks(3975), new DateTime(2023, 3, 3, 7, 14, 54, 872, DateTimeKind.Utc).AddTicks(3977), new DateTime(2023, 2, 4, 7, 14, 54, 872, DateTimeKind.Utc).AddTicks(3976) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 3, 3, 7, 14, 54, 872, DateTimeKind.Utc).AddTicks(3898));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 3, 3, 7, 14, 54, 872, DateTimeKind.Utc).AddTicks(3903));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2023, 3, 3, 7, 14, 54, 872, DateTimeKind.Utc).AddTicks(3906));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 3, 3, 7, 14, 54, 871, DateTimeKind.Utc).AddTicks(2961));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 3, 3, 7, 14, 54, 871, DateTimeKind.Utc).AddTicks(2969));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 3, 3, 7, 14, 54, 871, DateTimeKind.Utc).AddTicks(2972));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 3, 3, 7, 14, 54, 871, DateTimeKind.Utc).AddTicks(2975));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 3, 3, 7, 14, 54, 871, DateTimeKind.Utc).AddTicks(2977));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 3, 3, 7, 14, 54, 871, DateTimeKind.Utc).AddTicks(2980));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 3, 3, 7, 14, 54, 871, DateTimeKind.Utc).AddTicks(3056));
        }
    }
}
