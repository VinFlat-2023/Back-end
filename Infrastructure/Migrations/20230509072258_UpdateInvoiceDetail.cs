using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdateInvoiceDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "InvoiceDetails",
                newName: "Price");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Services",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3724), new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3726), new DateTime(2023, 4, 14, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3726) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 10, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3730), new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3730), new DateTime(2023, 4, 12, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3730) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 10, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3732), new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3733), new DateTime(2023, 4, 12, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3732) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 10, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3735), new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3735), new DateTime(2023, 4, 12, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3735) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 10, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3737), new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3748), new DateTime(2023, 4, 12, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3737) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 10, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3750), new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3753), new DateTime(2023, 4, 12, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3752) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3657));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3659));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3660), new DateTime(2023, 6, 8, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3660) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3663), new DateTime(2023, 2, 6, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3664), new DateTime(2023, 2, 4, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3664) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3666), new DateTime(2023, 2, 26, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3666), new DateTime(2023, 2, 24, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3667) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3668), new DateTime(2023, 4, 27, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3669), new DateTime(2023, 4, 25, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3669) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3670), new DateTime(2023, 3, 28, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3670), new DateTime(2023, 3, 26, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3671) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3191));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3195));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3196));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3197));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3198));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3199));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3226));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3535));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3536));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3537));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3538));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3539));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3540));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3540));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3541), new DateTime(2023, 5, 2, 14, 22, 57, 49, DateTimeKind.Local).AddTicks(3544) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "InvoiceDetails",
                newName: "Amount");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Services",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5580), new DateTime(2023, 5, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5582), new DateTime(2023, 4, 11, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5581) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 7, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5584), new DateTime(2023, 5, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5585), new DateTime(2023, 4, 9, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5585) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 7, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5587), new DateTime(2023, 5, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5588), new DateTime(2023, 4, 9, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5587) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 7, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5589), new DateTime(2023, 5, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5590), new DateTime(2023, 4, 9, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5590) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 7, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5591), new DateTime(2023, 5, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5601), new DateTime(2023, 4, 9, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5592) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 7, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5602), new DateTime(2023, 5, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5606), new DateTime(2023, 4, 9, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5605) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5535));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5537));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5539), new DateTime(2023, 6, 5, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5539) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5542), new DateTime(2023, 2, 3, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5543), new DateTime(2023, 2, 1, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5544) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5545), new DateTime(2023, 2, 23, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5546), new DateTime(2023, 2, 21, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5546) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5547), new DateTime(2023, 4, 24, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5548), new DateTime(2023, 4, 22, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5548) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5549), new DateTime(2023, 3, 25, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5550), new DateTime(2023, 3, 23, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5550) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5111));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5114));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5116));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5117));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5118));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5119));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5120));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 1,
                column: "Amount",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 2,
                column: "Amount",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 3,
                column: "Amount",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 4,
                column: "Amount",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 5,
                column: "Amount",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 6,
                column: "Amount",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5391));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5393));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5395));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5396));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5396));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5397));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 6, 7, 35, 10, 692, DateTimeKind.Utc).AddTicks(5398), new DateTime(2023, 4, 29, 14, 35, 10, 692, DateTimeKind.Local).AddTicks(5400) });
        }
    }
}
