using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.WebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Matricula = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataNasc = table.Column<DateTime>(nullable: false),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Registro = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenonome = table.Column<string>(nullable: true),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunoCurso",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoCurso", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunoCurso_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoCurso_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    CargaHoraria = table.Column<int>(nullable: false),
                    PreRequisitoId = table.Column<int>(nullable: true),
                    ProfessorId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Disciplinas_PreRequisitoId",
                        column: x => x.PreRequisitoId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunosDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    DisciplinaId = table.Column<int>(nullable: false),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: true),
                    Nota = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 1, true, null, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(1541), new DateTime(1993, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Marta", "Kent", "33225555" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 2, true, null, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(3185), new DateTime(1993, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Paula", "Isabela", "3354288" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 3, true, null, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(3246), new DateTime(1993, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Laura", "Antonia", "55668899" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 4, true, null, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(3252), new DateTime(1993, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Luiza", "Maria", "6565659" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 5, true, null, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(3256), new DateTime(1993, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Lucas", "Machado", "565685415" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 6, true, null, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(3265), new DateTime(1993, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Pedro", "Alvares", "456454545" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 7, true, null, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(3269), new DateTime(1993, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Paulo", "José", "9874512" });

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Tecnologia da Informação" });

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Sistemas de Informação" });

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "Ciência da Computação" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "Nome", "Registro", "Sobrenonome" },
                values: new object[] { 1, true, null, new DateTime(2021, 8, 19, 15, 44, 12, 359, DateTimeKind.Local).AddTicks(7678), "Lauro", 1, "Oliveira" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "Nome", "Registro", "Sobrenonome" },
                values: new object[] { 2, true, null, new DateTime(2021, 8, 19, 15, 44, 12, 362, DateTimeKind.Local).AddTicks(2272), "Roberto", 2, "Soares" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "Nome", "Registro", "Sobrenonome" },
                values: new object[] { 3, true, null, new DateTime(2021, 8, 19, 15, 44, 12, 362, DateTimeKind.Local).AddTicks(2330), "Ronaldo", 3, "Marconi" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "Nome", "Registro", "Sobrenonome" },
                values: new object[] { 4, true, null, new DateTime(2021, 8, 19, 15, 44, 12, 362, DateTimeKind.Local).AddTicks(2336), "Rodrigo", 4, "Carvalho" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "Nome", "Registro", "Sobrenonome" },
                values: new object[] { 5, true, null, new DateTime(2021, 8, 19, 15, 44, 12, 362, DateTimeKind.Local).AddTicks(2337), "Alexandre", 5, "Montanha" });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 1, 0, 1, "Matemática", null, 1 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 2, 0, 3, "Matemática", null, 1 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 3, 0, 3, "Física", null, 2 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 4, 0, 1, "Português", null, 3 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 5, 0, 1, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 6, 0, 2, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 7, 0, 3, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 8, 0, 1, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 9, 0, 2, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 10, 0, 3, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataIni", "DataInicio", "Nota" },
                values: new object[] { 2, 1, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(5169), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataIni", "DataInicio", "Nota" },
                values: new object[] { 4, 5, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(5183), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataIni", "DataInicio", "Nota" },
                values: new object[] { 2, 5, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(5174), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataIni", "DataInicio", "Nota" },
                values: new object[] { 1, 5, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(5167), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataIni", "DataInicio", "Nota" },
                values: new object[] { 7, 4, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(5197), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataIni", "DataInicio", "Nota" },
                values: new object[] { 6, 4, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(5192), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataIni", "DataInicio", "Nota" },
                values: new object[] { 5, 4, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(5185), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataIni", "DataInicio", "Nota" },
                values: new object[] { 4, 4, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(5182), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataIni", "DataInicio", "Nota" },
                values: new object[] { 1, 4, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(5131), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataIni", "DataInicio", "Nota" },
                values: new object[] { 7, 3, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(5196), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataIni", "DataInicio", "Nota" },
                values: new object[] { 5, 5, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(5186), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataIni", "DataInicio", "Nota" },
                values: new object[] { 6, 3, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(5190), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataIni", "DataInicio", "Nota" },
                values: new object[] { 7, 2, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(5195), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataIni", "DataInicio", "Nota" },
                values: new object[] { 6, 2, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(5188), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataIni", "DataInicio", "Nota" },
                values: new object[] { 3, 2, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(5177), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataIni", "DataInicio", "Nota" },
                values: new object[] { 2, 2, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(5170), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataIni", "DataInicio", "Nota" },
                values: new object[] { 1, 2, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(4629), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataIni", "DataInicio", "Nota" },
                values: new object[] { 7, 1, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(5193), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataIni", "DataInicio", "Nota" },
                values: new object[] { 6, 1, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(5187), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataIni", "DataInicio", "Nota" },
                values: new object[] { 4, 1, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(5181), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataIni", "DataInicio", "Nota" },
                values: new object[] { 3, 1, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(5176), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataIni", "DataInicio", "Nota" },
                values: new object[] { 3, 3, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(5178), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataIni", "DataInicio", "Nota" },
                values: new object[] { 7, 5, new DateTime(2021, 8, 19, 15, 44, 12, 366, DateTimeKind.Local).AddTicks(5199), null, null });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoCurso_CursoId",
                table: "AlunoCurso",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosDisciplinas_DisciplinaId",
                table: "AlunosDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_PreRequisitoId",
                table: "Disciplinas",
                column: "PreRequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoCurso");

            migrationBuilder.DropTable(
                name: "AlunosDisciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
