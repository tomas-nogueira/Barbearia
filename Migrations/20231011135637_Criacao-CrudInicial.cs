using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barbearia.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoCrudInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeService",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameService = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeService = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeService", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "TypeUser",
                columns: table => new
                {
                    TypeUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeNameUser = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeUser", x => x.TypeUserId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CpfUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CnpjUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeUserId = table.Column<int>(type: "int", nullable: false),
                    SenhaUser = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_TypeUser_TypeUserId",
                        column: x => x.TypeUserId,
                        principalTable: "TypeUser",
                        principalColumn: "TypeUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salao",
                columns: table => new
                {
                    SalaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSalao = table.Column<int>(type: "int", nullable: false),
                    CidadeSalao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RuaSalao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BairroSalao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CepSalao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salao", x => x.SalaoId);
                    table.ForeignKey(
                        name: "FK_Salao_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceSalao",
                columns: table => new
                {
                    ServiceSalaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaoId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    TypeServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceSalao", x => x.ServiceSalaoId);
                    table.ForeignKey(
                        name: "FK_ServiceSalao_Salao_SalaoId",
                        column: x => x.SalaoId,
                        principalTable: "Salao",
                        principalColumn: "SalaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceSalao_TypeService_TypeServiceId",
                        column: x => x.TypeServiceId,
                        principalTable: "TypeService",
                        principalColumn: "ServiceId");
                });

            migrationBuilder.CreateTable(
                name: "Agendamento",
                columns: table => new
                {
                    AgendamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HorarioAgendamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceSalaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.AgendamentoId);
                    table.ForeignKey(
                        name: "FK_Agendamento_ServiceSalao_ServiceSalaoId",
                        column: x => x.ServiceSalaoId,
                        principalTable: "ServiceSalao",
                        principalColumn: "ServiceSalaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_ServiceSalaoId",
                table: "Agendamento",
                column: "ServiceSalaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Salao_UserId",
                table: "Salao",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSalao_SalaoId",
                table: "ServiceSalao",
                column: "SalaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSalao_TypeServiceId",
                table: "ServiceSalao",
                column: "TypeServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_User_TypeUserId",
                table: "User",
                column: "TypeUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamento");

            migrationBuilder.DropTable(
                name: "ServiceSalao");

            migrationBuilder.DropTable(
                name: "Salao");

            migrationBuilder.DropTable(
                name: "TypeService");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "TypeUser");
        }
    }
}
