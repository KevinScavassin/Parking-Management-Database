﻿using ParkingDB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace ParkingDB.Configurations
{
    public class VagaConfiguration : IEntityTypeConfiguration<Vaga>
    {
        public void Configure(EntityTypeBuilder<Vaga> builder)
        {
            builder.HasKey(v => v.Id)
                   .IsClustered(true);

            builder.Property(v => v.Id)
                   .HasColumnName($"{nameof(Vaga)}Id")
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.HasOne(v => v.Estacionamento) 
                   .WithMany(e => e.Vagas) 
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(v => v.TipoVeiculo) 
                   .WithMany() 
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(v => v.StatusVaga) 
                   .WithMany() 
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(v => v.DataHoraInclusao)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(v => v.UsuarioInclusao)
                   .IsRequired()
                   .HasMaxLength(80);

            builder.Property(v => v.DataHoraAlteracao)
                   .IsRequired();

            builder.Property(v => v.UsuarioAlteracao)
                   .HasMaxLength(80);

            builder.Property(v => v.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);

        }
    }
}
