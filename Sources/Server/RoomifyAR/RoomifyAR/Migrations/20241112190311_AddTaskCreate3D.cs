using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoomifyAR.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskCreate3D : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TaskId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Products");
        }
    }
}
