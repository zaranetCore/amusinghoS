using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace amusinghoS.EntityData.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "amusingArticles",
                columns: table => new
                {
                    articleId = table.Column<string>(type: "varchar(48)", nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<string>(nullable: true),
                    DelTime = table.Column<DateTime>(nullable: false),
                    DeleteId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(type: "varchar(36)", nullable: false),
                    Image = table.Column<string>(type: "varchar(130)", nullable: true),
                    Description = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amusingArticles", x => x.articleId);
                });

            migrationBuilder.CreateTable(
                name: "amusingHosUsers",
                columns: table => new
                {
                    articleUserId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<string>(nullable: true),
                    DelTime = table.Column<DateTime>(nullable: false),
                    DeleteId = table.Column<string>(nullable: true),
                    articleUserName = table.Column<string>(type: "varchar(64)", nullable: true),
                    password = table.Column<string>(type: "varchar(128)", nullable: true),
                    phoneID = table.Column<string>(nullable: true),
                    wechat_user_ID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amusingHosUsers", x => x.articleUserId);
                });

            migrationBuilder.CreateTable(
                name: "amusingArticleComments",
                columns: table => new
                {
                    articleCommentId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<string>(nullable: true),
                    DelTime = table.Column<DateTime>(nullable: false),
                    DeleteId = table.Column<string>(nullable: true),
                    commentatorName = table.Column<string>(type: "varchar(64)", nullable: true),
                    content = table.Column<string>(type: "LongText", nullable: true),
                    eamil = table.Column<string>(nullable: true),
                    weburl = table.Column<string>(nullable: true),
                    amusingArticleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amusingArticleComments", x => x.articleCommentId);
                    table.ForeignKey(
                        name: "FK_amusingArticleComments_amusingArticles_amusingArticleId",
                        column: x => x.amusingArticleId,
                        principalTable: "amusingArticles",
                        principalColumn: "articleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "amusingArticleDetails",
                columns: table => new
                {
                    articleDetailsId = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<string>(nullable: true),
                    DelTime = table.Column<DateTime>(nullable: false),
                    DeleteId = table.Column<string>(nullable: true),
                    Html = table.Column<string>(type: "LongText", nullable: true),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    amusingArticleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amusingArticleDetails", x => x.articleDetailsId);
                    table.ForeignKey(
                        name: "FK_amusingArticleDetails_amusingArticles_amusingArticleId",
                        column: x => x.amusingArticleId,
                        principalTable: "amusingArticles",
                        principalColumn: "articleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_amusingArticleComments_amusingArticleId",
                table: "amusingArticleComments",
                column: "amusingArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_amusingArticleDetails_amusingArticleId",
                table: "amusingArticleDetails",
                column: "amusingArticleId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "amusingArticleComments");

            migrationBuilder.DropTable(
                name: "amusingArticleDetails");

            migrationBuilder.DropTable(
                name: "amusingHosUsers");

            migrationBuilder.DropTable(
                name: "amusingArticles");
        }
    }
}
