using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Universal.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class retıertueıorouopu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SurveyId",
                table: "SurveyLog",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SurveyId",
                table: "SurveyHistory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SurveyId",
                table: "SurveyDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Survey",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyLog_SurveyId",
                table: "SurveyLog",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyHistory_SurveyId",
                table: "SurveyHistory",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyDetail_SurveyId",
                table: "SurveyDetail",
                column: "SurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyDetail_Survey_SurveyId",
                table: "SurveyDetail",
                column: "SurveyId",
                principalTable: "Survey",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyHistory_Survey_SurveyId",
                table: "SurveyHistory",
                column: "SurveyId",
                principalTable: "Survey",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyLog_Survey_SurveyId",
                table: "SurveyLog",
                column: "SurveyId",
                principalTable: "Survey",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyDetail_Survey_SurveyId",
                table: "SurveyDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyHistory_Survey_SurveyId",
                table: "SurveyHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyLog_Survey_SurveyId",
                table: "SurveyLog");

            migrationBuilder.DropIndex(
                name: "IX_SurveyLog_SurveyId",
                table: "SurveyLog");

            migrationBuilder.DropIndex(
                name: "IX_SurveyHistory_SurveyId",
                table: "SurveyHistory");

            migrationBuilder.DropIndex(
                name: "IX_SurveyDetail_SurveyId",
                table: "SurveyDetail");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "SurveyLog");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "SurveyHistory");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "SurveyDetail");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Survey");
        }
    }
}
