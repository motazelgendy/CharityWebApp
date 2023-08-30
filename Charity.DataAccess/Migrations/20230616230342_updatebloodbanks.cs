using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Charity.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updatebloodbanks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bloodBanks_AspNetUsers_AppUserId",
                table: "bloodBanks");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "bloodBanks",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_bloodBanks_AppUserId",
                table: "bloodBanks",
                newName: "IX_bloodBanks_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_bloodBanks_AspNetUsers_UserId",
                table: "bloodBanks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bloodBanks_AspNetUsers_UserId",
                table: "bloodBanks");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "bloodBanks",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_bloodBanks_UserId",
                table: "bloodBanks",
                newName: "IX_bloodBanks_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_bloodBanks_AspNetUsers_AppUserId",
                table: "bloodBanks",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
