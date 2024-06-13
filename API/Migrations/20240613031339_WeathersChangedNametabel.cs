using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class WeathersChangedNametabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_wetherDetails_cities_cityId",
                table: "wetherDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_wetherDetails_Weathers_weatherId",
                table: "wetherDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_wetherDetails",
                table: "wetherDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cities",
                table: "cities");

            migrationBuilder.RenameTable(
                name: "wetherDetails",
                newName: "WetherDetails");

            migrationBuilder.RenameTable(
                name: "cities",
                newName: "Cities");

            migrationBuilder.RenameIndex(
                name: "IX_wetherDetails_weatherId",
                table: "WetherDetails",
                newName: "IX_WetherDetails_weatherId");

            migrationBuilder.RenameIndex(
                name: "IX_wetherDetails_cityId",
                table: "WetherDetails",
                newName: "IX_WetherDetails_cityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WetherDetails",
                table: "WetherDetails",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_WetherDetails_Cities_cityId",
                table: "WetherDetails",
                column: "cityId",
                principalTable: "Cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WetherDetails_Weathers_weatherId",
                table: "WetherDetails",
                column: "weatherId",
                principalTable: "Weathers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WetherDetails_Cities_cityId",
                table: "WetherDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_WetherDetails_Weathers_weatherId",
                table: "WetherDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WetherDetails",
                table: "WetherDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.RenameTable(
                name: "WetherDetails",
                newName: "wetherDetails");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "cities");

            migrationBuilder.RenameIndex(
                name: "IX_WetherDetails_weatherId",
                table: "wetherDetails",
                newName: "IX_wetherDetails_weatherId");

            migrationBuilder.RenameIndex(
                name: "IX_WetherDetails_cityId",
                table: "wetherDetails",
                newName: "IX_wetherDetails_cityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_wetherDetails",
                table: "wetherDetails",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cities",
                table: "cities",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_wetherDetails_cities_cityId",
                table: "wetherDetails",
                column: "cityId",
                principalTable: "cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_wetherDetails_Weathers_weatherId",
                table: "wetherDetails",
                column: "weatherId",
                principalTable: "Weathers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
