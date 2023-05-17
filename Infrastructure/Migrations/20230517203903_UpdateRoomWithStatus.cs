using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdateRoomWithStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2848), new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2854), new DateTime(2023, 4, 22, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2852) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 18, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2860), new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2862), new DateTime(2023, 4, 20, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2860) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 18, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2864), new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2866), new DateTime(2023, 4, 20, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2865) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 18, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2869), new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2870), new DateTime(2023, 4, 20, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2870) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 18, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2876), new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2893), new DateTime(2023, 4, 20, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2877) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 18, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2896), new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2903), new DateTime(2023, 4, 20, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2902) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2664));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2671), new DateTime(2023, 6, 16, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2672) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2676), new DateTime(2023, 2, 14, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2680), new DateTime(2023, 2, 12, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2681) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2686), new DateTime(2023, 3, 6, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2688), new DateTime(2023, 3, 4, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2690) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2698), new DateTime(2023, 5, 5, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2699), new DateTime(2023, 5, 3, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2700) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2751), new DateTime(2023, 4, 5, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2753), new DateTime(2023, 4, 3, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2754) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(1619));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(1627));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(1680));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(1682));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(1684));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(1686));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(1689));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1,
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2,
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2363));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2367));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2369));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2372));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2376));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2377));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2379));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 17, 20, 39, 1, 399, DateTimeKind.Utc).AddTicks(2382), new DateTime(2023, 5, 11, 3, 39, 1, 399, DateTimeKind.Local).AddTicks(2387) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Rooms");

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3804), new DateTime(2023, 5, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3806), new DateTime(2023, 4, 22, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3806) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 18, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3809), new DateTime(2023, 5, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3810), new DateTime(2023, 4, 20, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3810) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 18, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3812), new DateTime(2023, 5, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3813), new DateTime(2023, 4, 20, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3812) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 18, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3814), new DateTime(2023, 5, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3815), new DateTime(2023, 4, 20, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3815) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 18, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3817), new DateTime(2023, 5, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3825), new DateTime(2023, 4, 20, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3817) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 18, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3826), new DateTime(2023, 5, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3830), new DateTime(2023, 4, 20, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3829) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3727));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3729));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3730), new DateTime(2023, 6, 16, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3731) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3733), new DateTime(2023, 2, 14, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3734), new DateTime(2023, 2, 12, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3735) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3736), new DateTime(2023, 3, 6, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3736), new DateTime(2023, 3, 4, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3737) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3739), new DateTime(2023, 5, 5, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3739), new DateTime(2023, 5, 3, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3739) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3741), new DateTime(2023, 4, 5, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3741), new DateTime(2023, 4, 3, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3742) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3232));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3236));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3237));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3238));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3240));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3241));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3242));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3564));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3566));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3567));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3568));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3597));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3598));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3599));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 17, 8, 42, 7, 575, DateTimeKind.Utc).AddTicks(3600), new DateTime(2023, 5, 10, 15, 42, 7, 575, DateTimeKind.Local).AddTicks(3603) });
        }
    }
}
