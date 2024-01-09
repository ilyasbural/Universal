using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Universal.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class kjnjasjnkjkjjkhjk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "UserCountry",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserCountry",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserCountry_CountryId",
                table: "UserCountry",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCountry_UserId",
                table: "UserCountry",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCountry_Country_CountryId",
                table: "UserCountry",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCountry_User_UserId",
                table: "UserCountry",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCountry_Country_CountryId",
                table: "UserCountry");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCountry_User_UserId",
                table: "UserCountry");

            migrationBuilder.DropIndex(
                name: "IX_UserCountry_CountryId",
                table: "UserCountry");

            migrationBuilder.DropIndex(
                name: "IX_UserCountry_UserId",
                table: "UserCountry");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "UserCountry");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserCountry");
        }
    }
}
