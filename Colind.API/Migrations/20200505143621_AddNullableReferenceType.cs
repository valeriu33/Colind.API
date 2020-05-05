using Microsoft.EntityFrameworkCore.Migrations;

namespace Colind.API.Migrations
{
    public partial class AddNullableReferenceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColindTag_Tags_TagId",
                table: "ColindTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColindTag",
                table: "ColindTag");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "ColindTag");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tags",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TagName",
                table: "ColindTag",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Colinds",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Colinds",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColindTag",
                table: "ColindTag",
                columns: new[] { "TagName", "ColindId" });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Name",
                table: "Tags",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_ColindTag_Tags_TagName",
                table: "ColindTag",
                column: "TagName",
                principalTable: "Tags",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColindTag_Tags_TagName",
                table: "ColindTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_Name",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColindTag",
                table: "ColindTag");

            migrationBuilder.DropColumn(
                name: "TagName",
                table: "ColindTag");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tags",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "ColindTag",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Colinds",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Colinds",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColindTag",
                table: "ColindTag",
                columns: new[] { "TagId", "ColindId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ColindTag_Tags_TagId",
                table: "ColindTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
