using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddedNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlaceholderForFeeId",
                table: "InvoiceDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WildcardIdForFee",
                table: "InvoiceDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlaceholderForFee",
                columns: table => new
                {
                    PlaceholderForFeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceholderForFee", x => x.PlaceholderForFeeId);
                });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 17, 17, 58, 54, 372, DateTimeKind.Utc).AddTicks(5530), new DateTime(2023, 3, 19, 17, 58, 54, 372, DateTimeKind.Utc).AddTicks(5540), new DateTime(2023, 2, 22, 17, 58, 54, 372, DateTimeKind.Utc).AddTicks(5539) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 18, 17, 58, 54, 372, DateTimeKind.Utc).AddTicks(5542), new DateTime(2023, 3, 19, 17, 58, 54, 372, DateTimeKind.Utc).AddTicks(5543), new DateTime(2023, 2, 20, 17, 58, 54, 372, DateTimeKind.Utc).AddTicks(5542) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 18, 17, 58, 54, 372, DateTimeKind.Utc).AddTicks(5544), new DateTime(2023, 3, 19, 17, 58, 54, 372, DateTimeKind.Utc).AddTicks(5545), new DateTime(2023, 2, 20, 17, 58, 54, 372, DateTimeKind.Utc).AddTicks(5545) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 3, 19, 17, 58, 54, 372, DateTimeKind.Utc).AddTicks(5428));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 3, 19, 17, 58, 54, 372, DateTimeKind.Utc).AddTicks(5430));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2023, 3, 19, 17, 58, 54, 372, DateTimeKind.Utc).AddTicks(5431));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2023, 3, 19, 17, 58, 54, 372, DateTimeKind.Utc).AddTicks(5432));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2023, 3, 19, 17, 58, 54, 372, DateTimeKind.Utc).AddTicks(5433));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2023, 3, 19, 17, 58, 54, 372, DateTimeKind.Utc).AddTicks(5434));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                column: "CreatedTime",
                value: new DateTime(2023, 3, 19, 17, 58, 54, 372, DateTimeKind.Utc).AddTicks(5436));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 3, 19, 17, 58, 54, 372, DateTimeKind.Utc).AddTicks(5063));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 3, 19, 17, 58, 54, 372, DateTimeKind.Utc).AddTicks(5069));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 3, 19, 17, 58, 54, 372, DateTimeKind.Utc).AddTicks(5071));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 3, 19, 17, 58, 54, 372, DateTimeKind.Utc).AddTicks(5074));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 3, 19, 17, 58, 54, 372, DateTimeKind.Utc).AddTicks(5078));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 3, 19, 17, 58, 54, 372, DateTimeKind.Utc).AddTicks(5080));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 3, 19, 17, 58, 54, 372, DateTimeKind.Utc).AddTicks(5081));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 17, 58, 54, 372, DateTimeKind.Utc).AddTicks(5345));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 17, 58, 54, 372, DateTimeKind.Utc).AddTicks(5346));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 17, 58, 54, 372, DateTimeKind.Utc).AddTicks(5347));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 3, 19, 17, 58, 54, 372, DateTimeKind.Utc).AddTicks(5348));

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_PlaceholderForFeeId",
                table: "InvoiceDetails",
                column: "PlaceholderForFeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_PlaceholderForFee_PlaceholderForFeeId",
                table: "InvoiceDetails",
                column: "PlaceholderForFeeId",
                principalTable: "PlaceholderForFee",
                principalColumn: "PlaceholderForFeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_PlaceholderForFee_PlaceholderForFeeId",
                table: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "PlaceholderForFee");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetails_PlaceholderForFeeId",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "PlaceholderForFeeId",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "WildcardIdForFee",
                table: "InvoiceDetails");

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 16, 10, 28, 15, 160, DateTimeKind.Utc).AddTicks(823), new DateTime(2023, 3, 18, 10, 28, 15, 160, DateTimeKind.Utc).AddTicks(829), new DateTime(2023, 2, 21, 10, 28, 15, 160, DateTimeKind.Utc).AddTicks(829) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 17, 10, 28, 15, 160, DateTimeKind.Utc).AddTicks(832), new DateTime(2023, 3, 18, 10, 28, 15, 160, DateTimeKind.Utc).AddTicks(833), new DateTime(2023, 2, 19, 10, 28, 15, 160, DateTimeKind.Utc).AddTicks(833) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 17, 10, 28, 15, 160, DateTimeKind.Utc).AddTicks(834), new DateTime(2023, 3, 18, 10, 28, 15, 160, DateTimeKind.Utc).AddTicks(835), new DateTime(2023, 2, 19, 10, 28, 15, 160, DateTimeKind.Utc).AddTicks(835) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 3, 18, 10, 28, 15, 160, DateTimeKind.Utc).AddTicks(786));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 3, 18, 10, 28, 15, 160, DateTimeKind.Utc).AddTicks(787));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2023, 3, 18, 10, 28, 15, 160, DateTimeKind.Utc).AddTicks(788));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2023, 3, 18, 10, 28, 15, 160, DateTimeKind.Utc).AddTicks(789));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2023, 3, 18, 10, 28, 15, 160, DateTimeKind.Utc).AddTicks(790));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2023, 3, 18, 10, 28, 15, 160, DateTimeKind.Utc).AddTicks(791));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                column: "CreatedTime",
                value: new DateTime(2023, 3, 18, 10, 28, 15, 160, DateTimeKind.Utc).AddTicks(792));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 3, 18, 10, 28, 15, 160, DateTimeKind.Utc).AddTicks(470));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 3, 18, 10, 28, 15, 160, DateTimeKind.Utc).AddTicks(475));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 3, 18, 10, 28, 15, 160, DateTimeKind.Utc).AddTicks(477));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 3, 18, 10, 28, 15, 160, DateTimeKind.Utc).AddTicks(479));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 3, 18, 10, 28, 15, 160, DateTimeKind.Utc).AddTicks(480));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 3, 18, 10, 28, 15, 160, DateTimeKind.Utc).AddTicks(482));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 3, 18, 10, 28, 15, 160, DateTimeKind.Utc).AddTicks(484));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 3, 18, 10, 28, 15, 160, DateTimeKind.Utc).AddTicks(688));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 3, 18, 10, 28, 15, 160, DateTimeKind.Utc).AddTicks(690));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 3, 18, 10, 28, 15, 160, DateTimeKind.Utc).AddTicks(691));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 3, 18, 10, 28, 15, 160, DateTimeKind.Utc).AddTicks(691));
        }
    }
}
