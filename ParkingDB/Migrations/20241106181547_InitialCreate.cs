using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingDB.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IDCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    CNPJ = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IDCliente);
                });

            migrationBuilder.CreateTable(
                name: "EstadosBrasileiros",
                columns: table => new
                {
                    UF = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosBrasileiros", x => x.UF);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPagamentos",
                columns: table => new
                {
                    IDMetodoPagamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPagamentos", x => x.IDMetodoPagamento);
                });

            migrationBuilder.CreateTable(
                name: "StatusReservas",
                columns: table => new
                {
                    IDStatusReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusReservas", x => x.IDStatusReserva);
                });

            migrationBuilder.CreateTable(
                name: "StatusVagas",
                columns: table => new
                {
                    IDStatusVaga = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusVagas", x => x.IDStatusVaga);
                });

            migrationBuilder.CreateTable(
                name: "TipoVeiculos",
                columns: table => new
                {
                    IDTipoVeiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVeiculos", x => x.IDTipoVeiculo);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    IDTelefone = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCliente = table.Column<int>(type: "int", nullable: false),
                    DDD = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    NumeroTelefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.IDTelefone);
                    table.ForeignKey(
                        name: "FK_Telefones_Clientes_IDCliente",
                        column: x => x.IDCliente,
                        principalTable: "Clientes",
                        principalColumn: "IDCliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    IDEndereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rua = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UF = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.IDEndereco);
                    table.ForeignKey(
                        name: "FK_Enderecos_EstadosBrasileiros_UF",
                        column: x => x.UF,
                        principalTable: "EstadosBrasileiros",
                        principalColumn: "UF",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    IDVeiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCliente = table.Column<int>(type: "int", nullable: false),
                    IDTipoVeiculo = table.Column<int>(type: "int", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.IDVeiculo);
                    table.ForeignKey(
                        name: "FK_Veiculos_Clientes_IDCliente",
                        column: x => x.IDCliente,
                        principalTable: "Clientes",
                        principalColumn: "IDCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Veiculos_TipoVeiculos_IDTipoVeiculo",
                        column: x => x.IDTipoVeiculo,
                        principalTable: "TipoVeiculos",
                        principalColumn: "IDTipoVeiculo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estacionamentos",
                columns: table => new
                {
                    IDEstacionamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDEndereco = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Capacidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estacionamentos", x => x.IDEstacionamento);
                    table.ForeignKey(
                        name: "FK_Estacionamentos_Enderecos_IDEndereco",
                        column: x => x.IDEndereco,
                        principalTable: "Enderecos",
                        principalColumn: "IDEndereco",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vagas",
                columns: table => new
                {
                    IDVaga = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDEstacionamento = table.Column<int>(type: "int", nullable: false),
                    IDTipoVeiculo = table.Column<int>(type: "int", nullable: false),
                    IDStatusVaga = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vagas", x => x.IDVaga);
                    table.ForeignKey(
                        name: "FK_Vagas_Estacionamentos_IDEstacionamento",
                        column: x => x.IDEstacionamento,
                        principalTable: "Estacionamentos",
                        principalColumn: "IDEstacionamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vagas_StatusVagas_IDStatusVaga",
                        column: x => x.IDStatusVaga,
                        principalTable: "StatusVagas",
                        principalColumn: "IDStatusVaga",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vagas_TipoVeiculos_IDTipoVeiculo",
                        column: x => x.IDTipoVeiculo,
                        principalTable: "TipoVeiculos",
                        principalColumn: "IDTipoVeiculo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntradasSaidas",
                columns: table => new
                {
                    IDEntradaSaida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDVaga = table.Column<int>(type: "int", nullable: false),
                    IDVeiculo = table.Column<int>(type: "int", nullable: false),
                    DataHoraEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraSaida = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradasSaidas", x => x.IDEntradaSaida);
                    table.ForeignKey(
                        name: "FK_EntradasSaidas_Vagas_IDVaga",
                        column: x => x.IDVaga,
                        principalTable: "Vagas",
                        principalColumn: "IDVaga",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntradasSaidas_Veiculos_IDVeiculo",
                        column: x => x.IDVeiculo,
                        principalTable: "Veiculos",
                        principalColumn: "IDVeiculo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    IDReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCliente = table.Column<int>(type: "int", nullable: false),
                    IDVaga = table.Column<int>(type: "int", nullable: false),
                    IDStatusReserva = table.Column<int>(type: "int", nullable: false),
                    DataHoraReserva = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.IDReserva);
                    table.ForeignKey(
                        name: "FK_Reservas_Clientes_IDCliente",
                        column: x => x.IDCliente,
                        principalTable: "Clientes",
                        principalColumn: "IDCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_StatusReservas_IDStatusReserva",
                        column: x => x.IDStatusReserva,
                        principalTable: "StatusReservas",
                        principalColumn: "IDStatusReserva",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_Vagas_IDVaga",
                        column: x => x.IDVaga,
                        principalTable: "Vagas",
                        principalColumn: "IDVaga",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    IDPagamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCliente = table.Column<int>(type: "int", nullable: false),
                    IDMetodoPagamento = table.Column<int>(type: "int", nullable: false),
                    IDEntradaSaida = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.IDPagamento);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Clientes_IDCliente",
                        column: x => x.IDCliente,
                        principalTable: "Clientes",
                        principalColumn: "IDCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pagamentos_EntradasSaidas_IDEntradaSaida",
                        column: x => x.IDEntradaSaida,
                        principalTable: "EntradasSaidas",
                        principalColumn: "IDEntradaSaida",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagamentos_MetodoPagamentos_IDMetodoPagamento",
                        column: x => x.IDMetodoPagamento,
                        principalTable: "MetodoPagamentos",
                        principalColumn: "IDMetodoPagamento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_UF",
                table: "Enderecos",
                column: "UF");

            migrationBuilder.CreateIndex(
                name: "IX_EntradasSaidas_IDVaga",
                table: "EntradasSaidas",
                column: "IDVaga");

            migrationBuilder.CreateIndex(
                name: "IX_EntradasSaidas_IDVeiculo",
                table: "EntradasSaidas",
                column: "IDVeiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Estacionamentos_IDEndereco",
                table: "Estacionamentos",
                column: "IDEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_IDCliente",
                table: "Pagamentos",
                column: "IDCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_IDEntradaSaida",
                table: "Pagamentos",
                column: "IDEntradaSaida");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_IDMetodoPagamento",
                table: "Pagamentos",
                column: "IDMetodoPagamento");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IDCliente",
                table: "Reservas",
                column: "IDCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IDStatusReserva",
                table: "Reservas",
                column: "IDStatusReserva");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IDVaga",
                table: "Reservas",
                column: "IDVaga");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_IDCliente",
                table: "Telefones",
                column: "IDCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Vagas_IDEstacionamento",
                table: "Vagas",
                column: "IDEstacionamento");

            migrationBuilder.CreateIndex(
                name: "IX_Vagas_IDStatusVaga",
                table: "Vagas",
                column: "IDStatusVaga");

            migrationBuilder.CreateIndex(
                name: "IX_Vagas_IDTipoVeiculo",
                table: "Vagas",
                column: "IDTipoVeiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_IDCliente",
                table: "Veiculos",
                column: "IDCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_IDTipoVeiculo",
                table: "Veiculos",
                column: "IDTipoVeiculo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "EntradasSaidas");

            migrationBuilder.DropTable(
                name: "MetodoPagamentos");

            migrationBuilder.DropTable(
                name: "StatusReservas");

            migrationBuilder.DropTable(
                name: "Vagas");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Estacionamentos");

            migrationBuilder.DropTable(
                name: "StatusVagas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "TipoVeiculos");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "EstadosBrasileiros");
        }
    }
}
