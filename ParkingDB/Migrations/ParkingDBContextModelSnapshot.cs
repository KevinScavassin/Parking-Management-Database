﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkingDB.Data;

#nullable disable

namespace ParkingDB.Migrations
{
    [DbContext(typeof(ParkingDBContext))]
    partial class ParkingDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ParkingDB.Models.Cliente", b =>
                {
                    b.Property<int>("IDCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDCliente"));

                    b.Property<string>("CNPJ")
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("CPF")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraInclusão")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("UsuarioAlteracao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("UsuarioInclusao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("IDCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ParkingDB.Models.Endereco", b =>
                {
                    b.Property<int>("IDEndereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDEndereco"));

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Complemento")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraInclusão")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("UsuarioAlteracao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("UsuarioInclusao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("IDEndereco");

                    b.HasIndex("UF");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("ParkingDB.Models.EntradaSaida", b =>
                {
                    b.Property<int>("IDEntradaSaida")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDEntradaSaida"));

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraEntrada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraInclusão")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DataHoraSaida")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDVaga")
                        .HasColumnType("int");

                    b.Property<int>("IDVeiculo")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("UsuarioAlteracao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("UsuarioInclusao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("IDEntradaSaida");

                    b.HasIndex("IDVaga");

                    b.HasIndex("IDVeiculo");

                    b.ToTable("EntradasSaidas");
                });

            modelBuilder.Entity("ParkingDB.Models.Estacionamento", b =>
                {
                    b.Property<int>("IDEstacionamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDEstacionamento"));

                    b.Property<int>("Capacidade")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraInclusão")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("IDEndereco")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UsuarioAlteracao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("UsuarioInclusao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("IDEstacionamento");

                    b.HasIndex("IDEndereco");

                    b.ToTable("Estacionamentos");
                });

            modelBuilder.Entity("ParkingDB.Models.EstadosBrasileiros", b =>
                {
                    b.Property<string>("UF")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(1)");

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraInclusão")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UsuarioAlteracao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("UsuarioInclusao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("UF");

                    b.ToTable("EstadosBrasileiros");
                });

            modelBuilder.Entity("ParkingDB.Models.MetodoPagamento", b =>
                {
                    b.Property<int>("IDMetodoPagamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDMetodoPagamento"));

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraInclusão")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("UsuarioAlteracao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("UsuarioInclusao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("IDMetodoPagamento");

                    b.ToTable("MetodoPagamentos");
                });

