using Microsoft.EntityFrameworkCore.Migrations;

namespace amusinghoS.EntityData.Migrations
{
    public partial class addemail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "eamil",
                table: "amusingArticleComments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "weburl",
                table: "amusingArticleComments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "eamil",
                table: "amusingArticleComments");

            migrationBuilder.DropColumn(
                name: "weburl",
                table: "amusingArticleComments");
        }
    }
}
