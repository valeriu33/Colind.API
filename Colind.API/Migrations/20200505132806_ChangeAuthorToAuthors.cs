using Microsoft.EntityFrameworkCore.Migrations;

namespace Colind.API.Migrations
{
    public partial class ChangeAuthorToAuthors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colinds_Author_AuthorFullName",
                table: "Colinds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "Authors");

            migrationBuilder.RenameIndex(
                name: "IX_Author_FullName",
                table: "Authors",
                newName: "IX_Authors_FullName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "FullName");

            migrationBuilder.AddForeignKey(
                name: "FK_Colinds_Authors_AuthorFullName",
                table: "Colinds",
                column: "AuthorFullName",
                principalTable: "Authors",
                principalColumn: "FullName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colinds_Authors_AuthorFullName",
                table: "Colinds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Author");

            migrationBuilder.RenameIndex(
                name: "IX_Authors_FullName",
                table: "Author",
                newName: "IX_Author_FullName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "FullName");

            migrationBuilder.AddForeignKey(
                name: "FK_Colinds_Author_AuthorFullName",
                table: "Colinds",
                column: "AuthorFullName",
                principalTable: "Author",
                principalColumn: "FullName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
