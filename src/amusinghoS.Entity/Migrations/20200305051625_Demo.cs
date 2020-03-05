using Microsoft.EntityFrameworkCore.Migrations;

namespace amusinghoS.EntityData.Migrations
{
    public partial class Demo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Html",
                table: "amusingArticleDetails",
                type: "LongText",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(48)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Html",
                table: "amusingArticleDetails",
                type: "varchar(48)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "LongText",
                oldNullable: true);
        }
    }
}
