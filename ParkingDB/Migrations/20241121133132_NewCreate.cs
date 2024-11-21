using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingDB.Migrations
{
    /// <inheritdoc />
    public partial class NewCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    CNPJ = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    DataHoraInclusao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuarioInclusao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "EstadosBrasileiros",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataHoraInclusao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuarioInclusao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosBrasileiros", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataHoraInclusao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuarioInclusao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPagamentos", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "StatusReservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataHoraInclusao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuarioInclusao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusReservas", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "StatusVagas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataHoraInclusao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuarioInclusao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusVagas", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "TipoVeiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataHoraInclusao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuarioInclusao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVeiculos", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DDD = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    NumeroTelefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    DataHoraInclusao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuarioInclusao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Telefones_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rua = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdEstado = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DataHoraInclusao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuarioInclusao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Enderecos_EstadosBrasileiros_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "EstadosBrasileiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    IdMetodoPagamento = table.Column<int>(type: "int", nullable: false),
                    DataHoraInclusao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuarioInclusao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Pagamentos_MetodoPagamentos_IdMetodoPagamento",
                        column: x => x.IdMetodoPagamento,
                        principalTable: "MetodoPagamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdTipoVeiculo = table.Column<int>(type: "int", nullable: false),
                    DataHoraInclusao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuarioInclusao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Veiculos_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Veiculos_TipoVeiculos_IdTipoVeiculo",
                        column: x => x.IdTipoVeiculo,
                        principalTable: "TipoVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estacionamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Capacidade = table.Column<int>(type: "int", nullable: false),
                    IdEndereco = table.Column<int>(type: "int", nullable: false),
                    DataHoraInclusao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuarioInclusao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estacionamentos", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Estacionamentos_Enderecos_IdEndereco",
                        column: x => x.IdEndereco,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vagas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEstacionamento = table.Column<int>(type: "int", nullable: false),
                    IdTipoVeiculo = table.Column<int>(type: "int", nullable: false),
                    IdStatusVaga = table.Column<int>(type: "int", nullable: false),
                    DataHoraInclusao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuarioInclusao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vagas", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Vagas_Estacionamentos_IdEstacionamento",
                        column: x => x.IdEstacionamento,
                        principalTable: "Estacionamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vagas_StatusVagas_IdStatusVaga",
                        column: x => x.IdStatusVaga,
                        principalTable: "StatusVagas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vagas_TipoVeiculos_IdTipoVeiculo",
                        column: x => x.IdTipoVeiculo,
                        principalTable: "TipoVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntradasSaidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHoraEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraSaida = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdVaga = table.Column<int>(type: "int", nullable: false),
                    IdVeiculo = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdPagamento = table.Column<int>(type: "int", nullable: false),
                    DataHoraInclusao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuarioInclusao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradasSaidas", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_EntradasSaidas_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntradasSaidas_Pagamentos_IdPagamento",
                        column: x => x.IdPagamento,
                        principalTable: "Pagamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntradasSaidas_Vagas_IdVaga",
                        column: x => x.IdVaga,
                        principalTable: "Vagas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntradasSaidas_Veiculos_IdVeiculo",
                        column: x => x.IdVeiculo,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHoraReserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdVaga = table.Column<int>(type: "int", nullable: false),
                    IdStatusReserva = table.Column<int>(type: "int", nullable: false),
                    DataHoraInclusao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UsuarioInclusao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Reservas_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_StatusReservas_IdStatusReserva",
                        column: x => x.IdStatusReserva,
                        principalTable: "StatusReservas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_Vagas_IdVaga",
                        column: x => x.IdVaga,
                        principalTable: "Vagas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_IdEstado",
                table: "Enderecos",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_EntradasSaidas_IdCliente",
                table: "EntradasSaidas",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_EntradasSaidas_IdPagamento",
                table: "EntradasSaidas",
                column: "IdPagamento");

            migrationBuilder.CreateIndex(
                name: "IX_EntradasSaidas_IdVaga",
                table: "EntradasSaidas",
                column: "IdVaga");

            migrationBuilder.CreateIndex(
                name: "IX_EntradasSaidas_IdVeiculo",
                table: "EntradasSaidas",
                column: "IdVeiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Estacionamentos_IdEndereco",
                table: "Estacionamentos",
                column: "IdEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_IdMetodoPagamento",
                table: "Pagamentos",
                column: "IdMetodoPagamento");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdCliente",
                table: "Reservas",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdStatusReserva",
                table: "Reservas",
                column: "IdStatusReserva");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdVaga",
                table: "Reservas",
                column: "IdVaga");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_IdCliente",
                table: "Telefones",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Vagas_IdEstacionamento",
                table: "Vagas",
                column: "IdEstacionamento");

            migrationBuilder.CreateIndex(
                name: "IX_Vagas_IdStatusVaga",
                table: "Vagas",
                column: "IdStatusVaga");

            migrationBuilder.CreateIndex(
                name: "IX_Vagas_IdTipoVeiculo",
                table: "Vagas",
                column: "IdTipoVeiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_IdCliente",
                table: "Veiculos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_IdTipoVeiculo",
                table: "Veiculos",
                column: "IdTipoVeiculo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntradasSaidas");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "StatusReservas");

            migrationBuilder.DropTable(
                name: "Vagas");

            migrationBuilder.DropTable(
                name: "MetodoPagamentos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Estacionamentos");

            migrationBuilder.DropTable(
                name: "StatusVagas");

            migrationBuilder.DropTable(
                name: "TipoVeiculos");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "EstadosBrasileiros");
        }
    }
}
