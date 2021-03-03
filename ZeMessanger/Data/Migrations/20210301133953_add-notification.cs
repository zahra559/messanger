using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZeMessanger.Data.Migrations
{
    public partial class addnotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notis",
                columns: table => new
                {
                    NotiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotiHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotiBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notis", x => x.NotiId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notis");
        }
    }
}
