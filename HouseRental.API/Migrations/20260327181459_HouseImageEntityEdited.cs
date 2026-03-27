using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRental.API.Migrations
{
    /// <inheritdoc />
    public partial class HouseImageEntityEdited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CardImage",
                table: "HouseImages",
                newName: "Image");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "HouseImages",
                newName: "CardImage");
        }
    }
}
