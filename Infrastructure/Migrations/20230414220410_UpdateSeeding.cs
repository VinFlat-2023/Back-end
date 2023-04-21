using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdateSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Renters_Email",
                table: "Renters");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Email",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Renters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContractId",
                table: "Invoices",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "SupervisorBuildingId",
                table: "Employees",
                type: "int",
                nullable: true);

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
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "SupervisorBuildingId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                column: "SupervisorBuildingId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3,
                columns: new[] { "FullName", "SupervisorBuildingId", "Username" },
                values: new object[] { "Khôi Huy", 3, "sup3" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4,
                column: "SupervisorBuildingId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5,
                column: "SupervisorBuildingId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 6,
                column: "SupervisorBuildingId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 8,
                column: "SupervisorBuildingId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 9,
                column: "SupervisorBuildingId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 10,
                column: "SupervisorBuildingId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 11,
                column: "SupervisorBuildingId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 12,
                column: "SupervisorBuildingId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 13,
                column: "SupervisorBuildingId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 14,
                column: "SupervisorBuildingId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 15,
                column: "SupervisorBuildingId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 16,
                column: "SupervisorBuildingId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 17,
                column: "SupervisorBuildingId",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 18,
                column: "SupervisorBuildingId",
                value: 17);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 19,
                column: "SupervisorBuildingId",
                value: 18);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 20,
                column: "SupervisorBuildingId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 21,
                column: "SupervisorBuildingId",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 22,
                column: "SupervisorBuildingId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 23,
                column: "SupervisorBuildingId",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 24,
                column: "SupervisorBuildingId",
                value: 23);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 25,
                column: "SupervisorBuildingId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 26,
                column: "SupervisorBuildingId",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 27,
                column: "SupervisorBuildingId",
                value: 26);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 28,
                column: "SupervisorBuildingId",
                value: 27);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 29,
                column: "SupervisorBuildingId",
                value: 28);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 30,
                column: "SupervisorBuildingId",
                value: 29);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 31,
                column: "SupervisorBuildingId",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 32,
                column: "SupervisorBuildingId",
                value: 31);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Invoices")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "InvoicesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null);

            migrationBuilder.DropColumn(
                name: "SupervisorBuildingId",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Renters",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 14, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(814), new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(820), new DateTime(2023, 3, 19, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(820) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 15, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(823), new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(824), new DateTime(2023, 3, 17, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(823) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 15, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(825), new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(826), new DateTime(2023, 3, 17, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(825) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 15, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(831), new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(832), new DateTime(2023, 3, 17, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(831) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 15, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(833), new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(834), new DateTime(2023, 3, 17, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(833) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 15, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(835), new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(836), new DateTime(2023, 3, 17, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(835) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3,
                columns: new[] { "FullName", "Username" },
                values: new object[] { "sup3", "Khôi Huy" });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(755));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(757));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(758));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(759));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(760));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(760));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                column: "CreatedTime",
                value: new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(761));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(321));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(325));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(327));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(328));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(329));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(330));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(332));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(690));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(691));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(692));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 4, 13, 12, 1, 38, 848, DateTimeKind.Utc).AddTicks(693));

            migrationBuilder.CreateIndex(
                name: "IX_Renters_Email",
                table: "Renters",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                table: "Employees",
                column: "Email",
                unique: true);
        }
    }
}
