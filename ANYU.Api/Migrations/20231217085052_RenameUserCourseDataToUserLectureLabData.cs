using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ANYU.Api.Migrations
{
    /// <inheritdoc />
    public partial class RenameUserCourseDataToUserLectureLabData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCompletedRequirement_UserCourseData_UserCourseDataUserId_UserCourseDataLectureLabId",
                table: "UserCompletedRequirement");

            migrationBuilder.DropTable(
                name: "UserCourseData");

            migrationBuilder.RenameColumn(
                name: "UserCourseDataUserId",
                table: "UserCompletedRequirement",
                newName: "UserLectureLabDataUserId");

            migrationBuilder.RenameColumn(
                name: "UserCourseDataLectureLabId",
                table: "UserCompletedRequirement",
                newName: "UserLectureLabDataLectureLabId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCompletedRequirement_UserCourseDataUserId_UserCourseDataLectureLabId",
                table: "UserCompletedRequirement",
                newName: "IX_UserCompletedRequirement_UserLectureLabDataUserId_UserLectureLabDataLectureLabId");

            migrationBuilder.CreateTable(
                name: "UserLectureLabData",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LectureLabId = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLectureLabData", x => new { x.UserId, x.LectureLabId });
                    table.ForeignKey(
                        name: "FK_UserLectureLabData_LectureLab_LectureLabId",
                        column: x => x.LectureLabId,
                        principalTable: "LectureLab",
                        principalColumn: "LectureLabId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserLectureLabData_User_LectureLabId",
                        column: x => x.LectureLabId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLectureLabData_LectureLabId",
                table: "UserLectureLabData",
                column: "LectureLabId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompletedRequirement_UserLectureLabData_UserLectureLabDataUserId_UserLectureLabDataLectureLabId",
                table: "UserCompletedRequirement",
                columns: new[] { "UserLectureLabDataUserId", "UserLectureLabDataLectureLabId" },
                principalTable: "UserLectureLabData",
                principalColumns: new[] { "UserId", "LectureLabId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCompletedRequirement_UserLectureLabData_UserLectureLabDataUserId_UserLectureLabDataLectureLabId",
                table: "UserCompletedRequirement");

            migrationBuilder.DropTable(
                name: "UserLectureLabData");

            migrationBuilder.RenameColumn(
                name: "UserLectureLabDataUserId",
                table: "UserCompletedRequirement",
                newName: "UserCourseDataUserId");

            migrationBuilder.RenameColumn(
                name: "UserLectureLabDataLectureLabId",
                table: "UserCompletedRequirement",
                newName: "UserCourseDataLectureLabId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCompletedRequirement_UserLectureLabDataUserId_UserLectureLabDataLectureLabId",
                table: "UserCompletedRequirement",
                newName: "IX_UserCompletedRequirement_UserCourseDataUserId_UserCourseDataLectureLabId");

            migrationBuilder.CreateTable(
                name: "UserCourseData",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LectureLabId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourseData", x => new { x.UserId, x.LectureLabId });
                    table.ForeignKey(
                        name: "FK_UserCourseData_LectureLab_LectureLabId",
                        column: x => x.LectureLabId,
                        principalTable: "LectureLab",
                        principalColumn: "LectureLabId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCourseData_User_LectureLabId",
                        column: x => x.LectureLabId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCourseData_LectureLabId",
                table: "UserCourseData",
                column: "LectureLabId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompletedRequirement_UserCourseData_UserCourseDataUserId_UserCourseDataLectureLabId",
                table: "UserCompletedRequirement",
                columns: new[] { "UserCourseDataUserId", "UserCourseDataLectureLabId" },
                principalTable: "UserCourseData",
                principalColumns: new[] { "UserId", "LectureLabId" });
        }
    }
}
