using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class RemoveNotiTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Employees_EmployeeId",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_FeedbackTypes_FeedbackTypeId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Flats_FlatId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Renters_RenterId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Flats_FlatId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Employees_EmployeeId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeedbackTypes",
                table: "FeedbackTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "PlaceholderForFee");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "MetricHistories");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "MetricHistories");

            migrationBuilder.RenameTable(
                name: "FeedbackTypes",
                newName: "FeedbackType");

            migrationBuilder.RenameTable(
                name: "Feedbacks",
                newName: "Feedback");

            migrationBuilder.RenameColumn(
                name: "ContractServiceId",
                table: "PlaceholderForFee",
                newName: "ContractId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_RenterId",
                table: "Feedback",
                newName: "IX_Feedback_RenterId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_FlatId",
                table: "Feedback",
                newName: "IX_Feedback_FlatId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedbacks_FeedbackTypeId",
                table: "Feedback",
                newName: "IX_Feedback_FeedbackTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FlatId",
                table: "Rooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "PlaceholderForFee",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Detail",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Buildings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeedbackType",
                table: "FeedbackType",
                column: "FeedbackTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedback",
                table: "Feedback",
                column: "FeedbackId");

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7265), new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7268), new DateTime(2023, 5, 2, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7267) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 28, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7272), new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7273), new DateTime(2023, 4, 30, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7272) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 28, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7299), new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7300), new DateTime(2023, 4, 30, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7299) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 28, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7302), new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7303), new DateTime(2023, 4, 30, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7303) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 28, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7306), new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7319), new DateTime(2023, 4, 30, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7306) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 28, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7321), new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7324), new DateTime(2023, 4, 30, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7324) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7201), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7203), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7204), new DateTime(2023, 6, 26, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7204) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7207), new DateTime(2023, 2, 24, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7209), new DateTime(2023, 2, 22, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7209) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7211), new DateTime(2023, 3, 16, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7212), new DateTime(2023, 3, 14, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7212) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7214), new DateTime(2023, 5, 15, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7214), new DateTime(2023, 5, 13, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7219) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7220), new DateTime(2023, 4, 15, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7222), new DateTime(2023, 4, 13, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(7222) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 279, DateTimeKind.Utc).AddTicks(9746));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 279, DateTimeKind.Utc).AddTicks(9751));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 279, DateTimeKind.Utc).AddTicks(9752));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 279, DateTimeKind.Utc).AddTicks(9754));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 279, DateTimeKind.Utc).AddTicks(9756));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 279, DateTimeKind.Utc).AddTicks(9757));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 279, DateTimeKind.Utc).AddTicks(9758));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(6980));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(6982));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(6984));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(6988));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(6988));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(6989));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(6990));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 27, 4, 36, 13, 282, DateTimeKind.Utc).AddTicks(6991), new DateTime(2023, 5, 20, 11, 36, 13, 282, DateTimeKind.Local).AddTicks(6994) });

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Employees_EmployeeId",
                table: "Buildings",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_FeedbackType_FeedbackTypeId",
                table: "Feedback",
                column: "FeedbackTypeId",
                principalTable: "FeedbackType",
                principalColumn: "FeedbackTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Flats_FlatId",
                table: "Feedback",
                column: "FlatId",
                principalTable: "Flats",
                principalColumn: "FlatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Renters_RenterId",
                table: "Feedback",
                column: "RenterId",
                principalTable: "Renters",
                principalColumn: "RenterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Flats_FlatId",
                table: "Rooms",
                column: "FlatId",
                principalTable: "Flats",
                principalColumn: "FlatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Employees_EmployeeId",
                table: "Tickets",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Employees_EmployeeId",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_FeedbackType_FeedbackTypeId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Flats_FlatId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Renters_RenterId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Flats_FlatId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Employees_EmployeeId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeedbackType",
                table: "FeedbackType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedback",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "PlaceholderForFee");

            migrationBuilder.RenameTable(
                name: "FeedbackType",
                newName: "FeedbackTypes");

            migrationBuilder.RenameTable(
                name: "Feedback",
                newName: "Feedbacks");

            migrationBuilder.RenameColumn(
                name: "ContractId",
                table: "PlaceholderForFee",
                newName: "ContractServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedback_RenterId",
                table: "Feedbacks",
                newName: "IX_Feedbacks_RenterId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedback_FlatId",
                table: "Feedbacks",
                newName: "IX_Feedbacks_FlatId");

            migrationBuilder.RenameIndex(
                name: "IX_Feedback_FeedbackTypeId",
                table: "Feedbacks",
                newName: "IX_Feedbacks_FeedbackTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FlatId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "PlaceholderForFee",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "MetricHistories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "MetricHistories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Invoices",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Detail",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Buildings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeedbackTypes",
                table: "FeedbackTypes",
                column: "FeedbackTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks",
                column: "FeedbackId");

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9265), new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9268), new DateTime(2023, 4, 30, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9268) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 26, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9274), new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9275), new DateTime(2023, 4, 28, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9274) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 26, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9278), new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9278), new DateTime(2023, 4, 28, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9278) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 26, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9281), new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9282), new DateTime(2023, 4, 28, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9281) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 26, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9284), new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9298), new DateTime(2023, 4, 28, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9284) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 26, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9300), new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9306), new DateTime(2023, 4, 28, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9305) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9160), null });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9162), null });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9164), new DateTime(2023, 6, 24, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9165) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9169), new DateTime(2023, 2, 22, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9172), new DateTime(2023, 2, 20, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9173) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9177), new DateTime(2023, 3, 14, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9178), new DateTime(2023, 3, 12, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9179) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9180), new DateTime(2023, 5, 13, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9181), new DateTime(2023, 5, 11, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9181) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9184), new DateTime(2023, 4, 13, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9186), new DateTime(2023, 4, 11, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(9186) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 25, 22, 12, 47, 38, DateTimeKind.Utc).AddTicks(3171));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 25, 22, 12, 47, 38, DateTimeKind.Utc).AddTicks(3178));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 25, 22, 12, 47, 38, DateTimeKind.Utc).AddTicks(3181));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 25, 22, 12, 47, 38, DateTimeKind.Utc).AddTicks(3183));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 25, 22, 12, 47, 38, DateTimeKind.Utc).AddTicks(3185));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 25, 22, 12, 47, 38, DateTimeKind.Utc).AddTicks(3187));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 25, 22, 12, 47, 38, DateTimeKind.Utc).AddTicks(3189));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(8945));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(8947));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(8949));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(8950));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(8951));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(8952));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(8953));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 25, 22, 12, 47, 41, DateTimeKind.Utc).AddTicks(8988), new DateTime(2023, 5, 19, 5, 12, 47, 41, DateTimeKind.Local).AddTicks(8990) });

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Employees_EmployeeId",
                table: "Buildings",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_FeedbackTypes_FeedbackTypeId",
                table: "Feedbacks",
                column: "FeedbackTypeId",
                principalTable: "FeedbackTypes",
                principalColumn: "FeedbackTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Flats_FlatId",
                table: "Feedbacks",
                column: "FlatId",
                principalTable: "Flats",
                principalColumn: "FlatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Renters_RenterId",
                table: "Feedbacks",
                column: "RenterId",
                principalTable: "Renters",
                principalColumn: "RenterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Flats_FlatId",
                table: "Rooms",
                column: "FlatId",
                principalTable: "Flats",
                principalColumn: "FlatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Employees_EmployeeId",
                table: "Tickets",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
