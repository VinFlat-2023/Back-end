using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class RemoveWildCardId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceTypeIdWildCard",
                table: "InvoiceTypes");

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5186), new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5189), new DateTime(2023, 4, 15, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5188) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 11, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5192), new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5193), new DateTime(2023, 4, 13, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5193) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 11, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5196), new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5197), new DateTime(2023, 4, 13, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5196) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 11, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5199), new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5199), new DateTime(2023, 4, 13, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5199) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 11, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5201), new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5208), new DateTime(2023, 4, 13, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5201) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 11, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5210), new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5213), new DateTime(2023, 4, 13, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5212) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5137));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5139));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5140), new DateTime(2023, 6, 9, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5140) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5142), new DateTime(2023, 2, 7, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5144), new DateTime(2023, 2, 5, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5145) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5146), new DateTime(2023, 2, 27, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5146), new DateTime(2023, 2, 25, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5147) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5148), new DateTime(2023, 4, 28, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5149), new DateTime(2023, 4, 26, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5149) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5150), new DateTime(2023, 3, 29, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5151), new DateTime(2023, 3, 27, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5151) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(4681));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(4685));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(4687));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(4688));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(4689));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(4692));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(4995));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(4996));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(4997));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(4998));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(4999));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5000));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5000));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 10, 7, 32, 48, 138, DateTimeKind.Utc).AddTicks(5001), new DateTime(2023, 5, 3, 14, 32, 48, 138, DateTimeKind.Local).AddTicks(5004) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceTypeIdWildCard",
                table: "InvoiceTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 1,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3724), new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3726), new DateTime(2023, 4, 14, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3726) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 10, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3730), new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3730), new DateTime(2023, 4, 12, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3730) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 3,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 10, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3732), new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3733), new DateTime(2023, 4, 12, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3732) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 4,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 10, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3735), new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3735), new DateTime(2023, 4, 12, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3735) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 5,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 10, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3737), new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3748), new DateTime(2023, 4, 12, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3737) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "ContractId",
                keyValue: 6,
                columns: new[] { "DateSigned", "LastUpdated", "StartDate" },
                values: new object[] { new DateTime(2023, 4, 10, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3750), new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3753), new DateTime(2023, 4, 12, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3752) });

            migrationBuilder.UpdateData(
                table: "InvoiceTypes",
                keyColumn: "InvoiceTypeId",
                keyValue: 1,
                column: "InvoiceTypeIdWildCard",
                value: 1);

            migrationBuilder.UpdateData(
                table: "InvoiceTypes",
                keyColumn: "InvoiceTypeId",
                keyValue: 2,
                column: "InvoiceTypeIdWildCard",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3657));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3659));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 3,
                columns: new[] { "CreatedTime", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3660), new DateTime(2023, 6, 8, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3660) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 4,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 1, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3663), new DateTime(2023, 2, 6, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3664), new DateTime(2023, 2, 4, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3664) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 5,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 2, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3666), new DateTime(2023, 2, 26, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3666), new DateTime(2023, 2, 24, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3667) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 6,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 4, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3668), new DateTime(2023, 4, 27, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3669), new DateTime(2023, 4, 25, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3669) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 7,
                columns: new[] { "CreatedTime", "DueDate", "PaymentTime" },
                values: new object[] { new DateTime(2023, 3, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3670), new DateTime(2023, 3, 28, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3670), new DateTime(2023, 3, 26, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3671) });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3191));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3195));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3196));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3197));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3198));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3199));

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "RenterId",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3226));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3535));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3536));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3537));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3538));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3539));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3540));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3540));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 8,
                columns: new[] { "CreateDate", "SolveDate" },
                values: new object[] { new DateTime(2023, 5, 9, 7, 22, 57, 49, DateTimeKind.Utc).AddTicks(3541), new DateTime(2023, 5, 2, 14, 22, 57, 49, DateTimeKind.Local).AddTicks(3544) });
        }
    }
}
