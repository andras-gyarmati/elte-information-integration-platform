using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ANYU.Api.Migrations
{
    /// <inheritdoc />
    public partial class MakeCourseCodeUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Course_Code",
                table: "Course",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Course_Code",
                table: "Course");
        }
    }
}
