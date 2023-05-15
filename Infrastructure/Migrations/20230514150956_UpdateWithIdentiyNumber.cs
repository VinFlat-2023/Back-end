using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdateWithIdentiyNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CitizenImageUrl",
                table: "Renters",
                newName: "CitizenCardFrontImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "CitizenCardBackImageUrl",
                table: "Renters",
                type: "nvarchar(max)",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CitizenCardBackImageUrl",
                table: "Renters");

            migrationBuilder.RenameColumn(
                name: "CitizenCardFrontImageUrl",
                table: "Renters",
                newName: "CitizenImageUrl");

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
        }
    }
}
