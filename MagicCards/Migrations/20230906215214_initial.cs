using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicCards.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    ColecaoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Ano = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    LogoUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.ColecaoId);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    IlustradorId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.IlustradorId);
                });

            migrationBuilder.CreateTable(
                name: "Carta",
                columns: table => new
                {
                    CartaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FotoUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ColecaoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IlustradorId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carta", x => x.CartaId);
                    table.ForeignKey(
                        name: "FK_Carta_Enrollment_ColecaoId",
                        column: x => x.ColecaoId,
                        principalTable: "Enrollment",
                        principalColumn: "ColecaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carta_Student_IlustradorId",
                        column: x => x.IlustradorId,
                        principalTable: "Student",
                        principalColumn: "IlustradorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carta_ColecaoId",
                table: "Carta",
                column: "ColecaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Carta_IlustradorId",
                table: "Carta",
                column: "IlustradorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carta");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
