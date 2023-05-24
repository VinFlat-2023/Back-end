using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class RemoveUtility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UtilitiesRoom_Utilities_UtilityId",
                table: "UtilitiesRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Utilities",
                table: "Utilities");

            migrationBuilder.RenameTable(
                name: "Utilities",
                newName: "Utility");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utility",
                table: "Utility",
                column: "UtilityId");

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3091), new DateTime(2023, 5, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3093), new DateTime(2023, 4, 28, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3093) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 24, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3097), new DateTime(2023, 5, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3098), new DateTime(2023, 4, 26, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3098) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 24, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3100), new DateTime(2023, 5, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3101), new DateTime(2023, 4, 26, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3101) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 24, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3103), new DateTime(2023, 5, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3104), new DateTime(2023, 4, 26, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3104) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 24, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3106), new DateTime(2023, 5, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3107), new DateTime(2023, 4, 26, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3106) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 24, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3108), new DateTime(2023, 5, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3109), new DateTime(2023, 4, 26, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3108) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3042));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3044));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3045), new DateTime(2023, 6, 22, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3046) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3048), new DateTime(2023, 2, 20, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3050), new DateTime(2023, 2, 18, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3051) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3052), new DateTime(2023, 3, 12, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3053), new DateTime(2023, 3, 10, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3053) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3054), new DateTime(2023, 5, 11, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3055), new DateTime(2023, 5, 9, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3055) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3056), new DateTime(2023, 4, 11, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3057), new DateTime(2023, 4, 9, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(3057) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(2534));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(2536));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(2538));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(2540));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(2541));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(2542));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(2543));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(2890));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(2891));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(2893));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(2894));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(2894));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(2895));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(2896));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 23, 9, 5, 0, 681, DateTimeKind.Utc).AddTicks(2897), new DateTime(2023, 5, 16, 16, 5, 0, 681, DateTimeKind.Local).AddTicks(2901) });

            migrationBuilder.AddForeignKey(
                name: "FK_UtilitiesRoom_Utility_UtilityId",
                table: "UtilitiesRoom",
                column: "UtilityId",
                principalTable: "Utility",
                principalColumn: "UtilityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UtilitiesRoom_Utility_UtilityId",
                table: "UtilitiesRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Utility",
                table: "Utility");

            migrationBuilder.RenameTable(
                name: "Utility",
                newName: "Utilities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utilities",
                table: "Utilities",
                column: "UtilityId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UtilitiesRoom_Utilities_UtilityId",
                table: "UtilitiesRoom",
                column: "UtilityId",
                principalTable: "Utilities",
                principalColumn: "UtilityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
