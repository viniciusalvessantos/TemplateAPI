using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hosted.Usuarios.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class usertenantassinature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAssinaturaActive",
                table: "Tenants",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAssinaturaActive",
                table: "Tenants");
        }
    }
}
