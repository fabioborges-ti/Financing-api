using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppGroup.Financing.Infraesture.Database.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Uf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExcluidoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExcluidoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_tipos_creditos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Taxa = table.Column<double>(type: "float", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExcluidoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExcluidoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tipos_creditos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_propostas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrimeiroVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimoVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroParcelas = table.Column<int>(type: "int", nullable: false),
                    ValorEmprestimo = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    ValorParcela = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoCreditoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExcluidoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExcluidoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_propostas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Propostas",
                        column: x => x.ClienteId,
                        principalTable: "tb_clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipoCredito_Propostas",
                        column: x => x.TipoCreditoId,
                        principalTable: "tb_tipos_creditos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_emprestimos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropostaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExcluidoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExcluidoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_emprestimos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_emprestimos_tb_propostas_PropostaId",
                        column: x => x.PropostaId,
                        principalTable: "tb_propostas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_parcelas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroParcela = table.Column<int>(type: "int", nullable: false),
                    ValorParcela = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmprestimoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExcluidoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExcluidoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_parcelas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Financiamento_Parcelas",
                        column: x => x.EmprestimoId,
                        principalTable: "tb_emprestimos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tb_tipos_creditos",
                columns: new[] { "Id", "CriadoEm", "CriadoPor", "ExcluidoEm", "ExcluidoPor", "ModificadoEm", "ModificadoPor", "Taxa", "Tipo" },
                values: new object[,]
                {
                    { new Guid("3c040bfd-8b07-4d5b-9b9e-c5b43e7e22a4"), new DateTime(2024, 5, 8, 23, 12, 12, 515, DateTimeKind.Utc).AddTicks(6386), null, null, null, null, null, 5.0, 3 },
                    { new Guid("5bf61441-e127-493a-9aa7-d59303545597"), new DateTime(2024, 5, 8, 23, 12, 12, 515, DateTimeKind.Utc).AddTicks(6404), null, null, null, null, null, 9.0, 5 },
                    { new Guid("727f4ac0-6fb8-4087-86a6-1ae85cae4024"), new DateTime(2024, 5, 8, 23, 12, 12, 515, DateTimeKind.Utc).AddTicks(6339), null, null, null, null, null, 2.0, 1 },
                    { new Guid("92318cf3-daf6-4ffc-a513-c38fae46b19d"), new DateTime(2024, 5, 8, 23, 12, 12, 515, DateTimeKind.Utc).AddTicks(6360), null, null, null, null, null, 1.0, 2 },
                    { new Guid("d54b44aa-f77a-48fd-ab6c-e98925767a81"), new DateTime(2024, 5, 8, 23, 12, 12, 515, DateTimeKind.Utc).AddTicks(6395), null, null, null, null, null, 3.0, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_clientes_Cpf",
                table: "tb_clientes",
                column: "Cpf",
                unique: true,
                filter: "[Cpf] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tb_emprestimos_PropostaId",
                table: "tb_emprestimos",
                column: "PropostaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_parcelas_EmprestimoId",
                table: "tb_parcelas",
                column: "EmprestimoId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_propostas_ClienteId",
                table: "tb_propostas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_propostas_TipoCreditoId",
                table: "tb_propostas",
                column: "TipoCreditoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_parcelas");

            migrationBuilder.DropTable(
                name: "tb_emprestimos");

            migrationBuilder.DropTable(
                name: "tb_propostas");

            migrationBuilder.DropTable(
                name: "tb_clientes");

            migrationBuilder.DropTable(
                name: "tb_tipos_creditos");
        }
    }
}
