using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace amusinghoS.EntityData.Migrations
{
    public partial class @base : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "amusingArticleDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "amusingArticleDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DelTime",
                table: "amusingArticleDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeleteId",
                table: "amusingArticleDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "amusingArticleDetails");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "amusingArticleDetails");

            migrationBuilder.DropColumn(
                name: "DelTime",
                table: "amusingArticleDetails");

            migrationBuilder.DropColumn(
                name: "DeleteId",
                table: "amusingArticleDetails");
        }
    }
}
