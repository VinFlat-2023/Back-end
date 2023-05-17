using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdateRoomType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Renters_Username",
                table: "Renters");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Username",
                table: "Employees");

            migrationBuilder.AddColumn<decimal>(
                name: "ElectricityAttribute",
                table: "RoomTypes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WaterAttribute",
                table: "RoomTypes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Renters",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: 1,
                columns: new[] { "ElectricityAttribute", "WaterAttribute" },
                values: new object[] { 1m, 1m });

            migrationBuilder.UpdateData(
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: 2,
                columns: new[] { "ElectricityAttribute", "WaterAttribute" },
                values: new object[] { 1m, 1m });

            migrationBuilder.UpdateData(
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: 3,
                columns: new[] { "ElectricityAttribute", "WaterAttribute" },
                values: new object[] { 1m, 1m });

            migrationBuilder.UpdateData(
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: 4,
                columns: new[] { "ElectricityAttribute", "WaterAttribute" },
                values: new object[] { 1m, 1m });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ElectricityAttribute",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "WaterAttribute",
                table: "RoomTypes");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Renters",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
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
                values: new object[] { new DateTime(2023, 4, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9845), new DateTime(2023, 5, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9851), new DateTime(2023, 4, 19, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 15, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9854), new DateTime(2023, 5, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9856), new DateTime(2023, 4, 17, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9855) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 15, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9859), new DateTime(2023, 5, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9862), new DateTime(2023, 4, 17, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9859) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 15, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9865), new DateTime(2023, 5, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9877), new DateTime(2023, 4, 17, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9866) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 15, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9880), new DateTime(2023, 5, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9885), new DateTime(2023, 4, 17, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9884) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 15, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9887), new DateTime(2023, 5, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9889), new DateTime(2023, 4, 17, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9887) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9764));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9766));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9768), new DateTime(2023, 6, 13, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9768) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9772), new DateTime(2023, 2, 11, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9774), new DateTime(2023, 2, 9, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9776) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9778), new DateTime(2023, 3, 3, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9779), new DateTime(2023, 3, 1, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9780) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9781), new DateTime(2023, 5, 2, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9782), new DateTime(2023, 4, 30, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9782) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9786), new DateTime(2023, 4, 2, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9788), new DateTime(2023, 3, 31, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9789) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(8373));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(8383));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(8385));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(8387));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(8389));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(8391));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(8394));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9168));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9171));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9173));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9174));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9175));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9176));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9177));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 14, 15, 9, 55, 249, DateTimeKind.Utc).AddTicks(9178), new DateTime(2023, 5, 7, 22, 9, 55, 249, DateTimeKind.Local).AddTicks(9181) });

            migrationBuilder.CreateIndex(
                name: "IX_Renters_Username",
                table: "Renters",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Username",
                table: "Employees",
                column: "Username",
                unique: true);
        }
    }
}
