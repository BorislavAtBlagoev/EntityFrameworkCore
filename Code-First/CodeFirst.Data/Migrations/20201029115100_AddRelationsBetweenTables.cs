using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirst.Data.Migrations
{
    public partial class AddRelationsBetweenTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Patients_PatientId",
                table: "Diagnoses");

            migrationBuilder.DropColumn(
                name: "PatiantId",
                table: "Diagnoses");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Diagnoses",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_Patients_PatientId",
                table: "Diagnoses",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Patients_PatientId",
                table: "Diagnoses");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Diagnoses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PatiantId",
                table: "Diagnoses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_Patients_PatientId",
                table: "Diagnoses",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
