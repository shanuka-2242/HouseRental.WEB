using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRental.API.Migrations
{
    /// <inheritdoc />
    public partial class databaseupdated2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FeaturesCards",
                table: "FeaturesCards");

            migrationBuilder.RenameTable(
                name: "FeaturesCards",
                newName: "FeatureCards");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeatureCards",
                table: "FeatureCards",
                column: "EntryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FeatureCards",
                table: "FeatureCards");

            migrationBuilder.RenameTable(
                name: "FeatureCards",
                newName: "FeaturesCards");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeaturesCards",
                table: "FeaturesCards",
                column: "EntryId");
        }
    }
}
