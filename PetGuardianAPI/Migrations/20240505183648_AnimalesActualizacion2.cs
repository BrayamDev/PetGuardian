using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetGuardianAPI.Migrations
{
    public partial class AnimalesActualizacion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_animales_tipoAnimal_tipoAnimalId",
                table: "animales");

            migrationBuilder.DropForeignKey(
                name: "FK_animales_vacunas_vacunasId",
                table: "animales");

            migrationBuilder.DropIndex(
                name: "IX_animales_tipoAnimalId",
                table: "animales");

            migrationBuilder.DropIndex(
                name: "IX_animales_vacunasId",
                table: "animales");

            migrationBuilder.AddColumn<int>(
                name: "adoptanteId",
                table: "animales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fundacionId",
                table: "animales",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "adoptanteId",
                table: "animales");

            migrationBuilder.DropColumn(
                name: "fundacionId",
                table: "animales");

            migrationBuilder.CreateIndex(
                name: "IX_animales_tipoAnimalId",
                table: "animales",
                column: "tipoAnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_animales_vacunasId",
                table: "animales",
                column: "vacunasId");

            migrationBuilder.AddForeignKey(
                name: "FK_animales_tipoAnimal_tipoAnimalId",
                table: "animales",
                column: "tipoAnimalId",
                principalTable: "tipoAnimal",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_animales_vacunas_vacunasId",
                table: "animales",
                column: "vacunasId",
                principalTable: "vacunas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
