using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddRoomFlat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Contracts",
                newName: "RoomFlatId");

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 26, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4377), new DateTime(2023, 4, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4379), new DateTime(2023, 3, 31, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4379) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 27, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4383), new DateTime(2023, 4, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4384), new DateTime(2023, 3, 29, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4384) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 27, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4386), new DateTime(2023, 4, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4387), new DateTime(2023, 3, 29, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4386) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 27, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4388), new DateTime(2023, 4, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4389), new DateTime(2023, 3, 29, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4389) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 27, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4391), new DateTime(2023, 4, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4403), new DateTime(2023, 3, 29, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4391) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 27, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4405), new DateTime(2023, 4, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4408), new DateTime(2023, 3, 29, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4408) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4301));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4302));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 4, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4303), new DateTime(2023, 5, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4304) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2022, 12, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4306), new DateTime(2023, 1, 23, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4308), new DateTime(2023, 1, 21, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4308) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4309), new DateTime(2023, 2, 12, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4310), new DateTime(2023, 2, 10, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4311) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4312), new DateTime(2023, 4, 13, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4312), new DateTime(2023, 4, 11, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4313) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4314), new DateTime(2023, 3, 14, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4315), new DateTime(2023, 3, 12, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4315) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 4, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(3814));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 4, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(3819));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 4, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(3821));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 4, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(3822));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 4, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(3823));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 4, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(3825));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 4, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(3826));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 4, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4156));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 4, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4158));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 4, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4181));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 4, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4182));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 4, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4182));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 4, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4183));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 4, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4184));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 4, 25, 8, 4, 28, 873, DateTimeKind.Utc).AddTicks(4185), new DateTime(2023, 4, 18, 15, 4, 28, 873, DateTimeKind.Local).AddTicks(4188) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomFlatId",
                table: "Contracts",
                newName: "RoomId");

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
                column: "CreateDate",
                value: new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1635));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1637));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1638));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1640));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1640));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1641));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1642));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 4, 24, 15, 35, 13, 531, DateTimeKind.Utc).AddTicks(1643), new DateTime(2023, 4, 17, 22, 35, 13, 531, DateTimeKind.Local).AddTicks(1645) });
        }
    }
}
