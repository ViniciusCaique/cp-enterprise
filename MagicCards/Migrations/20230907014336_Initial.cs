using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicCards.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carta_Colecoes_IlustradorId",
                table: "Carta");

            migrationBuilder.DropForeignKey(
                name: "FK_Carta_Ilustradores_ColecaoId",
                table: "Carta");

            migrationBuilder.DropColumn(
                name: "Ano",
                table: "Ilustradores");

            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Ilustradores");

            migrationBuilder.RenameColumn(
                name: "ColecaoId",
                table: "Ilustradores",
                newName: "IlustradorId");

            migrationBuilder.RenameColumn(
                name: "IlustradorId",
                table: "Colecoes",
                newName: "ColecaoId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Ano",
                table: "Colecoes",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Colecoes",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Carta_Colecoes_ColecaoId",
                table: "Carta",
                column: "ColecaoId",
                principalTable: "Colecoes",
                principalColumn: "ColecaoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carta_Ilustradores_IlustradorId",
                table: "Carta",
                column: "IlustradorId",
                principalTable: "Ilustradores",
                principalColumn: "IlustradorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carta_Colecoes_ColecaoId",
                table: "Carta");

            migrationBuilder.DropForeignKey(
                name: "FK_Carta_Ilustradores_IlustradorId",
                table: "Carta");

            migrationBuilder.DropColumn(
                name: "Ano",
                table: "Colecoes");

            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Colecoes");

            migrationBuilder.RenameColumn(
                name: "IlustradorId",
                table: "Ilustradores",
                newName: "ColecaoId");

            migrationBuilder.RenameColumn(
                name: "ColecaoId",
                table: "Colecoes",
                newName: "IlustradorId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Ano",
                table: "Ilustradores",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Ilustradores",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Carta_Colecoes_IlustradorId",
                table: "Carta",
                column: "IlustradorId",
                principalTable: "Colecoes",
                principalColumn: "IlustradorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carta_Ilustradores_ColecaoId",
                table: "Carta",
                column: "ColecaoId",
                principalTable: "Ilustradores",
                principalColumn: "ColecaoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
