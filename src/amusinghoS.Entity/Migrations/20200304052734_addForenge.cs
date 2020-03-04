using Microsoft.EntityFrameworkCore.Migrations;

namespace amusinghoS.EntityData.Migrations
{
    public partial class addForenge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_amusingArticleDetails_amusingArticles_AmusingArticlearticleId",
                table: "amusingArticleDetails");

            migrationBuilder.DropIndex(
                name: "IX_amusingArticleDetails_AmusingArticlearticleId",
                table: "amusingArticleDetails");

            migrationBuilder.DropColumn(
                name: "AmusingArticlearticleId",
                table: "amusingArticleDetails");

            migrationBuilder.AddColumn<string>(
                name: "amusingArticleId",
                table: "amusingArticleDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_amusingArticleDetails_amusingArticleId",
                table: "amusingArticleDetails",
                column: "amusingArticleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_amusingArticleDetails_amusingArticles_amusingArticleId",
                table: "amusingArticleDetails",
                column: "amusingArticleId",
                principalTable: "amusingArticles",
                principalColumn: "articleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_amusingArticleDetails_amusingArticles_amusingArticleId",
                table: "amusingArticleDetails");

            migrationBuilder.DropIndex(
                name: "IX_amusingArticleDetails_amusingArticleId",
                table: "amusingArticleDetails");

            migrationBuilder.DropColumn(
                name: "amusingArticleId",
                table: "amusingArticleDetails");

            migrationBuilder.AddColumn<string>(
                name: "AmusingArticlearticleId",
                table: "amusingArticleDetails",
                type: "varchar(48)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_amusingArticleDetails_AmusingArticlearticleId",
                table: "amusingArticleDetails",
                column: "AmusingArticlearticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_amusingArticleDetails_amusingArticles_AmusingArticlearticleId",
                table: "amusingArticleDetails",
                column: "AmusingArticlearticleId",
                principalTable: "amusingArticles",
                principalColumn: "articleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
