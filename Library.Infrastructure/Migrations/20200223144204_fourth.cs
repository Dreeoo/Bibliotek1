using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Infrastructure.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookDetails",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookDetails",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookDetails",
                keyColumn: "ID",
                keyValue: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BookDetails",
                columns: new[] { "ID", "AuthorID", "CopiesAvailable", "Description", "ISBN", "Title" },
                values: new object[] { 1, 1, 0, "Arguably Shakespeare's greatest tragedy", "1472518381", "Hamlet" });

            migrationBuilder.InsertData(
                table: "BookDetails",
                columns: new[] { "ID", "AuthorID", "CopiesAvailable", "Description", "ISBN", "Title" },
                values: new object[] { 2, 1, 0, "King Lear is a tragedy written by William Shakespeare. It depicts the gradual descent into madness of the title character, after he disposes of his kingdom by giving bequests to two of his three daughters egged on by their continual flattery, bringing tragic consequences for all.", "9780141012292", "King Lear" });

            migrationBuilder.InsertData(
                table: "BookDetails",
                columns: new[] { "ID", "AuthorID", "CopiesAvailable", "Description", "ISBN", "Title" },
                values: new object[] { 3, 2, 0, "An intense drama of love, deception, jealousy and destruction.", "1853260185", "Othello" });
        }
    }
}
