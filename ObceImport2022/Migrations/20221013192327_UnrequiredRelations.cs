using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObceImport2022.Migrations
{
    public partial class UnrequiredRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Regions_LAU2",
                table: "Regions");

            migrationBuilder.AlterColumn<string>(
                name: "LAU2",
                table: "Regions",
                type: "nvarchar(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_LAU2",
                table: "Regions",
                column: "LAU2",
                unique: true,
                filter: "[LAU2] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Regions_LAU2",
                table: "Regions");

            migrationBuilder.AlterColumn<string>(
                name: "LAU2",
                table: "Regions",
                type: "nvarchar(6)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Regions_LAU2",
                table: "Regions",
                column: "LAU2",
                unique: true);
        }
    }
}
