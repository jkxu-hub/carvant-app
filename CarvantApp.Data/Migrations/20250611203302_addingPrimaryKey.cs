using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarvantApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Rename the old table
            migrationBuilder.Sql("ALTER TABLE Locations RENAME TO Locations_Old;");

            // 2. Create the new table with primary key
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    id = table.Column<string>(type: "INTEGER", nullable: false),
                    Zip = table.Column<string>(type: "INTEGER", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<string>(type: "TEXT", nullable: true),
                    County = table.Column<string>(type: "TEXT", nullable: true),
                    Latitude = table.Column<double>(type: "REAL", nullable: true),
                    Longtitude = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.id);
                });

            // 3. Copy data from old table
            migrationBuilder.Sql(@"
                INSERT INTO Locations (id, Zip, City, State, County, Latitude, Longtitude)
                SELECT CAST(id AS INTEGER), Zip, City, State, County, Latitude, Longtitude FROM Locations_Old;
            ");

            // 4. Drop old table
            migrationBuilder.Sql("DROP TABLE Locations_Old;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
