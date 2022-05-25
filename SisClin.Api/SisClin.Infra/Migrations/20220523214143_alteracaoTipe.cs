using Microsoft.EntityFrameworkCore.Migrations;

namespace SisClin.Infra.Migrations
{
    public partial class alteracaoTipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employers_Tipes_TipeId",
                table: "Employers");

            migrationBuilder.DropIndex(
                name: "IX_Employers_TipeId",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "TipeId",
                table: "Employers");

            migrationBuilder.AddColumn<int>(
                name: "EmployerId",
                table: "Tipes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tipes_EmployerId",
                table: "Tipes",
                column: "EmployerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tipes_Employers_EmployerId",
                table: "Tipes",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "EmployerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tipes_Employers_EmployerId",
                table: "Tipes");

            migrationBuilder.DropIndex(
                name: "IX_Tipes_EmployerId",
                table: "Tipes");

            migrationBuilder.DropColumn(
                name: "EmployerId",
                table: "Tipes");

            migrationBuilder.AddColumn<int>(
                name: "TipeId",
                table: "Employers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employers_TipeId",
                table: "Employers",
                column: "TipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employers_Tipes_TipeId",
                table: "Employers",
                column: "TipeId",
                principalTable: "Tipes",
                principalColumn: "TipeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
