using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csharp3_A3.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToContentCardMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentCards_PageContents_PageContentId",
                table: "ContentCards");

            migrationBuilder.AlterColumn<int>(
                name: "PageContentId",
                table: "ContentCards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContentCards_PageContents_PageContentId",
                table: "ContentCards",
                column: "PageContentId",
                principalTable: "PageContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentCards_PageContents_PageContentId",
                table: "ContentCards");

            migrationBuilder.AlterColumn<int>(
                name: "PageContentId",
                table: "ContentCards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentCards_PageContents_PageContentId",
                table: "ContentCards",
                column: "PageContentId",
                principalTable: "PageContents",
                principalColumn: "Id");
        }
    }
}
