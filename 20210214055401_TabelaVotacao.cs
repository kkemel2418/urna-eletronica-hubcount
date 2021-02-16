using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Urna.Migrations
{
    public partial class TabelaVotacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Votacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Candidato = table.Column<string>(nullable: true),
                    Data_Cadastro = table.Column<DateTime>(nullable: false),
                    CandidatosId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votacao_Candidatos_CandidatosId",
                        column: x => x.CandidatosId,
                        principalTable: "Candidatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votacao_CandidatosId",
                table: "Votacao",
                column: "CandidatosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votacao");
        }
    }
}
