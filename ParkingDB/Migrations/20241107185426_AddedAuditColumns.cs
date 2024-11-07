using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingDB.Migrations
{
    /// <inheritdoc />
    public partial class AddedAuditColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraAlteracao",
                table: "Veiculos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraInclusão",
                table: "Veiculos",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Veiculos",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioAlteracao",
                table: "Veiculos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioInclusao",
                table: "Veiculos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraAlteracao",
                table: "Vagas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraInclusão",
                table: "Vagas",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Vagas",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioAlteracao",
                table: "Vagas",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioInclusao",
                table: "Vagas",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraAlteracao",
                table: "TipoVeiculos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraInclusão",
                table: "TipoVeiculos",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TipoVeiculos",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioAlteracao",
                table: "TipoVeiculos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioInclusao",
                table: "TipoVeiculos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraAlteracao",
                table: "Telefones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraInclusão",
                table: "Telefones",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Telefones",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioAlteracao",
                table: "Telefones",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioInclusao",
                table: "Telefones",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraAlteracao",
                table: "StatusVagas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraInclusão",
                table: "StatusVagas",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "StatusVagas",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioAlteracao",
                table: "StatusVagas",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioInclusao",
                table: "StatusVagas",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraAlteracao",
                table: "StatusReservas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraInclusão",
                table: "StatusReservas",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "StatusReservas",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioAlteracao",
                table: "StatusReservas",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioInclusao",
                table: "StatusReservas",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraAlteracao",
                table: "Reservas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraInclusão",
                table: "Reservas",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Reservas",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioAlteracao",
                table: "Reservas",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioInclusao",
                table: "Reservas",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraAlteracao",
                table: "Pagamentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraInclusão",
                table: "Pagamentos",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Pagamentos",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioAlteracao",
                table: "Pagamentos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioInclusao",
                table: "Pagamentos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraAlteracao",
                table: "MetodoPagamentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraInclusão",
                table: "MetodoPagamentos",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MetodoPagamentos",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioAlteracao",
                table: "MetodoPagamentos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioInclusao",
                table: "MetodoPagamentos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraAlteracao",
                table: "EstadosBrasileiros",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraInclusão",
                table: "EstadosBrasileiros",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "EstadosBrasileiros",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioAlteracao",
                table: "EstadosBrasileiros",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioInclusao",
                table: "EstadosBrasileiros",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraAlteracao",
                table: "Estacionamentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraInclusão",
                table: "Estacionamentos",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Estacionamentos",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioAlteracao",
                table: "Estacionamentos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioInclusao",
                table: "Estacionamentos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraAlteracao",
                table: "EntradasSaidas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraInclusão",
                table: "EntradasSaidas",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "EntradasSaidas",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioAlteracao",
                table: "EntradasSaidas",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioInclusao",
                table: "EntradasSaidas",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraAlteracao",
                table: "Enderecos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraInclusão",
                table: "Enderecos",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Enderecos",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioAlteracao",
                table: "Enderecos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioInclusao",
                table: "Enderecos",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraAlteracao",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraInclusão",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Clientes",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioAlteracao",
                table: "Clientes",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioInclusao",
                table: "Clientes",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataHoraAlteracao",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "DataHoraInclusão",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "UsuarioAlteracao",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "UsuarioInclusao",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "DataHoraAlteracao",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "DataHoraInclusão",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "UsuarioAlteracao",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "UsuarioInclusao",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "DataHoraAlteracao",
                table: "TipoVeiculos");

            migrationBuilder.DropColumn(
                name: "DataHoraInclusão",
                table: "TipoVeiculos");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TipoVeiculos");

            migrationBuilder.DropColumn(
                name: "UsuarioAlteracao",
                table: "TipoVeiculos");

            migrationBuilder.DropColumn(
                name: "UsuarioInclusao",
                table: "TipoVeiculos");

            migrationBuilder.DropColumn(
                name: "DataHoraAlteracao",
                table: "Telefones");

            migrationBuilder.DropColumn(
                name: "DataHoraInclusão",
                table: "Telefones");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Telefones");

            migrationBuilder.DropColumn(
                name: "UsuarioAlteracao",
                table: "Telefones");

            migrationBuilder.DropColumn(
                name: "UsuarioInclusao",
                table: "Telefones");

            migrationBuilder.DropColumn(
                name: "DataHoraAlteracao",
                table: "StatusVagas");

            migrationBuilder.DropColumn(
                name: "DataHoraInclusão",
                table: "StatusVagas");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "StatusVagas");

            migrationBuilder.DropColumn(
                name: "UsuarioAlteracao",
                table: "StatusVagas");

            migrationBuilder.DropColumn(
                name: "UsuarioInclusao",
                table: "StatusVagas");

            migrationBuilder.DropColumn(
                name: "DataHoraAlteracao",
                table: "StatusReservas");

            migrationBuilder.DropColumn(
                name: "DataHoraInclusão",
                table: "StatusReservas");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "StatusReservas");

            migrationBuilder.DropColumn(
                name: "UsuarioAlteracao",
                table: "StatusReservas");

            migrationBuilder.DropColumn(
                name: "UsuarioInclusao",
                table: "StatusReservas");

            migrationBuilder.DropColumn(
                name: "DataHoraAlteracao",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "DataHoraInclusão",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "UsuarioAlteracao",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "UsuarioInclusao",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "DataHoraAlteracao",
                table: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "DataHoraInclusão",
                table: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "UsuarioAlteracao",
                table: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "UsuarioInclusao",
                table: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "DataHoraAlteracao",
                table: "MetodoPagamentos");

            migrationBuilder.DropColumn(
                name: "DataHoraInclusão",
                table: "MetodoPagamentos");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MetodoPagamentos");

            migrationBuilder.DropColumn(
                name: "UsuarioAlteracao",
                table: "MetodoPagamentos");

            migrationBuilder.DropColumn(
                name: "UsuarioInclusao",
                table: "MetodoPagamentos");

            migrationBuilder.DropColumn(
                name: "DataHoraAlteracao",
                table: "EstadosBrasileiros");

            migrationBuilder.DropColumn(
                name: "DataHoraInclusão",
                table: "EstadosBrasileiros");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "EstadosBrasileiros");

            migrationBuilder.DropColumn(
                name: "UsuarioAlteracao",
                table: "EstadosBrasileiros");

            migrationBuilder.DropColumn(
                name: "UsuarioInclusao",
                table: "EstadosBrasileiros");

            migrationBuilder.DropColumn(
                name: "DataHoraAlteracao",
                table: "Estacionamentos");

            migrationBuilder.DropColumn(
                name: "DataHoraInclusão",
                table: "Estacionamentos");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Estacionamentos");

            migrationBuilder.DropColumn(
                name: "UsuarioAlteracao",
                table: "Estacionamentos");

            migrationBuilder.DropColumn(
                name: "UsuarioInclusao",
                table: "Estacionamentos");

            migrationBuilder.DropColumn(
                name: "DataHoraAlteracao",
                table: "EntradasSaidas");

            migrationBuilder.DropColumn(
                name: "DataHoraInclusão",
                table: "EntradasSaidas");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "EntradasSaidas");

            migrationBuilder.DropColumn(
                name: "UsuarioAlteracao",
                table: "EntradasSaidas");

            migrationBuilder.DropColumn(
                name: "UsuarioInclusao",
                table: "EntradasSaidas");

            migrationBuilder.DropColumn(
                name: "DataHoraAlteracao",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "DataHoraInclusão",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "UsuarioAlteracao",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "UsuarioInclusao",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "DataHoraAlteracao",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "DataHoraInclusão",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "UsuarioAlteracao",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "UsuarioInclusao",
                table: "Clientes");
        }
    }
}
