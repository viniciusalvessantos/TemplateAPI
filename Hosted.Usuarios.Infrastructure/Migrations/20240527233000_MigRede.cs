using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hosted.Usuarios.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigRede : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAssinaturaActive",
                table: "Tenants");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tenants",
                newName: "Nome");

            migrationBuilder.AddColumn<string>(
                name: "Cnpj",
                table: "Tenants",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "RedeId",
                table: "Tenants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Tenants",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SobreNome",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "RedeTenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedeTenants", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_RedeId",
                table: "Tenants",
                column: "RedeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_RedeTenants_RedeId",
                table: "Tenants",
                column: "RedeId",
                principalTable: "RedeTenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_RedeTenants_RedeId",
                table: "Tenants");

            migrationBuilder.DropTable(
                name: "RedeTenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_RedeId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Cnpj",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "RedeId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SobreNome",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Tenants",
                newName: "Name");

            migrationBuilder.AddColumn<bool>(
                name: "IsAssinaturaActive",
                table: "Tenants",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
