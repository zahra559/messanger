using Microsoft.EntityFrameworkCore.Migrations;

namespace ZeMessanger.Data.Migrations
{
    public partial class addReceiver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RceiverId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RcreiverName",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RceiverId",
                table: "Messages",
                column: "RceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_RceiverId",
                table: "Messages",
                column: "RceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_RceiverId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_RceiverId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "RceiverId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "RcreiverName",
                table: "Messages");
        }
    }
}
