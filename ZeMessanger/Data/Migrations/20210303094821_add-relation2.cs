using Microsoft.EntityFrameworkCore.Migrations;

namespace ZeMessanger.Data.Migrations
{
    public partial class addrelation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notis_AspNetUsers_SenderId",
                table: "Notis");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Notis",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Notis_SenderId",
                table: "Notis",
                newName: "IX_Notis_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Notis_AspNetUsers_UserID",
                table: "Notis",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notis_AspNetUsers_UserID",
                table: "Notis");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Notis",
                newName: "SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Notis_UserID",
                table: "Notis",
                newName: "IX_Notis_SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notis_AspNetUsers_SenderId",
                table: "Notis",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
