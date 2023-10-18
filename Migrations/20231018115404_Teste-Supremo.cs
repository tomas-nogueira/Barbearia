using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barbearia.Migrations
{
    /// <inheritdoc />
    public partial class TesteSupremo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceSalao_TypeService_TypeServiceId",
                table: "ServiceSalao");

            migrationBuilder.DropTable(
                name: "TypeService");

            migrationBuilder.DropIndex(
                name: "IX_ServiceSalao_TypeServiceId",
                table: "ServiceSalao");

            migrationBuilder.DropColumn(
                name: "TypeServiceId",
                table: "ServiceSalao");

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameService = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeService = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSalao_ServiceId",
                table: "ServiceSalao",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceSalao_Service_ServiceId",
                table: "ServiceSalao",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceSalao_Service_ServiceId",
                table: "ServiceSalao");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropIndex(
                name: "IX_ServiceSalao_ServiceId",
                table: "ServiceSalao");

            migrationBuilder.AddColumn<int>(
                name: "TypeServiceId",
                table: "ServiceSalao",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSalao_TypeServiceId",
                table: "ServiceSalao",
                column: "TypeServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceSalao_TypeService_TypeServiceId",
                table: "ServiceSalao",
                column: "TypeServiceId",
                principalTable: "TypeService",
                principalColumn: "ServiceId");
        }
    }
}
