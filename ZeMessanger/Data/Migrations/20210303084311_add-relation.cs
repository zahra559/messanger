using Microsoft.EntityFrameworkCore.Migrations;

namespace ZeMessanger.Data.Migrations
{
    public partial class addrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SenderId",
                table: "Notis",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notis_SenderId",
                table: "Notis",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notis_AspNetUsers_SenderId",
                table: "Notis",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notis_AspNetUsers_SenderId",
                table: "Notis");

            migrationBuilder.DropIndex(
                name: "IX_Notis_SenderId",
                table: "Notis");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Notis");
        }
    }
}
