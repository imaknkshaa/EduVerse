using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_emailId",
                table: "Users",
                column: "emailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_mobileNumber",
                table: "Users",
                column: "mobileNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_emailId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_mobileNumber",
                table: "Users");
        }
    }
}
