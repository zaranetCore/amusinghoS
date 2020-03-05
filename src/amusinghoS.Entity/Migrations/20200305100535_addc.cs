using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace amusinghoS.EntityData.Migrations
{
    public partial class addc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    content = table.Column<string>(type: "LongText", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amusingArticleComments", x => x.articleCommentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "amusingArticleComments");
        }
    }
}
