using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdateTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TicketName",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 25, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1858), new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1861), new DateTime(2023, 3, 30, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1860) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 26, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1864), new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1865), new DateTime(2023, 3, 28, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1864) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 26, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1867), new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1868), new DateTime(2023, 3, 28, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1867) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 26, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1870), new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1871), new DateTime(2023, 3, 28, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1871) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 26, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1873), new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1874), new DateTime(2023, 3, 28, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1873) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 26, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1876), new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1878), new DateTime(2023, 3, 28, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1877) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1767));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1770));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1771), new DateTime(2023, 5, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1771) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1773), new DateTime(2023, 1, 22, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1776), new DateTime(2023, 1, 20, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1776) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1778), new DateTime(2023, 2, 11, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1779), new DateTime(2023, 2, 9, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1779) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1780), new DateTime(2023, 4, 12, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1781), new DateTime(2023, 4, 10, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1781) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1782), new DateTime(2023, 3, 13, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1783), new DateTime(2023, 3, 11, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1783) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1306));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1310));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1311));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1313));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1340));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1342));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1346));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                columns: new[] { "CreateDate", "TicketName" },
                values: new object[] { new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1635), "Ticket của renter 3 sự cố 1" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                columns: new[] { "CreateDate", "TicketName" },
                values: new object[] { new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1637), "Ticket của renter 3 sự cố 2" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                columns: new[] { "CreateDate", "Status", "TicketName" },
                values: new object[] { new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1638), "Confirming", "Ticket của renter 3 sự cố 3" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                columns: new[] { "CreateDate", "Status", "TicketName" },
                values: new object[] { new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1640), "Solved", "Ticket của renter 3 sự cố 4" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "ContractId", "CreateDate", "Description", "EmployeeId", "ImageUrl1", "ImageUrl2", "ImageUrl3", "SolveDate", "Status", "TicketName", "TicketTypeId", "TotalAmount" },
                values: new object[,]
                {
                    { 5, 3, new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1640), "Sự cố 1", 2, null, null, null, null, "Active", "Ticket của renter 3 sự cố 5", 1, null },
                    { 6, 3, new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1641), "Sự cố 2", 2, null, null, null, null, "Processing", "Ticket của renter 3 sự cố 6", 2, null },
                    { 7, 3, new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1642), "Sự cố 3", 2, null, null, null, null, "Confirming", "Ticket 7 test", 3, null },
                    { 8, 3, new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1643), "Sự cố 4", 2, null, null, null, new DateTime(2023, 4, 17, 22, 35, 13, 531, DateTimeKind.Local).AddTicks(1645), "Solved", "Ticket 8 esting", 1, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "TicketName",
                table: "Tickets");

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 25, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9241), new DateTime(2023, 4, 24, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9248), new DateTime(2023, 3, 30, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9247) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 26, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9251), new DateTime(2023, 4, 24, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9252), new DateTime(2023, 3, 28, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9251) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 26, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9254), new DateTime(2023, 4, 24, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9255), new DateTime(2023, 3, 28, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9254) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 26, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9280), new DateTime(2023, 4, 24, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9281), new DateTime(2023, 3, 28, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9281) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 26, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9283), new DateTime(2023, 4, 24, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9284), new DateTime(2023, 3, 28, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9284) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 26, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9286), new DateTime(2023, 4, 24, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9287), new DateTime(2023, 3, 28, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9286) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 24, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9189));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 24, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9191));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 4, 24, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9193), new DateTime(2023, 5, 24, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9193) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2022, 12, 24, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9198), new DateTime(2023, 1, 22, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9201), new DateTime(2023, 1, 20, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9201) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 24, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9202), new DateTime(2023, 2, 11, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9203), new DateTime(2023, 2, 9, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9203) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 24, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9205), new DateTime(2023, 4, 12, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9205), new DateTime(2023, 4, 10, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9206) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 24, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9207), new DateTime(2023, 3, 13, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9208), new DateTime(2023, 3, 11, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9208) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 4, 24, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(8786));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 4, 24, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(8791));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 4, 24, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(8794));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 4, 24, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(8796));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 4, 24, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(8797));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 4, 24, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(8799));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 4, 24, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(8800));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 4, 24, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9087));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 4, 24, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9090));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                columns: new[] { "CreateDate", "Status" },
                values: new object[] { new DateTime(2023, 4, 24, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9091), "Completed" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                columns: new[] { "CreateDate", "Status" },
                values: new object[] { new DateTime(2023, 4, 24, 14, 48, 26, 162, DateTimeKind.Utc).AddTicks(9091), "Active" });
        }
    }
}
