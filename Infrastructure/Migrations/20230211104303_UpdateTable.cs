using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FlatTypes",
                keyColumn: "FlatTypeId",
                keyValue: 1,
                column: "RoomCapacity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "FlatTypes",
                keyColumn: "FlatTypeId",
                keyValue: 2,
                column: "RoomCapacity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "FlatTypes",
                keyColumn: "FlatTypeId",
                keyValue: 3,
                column: "RoomCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "FlatTypes",
                keyColumn: "FlatTypeId",
                keyValue: 4,
                column: "RoomCapacity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "FlatTypes",
                keyColumn: "FlatTypeId",
                keyValue: 5,
                column: "RoomCapacity",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 2, 11, 10, 43, 2, 979, DateTimeKind.Utc).AddTicks(5263));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 2, 11, 10, 43, 2, 979, DateTimeKind.Utc).AddTicks(5269));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 2, 11, 10, 43, 2, 979, DateTimeKind.Utc).AddTicks(5271));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 2, 11, 10, 43, 2, 979, DateTimeKind.Utc).AddTicks(5274));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FlatTypes",
                keyColumn: "FlatTypeId",
                keyValue: 1,
                column: "RoomCapacity",
                value: null);

            migrationBuilder.UpdateData(
                table: "FlatTypes",
                keyColumn: "FlatTypeId",
                keyValue: 2,
                column: "RoomCapacity",
                value: null);

            migrationBuilder.UpdateData(
                table: "FlatTypes",
                keyColumn: "FlatTypeId",
                keyValue: 3,
                column: "RoomCapacity",
                value: null);

            migrationBuilder.UpdateData(
                table: "FlatTypes",
                keyColumn: "FlatTypeId",
                keyValue: 4,
                column: "RoomCapacity",
                value: null);

            migrationBuilder.UpdateData(
                table: "FlatTypes",
                keyColumn: "FlatTypeId",
                keyValue: 5,
                column: "RoomCapacity",
                value: null);

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 2, 11, 9, 33, 38, 799, DateTimeKind.Utc).AddTicks(5387));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 2, 11, 9, 33, 38, 799, DateTimeKind.Utc).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 2, 11, 9, 33, 38, 799, DateTimeKind.Utc).AddTicks(5396));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 2, 11, 9, 33, 38, 799, DateTimeKind.Utc).AddTicks(5398));
        }
    }
}
