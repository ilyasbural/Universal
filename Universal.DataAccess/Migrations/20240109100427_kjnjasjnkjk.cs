using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Universal.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class kjnjasjnkjk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserAbout",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserAbout_UserId",
                table: "UserAbout",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAbout_User_UserId",
                table: "UserAbout",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAbout_User_UserId",
                table: "UserAbout");

            migrationBuilder.DropIndex(
                name: "IX_UserAbout_UserId",
                table: "UserAbout");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserAbout");
        }
    }
}
