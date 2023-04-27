using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdateName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomName",
                table: "Rooms",
                newName: "RoomSignName");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Employees",
                newName: "EmployeeImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "RoomName",
                table: "RoomFlat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 27, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1433), new DateTime(2023, 4, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1435), new DateTime(2023, 4, 1, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1435) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 28, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1439), new DateTime(2023, 4, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1439), new DateTime(2023, 3, 30, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1439) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 28, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1441), new DateTime(2023, 4, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1442), new DateTime(2023, 3, 30, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1442) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 28, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1445), new DateTime(2023, 4, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1457), new DateTime(2023, 3, 30, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1445) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 28, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1459), new DateTime(2023, 4, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1462), new DateTime(2023, 3, 30, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1462) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 28, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1484), new DateTime(2023, 4, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1486), new DateTime(2023, 3, 30, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1485) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1385));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1387));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 4, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1388), new DateTime(2023, 5, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1389) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2022, 12, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1391), new DateTime(2023, 1, 24, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1393), new DateTime(2023, 1, 22, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1393) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1395), new DateTime(2023, 2, 13, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1395), new DateTime(2023, 2, 11, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1396) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1397), new DateTime(2023, 4, 14, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1398), new DateTime(2023, 4, 12, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1398) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1400), new DateTime(2023, 3, 15, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1400), new DateTime(2023, 3, 13, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1401) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 4, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(912));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 4, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(919));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 4, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(923));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 4, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(925));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 4, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(927));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 4, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(929));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 4, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(931));

            migrationBuilder.UpdateData(
                table: "RoomFlat",
                keyColumn: "RoomFlatId",
                keyValue: 1,
                column: "RoomName",
                value: "VF-02");

            migrationBuilder.UpdateData(
                table: "RoomFlat",
                keyColumn: "RoomFlatId",
                keyValue: 2,
                column: "RoomName",
                value: "VLA-203");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 4, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1238));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 4, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1239));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 4, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1240));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 4, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1241));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 4, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1242));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 4, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1243));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 4, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1244));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 4, 26, 6, 34, 7, 196, DateTimeKind.Utc).AddTicks(1245), new DateTime(2023, 4, 19, 13, 34, 7, 196, DateTimeKind.Local).AddTicks(1248) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomName",
                table: "RoomFlat");

            migrationBuilder.RenameColumn(
                name: "RoomSignName",
                table: "Rooms",
                newName: "RoomName");

            migrationBuilder.RenameColumn(
                name: "EmployeeImageUrl",
                table: "Employees",
                newName: "ImageUrl");

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
    }
}
