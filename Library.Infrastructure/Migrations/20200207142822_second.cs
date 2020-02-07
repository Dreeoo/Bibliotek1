using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Infrastructure.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_BookCopy_BookCopyID",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_BookCopyID",
                table: "Loans");

            migrationBuilder.AddColumn<int>(
                name: "BookCopyID1",
                table: "Loans",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoanID",
                table: "BookCopy",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BookCopyID1",
                table: "Loans",
                column: "BookCopyID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_BookCopy_BookCopyID1",
                table: "Loans",
                column: "BookCopyID1",
                principalTable: "BookCopy",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_BookCopy_BookCopyID1",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_BookCopyID1",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "BookCopyID1",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "LoanID",
                table: "BookCopy");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BookCopyID",
                table: "Loans",
                column: "BookCopyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_BookCopy_BookCopyID",
                table: "Loans",
                column: "BookCopyID",
                principalTable: "BookCopy",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
