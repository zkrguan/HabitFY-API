using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitFY_API.Migrations
{
    /// <inheritdoc />
    public partial class addingemailaddressuserprofile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Userprofiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Userprofiles");
        }
    }
}
