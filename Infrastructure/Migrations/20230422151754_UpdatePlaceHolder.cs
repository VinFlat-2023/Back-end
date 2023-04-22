using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdatePlaceHolder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "PlaceholderForFee");

            migrationBuilder.AddColumn<int>(
                name: "ContractServiceId",
                table: "PlaceholderForFee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "PlaceholderForFee",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 23, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9950), new DateTime(2023, 4, 22, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9959), new DateTime(2023, 3, 28, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9958) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 24, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9981), new DateTime(2023, 4, 22, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9983), new DateTime(2023, 3, 26, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9982) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 24, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9984), new DateTime(2023, 4, 22, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9985), new DateTime(2023, 3, 26, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9985) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 24, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9987), new DateTime(2023, 4, 22, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9988), new DateTime(2023, 3, 26, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9987) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 24, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9989), new DateTime(2023, 4, 22, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9990), new DateTime(2023, 3, 26, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9990) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 24, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9991), new DateTime(2023, 4, 22, 15, 17, 53, 348, DateTimeKind.Utc).AddTicks(5), new DateTime(2023, 3, 26, 15, 17, 53, 348, DateTimeKind.Utc).AddTicks(5) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 22, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9913));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 22, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9915));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 22, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9916));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 22, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9917));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 22, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9918));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 22, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9919));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 22, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9920));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 4, 22, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9489));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 4, 22, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9493));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 4, 22, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9495));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 4, 22, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9496));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 4, 22, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9498));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 4, 22, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9499));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 4, 22, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9501));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 4, 22, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9809));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 4, 22, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9811));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 4, 22, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9812));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 4, 22, 15, 17, 53, 347, DateTimeKind.Utc).AddTicks(9813));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractServiceId",
                table: "PlaceholderForFee");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "PlaceholderForFee");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "PlaceholderForFee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 23, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6727), new DateTime(2023, 4, 22, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6738), new DateTime(2023, 3, 28, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6737) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 24, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6741), new DateTime(2023, 4, 22, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6742), new DateTime(2023, 3, 26, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6741) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 24, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6743), new DateTime(2023, 4, 22, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6744), new DateTime(2023, 3, 26, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6743) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 24, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6745), new DateTime(2023, 4, 22, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6746), new DateTime(2023, 3, 26, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6746) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 24, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6748), new DateTime(2023, 4, 22, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6749), new DateTime(2023, 3, 26, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6748) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 24, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6750), new DateTime(2023, 4, 22, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6751), new DateTime(2023, 3, 26, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6750) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 22, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6654));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 22, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6656));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 22, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6657));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 22, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6658));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 22, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6659));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 22, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6660));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 22, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6661));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 4, 22, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6150));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 4, 22, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6155));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 4, 22, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6157));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 4, 22, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6158));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 4, 22, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6160));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 4, 22, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6161));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 4, 22, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6162));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 4, 22, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6569));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 4, 22, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6571));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 4, 22, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6572));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 4, 22, 6, 6, 19, 332, DateTimeKind.Utc).AddTicks(6573));
        }
    }
}
