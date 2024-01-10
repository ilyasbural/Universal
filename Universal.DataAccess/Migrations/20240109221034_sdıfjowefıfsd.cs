using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Universal.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class sdıfjowefıfsd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserVideo",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserSettings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserReferance",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserPublish",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserProject",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserNetwork",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LanguageId",
                table: "UserLanguage",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserLanguage",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FollowerId",
                table: "UserFollower",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserFollower",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserExperience",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserEducation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserVideo_UserId",
                table: "UserVideo",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserType_UserId",
                table: "UserType",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_UserId",
                table: "UserSettings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReferance_UserId",
                table: "UserReferance",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPublish_UserId",
                table: "UserPublish",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProject_UserId",
                table: "UserProject",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNetwork_UserId",
                table: "UserNetwork",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguage_LanguageId",
                table: "UserLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguage_UserId",
                table: "UserLanguage",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFollower_FollowerId",
                table: "UserFollower",
                column: "FollowerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFollower_UserId",
                table: "UserFollower",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExperience_UserId",
                table: "UserExperience",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEducation_UserId",
                table: "UserEducation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetail_UserId",
                table: "UserDetail",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetail_User_UserId",
                table: "UserDetail",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEducation_User_UserId",
                table: "UserEducation",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExperience_User_UserId",
                table: "UserExperience",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollower_User_FollowerId",
                table: "UserFollower",
                column: "FollowerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollower_User_UserId",
                table: "UserFollower",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLanguage_Language_LanguageId",
                table: "UserLanguage",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLanguage_User_UserId",
                table: "UserLanguage",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNetwork_User_UserId",
                table: "UserNetwork",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProject_User_UserId",
                table: "UserProject",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPublish_User_UserId",
                table: "UserPublish",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserReferance_User_UserId",
                table: "UserReferance",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSettings_User_UserId",
                table: "UserSettings",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserType_User_UserId",
                table: "UserType",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVideo_User_UserId",
                table: "UserVideo",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetail_User_UserId",
                table: "UserDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEducation_User_UserId",
                table: "UserEducation");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExperience_User_UserId",
                table: "UserExperience");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollower_User_FollowerId",
                table: "UserFollower");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollower_User_UserId",
                table: "UserFollower");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLanguage_Language_LanguageId",
                table: "UserLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLanguage_User_UserId",
                table: "UserLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNetwork_User_UserId",
                table: "UserNetwork");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProject_User_UserId",
                table: "UserProject");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPublish_User_UserId",
                table: "UserPublish");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReferance_User_UserId",
                table: "UserReferance");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSettings_User_UserId",
                table: "UserSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserType_User_UserId",
                table: "UserType");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVideo_User_UserId",
                table: "UserVideo");

            migrationBuilder.DropIndex(
                name: "IX_UserVideo_UserId",
                table: "UserVideo");

            migrationBuilder.DropIndex(
                name: "IX_UserType_UserId",
                table: "UserType");

            migrationBuilder.DropIndex(
                name: "IX_UserSettings_UserId",
                table: "UserSettings");

            migrationBuilder.DropIndex(
                name: "IX_UserReferance_UserId",
                table: "UserReferance");

            migrationBuilder.DropIndex(
                name: "IX_UserPublish_UserId",
                table: "UserPublish");

            migrationBuilder.DropIndex(
                name: "IX_UserProject_UserId",
                table: "UserProject");

            migrationBuilder.DropIndex(
                name: "IX_UserNetwork_UserId",
                table: "UserNetwork");

            migrationBuilder.DropIndex(
                name: "IX_UserLanguage_LanguageId",
                table: "UserLanguage");

            migrationBuilder.DropIndex(
                name: "IX_UserLanguage_UserId",
                table: "UserLanguage");

            migrationBuilder.DropIndex(
                name: "IX_UserFollower_FollowerId",
                table: "UserFollower");

            migrationBuilder.DropIndex(
                name: "IX_UserFollower_UserId",
                table: "UserFollower");

            migrationBuilder.DropIndex(
                name: "IX_UserExperience_UserId",
                table: "UserExperience");

            migrationBuilder.DropIndex(
                name: "IX_UserEducation_UserId",
                table: "UserEducation");

            migrationBuilder.DropIndex(
                name: "IX_UserDetail_UserId",
                table: "UserDetail");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserVideo");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserType");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserSettings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserReferance");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserPublish");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserProject");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserNetwork");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "UserLanguage");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserLanguage");

            migrationBuilder.DropColumn(
                name: "FollowerId",
                table: "UserFollower");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserFollower");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserExperience");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserEducation");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserDetail");
        }
    }
}
