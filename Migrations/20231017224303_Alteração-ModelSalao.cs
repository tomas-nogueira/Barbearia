using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barbearia.Migrations
{
    /// <inheritdoc />
    public partial class AlteraçãoModelSalao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumeroSalao",
                table: "Salao",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroSalao",
                table: "Salao");
        }
    }
}
