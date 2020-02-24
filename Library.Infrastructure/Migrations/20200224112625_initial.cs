using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 55, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SSN = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BookDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISBN = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    AuthorID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CopiesAvailable = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BookDetails_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReturnedLoans",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Delayed = table.Column<bool>(nullable: false),
                    Fine = table.Column<int>(nullable: false),
                    Returned = table.Column<bool>(nullable: false),
                    BookCopyID = table.Column<int>(nullable: false),
                    MemberID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnedLoans", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReturnedLoans_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCopies",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnLoan = table.Column<bool>(nullable: false),
                    DetailsID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCopies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BookCopies_BookDetails_DetailsID",
                        column: x => x.DetailsID,
                        principalTable: "BookDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanTime = table.Column<DateTime>(nullable: false),
                    ReturnTime = table.Column<DateTime>(nullable: false),
                    Delayed = table.Column<bool>(nullable: false),
                    Fine = table.Column<int>(nullable: false),
                    Returned = table.Column<bool>(nullable: false),
                    BookCopyID = table.Column<int>(nullable: false),
                    MemberID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Loans_BookCopies_BookCopyID",
                        column: x => x.BookCopyID,
                        principalTable: "BookCopies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "William Shakespeare" },
                    { 2, "Villiam Skakspjut" },
                    { 3, "Robert C. Martin" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "ID", "Name", "SSN" },
                values: new object[,]
                {
                    { 1, "Jonas Gren", "897658" },
                    { 2, "Elin Skog", "897328" },
                    { 3, "Hampus Log", "862393" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCopies_DetailsID",
                table: "BookCopies",
                column: "DetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_BookDetails_AuthorID",
                table: "BookDetails",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BookCopyID",
                table: "Loans",
                column: "BookCopyID");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_MemberID",
                table: "Loans",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnedLoans_MemberID",
                table: "ReturnedLoans",
                column: "MemberID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "ReturnedLoans");

            migrationBuilder.DropTable(
                name: "BookCopies");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "BookDetails");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
