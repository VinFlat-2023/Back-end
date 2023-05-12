using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdateRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UtilitiesRoomFlats");

            migrationBuilder.DropTable(
                name: "RoomFlats");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "RoomSignName",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "TotalSlot",
                table: "Rooms",
                newName: "RoomTypeId");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Rooms",
                newName: "RoomName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Rooms",
                newName: "RoomImageUrl6");

            migrationBuilder.RenameColumn(
                name: "RoomFlatId",
                table: "Contracts",
                newName: "RoomId");

            migrationBuilder.AddColumn<int>(
                name: "AvailableSlots",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ElectricityAttribute",
                table: "Rooms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "FlatId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RoomImageUrl1",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomImageUrl2",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomImageUrl3",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomImageUrl4",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomImageUrl5",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "WaterAttribute",
                table: "Rooms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "BuildingId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    RoomTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalSlot = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.RoomTypeId);
                });

            migrationBuilder.CreateTable(
                name: "UtilitiesRoom",
                columns: table => new
                {
                    UtilitiesRoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    UtilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilitiesRoom", x => x.UtilitiesRoomId);
                    table.ForeignKey(
                        name: "FK_UtilitiesRoom_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UtilitiesRoom_Utilities_UtilityId",
                        column: x => x.UtilityId,
                        principalTable: "Utilities",
                        principalColumn: "UtilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9889), new DateTime(2023, 5, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9893), new DateTime(2023, 4, 17, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9892) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 13, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9896), new DateTime(2023, 5, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9898), new DateTime(2023, 4, 15, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9897) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 13, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9900), new DateTime(2023, 5, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9901), new DateTime(2023, 4, 15, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9900) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 13, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9903), new DateTime(2023, 5, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9914), new DateTime(2023, 4, 15, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9904) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 13, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9916), new DateTime(2023, 5, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9920), new DateTime(2023, 4, 15, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9919) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 13, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9922), new DateTime(2023, 5, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9923), new DateTime(2023, 4, 15, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9922) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9832));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9834));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9836), new DateTime(2023, 6, 11, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9836) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9839), new DateTime(2023, 2, 9, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9841), new DateTime(2023, 2, 7, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9842) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9843), new DateTime(2023, 3, 1, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9844), new DateTime(2023, 2, 27, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9845) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9846), new DateTime(2023, 4, 30, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9847), new DateTime(2023, 4, 28, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9847) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9849), new DateTime(2023, 3, 31, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9850), new DateTime(2023, 3, 29, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9279));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9283));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9285));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9287));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9288));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9290));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9291));

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "RoomTypeId", "BuildingId", "Description", "RoomTypeName", "Status", "TotalSlot" },
                values: new object[,]
                {
                    { 1, 3, "ABCDEF", "Room 1 with 4 slots", "Ok", 4 },
                    { 2, 3, "ABCDEF", "Room 2 for 5 slots", "Active", 5 },
                    { 3, 3, "ABCDEF", "Room 3 for 6 slots", "Active", 5 },
                    { 4, 3, "ABCDEF", "Room 4 for 6 slots", "Maintaince", 0 }
                });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9652));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9655));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9657));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9658));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9659));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9660));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9661));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 12, 9, 40, 14, 407, DateTimeKind.Utc).AddTicks(9662), new DateTime(2023, 5, 5, 16, 40, 14, 407, DateTimeKind.Local).AddTicks(9665) });

            migrationBuilder.InsertData(
                table: "UtilitiesRoom",
                columns: new[] { "UtilitiesRoomId", "RoomId", "UtilityId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1,
                columns: new[] { "AvailableSlots", "ElectricityAttribute", "FlatId", "RoomImageUrl6", "RoomName", "RoomTypeId", "WaterAttribute" },
                values: new object[] { 5, 1m, 1, null, "VF-02", 1, 1m });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2,
                columns: new[] { "AvailableSlots", "ElectricityAttribute", "FlatId", "RoomImageUrl6", "RoomName", "RoomTypeId", "WaterAttribute" },
                values: new object[] { 5, 1m, 2, null, "VLA-203", 2, 1m });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_FlatId",
                table: "Rooms",
                column: "FlatId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ContractId",
                table: "Invoices",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_UtilitiesRoom_RoomId",
                table: "UtilitiesRoom",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_UtilitiesRoom_UtilityId",
                table: "UtilitiesRoom",
                column: "UtilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Contracts_ContractId",
                table: "Invoices",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Flats_FlatId",
                table: "Rooms",
                column: "FlatId",
                principalTable: "Flats",
                principalColumn: "FlatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomTypes_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId",
                principalTable: "RoomTypes",
                principalColumn: "RoomTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Contracts_ContractId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Flats_FlatId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomTypes_RoomTypeId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropTable(
                name: "UtilitiesRoom");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_FlatId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ContractId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "AvailableSlots",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ElectricityAttribute",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "FlatId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomImageUrl1",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomImageUrl2",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomImageUrl3",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomImageUrl4",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomImageUrl5",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "WaterAttribute",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "Invoices")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "InvoicesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null);

            migrationBuilder.RenameColumn(
                name: "RoomTypeId",
                table: "Rooms",
                newName: "TotalSlot");

            migrationBuilder.RenameColumn(
                name: "RoomName",
                table: "Rooms",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "RoomImageUrl6",
                table: "Rooms",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Contracts",
                newName: "RoomFlatId");

            migrationBuilder.AddColumn<string>(
                name: "RoomSignName",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "RoomFlats",
                columns: table => new
                {
                    RoomFlatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlatId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    AvailableSlots = table.Column<int>(type: "int", nullable: false),
                    ElectricityAttribute = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RoomFlatImageUrl1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomFlatImageUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomFlatImageUrl3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomFlatImageUrl4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomFlatImageUrl5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomFlatImageUrl6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WaterAttribute = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomFlats", x => x.RoomFlatId);
                    table.ForeignKey(
                        name: "FK_RoomFlats_Flats_FlatId",
                        column: x => x.FlatId,
                        principalTable: "Flats",
                        principalColumn: "FlatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomFlats_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UtilitiesRoomFlats",
                columns: table => new
                {
                    UtilitiesRoomFlatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomFlatId = table.Column<int>(type: "int", nullable: false),
                    UtilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilitiesRoomFlats", x => x.UtilitiesRoomFlatId);
                    table.ForeignKey(
                        name: "FK_UtilitiesRoomFlats_RoomFlats_RoomFlatId",
                        column: x => x.RoomFlatId,
                        principalTable: "RoomFlats",
                        principalColumn: "RoomFlatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UtilitiesRoomFlats_Utilities_UtilityId",
                        column: x => x.UtilityId,
                        principalTable: "Utilities",
                        principalColumn: "UtilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2206), new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2209), new DateTime(2023, 4, 16, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2208) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 12, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2212), new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2213), new DateTime(2023, 4, 14, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2213) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 12, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2215), new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2216), new DateTime(2023, 4, 14, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2216) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 12, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2218), new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2228), new DateTime(2023, 4, 14, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2218) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 12, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2230), new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2233), new DateTime(2023, 4, 14, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2232) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 12, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2235), new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2235), new DateTime(2023, 4, 14, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2235) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2133));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2135));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2136), new DateTime(2023, 6, 10, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2136) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2138), new DateTime(2023, 2, 8, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2140), new DateTime(2023, 2, 6, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2141) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2142), new DateTime(2023, 2, 28, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2143), new DateTime(2023, 2, 26, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2143) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2145), new DateTime(2023, 4, 29, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2146), new DateTime(2023, 4, 27, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2146) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2147), new DateTime(2023, 3, 30, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2148), new DateTime(2023, 3, 28, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(1661));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(1664));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(1667));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(1668));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(1669));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(1670));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(1671));

            migrationBuilder.InsertData(
                table: "RoomFlats",
                columns: new[] { "RoomFlatId", "AvailableSlots", "ElectricityAttribute", "FlatId", "RoomFlatImageUrl1", "RoomFlatImageUrl2", "RoomFlatImageUrl3", "RoomFlatImageUrl4", "RoomFlatImageUrl5", "RoomFlatImageUrl6", "RoomId", "RoomName", "WaterAttribute" },
                values: new object[,]
                {
                    { 1, 5, 1m, 1, null, null, null, null, null, null, 1, "VF-02", 1m },
                    { 2, 5, 1m, 2, null, null, null, null, null, null, 2, "VLA-203", 1m }
                });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1,
                columns: new[] { "Description", "RoomSignName", "Status", "TotalSlot" },
                values: new object[] { "ABCDEF", "Room 1 with 4 slots", "Ok", 4 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2,
                columns: new[] { "Description", "RoomSignName", "Status", "TotalSlot" },
                values: new object[] { "ABCDEF", "Room 2 for 5 slots", "Active", 5 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "BuildingId", "Description", "RoomSignName", "Status", "TotalSlot" },
                values: new object[,]
                {
                    { 3, 3, "ABCDEF", "Room 3 for 6 slots", "Active", 5 },
                    { 4, 3, "ABCDEF", "Room 4 for 6 slots", "Maintaince", 0 }
                });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(1984));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(1986));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(1987));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2012));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2013));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2014));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2015));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 11, 6, 10, 23, 671, DateTimeKind.Utc).AddTicks(2016), new DateTime(2023, 5, 4, 13, 10, 23, 671, DateTimeKind.Local).AddTicks(2020) });

            migrationBuilder.InsertData(
                table: "UtilitiesRoomFlats",
                columns: new[] { "UtilitiesRoomFlatId", "RoomFlatId", "UtilityId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "UtilitiesRoomFlats",
                columns: new[] { "UtilitiesRoomFlatId", "RoomFlatId", "UtilityId" },
                values: new object[] { 2, 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_RoomFlats_FlatId",
                table: "RoomFlats",
                column: "FlatId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomFlats_RoomId",
                table: "RoomFlats",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_UtilitiesRoomFlats_RoomFlatId",
                table: "UtilitiesRoomFlats",
                column: "RoomFlatId");

            migrationBuilder.CreateIndex(
                name: "IX_UtilitiesRoomFlats_UtilityId",
                table: "UtilitiesRoomFlats",
                column: "UtilityId");
        }
    }
}
