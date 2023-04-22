using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class aa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl5",
                table: "Flats",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl6",
                table: "Flats",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl5",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl6",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl5",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "ImageUrl6",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "ImageUrl5",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "ImageUrl6",
                table: "Buildings");

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
    }
}
