using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AAAAA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CancelledReason",
                table: "Tickets",
                type: "nvarchar(max)",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancelledReason",
                table: "Tickets");

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8903), new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8906), new DateTime(2023, 4, 7, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8906) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 3, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8911), new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8912), new DateTime(2023, 4, 5, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8911) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 3, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8913), new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8914), new DateTime(2023, 4, 5, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8914) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 3, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8916), new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8916), new DateTime(2023, 4, 5, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8916) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 3, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8918), new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8926), new DateTime(2023, 4, 5, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8918) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 3, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8927), new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8930), new DateTime(2023, 4, 5, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8930) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8819));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8821));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8822), new DateTime(2023, 6, 1, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8822) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8824), new DateTime(2023, 1, 30, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8826), new DateTime(2023, 1, 28, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8826) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8827), new DateTime(2023, 2, 19, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8828), new DateTime(2023, 2, 17, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8828) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8830), new DateTime(2023, 4, 20, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8830), new DateTime(2023, 4, 18, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8830) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8832), new DateTime(2023, 3, 21, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8832), new DateTime(2023, 3, 19, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8832) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8369));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8373));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8398));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8399));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8400));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8401));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8403));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8698));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8700));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8701));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8702));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8703));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8704));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8705));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8705), new DateTime(2023, 4, 25, 16, 45, 8, 441, DateTimeKind.Local).AddTicks(8708) });
        }
    }
}
