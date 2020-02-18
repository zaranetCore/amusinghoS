using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace amusinghoS.EntityData.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "amusingHosUsers",
                columns: table => new
                {
                    userId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 16, nullable: true),
                    PassWord = table.Column<string>(maxLength: 18, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amusingHosUsers", x => x.userId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "amusingHosUsers");
        }
    }
}
