using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RH_Project.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbBeneficio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbBeneficio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbCargo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCargo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbEmpresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cnpj = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    RazaoSocial = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    NomeFantasia = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbEmpresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbColaborador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SalarioBase = table.Column<double>(type: "float", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDemissao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Dependentes = table.Column<int>(type: "int", nullable: true),
                    Filhos = table.Column<int>(type: "int", nullable: true),
                    CargoId = table.Column<int>(type: "int", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbColaborador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbColaborador_TbCargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "TbCargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbColaborador_TbEmpresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "TbEmpresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbBeneficioColaborador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    BeneficioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbBeneficioColaborador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbBeneficioColaborador_TbBeneficio_BeneficioId",
                        column: x => x.BeneficioId,
                        principalTable: "TbBeneficio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbBeneficioColaborador_TbColaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "TbColaborador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbHolerite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    MesAno = table.Column<int>(type: "int", nullable: false),
                    SalarioBruto = table.Column<double>(type: "float", nullable: false),
                    DescontoINSS = table.Column<double>(type: "float", nullable: false),
                    DescontoIRRF = table.Column<double>(type: "float", nullable: false),
                    HorasNormais = table.Column<double>(type: "float", nullable: false),
                    SalarioLiquido = table.Column<double>(type: "float", nullable: false),
                    DependentesHolerite = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbHolerite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbHolerite_TbColaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "TbColaborador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbUsuario_TbColaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "TbColaborador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbBeneficioColaborador_BeneficioId",
                table: "TbBeneficioColaborador",
                column: "BeneficioId");

            migrationBuilder.CreateIndex(
                name: "IX_TbBeneficioColaborador_ColaboradorId",
                table: "TbBeneficioColaborador",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_TbColaborador_CargoId",
                table: "TbColaborador",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_TbColaborador_EmpresaId",
                table: "TbColaborador",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_TbHolerite_ColaboradorId",
                table: "TbHolerite",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_TbUsuario_ColaboradorId",
                table: "TbUsuario",
                column: "ColaboradorId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbBeneficioColaborador");

            migrationBuilder.DropTable(
                name: "TbHolerite");

            migrationBuilder.DropTable(
                name: "TbUsuario");

            migrationBuilder.DropTable(
                name: "TbBeneficio");

            migrationBuilder.DropTable(
                name: "TbColaborador");

            migrationBuilder.DropTable(
                name: "TbCargo");

            migrationBuilder.DropTable(
                name: "TbEmpresa");
        }
    }
}
