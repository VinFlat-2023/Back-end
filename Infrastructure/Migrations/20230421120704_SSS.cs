using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class SSS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 22, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8211), new DateTime(2023, 4, 21, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8220), new DateTime(2023, 3, 27, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8219) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 23, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8222), new DateTime(2023, 4, 21, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8223), new DateTime(2023, 3, 25, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8223) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 23, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8224), new DateTime(2023, 4, 21, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8225), new DateTime(2023, 3, 25, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8225) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 23, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8227), new DateTime(2023, 4, 21, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8227), new DateTime(2023, 3, 25, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8227) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 23, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8229), new DateTime(2023, 4, 21, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8230), new DateTime(2023, 3, 25, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8230) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 23, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8231), new DateTime(2023, 4, 21, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8232), new DateTime(2023, 3, 25, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8232) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 21, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 21, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8146));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 21, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8147));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 21, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8148));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 21, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8149));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 21, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8150));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 21, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8150));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 4, 21, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(7653));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 4, 21, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(7657));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 4, 21, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(7660));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 4, 21, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(7661));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 4, 21, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(7662));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 4, 21, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(7664));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 4, 21, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(7693));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1,
                columns: new[] { "Description", "Status" },
                values: new object[] { "sadasdasd", "Ok" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2,
                columns: new[] { "Description", "Status" },
                values: new object[] { "sadasdasd", "Ok" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3,
                columns: new[] { "Description", "Status" },
                values: new object[] { "sadasdasd", "Ok" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 4,
                columns: new[] { "Description", "Status" },
                values: new object[] { "sadasdasd", "Ok" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 4, 21, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8055));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 4, 21, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8057));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 4, 21, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8058));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 4, 21, 12, 7, 3, 171, DateTimeKind.Utc).AddTicks(8059));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Rooms");

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 15, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2176), new DateTime(2023, 4, 14, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2187), new DateTime(2023, 3, 20, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2186) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 16, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2190), new DateTime(2023, 4, 14, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2191), new DateTime(2023, 3, 18, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2190) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 16, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2192), new DateTime(2023, 4, 14, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2193), new DateTime(2023, 3, 18, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2193) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 16, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2249), new DateTime(2023, 4, 14, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2250), new DateTime(2023, 3, 18, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2249) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 16, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2252), new DateTime(2023, 4, 14, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2253), new DateTime(2023, 3, 18, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2253) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 16, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2254), new DateTime(2023, 4, 14, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2255), new DateTime(2023, 3, 18, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2255) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 14, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2132));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 14, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2135));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 14, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2137));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 14, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2138));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 14, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2139));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 14, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2140));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 14, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2141));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 4, 14, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(1644));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 4, 14, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(1650));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 4, 14, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(1651));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 4, 14, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(1653));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 4, 14, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(1654));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 4, 14, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(1655));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 4, 14, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(1657));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 4, 14, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2021));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 4, 14, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2024));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 4, 14, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2025));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 4, 14, 22, 4, 8, 754, DateTimeKind.Utc).AddTicks(2025));
        }
    }
}
