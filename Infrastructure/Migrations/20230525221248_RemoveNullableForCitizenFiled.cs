using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class RemoveNullableForCitizenFiled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CitizenNumber",
                table: "Renters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CitizenCardFrontImageUrl",
                table: "Renters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CitizenCardBackImageUrl",
                table: "Renters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "WaterMeterBefore",
                table: "Flats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "WaterMeterAfter",
                table: "Flats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ElectricityMeterBefore",
                table: "Flats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ElectricityMeterAfter",
                table: "Flats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9265), new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9268), new DateTime(2023, 4, 30, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9268) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 26, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9274), new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9275), new DateTime(2023, 4, 28, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9274) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 26, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9278), new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9278), new DateTime(2023, 4, 28, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9278) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 26, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9281), new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9282), new DateTime(2023, 4, 28, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9281) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 26, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9284), new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9298), new DateTime(2023, 4, 28, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9284) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 26, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9300), new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9306), new DateTime(2023, 4, 28, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9305) });

            migrationBuilder.UpdateData(
                table: "Flats",
                keyColumn: "FlatId",
                keyValue: 1,
                columns: new[] { "ElectricityMeterAfter", "ElectricityMeterBefore", "WaterMeterAfter", "WaterMeterBefore" },
                values: new object[] { 0m, 0m, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Flats",
                keyColumn: "FlatId",
                keyValue: 2,
                columns: new[] { "ElectricityMeterAfter", "ElectricityMeterBefore", "WaterMeterAfter", "WaterMeterBefore" },
                values: new object[] { 0m, 0m, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Flats",
                keyColumn: "FlatId",
                keyValue: 3,
                columns: new[] { "ElectricityMeterAfter", "ElectricityMeterBefore", "WaterMeterAfter", "WaterMeterBefore" },
                values: new object[] { 0m, 0m, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Flats",
                keyColumn: "FlatId",
                keyValue: 4,
                columns: new[] { "ElectricityMeterAfter", "ElectricityMeterBefore", "WaterMeterAfter", "WaterMeterBefore" },
                values: new object[] { 0m, 0m, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9160));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9162));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9164), new DateTime(2023, 6, 24, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9165) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9169), new DateTime(2023, 2, 22, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9172), new DateTime(2023, 2, 20, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9173) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9177), new DateTime(2023, 3, 14, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9178), new DateTime(2023, 3, 12, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9179) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9180), new DateTime(2023, 5, 13, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9181), new DateTime(2023, 5, 11, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9181) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9184), new DateTime(2023, 4, 13, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9186), new DateTime(2023, 4, 11, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9186) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                columns: new[] { "BirthDate", "CitizenCardBackImageUrl", "CitizenCardFrontImageUrl" },
                values: new object[] { new DateTime(2023, 5, 25, 22, 12, 47, 38, DateTimeKind.Utc).AddTicks(3171), "ewqe", "Ewqea" });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                columns: new[] { "BirthDate", "CitizenCardBackImageUrl", "CitizenCardFrontImageUrl" },
                values: new object[] { new DateTime(2023, 5, 25, 22, 12, 47, 38, DateTimeKind.Utc).AddTicks(3178), "ewqe", "Ewqea" });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                columns: new[] { "BirthDate", "CitizenCardBackImageUrl", "CitizenCardFrontImageUrl" },
                values: new object[] { new DateTime(2023, 5, 25, 22, 12, 47, 38, DateTimeKind.Utc).AddTicks(3181), "ewqe", "Ewqea" });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                columns: new[] { "BirthDate", "CitizenCardBackImageUrl", "CitizenCardFrontImageUrl" },
                values: new object[] { new DateTime(2023, 5, 25, 22, 12, 47, 38, DateTimeKind.Utc).AddTicks(3183), "ewqe", "Ewqea" });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                columns: new[] { "BirthDate", "CitizenCardBackImageUrl", "CitizenCardFrontImageUrl" },
                values: new object[] { new DateTime(2023, 5, 25, 22, 12, 47, 38, DateTimeKind.Utc).AddTicks(3185), "ewqe", "Ewqea" });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                columns: new[] { "BirthDate", "CitizenCardBackImageUrl", "CitizenCardFrontImageUrl" },
                values: new object[] { new DateTime(2023, 5, 25, 22, 12, 47, 38, DateTimeKind.Utc).AddTicks(3187), "ewqe", "Ewqea" });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                columns: new[] { "BirthDate", "CitizenCardBackImageUrl", "CitizenCardFrontImageUrl" },
                values: new object[] { new DateTime(2023, 5, 25, 22, 12, 47, 38, DateTimeKind.Utc).AddTicks(3189), "ewqe", "Ewqea" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(8945));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(8947));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(8949));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(8950));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(8951));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(8952));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(8953));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(8988), new DateTime(2023, 5, 19, 5, 12, 47, 41, DateTimeKind.Local).AddTicks(8990) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CitizenNumber",
                table: "Renters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CitizenCardFrontImageUrl",
                table: "Renters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CitizenCardBackImageUrl",
                table: "Renters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "WaterMeterBefore",
                table: "Flats",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "WaterMeterAfter",
                table: "Flats",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "ElectricityMeterBefore",
                table: "Flats",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "ElectricityMeterAfter",
                table: "Flats",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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
                table: "Flats",
                keyColumn: "FlatId",
                keyValue: 1,
                columns: new[] { "ElectricityMeterAfter", "ElectricityMeterBefore", "WaterMeterAfter", "WaterMeterBefore" },
                values: new object[] { 0, 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Flats",
                keyColumn: "FlatId",
                keyValue: 2,
                columns: new[] { "ElectricityMeterAfter", "ElectricityMeterBefore", "WaterMeterAfter", "WaterMeterBefore" },
                values: new object[] { 0, 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Flats",
                keyColumn: "FlatId",
                keyValue: 3,
                columns: new[] { "ElectricityMeterAfter", "ElectricityMeterBefore", "WaterMeterAfter", "WaterMeterBefore" },
                values: new object[] { 0, 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Flats",
                keyColumn: "FlatId",
                keyValue: 4,
                columns: new[] { "ElectricityMeterAfter", "ElectricityMeterBefore", "WaterMeterAfter", "WaterMeterBefore" },
                values: new object[] { 0, 0, 0, 0 });

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
                columns: new[] { "BirthDate", "CitizenCardBackImageUrl", "CitizenCardFrontImageUrl" },
                values: new object[] { new DateTime(2023, 5, 25, 7, 13, 7, 713, DateTimeKind.Utc).AddTicks(6044), null, null });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                columns: new[] { "BirthDate", "CitizenCardBackImageUrl", "CitizenCardFrontImageUrl" },
                values: new object[] { new DateTime(2023, 5, 25, 7, 13, 7, 713, DateTimeKind.Utc).AddTicks(6049), null, null });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                columns: new[] { "BirthDate", "CitizenCardBackImageUrl", "CitizenCardFrontImageUrl" },
                values: new object[] { new DateTime(2023, 5, 25, 7, 13, 7, 713, DateTimeKind.Utc).AddTicks(6050), null, null });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                columns: new[] { "BirthDate", "CitizenCardBackImageUrl", "CitizenCardFrontImageUrl" },
                values: new object[] { new DateTime(2023, 5, 25, 7, 13, 7, 713, DateTimeKind.Utc).AddTicks(6051), null, null });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                columns: new[] { "BirthDate", "CitizenCardBackImageUrl", "CitizenCardFrontImageUrl" },
                values: new object[] { new DateTime(2023, 5, 25, 7, 13, 7, 713, DateTimeKind.Utc).AddTicks(6053), null, null });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                columns: new[] { "BirthDate", "CitizenCardBackImageUrl", "CitizenCardFrontImageUrl" },
                values: new object[] { new DateTime(2023, 5, 25, 7, 13, 7, 713, DateTimeKind.Utc).AddTicks(6055), null, null });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                columns: new[] { "BirthDate", "CitizenCardBackImageUrl", "CitizenCardFrontImageUrl" },
                values: new object[] { new DateTime(2023, 5, 25, 7, 13, 7, 713, DateTimeKind.Utc).AddTicks(6056), null, null });

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
    }
}
