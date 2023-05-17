using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class RemoveNullableInRoomCap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RoomCapacity",
                table: "FlatTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RoomCapacity",
                table: "FlatTypes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9851), new DateTime(2023, 5, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9853), new DateTime(2023, 4, 21, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9853) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 17, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9856), new DateTime(2023, 5, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9857), new DateTime(2023, 4, 19, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9857) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 17, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9880), new DateTime(2023, 5, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9881), new DateTime(2023, 4, 19, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9880) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 17, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9884), new DateTime(2023, 5, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9885), new DateTime(2023, 4, 19, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9884) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 17, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9886), new DateTime(2023, 5, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9894), new DateTime(2023, 4, 19, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9887) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 17, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9895), new DateTime(2023, 5, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9898), new DateTime(2023, 4, 19, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9897) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9803));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9805));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9806), new DateTime(2023, 6, 15, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9806) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9809), new DateTime(2023, 2, 13, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9811), new DateTime(2023, 2, 11, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9812) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9813), new DateTime(2023, 3, 5, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9814), new DateTime(2023, 3, 3, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9814) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9816), new DateTime(2023, 5, 4, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9816), new DateTime(2023, 5, 2, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9817) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9817), new DateTime(2023, 4, 4, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9818), new DateTime(2023, 4, 2, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9818) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9342));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9345));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9347));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9348));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9349));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9350));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9351));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9649));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9651));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9652));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9653));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9653));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9654));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9655));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 16, 19, 17, 20, 522, DateTimeKind.Utc).AddTicks(9656), new DateTime(2023, 5, 10, 2, 17, 20, 522, DateTimeKind.Local).AddTicks(9659) });
        }
    }
}
