using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ANYU.Api.Migrations
{
    /// <inheritdoc />
    public partial class ConnectUserDataPassReqToLectureLabInsteadOfCourseInstance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCompletedRequirement_UserCourseData_UserCourseDataUserId_UserCourseDataCourseInstanceId",
                table: "UserCompletedRequirement");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseData_CourseInstance_CourseInstanceId",
                table: "UserCourseData");

            migrationBuilder.RenameColumn(
                name: "CourseInstanceId",
                table: "UserCourseData",
                newName: "LectureLabId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCourseData_CourseInstanceId",
                table: "UserCourseData",
                newName: "IX_UserCourseData_LectureLabId");

            migrationBuilder.RenameColumn(
                name: "UserCourseDataCourseInstanceId",
                table: "UserCompletedRequirement",
                newName: "UserCourseDataLectureLabId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCompletedRequirement_UserCourseDataUserId_UserCourseDataCourseInstanceId",
                table: "UserCompletedRequirement",
                newName: "IX_UserCompletedRequirement_UserCourseDataUserId_UserCourseDataLectureLabId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "PassingRequirement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MaxScore",
                table: "PassingRequirement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PassingRequirement",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "PassingRequirement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "PassingRequirement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompletedRequirement_UserCourseData_UserCourseDataUserId_UserCourseDataLectureLabId",
                table: "UserCompletedRequirement",
                columns: new[] { "UserCourseDataUserId", "UserCourseDataLectureLabId" },
                principalTable: "UserCourseData",
                principalColumns: new[] { "UserId", "LectureLabId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseData_LectureLab_LectureLabId",
                table: "UserCourseData",
                column: "LectureLabId",
                principalTable: "LectureLab",
                principalColumn: "LectureLabId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCompletedRequirement_UserCourseData_UserCourseDataUserId_UserCourseDataLectureLabId",
                table: "UserCompletedRequirement");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseData_LectureLab_LectureLabId",
                table: "UserCourseData");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "PassingRequirement");

            migrationBuilder.DropColumn(
                name: "MaxScore",
                table: "PassingRequirement");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PassingRequirement");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "PassingRequirement");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "PassingRequirement");

            migrationBuilder.RenameColumn(
                name: "LectureLabId",
                table: "UserCourseData",
                newName: "CourseInstanceId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCourseData_LectureLabId",
                table: "UserCourseData",
                newName: "IX_UserCourseData_CourseInstanceId");

            migrationBuilder.RenameColumn(
                name: "UserCourseDataLectureLabId",
                table: "UserCompletedRequirement",
                newName: "UserCourseDataCourseInstanceId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCompletedRequirement_UserCourseDataUserId_UserCourseDataLectureLabId",
                table: "UserCompletedRequirement",
                newName: "IX_UserCompletedRequirement_UserCourseDataUserId_UserCourseDataCourseInstanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompletedRequirement_UserCourseData_UserCourseDataUserId_UserCourseDataCourseInstanceId",
                table: "UserCompletedRequirement",
                columns: new[] { "UserCourseDataUserId", "UserCourseDataCourseInstanceId" },
                principalTable: "UserCourseData",
                principalColumns: new[] { "UserId", "CourseInstanceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseData_CourseInstance_CourseInstanceId",
                table: "UserCourseData",
                column: "CourseInstanceId",
                principalTable: "CourseInstance",
                principalColumn: "CourseInstanceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
