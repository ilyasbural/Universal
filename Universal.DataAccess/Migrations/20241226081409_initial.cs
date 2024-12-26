using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Universal.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ability",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ability", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Announce",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announce", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnnounceDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnounceDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnnounceLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Note = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnounceLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Certificate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "College",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_College", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyAbout",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAbout", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyFollower",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyFollower", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanySettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AutomaticEmail = table.Column<bool>(type: "BIT", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanySettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emoji",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emoji", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobPosting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPosting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Management",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Management", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManagementContacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementContacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManagementDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManagementEmail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementEmail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessageBox",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageBox", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Network",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Network", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Occupation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobPostingApply",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobPostingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPostingApply", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobPostingApply_JobPosting_JobPostingId",
                        column: x => x.JobPostingId,
                        principalTable: "JobPosting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "JobPostingDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobPostingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPostingDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobPostingDetail_JobPosting_JobPostingId",
                        column: x => x.JobPostingId,
                        principalTable: "JobPosting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "NetworkAction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NetworkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkAction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NetworkAction_Network_NetworkId",
                        column: x => x.NetworkId,
                        principalTable: "Network",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "NetworkComment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NetworkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NetworkComment_Network_NetworkId",
                        column: x => x.NetworkId,
                        principalTable: "Network",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "NetworkDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NetworkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NetworkDetail_Network_NetworkId",
                        column: x => x.NetworkId,
                        principalTable: "Network",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SurveyDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyDetail_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SurveyHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyHistory_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SurveyLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyLog_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserAbility",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AbilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAbility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAbility_Ability_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Ability",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserAbility_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserAbout",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAbout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAbout_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserCertificate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CertificateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCertificate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCertificate_Certificate_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserCertificate_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserCountry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCountry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCountry_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserCountry_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDetail_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserEducation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEducation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEducation_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserExperience",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExperience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserExperience_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserFollower",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FollowerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFollower", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFollower_User_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserFollower_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserLanguage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLanguage_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserLanguage_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserNetwork",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNetwork", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNetwork_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserProject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProject_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserPublish",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPublish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPublish_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserReferance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReferance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserReferance_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSettings_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserType_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserVideo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVideo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserVideo_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobPostingApply_JobPostingId",
                table: "JobPostingApply",
                column: "JobPostingId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPostingDetail_JobPostingId",
                table: "JobPostingDetail",
                column: "JobPostingId");

            migrationBuilder.CreateIndex(
                name: "IX_NetworkAction_NetworkId",
                table: "NetworkAction",
                column: "NetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_NetworkComment_NetworkId",
                table: "NetworkComment",
                column: "NetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_NetworkDetail_NetworkId",
                table: "NetworkDetail",
                column: "NetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyDetail_SurveyId",
                table: "SurveyDetail",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyHistory_SurveyId",
                table: "SurveyHistory",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyLog_SurveyId",
                table: "SurveyLog",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAbility_AbilityId",
                table: "UserAbility",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAbility_UserId",
                table: "UserAbility",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAbout_UserId",
                table: "UserAbout",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCertificate_CertificateId",
                table: "UserCertificate",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCertificate_UserId",
                table: "UserCertificate",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCountry_CountryId",
                table: "UserCountry",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCountry_UserId",
                table: "UserCountry",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetail_UserId",
                table: "UserDetail",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEducation_UserId",
                table: "UserEducation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExperience_UserId",
                table: "UserExperience",
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
                name: "IX_UserLanguage_LanguageId",
                table: "UserLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguage_UserId",
                table: "UserLanguage",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNetwork_UserId",
                table: "UserNetwork",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProject_UserId",
                table: "UserProject",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPublish_UserId",
                table: "UserPublish",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReferance_UserId",
                table: "UserReferance",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_UserId",
                table: "UserSettings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserType_UserId",
                table: "UserType",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVideo_UserId",
                table: "UserVideo",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announce");

            migrationBuilder.DropTable(
                name: "AnnounceDetail");

            migrationBuilder.DropTable(
                name: "AnnounceLog");

            migrationBuilder.DropTable(
                name: "College");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "CompanyAbout");

            migrationBuilder.DropTable(
                name: "CompanyDetail");

            migrationBuilder.DropTable(
                name: "CompanyFollower");

            migrationBuilder.DropTable(
                name: "CompanySettings");

            migrationBuilder.DropTable(
                name: "Emoji");

            migrationBuilder.DropTable(
                name: "JobPostingApply");

            migrationBuilder.DropTable(
                name: "JobPostingDetail");

            migrationBuilder.DropTable(
                name: "Management");

            migrationBuilder.DropTable(
                name: "ManagementContacts");

            migrationBuilder.DropTable(
                name: "ManagementDetail");

            migrationBuilder.DropTable(
                name: "ManagementEmail");

            migrationBuilder.DropTable(
                name: "MessageBox");

            migrationBuilder.DropTable(
                name: "NetworkAction");

            migrationBuilder.DropTable(
                name: "NetworkComment");

            migrationBuilder.DropTable(
                name: "NetworkDetail");

            migrationBuilder.DropTable(
                name: "Occupation");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "SurveyDetail");

            migrationBuilder.DropTable(
                name: "SurveyHistory");

            migrationBuilder.DropTable(
                name: "SurveyLog");

            migrationBuilder.DropTable(
                name: "UserAbility");

            migrationBuilder.DropTable(
                name: "UserAbout");

            migrationBuilder.DropTable(
                name: "UserCertificate");

            migrationBuilder.DropTable(
                name: "UserCountry");

            migrationBuilder.DropTable(
                name: "UserDetail");

            migrationBuilder.DropTable(
                name: "UserEducation");

            migrationBuilder.DropTable(
                name: "UserExperience");

            migrationBuilder.DropTable(
                name: "UserFollower");

            migrationBuilder.DropTable(
                name: "UserLanguage");

            migrationBuilder.DropTable(
                name: "UserNetwork");

            migrationBuilder.DropTable(
                name: "UserProject");

            migrationBuilder.DropTable(
                name: "UserPublish");

            migrationBuilder.DropTable(
                name: "UserReferance");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropTable(
                name: "UserVideo");

            migrationBuilder.DropTable(
                name: "JobPosting");

            migrationBuilder.DropTable(
                name: "Network");

            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropTable(
                name: "Ability");

            migrationBuilder.DropTable(
                name: "Certificate");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
