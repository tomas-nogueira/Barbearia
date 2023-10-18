using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barbearia.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_ServiceSalao_ServiceSalaoId",
                table: "Agendamento");

            migrationBuilder.RenameColumn(
                name: "ServiceSalaoId",
                table: "Agendamento",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamento_ServiceSalaoId",
                table: "Agendamento",
                newName: "IX_Agendamento_ServiceId");

            migrationBuilder.AddColumn<int>(
                name: "SalaoId",
                table: "Agendamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_SalaoId",
                table: "Agendamento",
                column: "SalaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Salao_SalaoId",
                table: "Agendamento",
                column: "SalaoId",
                principalTable: "Salao",
                principalColumn: "SalaoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Service_ServiceId",
                table: "Agendamento",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Salao_SalaoId",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Service_ServiceId",
                table: "Agendamento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_SalaoId",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "SalaoId",
                table: "Agendamento");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Agendamento",
                newName: "ServiceSalaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamento_ServiceId",
                table: "Agendamento",
                newName: "IX_Agendamento_ServiceSalaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_ServiceSalao_ServiceSalaoId",
                table: "Agendamento",
                column: "ServiceSalaoId",
                principalTable: "ServiceSalao",
                principalColumn: "ServiceSalaoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
