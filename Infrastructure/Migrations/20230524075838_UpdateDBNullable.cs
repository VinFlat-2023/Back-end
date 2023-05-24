using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdateDBNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Invoices")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "InvoicesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null);

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8397), new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8400), new DateTime(2023, 4, 29, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8399) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 25, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8404), new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8405), new DateTime(2023, 4, 27, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8405) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 25, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8407), new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8408), new DateTime(2023, 4, 27, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8407) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 25, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8410), new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8410), new DateTime(2023, 4, 27, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8410) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 25, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8412), new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8422), new DateTime(2023, 4, 27, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8413) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 25, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8423), new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8427), new DateTime(2023, 4, 27, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8426) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8283));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8285));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8286), new DateTime(2023, 6, 23, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8286) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8289), new DateTime(2023, 2, 21, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8291), new DateTime(2023, 2, 19, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8293) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8294), new DateTime(2023, 3, 13, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8295), new DateTime(2023, 3, 11, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8295) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8338), new DateTime(2023, 5, 12, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8339), new DateTime(2023, 5, 10, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8339) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8341), new DateTime(2023, 4, 12, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8341), new DateTime(2023, 4, 10, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8342) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 710, DateTimeKind.Utc).AddTicks(2180));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 710, DateTimeKind.Utc).AddTicks(2184));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 710, DateTimeKind.Utc).AddTicks(2232));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 710, DateTimeKind.Utc).AddTicks(2233));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 710, DateTimeKind.Utc).AddTicks(2235));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 710, DateTimeKind.Utc).AddTicks(2237));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 710, DateTimeKind.Utc).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "Status",
                value: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "Status",
                value: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "Status",
                value: false);

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8112));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8116));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8117));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8119));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8119));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8120));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8121));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 24, 7, 58, 36, 712, DateTimeKind.Utc).AddTicks(8122), new DateTime(2023, 5, 17, 14, 58, 36, 712, DateTimeKind.Local).AddTicks(8126) });

            migrationBuilder.CreateIndex(
                name: "IX_MetricHistories_FlatId",
                table: "MetricHistories",
                column: "FlatId");

            migrationBuilder.AddForeignKey(
                name: "FK_MetricHistories_Flats_FlatId",
                table: "MetricHistories",
                column: "FlatId",
                principalTable: "Flats",
                principalColumn: "FlatId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MetricHistories_Flats_FlatId",
                table: "MetricHistories");

            migrationBuilder.DropIndex(
                name: "IX_MetricHistories_FlatId",
                table: "MetricHistories");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true);

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
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "Status",
                value: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "Status",
                value: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "Status",
                value: true);

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
        }
    }
}
