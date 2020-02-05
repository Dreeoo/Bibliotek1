using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Infrastructure.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SSN",
                table: "Members",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "ID",
                keyValue: 1,
                column: "SSN",
                value: "897658");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "ID",
                keyValue: 2,
                column: "SSN",
                value: "897328");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "ID",
                keyValue: 3,
                column: "SSN",
                value: "862393");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SSN",
                table: "Members",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "ID",
                keyValue: 1,
                column: "SSN",
                value: 897658);

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "ID",
                keyValue: 2,
                column: "SSN",
                value: 897328);

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "ID",
                keyValue: 3,
                column: "SSN",
                value: 862393);
        }
    }
}
