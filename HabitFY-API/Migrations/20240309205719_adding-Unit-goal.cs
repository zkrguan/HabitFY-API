using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitFY_API.Migrations
{
    /// <inheritdoc />
    public partial class addingUnitgoal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Goals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Goals");
        }
    }
}
