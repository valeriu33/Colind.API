using Microsoft.EntityFrameworkCore.Migrations;

namespace Colind.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    FullName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.FullName);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colinds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    AuthorFullName = table.Column<string>(maxLength: 50, nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colinds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colinds_Author_AuthorFullName",
                        column: x => x.AuthorFullName,
                        principalTable: "Author",
                        principalColumn: "FullName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ColindTag",
                columns: table => new
                {
                    ColindId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColindTag", x => new { x.TagId, x.ColindId });
                    table.ForeignKey(
                        name: "FK_ColindTag_Colinds_ColindId",
                        column: x => x.ColindId,
                        principalTable: "Colinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColindTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Author_FullName",
                table: "Author",
                column: "FullName");

            migrationBuilder.CreateIndex(
                name: "IX_Colinds_AuthorFullName",
                table: "Colinds",
                column: "AuthorFullName");

            migrationBuilder.CreateIndex(
                name: "IX_ColindTag_ColindId",
                table: "ColindTag",
                column: "ColindId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColindTag");

            migrationBuilder.DropTable(
                name: "Colinds");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
