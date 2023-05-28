using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheBigBang.Migrations.BookingDb
{
    /// <inheritdoc />
    public partial class Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Hid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hcity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hprice = table.Column<int>(type: "int", nullable: false),
                    Hrating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Hid);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Rid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rtype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vacancy = table.Column<bool>(type: "bit", nullable: false),
                    Hid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Rid);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_Hid",
                        column: x => x.Hid,
                        principalTable: "Hotels",
                        principalColumn: "Hid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Hid",
                table: "Rooms",
                column: "Hid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
