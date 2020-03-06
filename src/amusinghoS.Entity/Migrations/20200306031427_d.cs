using Microsoft.EntityFrameworkCore.Migrations;

namespace amusinghoS.EntityData.Migrations
{
    public partial class d : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "amusingArticleId",
                table: "amusingArticleComments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_amusingArticleComments_amusingArticleId",
                table: "amusingArticleComments",
                column: "amusingArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_amusingArticleComments_amusingArticles_amusingArticleId",
                table: "amusingArticleComments",
                column: "amusingArticleId",
                principalTable: "amusingArticles",
                principalColumn: "articleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_amusingArticleComments_amusingArticles_amusingArticleId",
                table: "amusingArticleComments");

            migrationBuilder.DropIndex(
                name: "IX_amusingArticleComments_amusingArticleId",
                table: "amusingArticleComments");

            migrationBuilder.DropColumn(
                name: "amusingArticleId",
                table: "amusingArticleComments");
        }
    }
}
