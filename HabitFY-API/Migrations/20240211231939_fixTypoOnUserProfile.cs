using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitFY_API.Migrations
{
    /// <inheritdoc />
    public partial class fixTypoOnUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "needReport",
                table: "Userprofiles",
                newName: "NeedReport");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NeedReport",
                table: "Userprofiles",
                newName: "needReport");
        }
    }
}
