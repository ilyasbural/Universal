using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Universal.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class sdfsıofjewfewıof : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AbilityId",
                table: "UserAbility",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserAbility",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserAbility_AbilityId",
                table: "UserAbility",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAbility_UserId",
                table: "UserAbility",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAbility_Ability_AbilityId",
                table: "UserAbility",
                column: "AbilityId",
                principalTable: "Ability",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAbility_User_UserId",
                table: "UserAbility",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAbility_Ability_AbilityId",
                table: "UserAbility");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAbility_User_UserId",
                table: "UserAbility");

            migrationBuilder.DropIndex(
                name: "IX_UserAbility_AbilityId",
                table: "UserAbility");

            migrationBuilder.DropIndex(
                name: "IX_UserAbility_UserId",
                table: "UserAbility");

            migrationBuilder.DropColumn(
                name: "AbilityId",
                table: "UserAbility");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserAbility");
        }
    }
}
