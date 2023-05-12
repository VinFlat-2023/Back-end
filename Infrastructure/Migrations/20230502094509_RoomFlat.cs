using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class RoomFlat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomFlat_Flats_FlatId",
                table: "RoomFlat");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomFlat_Rooms_RoomId",
                table: "RoomFlat");

            migrationBuilder.DropForeignKey(
                name: "FK_UtilitiesRooms_RoomFlat_RoomFlatId",
                table: "UtilitiesRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_UtilitiesRooms_Utilities_UtilityId",
                table: "UtilitiesRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UtilitiesRooms",
                table: "UtilitiesRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomFlat",
                table: "RoomFlat");

            migrationBuilder.RenameTable(
                name: "UtilitiesRooms",
                newName: "UtilitiesRoomFlats");

            migrationBuilder.RenameTable(
                name: "RoomFlat",
                newName: "RoomFlats");

            migrationBuilder.RenameIndex(
                name: "IX_UtilitiesRooms_UtilityId",
                table: "UtilitiesRoomFlats",
                newName: "IX_UtilitiesRoomFlats_UtilityId");

            migrationBuilder.RenameIndex(
                name: "IX_UtilitiesRooms_RoomFlatId",
                table: "UtilitiesRoomFlats",
                newName: "IX_UtilitiesRoomFlats_RoomFlatId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomFlat_RoomId",
                table: "RoomFlats",
                newName: "IX_RoomFlats_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomFlat_FlatId",
                table: "RoomFlats",
                newName: "IX_RoomFlats_FlatId");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Renters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UtilitiesRoomFlats",
                table: "UtilitiesRoomFlats",
                column: "UtilitiesRoomFlatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomFlats",
                table: "RoomFlats",
                column: "RoomFlatId");

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8903), new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8906), new DateTime(2023, 4, 7, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8906) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 3, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8911), new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8912), new DateTime(2023, 4, 5, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8911) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 3, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8913), new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8914), new DateTime(2023, 4, 5, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8914) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 3, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8916), new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8916), new DateTime(2023, 4, 5, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8916) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 3, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8918), new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8926), new DateTime(2023, 4, 5, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8918) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 3, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8927), new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8930), new DateTime(2023, 4, 5, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8930) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8819));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8821));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8822), new DateTime(2023, 6, 1, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8822) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8824), new DateTime(2023, 1, 30, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8826), new DateTime(2023, 1, 28, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8826) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8827), new DateTime(2023, 2, 19, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8828), new DateTime(2023, 2, 17, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8828) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8830), new DateTime(2023, 4, 20, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8830), new DateTime(2023, 4, 18, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8830) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8832), new DateTime(2023, 3, 21, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8832), new DateTime(2023, 3, 19, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8832) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8369));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8373));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8398));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8399));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8400));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8401));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8403));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2,
                columns: new[] { "RoomSignName", "Status" },
                values: new object[] { "Room 2 for 5 slots", "Active" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3,
                columns: new[] { "RoomSignName", "Status" },
                values: new object[] { "Room 3 for 6 slots", "Active" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 4,
                columns: new[] { "RoomSignName", "Status" },
                values: new object[] { "Room 4 for 6 slots", "Maintaince" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8698));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8700));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8701));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8702));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8703));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8704));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8705));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 2, 9, 45, 8, 441, DateTimeKind.Utc).AddTicks(8705), new DateTime(2023, 4, 25, 16, 45, 8, 441, DateTimeKind.Local).AddTicks(8708) });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomFlats_Flats_FlatId",
                table: "RoomFlats",
                column: "FlatId",
                principalTable: "Flats",
                principalColumn: "FlatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomFlats_Rooms_RoomId",
                table: "RoomFlats",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UtilitiesRoomFlats_RoomFlats_RoomFlatId",
                table: "UtilitiesRoomFlats",
                column: "RoomFlatId",
                principalTable: "RoomFlats",
                principalColumn: "RoomFlatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UtilitiesRoomFlats_Utilities_UtilityId",
                table: "UtilitiesRoomFlats",
                column: "UtilityId",
                principalTable: "Utilities",
                principalColumn: "UtilityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomFlats_Flats_FlatId",
                table: "RoomFlats");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomFlats_Rooms_RoomId",
                table: "RoomFlats");

            migrationBuilder.DropForeignKey(
                name: "FK_UtilitiesRoomFlats_RoomFlats_RoomFlatId",
                table: "UtilitiesRoomFlats");

            migrationBuilder.DropForeignKey(
                name: "FK_UtilitiesRoomFlats_Utilities_UtilityId",
                table: "UtilitiesRoomFlats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UtilitiesRoomFlats",
                table: "UtilitiesRoomFlats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomFlats",
                table: "RoomFlats");

            migrationBuilder.RenameTable(
                name: "UtilitiesRoomFlats",
                newName: "UtilitiesRooms");

            migrationBuilder.RenameTable(
                name: "RoomFlats",
                newName: "RoomFlat");

            migrationBuilder.RenameIndex(
                name: "IX_UtilitiesRoomFlats_UtilityId",
                table: "UtilitiesRooms",
                newName: "IX_UtilitiesRooms_UtilityId");

            migrationBuilder.RenameIndex(
                name: "IX_UtilitiesRoomFlats_RoomFlatId",
                table: "UtilitiesRooms",
                newName: "IX_UtilitiesRooms_RoomFlatId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomFlats_RoomId",
                table: "RoomFlat",
                newName: "IX_RoomFlat_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomFlats_FlatId",
                table: "RoomFlat",
                newName: "IX_RoomFlat_FlatId");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Renters",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UtilitiesRooms",
                table: "UtilitiesRooms",
                column: "UtilitiesRoomFlatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomFlat",
                table: "RoomFlat",
                column: "RoomFlatId");

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
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2,
                columns: new[] { "RoomSignName", "Status" },
                values: new object[] { "Room 1 for 5 slots", "Ok" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3,
                columns: new[] { "RoomSignName", "Status" },
                values: new object[] { "Room 2 for 6 slots", "Ok" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 4,
                columns: new[] { "RoomSignName", "Status" },
                values: new object[] { "Room 3 for flat 3", "Ok" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_RoomFlat_Flats_FlatId",
                table: "RoomFlat",
                column: "FlatId",
                principalTable: "Flats",
                principalColumn: "FlatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomFlat_Rooms_RoomId",
                table: "RoomFlat",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UtilitiesRooms_RoomFlat_RoomFlatId",
                table: "UtilitiesRooms",
                column: "RoomFlatId",
                principalTable: "RoomFlat",
                principalColumn: "RoomFlatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UtilitiesRooms_Utilities_UtilityId",
                table: "UtilitiesRooms",
                column: "UtilityId",
                principalTable: "Utilities",
                principalColumn: "UtilityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
