using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace amusinghoS.EntityData.Migrations
{
    public partial class adddetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "amusingHosUsers",
                columns: table => new
                {
                    userId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 16, nullable: true),
                    PassWord = table.Column<string>(maxLength: 18, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amusingHosUsers", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "amusingArticleDetails",
                columns: table => new
                {
                    articleDetailsId = table.Column<string>(nullable: false),
                    Html = table.Column<string>(type: "varchar(48)", nullable: true),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    AmusingArticlearticleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amusingArticleDetails", x => x.articleDetailsId);
                    table.ForeignKey(
                        name: "FK_amusingArticleDetails_amusingArticles_AmusingArticlearticleId",
                        column: x => x.AmusingArticlearticleId,
                        principalTable: "amusingArticles",
                        principalColumn: "articleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_amusingArticleDetails_AmusingArticlearticleId",
                table: "amusingArticleDetails",
                column: "AmusingArticlearticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "amusingArticleDetails");

            migrationBuilder.DropTable(
                name: "amusingHosUsers");

            migrationBuilder.DropTable(
                name: "amusingArticles");
        }
    }
}
