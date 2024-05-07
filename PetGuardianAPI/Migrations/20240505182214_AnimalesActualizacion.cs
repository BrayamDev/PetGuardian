using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetGuardianAPI.Migrations
{
    public partial class AnimalesActualizacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_animales_tipoAnimal_tipoAnimalid",
                table: "animales");

            migrationBuilder.DropForeignKey(
                name: "FK_animales_vacunas_vacunasid",
                table: "animales");

            migrationBuilder.RenameColumn(
                name: "vacunasid",
                table: "animales",
                newName: "vacunasId");

            migrationBuilder.RenameColumn(
                name: "tipoAnimalid",
                table: "animales",
                newName: "tipoAnimalId");

            migrationBuilder.RenameIndex(
                name: "IX_animales_vacunasid",
                table: "animales",
                newName: "IX_animales_vacunasId");

            migrationBuilder.RenameIndex(
                name: "IX_animales_tipoAnimalid",
                table: "animales",
                newName: "IX_animales_tipoAnimalId");

            migrationBuilder.AlterColumn<int>(
                name: "vacunasId",
                table: "animales",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "tipoAnimalId",
                table: "animales",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_animales_tipoAnimal_tipoAnimalId",
                table: "animales");

            migrationBuilder.DropForeignKey(
                name: "FK_animales_vacunas_vacunasId",
                table: "animales");

            migrationBuilder.RenameColumn(
                name: "vacunasId",
                table: "animales",
                newName: "vacunasid");

            migrationBuilder.RenameColumn(
                name: "tipoAnimalId",
                table: "animales",
                newName: "tipoAnimalid");

            migrationBuilder.RenameIndex(
                name: "IX_animales_vacunasId",
                table: "animales",
                newName: "IX_animales_vacunasid");

            migrationBuilder.RenameIndex(
                name: "IX_animales_tipoAnimalId",
                table: "animales",
                newName: "IX_animales_tipoAnimalid");

            migrationBuilder.AlterColumn<int>(
                name: "vacunasid",
                table: "animales",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "tipoAnimalid",
                table: "animales",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_animales_tipoAnimal_tipoAnimalid",
                table: "animales",
                column: "tipoAnimalid",
                principalTable: "tipoAnimal",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_animales_vacunas_vacunasid",
                table: "animales",
                column: "vacunasid",
                principalTable: "vacunas",
                principalColumn: "id");
        }
    }
}
