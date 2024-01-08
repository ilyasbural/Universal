using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Universal.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class sdfsdfertergdfgıjıjı : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CertificateId",
                table: "UserCertificate",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserCertificate",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserCertificate_CertificateId",
                table: "UserCertificate",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCertificate_UserId",
                table: "UserCertificate",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCertificate_Certificate_CertificateId",
                table: "UserCertificate",
                column: "CertificateId",
                principalTable: "Certificate",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCertificate_User_UserId",
                table: "UserCertificate",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCertificate_Certificate_CertificateId",
                table: "UserCertificate");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCertificate_User_UserId",
                table: "UserCertificate");

            migrationBuilder.DropIndex(
                name: "IX_UserCertificate_CertificateId",
                table: "UserCertificate");

            migrationBuilder.DropIndex(
                name: "IX_UserCertificate_UserId",
                table: "UserCertificate");

            migrationBuilder.DropColumn(
                name: "CertificateId",
                table: "UserCertificate");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserCertificate");
        }
    }
}
