using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdateInvoiceStatusToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Employees_EmployeeId",
                table: "Buildings");

            migrationBuilder.AlterColumn<decimal>(
                name: "WaterMeterBefore",
                table: "MetricHistories",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "WaterMeterAfter",
                table: "MetricHistories",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RecordedDate",
                table: "MetricHistories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ElectricityMeterBefore",
                table: "MetricHistories",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ElectricityMeterAfter",
                table: "MetricHistories",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Buildings",
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
                values: new object[] { new DateTime(2023, 5, 2, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5660), new DateTime(2023, 6, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5662), new DateTime(2023, 5, 7, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5661) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 5, 3, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5670), new DateTime(2023, 6, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5670), new DateTime(2023, 5, 5, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5670) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 5, 3, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5693), new DateTime(2023, 6, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5694), new DateTime(2023, 5, 5, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5694) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 5, 3, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5696), new DateTime(2023, 6, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5697), new DateTime(2023, 5, 5, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5697) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 5, 3, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5699), new DateTime(2023, 6, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5699), new DateTime(2023, 5, 5, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5699) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 5, 3, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5701), new DateTime(2023, 6, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5701), new DateTime(2023, 5, 5, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5701) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                columns: new[] { "CreatedTime", "DueDate", "Status" },
                values: new object[] { new DateTime(2023, 6, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5605), new DateTime(2023, 7, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5605), "Paid" });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                columns: new[] { "CreatedTime", "DueDate", "Status" },
                values: new object[] { new DateTime(2023, 6, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5610), new DateTime(2023, 7, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5610), "PaidButOverdue" });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate", "Status" },
                values: new object[] { new DateTime(2023, 6, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5612), new DateTime(2023, 7, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5612), "Overdue" });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime", "Status" },
                values: new object[] { new DateTime(2023, 2, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5614), new DateTime(2023, 3, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5616), new DateTime(2023, 2, 27, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5616), "Paid" });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime", "Status" },
                values: new object[] { new DateTime(2023, 3, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5618), new DateTime(2023, 3, 21, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5619), new DateTime(2023, 3, 19, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5619), "PaidButOverdue" });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime", "Status" },
                values: new object[] { new DateTime(2023, 5, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5621), new DateTime(2023, 5, 20, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5621), new DateTime(2023, 5, 18, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5622), "PaidButOverdue" });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime", "Status" },
                values: new object[] { new DateTime(2023, 4, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5623), new DateTime(2023, 4, 20, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5624), new DateTime(2023, 4, 18, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5624), "Paid" });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 6, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(4909));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 6, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(4913));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 6, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(4915));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 6, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(4916));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 6, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(4917));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 6, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(4919));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 6, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(4920));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 6, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5396));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 6, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5398));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 6, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5399));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 6, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5400));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 6, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5401));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 6, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5403));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 6, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5405));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 6, 1, 17, 9, 38, 772, DateTimeKind.Utc).AddTicks(5406), new DateTime(2023, 5, 26, 0, 9, 38, 772, DateTimeKind.Local).AddTicks(5409) });

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Employees_EmployeeId",
                table: "Buildings",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Employees_EmployeeId",
                table: "Buildings");

            migrationBuilder.AlterColumn<int>(
                name: "WaterMeterBefore",
                table: "MetricHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "WaterMeterAfter",
                table: "MetricHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RecordedDate",
                table: "MetricHistories",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ElectricityMeterBefore",
                table: "MetricHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "ElectricityMeterAfter",
                table: "MetricHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Invoices",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Invoices",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Buildings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8158), new DateTime(2023, 5, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8161), new DateTime(2023, 5, 2, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8160) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 28, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8164), new DateTime(2023, 5, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8166), new DateTime(2023, 4, 30, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8165) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 28, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8168), new DateTime(2023, 5, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8169), new DateTime(2023, 4, 30, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8168) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 28, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8172), new DateTime(2023, 5, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8172), new DateTime(2023, 4, 30, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8172) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 28, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8174), new DateTime(2023, 5, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8182), new DateTime(2023, 4, 30, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8174) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 28, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8184), new DateTime(2023, 5, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8186), new DateTime(2023, 4, 30, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8186) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                columns: new[] { "CreatedTime", "DueDate", "Status" },
                values: new object[] { new DateTime(2023, 5, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8059), new DateTime(2023, 6, 26, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8059), true });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                columns: new[] { "CreatedTime", "DueDate", "Status" },
                values: new object[] { new DateTime(2023, 5, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8062), new DateTime(2023, 6, 26, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8062), true });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate", "Status" },
                values: new object[] { new DateTime(2023, 5, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8064), new DateTime(2023, 6, 26, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8064), false });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime", "Status" },
                values: new object[] { new DateTime(2023, 1, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8066), new DateTime(2023, 2, 24, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8068), new DateTime(2023, 2, 22, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8068), true });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime", "Status" },
                values: new object[] { new DateTime(2023, 2, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8070), new DateTime(2023, 3, 16, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8070), new DateTime(2023, 3, 14, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8071), true });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime", "Status" },
                values: new object[] { new DateTime(2023, 4, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8073), new DateTime(2023, 5, 15, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8073), new DateTime(2023, 5, 13, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8074), true });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime", "Status" },
                values: new object[] { new DateTime(2023, 3, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8075), new DateTime(2023, 4, 15, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8081), new DateTime(2023, 4, 13, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(8081), true });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(7405));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(7408));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(7410));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(7411));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(7413));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(7414));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(7415));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(7921));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(7923));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(7924));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(7925));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(7926));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(7927));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(7927));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 27, 10, 19, 27, 954, DateTimeKind.Utc).AddTicks(7928), new DateTime(2023, 5, 20, 17, 19, 27, 954, DateTimeKind.Local).AddTicks(7932) });

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Employees_EmployeeId",
                table: "Buildings",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }
    }
}
