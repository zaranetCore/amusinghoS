using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace amusinghoS.EntityData.Migrations
{
    public partial class updatDelTim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteTime",
                table: "amusingArticles");

            migrationBuilder.AddColumn<DateTime>(
                name: "DelTime",
                table: "amusingArticles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DelTime",
                table: "amusingArticles");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteTime",
                table: "amusingArticles",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
