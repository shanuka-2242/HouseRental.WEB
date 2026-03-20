using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRental.API.Migrations
{
    /// <inheritdoc />
    public partial class featurecardmodelchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FeatureCardTitle",
                table: "FeatureCards",
                newName: "CardTitle");

            migrationBuilder.RenameColumn(
                name: "FeatureCardImage",
                table: "FeatureCards",
                newName: "CardImage");

            migrationBuilder.RenameColumn(
                name: "FeatureCardDescription",
                table: "FeatureCards",
                newName: "CardDescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CardTitle",
                table: "FeatureCards",
                newName: "FeatureCardTitle");

            migrationBuilder.RenameColumn(
                name: "CardImage",
                table: "FeatureCards",
                newName: "FeatureCardImage");

            migrationBuilder.RenameColumn(
                name: "CardDescription",
                table: "FeatureCards",
                newName: "FeatureCardDescription");
        }
    }
}
