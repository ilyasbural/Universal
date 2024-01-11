using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Universal.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class retıertueıor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NetworkId",
                table: "NetworkDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "NetworkId",
                table: "NetworkComment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "NetworkId",
                table: "NetworkAction",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Network",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_NetworkDetail_NetworkId",
                table: "NetworkDetail",
                column: "NetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_NetworkComment_NetworkId",
                table: "NetworkComment",
                column: "NetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_NetworkAction_NetworkId",
                table: "NetworkAction",
                column: "NetworkId");

            migrationBuilder.AddForeignKey(
                name: "FK_NetworkAction_Network_NetworkId",
                table: "NetworkAction",
                column: "NetworkId",
                principalTable: "Network",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_NetworkComment_Network_NetworkId",
                table: "NetworkComment",
                column: "NetworkId",
                principalTable: "Network",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_NetworkDetail_Network_NetworkId",
                table: "NetworkDetail",
                column: "NetworkId",
                principalTable: "Network",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NetworkAction_Network_NetworkId",
                table: "NetworkAction");

            migrationBuilder.DropForeignKey(
                name: "FK_NetworkComment_Network_NetworkId",
                table: "NetworkComment");

            migrationBuilder.DropForeignKey(
                name: "FK_NetworkDetail_Network_NetworkId",
                table: "NetworkDetail");

            migrationBuilder.DropIndex(
                name: "IX_NetworkDetail_NetworkId",
                table: "NetworkDetail");

            migrationBuilder.DropIndex(
                name: "IX_NetworkComment_NetworkId",
                table: "NetworkComment");

            migrationBuilder.DropIndex(
                name: "IX_NetworkAction_NetworkId",
                table: "NetworkAction");

            migrationBuilder.DropColumn(
                name: "NetworkId",
                table: "NetworkDetail");

            migrationBuilder.DropColumn(
                name: "NetworkId",
                table: "NetworkComment");

            migrationBuilder.DropColumn(
                name: "NetworkId",
                table: "NetworkAction");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Network");
        }
    }
}
