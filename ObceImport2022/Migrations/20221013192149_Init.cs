using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObceImport2022.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    LAU1 = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NUTS3 = table.Column<string>(type: "nvarchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.LAU1);
                });

            migrationBuilder.CreateTable(
                name: "Municipalities",
                columns: table => new
                {
                    LAU2 = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LAU1 = table.Column<string>(type: "nvarchar(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalities", x => x.LAU2);
                    table.ForeignKey(
                        name: "FK_Municipalities_Districts_LAU1",
                        column: x => x.LAU1,
                        principalTable: "Districts",
                        principalColumn: "LAU1",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Populations",
                columns: table => new
                {
                    LAU2 = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Men = table.Column<int>(type: "int", nullable: false),
                    Women = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<double>(type: "float", nullable: false),
                    MensAge = table.Column<double>(type: "float", nullable: false),
                    WomensAge = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Populations", x => new { x.LAU2, x.Year });
                    table.ForeignKey(
                        name: "FK_Populations_Municipalities_LAU2",
                        column: x => x.LAU2,
                        principalTable: "Municipalities",
                        principalColumn: "LAU2",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    NUTS3 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LAU2 = table.Column<string>(type: "nvarchar(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.NUTS3);
                    table.ForeignKey(
                        name: "FK_Regions_Municipalities_LAU2",
                        column: x => x.LAU2,
                        principalTable: "Municipalities",
                        principalColumn: "LAU2",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Districts_NUTS3",
                table: "Districts",
                column: "NUTS3");

            migrationBuilder.CreateIndex(
                name: "IX_Municipalities_LAU1",
                table: "Municipalities",
                column: "LAU1");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_LAU2",
                table: "Regions",
                column: "LAU2",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Regions_NUTS3",
                table: "Districts",
                column: "NUTS3",
                principalTable: "Regions",
                principalColumn: "NUTS3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Regions_NUTS3",
                table: "Districts");

            migrationBuilder.DropTable(
                name: "Populations");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Municipalities");

            migrationBuilder.DropTable(
                name: "Districts");
        }
    }
}
