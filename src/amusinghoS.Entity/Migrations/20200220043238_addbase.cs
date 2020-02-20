using Microsoft.EntityFrameworkCore.Migrations;

namespace amusinghoS.EntityData.Migrations
{
    public partial class addbase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateTime",
                table: "amusingArticles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "amusingArticles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeleteId",
                table: "amusingArticles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeleteTime",
                table: "amusingArticles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "amusingArticles");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "amusingArticles");

            migrationBuilder.DropColumn(
                name: "DeleteId",
                table: "amusingArticles");

            migrationBuilder.DropColumn(
                name: "DeleteTime",
                table: "amusingArticles");
        }
    }
}
