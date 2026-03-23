using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRental.API.Migrations
{
    /// <inheritdoc />
    public partial class FeaturcardEntiyChangedAddedImageContentType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageContentType",
                table: "FeatureCards",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "FeatureCards",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageContentType",
                table: "FeatureCards");

            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "FeatureCards");
        }
    }
}
