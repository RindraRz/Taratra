using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taratra.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnneeScolaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(type: "TEXT", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateFin = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnneeScolaire", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eleves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Matricule = table.Column<string>(type: "TEXT", nullable: false),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", nullable: true),
                    DateNaissance = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Sexe = table.Column<char>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eleves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matiere",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    CodeMatiere = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matiere", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Periode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(type: "TEXT", nullable: false),
                    Ordre = table.Column<int>(type: "INTEGER", nullable: true),
                    Actif = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeEvaluation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    Ordre = table.Column<int>(type: "INTEGER", nullable: true),
                    Actif = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeEvaluation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inscription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EleveId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClasseId = table.Column<int>(type: "INTEGER", nullable: false),
                    AnneeScolaireId = table.Column<int>(type: "INTEGER", nullable: false),
                    Situation = table.Column<string>(type: "TEXT", nullable: true),
                    Option = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscription_AnneeScolaire_AnneeScolaireId",
                        column: x => x.AnneeScolaireId,
                        principalTable: "AnneeScolaire",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscription_Classe_ClasseId",
                        column: x => x.ClasseId,
                        principalTable: "Classe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscription_Eleves_EleveId",
                        column: x => x.EleveId,
                        principalTable: "Eleves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemeEvaluation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClasseId = table.Column<int>(type: "INTEGER", nullable: false),
                    MatiereId = table.Column<int>(type: "INTEGER", nullable: false),
                    TypeEvaluationId = table.Column<int>(type: "INTEGER", nullable: false),
                    Coefficient = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemeEvaluation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemeEvaluation_Classe_ClasseId",
                        column: x => x.ClasseId,
                        principalTable: "Classe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SystemeEvaluation_Matiere_MatiereId",
                        column: x => x.MatiereId,
                        principalTable: "Matiere",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SystemeEvaluation_TypeEvaluation_TypeEvaluationId",
                        column: x => x.TypeEvaluationId,
                        principalTable: "TypeEvaluation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EleveId = table.Column<int>(type: "INTEGER", nullable: false),
                    AnneeScolaireId = table.Column<int>(type: "INTEGER", nullable: false),
                    SystemeEvaluationId = table.Column<int>(type: "INTEGER", nullable: false),
                    PeriodeId = table.Column<int>(type: "INTEGER", nullable: false),
                    NoteObtenue = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Note_AnneeScolaire_AnneeScolaireId",
                        column: x => x.AnneeScolaireId,
                        principalTable: "AnneeScolaire",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Note_Eleves_EleveId",
                        column: x => x.EleveId,
                        principalTable: "Eleves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Note_Periode_PeriodeId",
                        column: x => x.PeriodeId,
                        principalTable: "Periode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Note_SystemeEvaluation_SystemeEvaluationId",
                        column: x => x.SystemeEvaluationId,
                        principalTable: "SystemeEvaluation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscription_AnneeScolaireId",
                table: "Inscription",
                column: "AnneeScolaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscription_ClasseId",
                table: "Inscription",
                column: "ClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscription_EleveId",
                table: "Inscription",
                column: "EleveId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_AnneeScolaireId",
                table: "Note",
                column: "AnneeScolaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_EleveId",
                table: "Note",
                column: "EleveId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_PeriodeId",
                table: "Note",
                column: "PeriodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_SystemeEvaluationId",
                table: "Note",
                column: "SystemeEvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemeEvaluation_ClasseId",
                table: "SystemeEvaluation",
                column: "ClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemeEvaluation_MatiereId",
                table: "SystemeEvaluation",
                column: "MatiereId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemeEvaluation_TypeEvaluationId",
                table: "SystemeEvaluation",
                column: "TypeEvaluationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscription");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "AnneeScolaire");

            migrationBuilder.DropTable(
                name: "Eleves");

            migrationBuilder.DropTable(
                name: "Periode");

            migrationBuilder.DropTable(
                name: "SystemeEvaluation");

            migrationBuilder.DropTable(
                name: "Classe");

            migrationBuilder.DropTable(
                name: "Matiere");

            migrationBuilder.DropTable(
                name: "TypeEvaluation");
        }
    }
}
