using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace amusinghoS.EntityData.Migrations
{
    public partial class ad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "articleId",
                table: "amusingArticles",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "articleId",
                table: "amusingArticles",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
