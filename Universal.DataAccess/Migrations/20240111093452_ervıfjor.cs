using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Universal.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ervıfjor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "JobPostingId",
                table: "JobPostingDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "JobPostingId",
                table: "JobPostingApply",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "JobPosting",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_JobPostingDetail_JobPostingId",
                table: "JobPostingDetail",
                column: "JobPostingId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPostingApply_JobPostingId",
                table: "JobPostingApply",
                column: "JobPostingId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostingApply_JobPosting_JobPostingId",
                table: "JobPostingApply",
                column: "JobPostingId",
                principalTable: "JobPosting",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostingDetail_JobPosting_JobPostingId",
                table: "JobPostingDetail",
                column: "JobPostingId",
                principalTable: "JobPosting",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPostingApply_JobPosting_JobPostingId",
                table: "JobPostingApply");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPostingDetail_JobPosting_JobPostingId",
                table: "JobPostingDetail");

            migrationBuilder.DropIndex(
                name: "IX_JobPostingDetail_JobPostingId",
                table: "JobPostingDetail");

            migrationBuilder.DropIndex(
                name: "IX_JobPostingApply_JobPostingId",
                table: "JobPostingApply");

            migrationBuilder.DropColumn(
                name: "JobPostingId",
                table: "JobPostingDetail");

            migrationBuilder.DropColumn(
                name: "JobPostingId",
                table: "JobPostingApply");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "JobPosting");
        }
    }
}
