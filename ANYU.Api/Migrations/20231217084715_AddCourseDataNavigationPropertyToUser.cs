using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ANYU.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseDataNavigationPropertyToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseData_User_UserId",
                table: "UserCourseData");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseData_User_LectureLabId",
                table: "UserCourseData",
                column: "LectureLabId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseData_User_LectureLabId",
                table: "UserCourseData");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseData_User_UserId",
                table: "UserCourseData",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
