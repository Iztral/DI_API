using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtistID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tracks_Artists_ArtistID",
                        column: x => x.ArtistID,
                        principalTable: "Artists",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Metallica" },
                    { 2, "Led Zeppelin" },
                    { 3, "ACDC" },
                    { 4, "Panthera" },
                    { 5, "Motorhead" }
                });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "ID", "ArtistID", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Master of Puppets" },
                    { 2, 2, "Satairway to Heaven" },
                    { 3, 3, "Back in Black" },
                    { 4, 4, "Walk" },
                    { 5, 5, "Ace of Spades" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_ArtistID",
                table: "Tracks",
                column: "ArtistID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