            modelBuilder.Entity("ParkingDB.Models.Pagamento", b =>
                {
                    b.Property<int>("IDPagamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDPagamento"));

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraInclusão")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("IDCliente")
                        .HasColumnType("int");

                    b.Property<int>("IDEntradaSaida")
                        .HasColumnType("int");

                    b.Property<int>("IDMetodoPagamento")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("UsuarioAlteracao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("UsuarioInclusao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("IDPagamento");

                    b.HasIndex("IDCliente");

                    b.HasIndex("IDEntradaSaida");

                    b.HasIndex("IDMetodoPagamento");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("ParkingDB.Models.Reserva", b =>
                {
                    b.Property<int>("IDReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDReserva"));

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraInclusão")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("DataHoraReserva")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDCliente")
                        .HasColumnType("int");

                    b.Property<int>("IDStatusReserva")
                        .HasColumnType("int");

                    b.Property<int>("IDVaga")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("UsuarioAlteracao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("UsuarioInclusao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("IDReserva");

                    b.HasIndex("IDCliente");

                    b.HasIndex("IDStatusReserva");

                    b.HasIndex("IDVaga");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("ParkingDB.Models.StatusReserva", b =>
                {
                    b.Property<int>("IDStatusReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDStatusReserva"));

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraInclusão")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("UsuarioAlteracao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("UsuarioInclusao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("IDStatusReserva");

                    b.ToTable("StatusReservas");
                });

            modelBuilder.Entity("ParkingDB.Models.StatusVaga", b =>
                {
                    b.Property<int>("IDStatusVaga")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDStatusVaga"));

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraInclusão")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("UsuarioAlteracao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("UsuarioInclusao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("IDStatusVaga");

                    b.ToTable("StatusVagas");
                });

            modelBuilder.Entity("ParkingDB.Models.Telefone", b =>
                {
                    b.Property<int>("IDTelefone")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDTelefone"));

                    b.Property<string>("DDD")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraInclusão")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("IDCliente")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("NumeroTelefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("UsuarioAlteracao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("UsuarioInclusao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("IDTelefone");

                    b.HasIndex("IDCliente");

                    b.ToTable("Telefones");
                });

            modelBuilder.Entity("ParkingDB.Models.TipoVeiculo", b =>
                {
                    b.Property<int>("IDTipoVeiculo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDTipoVeiculo"));

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraInclusão")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("UsuarioAlteracao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("UsuarioInclusao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("IDTipoVeiculo");

                    b.ToTable("TipoVeiculos");
                });

            modelBuilder.Entity("ParkingDB.Models.Vaga", b =>
                {
                    b.Property<int>("IDVaga")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDVaga"));

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraInclusão")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("IDEstacionamento")
                        .HasColumnType("int");

                    b.Property<int>("IDStatusVaga")
                        .HasColumnType("int");

                    b.Property<int>("IDTipoVeiculo")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("UsuarioAlteracao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("UsuarioInclusao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("IDVaga");

                    b.HasIndex("IDEstacionamento");

                    b.HasIndex("IDStatusVaga");

                    b.HasIndex("IDTipoVeiculo");

                    b.ToTable("Vagas");
                });

            modelBuilder.Entity("ParkingDB.Models.Veiculo", b =>
                {
                    b.Property<int>("IDVeiculo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDVeiculo"));

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraInclusão")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("IDCliente")
                        .HasColumnType("int");

                    b.Property<int>("IDTipoVeiculo")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("UsuarioAlteracao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("UsuarioInclusao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("IDVeiculo");

                    b.HasIndex("IDCliente");

                    b.HasIndex("IDTipoVeiculo");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("ParkingDB.Models.Endereco", b =>
                {
                    b.HasOne("ParkingDB.Models.EstadosBrasileiros", null)
                        .WithMany("Enderecos")
                        .HasForeignKey("UF")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ParkingDB.Models.EntradaSaida", b =>
                {
                    b.HasOne("ParkingDB.Models.Vaga", null)
                        .WithMany("EntradaSaidas")
                        .HasForeignKey("IDVaga")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ParkingDB.Models.Veiculo", null)
                        .WithMany("EntradaSaidas")
                        .HasForeignKey("IDVeiculo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ParkingDB.Models.Estacionamento", b =>
                {
                    b.HasOne("ParkingDB.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("IDEndereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("ParkingDB.Models.Pagamento", b =>
                {
                    b.HasOne("ParkingDB.Models.Cliente", null)
                        .WithMany("Pagamentos")
                        .HasForeignKey("IDCliente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ParkingDB.Models.EntradaSaida", "EntradaSaida")
                        .WithMany()
                        .HasForeignKey("IDEntradaSaida")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkingDB.Models.MetodoPagamento", null)
                        .WithMany("Pagamentos")
                        .HasForeignKey("IDMetodoPagamento")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("EntradaSaida");
                });

            modelBuilder.Entity("ParkingDB.Models.Reserva", b =>
                {
                    b.HasOne("ParkingDB.Models.Cliente", null)
                        .WithMany("Reservas")
                        .HasForeignKey("IDCliente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ParkingDB.Models.StatusReserva", null)
                        .WithMany("Reservas")
                        .HasForeignKey("IDStatusReserva")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ParkingDB.Models.Vaga", null)
                        .WithMany("Reservas")
                        .HasForeignKey("IDVaga")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ParkingDB.Models.Telefone", b =>
                {
                    b.HasOne("ParkingDB.Models.Cliente", null)
                        .WithMany("Telefones")
                        .HasForeignKey("IDCliente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ParkingDB.Models.Vaga", b =>
                {
                    b.HasOne("ParkingDB.Models.Estacionamento", "Estacionamento")
                        .WithMany()
                        .HasForeignKey("IDEstacionamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkingDB.Models.StatusVaga", null)
                        .WithMany("Vagas")
                        .HasForeignKey("IDStatusVaga")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ParkingDB.Models.TipoVeiculo", null)
                        .WithMany("Vagas")
                        .HasForeignKey("IDTipoVeiculo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Estacionamento");
                });

            modelBuilder.Entity("ParkingDB.Models.Veiculo", b =>
                {
                    b.HasOne("ParkingDB.Models.Cliente", null)
                        .WithMany("Veiculos")
                        .HasForeignKey("IDCliente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ParkingDB.Models.TipoVeiculo", null)
                        .WithMany("Veiculos")
                        .HasForeignKey("IDTipoVeiculo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ParkingDB.Models.Cliente", b =>
                {
                    b.Navigation("Pagamentos");

                    b.Navigation("Reservas");

                    b.Navigation("Telefones");

                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("ParkingDB.Models.EstadosBrasileiros", b =>
                {
                    b.Navigation("Enderecos");
                });

            modelBuilder.Entity("ParkingDB.Models.MetodoPagamento", b =>
                {
                    b.Navigation("Pagamentos");
                });

            modelBuilder.Entity("ParkingDB.Models.StatusReserva", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("ParkingDB.Models.StatusVaga", b =>
                {
                    b.Navigation("Vagas");
                });

            modelBuilder.Entity("ParkingDB.Models.TipoVeiculo", b =>
                {
                    b.Navigation("Vagas");

                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("ParkingDB.Models.Vaga", b =>
                {
                    b.Navigation("EntradaSaidas");

                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("ParkingDB.Models.Veiculo", b =>
                {
                    b.Navigation("EntradaSaidas");
                });
#pragma warning restore 612, 618
        }
    }
}
