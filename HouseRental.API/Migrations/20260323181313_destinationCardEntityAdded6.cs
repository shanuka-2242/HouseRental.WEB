using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRental.API.Migrations
{
    /// <inheritdoc />
    public partial class destinationCardEntityAdded6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DestinationCards",
                columns: table => new
                {
                    EntryID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardTitle = table.Column<string>(type: "TEXT", nullable: false),
                    CardDescription = table.Column<string>(type: "TEXT", nullable: false),
                    Distance = table.Column<string>(type: "TEXT", nullable: false),
                    CardImage = table.Column<byte[]>(type: "BLOB", nullable: false),
                    ImageContentType = table.Column<string>(type: "TEXT", nullable: false),
                    ImageFileName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinationCards", x => x.EntryID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DestinationCards");
        }
    }
}
