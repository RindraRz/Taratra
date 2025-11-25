using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taratra.Migrations
{
    /// <inheritdoc />
    public partial class ajout_de_proviseur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProviseurName",
                table: "Ecoles",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProviseurName",
                table: "Ecoles");
        }
    }
}
