using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelRez.Migrations
{
    /// <inheritdoc />
    public partial class CityNameAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "WeatherEntries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "WeatherEntries");
        }
    }
}
