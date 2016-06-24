using Microsoft.EntityFrameworkCore.Migrations;

namespace TDiary.Migrations
{
    public partial class Rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Experiences",
                nullable: false,
                defaultValue: TDiary.Model.Rating.Indifferent);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Experiences");
        }
    }
}
