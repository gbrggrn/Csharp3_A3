using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csharp3_A3.Migrations
{
    /// <inheritdoc />
    public partial class AddContentCardDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentCard_PageContents_PageContentId",
                table: "ContentCard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContentCard",
                table: "ContentCard");

            migrationBuilder.RenameTable(
                name: "ContentCard",
                newName: "ContentCards");

            migrationBuilder.RenameIndex(
                name: "IX_ContentCard_PageContentId",
                table: "ContentCards",
                newName: "IX_ContentCards_PageContentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContentCards",
                table: "ContentCards",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentCards_PageContents_PageContentId",
                table: "ContentCards",
                column: "PageContentId",
                principalTable: "PageContents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentCards_PageContents_PageContentId",
                table: "ContentCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContentCards",
                table: "ContentCards");

            migrationBuilder.RenameTable(
                name: "ContentCards",
                newName: "ContentCard");

            migrationBuilder.RenameIndex(
                name: "IX_ContentCards_PageContentId",
                table: "ContentCard",
                newName: "IX_ContentCard_PageContentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContentCard",
                table: "ContentCard",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentCard_PageContents_PageContentId",
                table: "ContentCard",
                column: "PageContentId",
                principalTable: "PageContents",
                principalColumn: "Id");
        }
    }
}
