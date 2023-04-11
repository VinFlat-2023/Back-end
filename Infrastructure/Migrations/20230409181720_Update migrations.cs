using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Updatemigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "BuildingId",
                keyValue: 1,
                columns: new[] { "AveragePrice", "BuildingAddress", "ImageUrl" },
                values: new object[] { 2500000m, "Quận 9", "https://vinflat.blob.core.windows.net/building-image/6716250e-8169-446d-a54e-37094c30ae70thumbnail-202303031027054744.jpg" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "BuildingId",
                keyValue: 2,
                columns: new[] { "AveragePrice", "ImageUrl" },
                values: new object[] { 2600000m, "https://vinflat.blob.core.windows.net/building-image/be39f244-45d1-48cc-94dc-7e1b138caa3athumbnail-202302251636284394.jpg" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "BuildingId",
                keyValue: 3,
                columns: new[] { "AveragePrice", "ImageUrl" },
                values: new object[] { 3500000m, "https://vinflat.blob.core.windows.net/building-image/8a8ea225-ea25-422c-a20d-299c7ed42456thumbnail-202302041627581789.jpg" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "BuildingId",
                keyValue: 4,
                columns: new[] { "AveragePrice", "ImageUrl" },
                values: new object[] { 4500000m, "https://vinflat.blob.core.windows.net/building-image/69d0767f-ff29-49dc-88fc-c3bc87cba986thumbnail-202212291740189478.jpg" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "BuildingId",
                keyValue: 5,
                columns: new[] { "AveragePrice", "ImageUrl" },
                values: new object[] { 4600000m, "https://vinflat.blob.core.windows.net/building-image/a3f9897c-800e-4d5e-92b7-e388eefdf64bthumbnail-202212151636139810.jpg" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "BuildingId",
                keyValue: 6,
                columns: new[] { "AveragePrice", "ImageUrl" },
                values: new object[] { 5300000m, "https://vinflat.blob.core.windows.net/building-image/a040d02d-634a-4206-88a5-10fbbc1482f7image7.jpg" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "BuildingId",
                keyValue: 1,
                columns: new[] { "AveragePrice", "BuildingAddress", "ImageUrl" },
                values: new object[] { 0m, "Quajan 9", "" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "BuildingId",
                keyValue: 2,
                columns: new[] { "AveragePrice", "ImageUrl" },
                values: new object[] { 0m, "" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "BuildingId",
                keyValue: 3,
                columns: new[] { "AveragePrice", "ImageUrl" },
                values: new object[] { 0m, "" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "BuildingId",
                keyValue: 4,
                columns: new[] { "AveragePrice", "ImageUrl" },
                values: new object[] { 0m, "" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "BuildingId",
                keyValue: 5,
                columns: new[] { "AveragePrice", "ImageUrl" },
                values: new object[] { 0m, "" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "BuildingId",
                keyValue: 6,
                columns: new[] { "AveragePrice", "ImageUrl" },
                values: new object[] { 0m, "" });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 7, 5, 17, 57, 27, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 4, 17, 57, 27, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 10, 17, 57, 27, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 7, 6, 17, 57, 27, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 4, 17, 57, 27, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 8, 17, 57, 27, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 7, 6, 17, 57, 27, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 4, 17, 57, 27, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 8, 17, 57, 27, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 7, 6, 17, 57, 27, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 4, 17, 57, 27, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 8, 17, 57, 27, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 7, 6, 17, 57, 27, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 4, 17, 57, 27, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 8, 17, 57, 27, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 7, 6, 17, 57, 27, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 4, 17, 57, 27, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 8, 17, 57, 27, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 8, 4, 17, 57, 27, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 8, 4, 17, 57, 27, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2023, 8, 4, 17, 57, 27, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2023, 8, 4, 17, 57, 27, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2023, 8, 4, 17, 57, 27, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2023, 8, 4, 17, 57, 27, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                column: "CreatedTime",
                value: new DateTime(2023, 8, 4, 17, 57, 27, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 8, 4, 17, 57, 27, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 8, 4, 17, 57, 27, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 8, 4, 17, 57, 27, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 8, 4, 17, 57, 27, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 8, 4, 17, 57, 27, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 8, 4, 17, 57, 27, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 8, 4, 17, 57, 27, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 8, 4, 17, 57, 27, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 8, 4, 17, 57, 27, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 8, 4, 17, 57, 27, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 8, 4, 17, 57, 27, 0, DateTimeKind.Unspecified));
        }
    }
}
