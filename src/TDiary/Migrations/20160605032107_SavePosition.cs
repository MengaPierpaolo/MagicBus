using Microsoft.EntityFrameworkCore.Migrations;

namespace TDiary.Migrations
{
    public partial class SavePosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SavePosition",
                table: "Experiences",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SavePosition",
                table: "Experiences");
        }
    }
}
