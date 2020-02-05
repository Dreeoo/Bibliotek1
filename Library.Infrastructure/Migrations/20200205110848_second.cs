using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Infrastructure.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BookCopy",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Authors",
                newName: "ID");

            migrationBuilder.AddColumn<int>(
                name: "LoanID",
                table: "BookCopy",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SSN = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Loan",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanTime = table.Column<string>(nullable: true),
                    ReturnTime = table.Column<string>(nullable: true),
                    Delayed = table.Column<bool>(nullable: false),
                    Fine = table.Column<int>(nullable: false),
                    MemberID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Loan_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "ID", "Name", "SSN" },
                values: new object[] { 1, "Jonas Gren", 897658 });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "ID", "Name", "SSN" },
                values: new object[] { 2, "Elin Skog", 897328 });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "ID", "Name", "SSN" },
                values: new object[] { 3, "Hampus Log", 862393 });

            migrationBuilder.CreateIndex(
                name: "IX_BookCopy_LoanID",
                table: "BookCopy",
                column: "LoanID");

            migrationBuilder.CreateIndex(
                name: "IX_Loan_MemberID",
                table: "Loan",
                column: "MemberID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookCopy_Loan_LoanID",
                table: "BookCopy",
                column: "LoanID",
                principalTable: "Loan",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCopy_Loan_LoanID",
                table: "BookCopy");

            migrationBuilder.DropTable(
                name: "Loan");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropIndex(
                name: "IX_BookCopy_LoanID",
                table: "BookCopy");

            migrationBuilder.DropColumn(
                name: "LoanID",
                table: "BookCopy");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "BookCopy",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Authors",
                newName: "Id");
        }
    }
}
