using Microsoft.EntityFrameworkCore.Migrations;

namespace LI.BookService.DAL.Migrations
{
    public partial class SS58_20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLists_Lists_ListId",
                table: "UserLists");

            migrationBuilder.DropIndex(
                name: "IX_UserLists_ListId",
                table: "UserLists");

            migrationBuilder.DropColumn(
                name: "ListId",
                table: "UserLists");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ListId",
                table: "UserLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserLists_ListId",
                table: "UserLists",
                column: "ListId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLists_Lists_ListId",
                table: "UserLists",
                column: "ListId",
                principalTable: "Lists",
                principalColumn: "ListId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
