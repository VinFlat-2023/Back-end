using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class RemoveWalletFeedBackAndRoomDesc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9428), new DateTime(2023, 5, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9431), new DateTime(2023, 4, 28, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9430) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 24, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9434), new DateTime(2023, 5, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9435), new DateTime(2023, 4, 26, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9434) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 24, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9436), new DateTime(2023, 5, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9437), new DateTime(2023, 4, 26, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9436) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 24, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9438), new DateTime(2023, 5, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9439), new DateTime(2023, 4, 26, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9439) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 24, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9442), new DateTime(2023, 5, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9443), new DateTime(2023, 4, 26, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9442) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 24, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9444), new DateTime(2023, 5, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9445), new DateTime(2023, 4, 26, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9445) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9363));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9364));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9365), new DateTime(2023, 6, 22, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9366) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9368), new DateTime(2023, 2, 20, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9370), new DateTime(2023, 2, 18, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9370) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9371), new DateTime(2023, 3, 12, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9372), new DateTime(2023, 3, 10, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9372) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9373), new DateTime(2023, 5, 11, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9374), new DateTime(2023, 5, 9, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9374) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9375), new DateTime(2023, 4, 11, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9376), new DateTime(2023, 4, 9, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9376) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(8931));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(8934));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(8935));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(8936));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(8938));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(8939));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(8940));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9207));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9208));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9209));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9210));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9233));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9235));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9236));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 23, 8, 48, 29, 620, DateTimeKind.Utc).AddTicks(9237), new DateTime(2023, 5, 16, 15, 48, 29, 620, DateTimeKind.Local).AddTicks(9246) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6383), new DateTime(2023, 5, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6385), new DateTime(2023, 4, 28, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6385) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 24, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6390), new DateTime(2023, 5, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6391), new DateTime(2023, 4, 26, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6390) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 24, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6394), new DateTime(2023, 5, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6395), new DateTime(2023, 4, 26, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6394) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 24, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6397), new DateTime(2023, 5, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6399), new DateTime(2023, 4, 26, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6398) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 24, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6401), new DateTime(2023, 5, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6402), new DateTime(2023, 4, 26, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6402) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 24, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6404), new DateTime(2023, 5, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6406), new DateTime(2023, 4, 26, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6405) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6287));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6289));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6319), new DateTime(2023, 6, 22, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6319) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6323), new DateTime(2023, 2, 20, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6325), new DateTime(2023, 2, 18, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6325) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6327), new DateTime(2023, 3, 12, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6328), new DateTime(2023, 3, 10, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6328) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6331), new DateTime(2023, 5, 11, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6331), new DateTime(2023, 5, 9, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6332) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6334), new DateTime(2023, 4, 11, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6334), new DateTime(2023, 4, 9, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6335) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(5678));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(5683));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(5685));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(5687));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(5689));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(5690));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(5692));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6129));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6132));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6134));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6136));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6137));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6138));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6139));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 23, 8, 44, 5, 937, DateTimeKind.Utc).AddTicks(6140), new DateTime(2023, 5, 16, 15, 44, 5, 937, DateTimeKind.Local).AddTicks(6148) });
        }
    }
}
