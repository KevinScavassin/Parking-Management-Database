﻿using ParkingDB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingDB.Configurations
{
    public class StatusVagaConfiguration : IEntityTypeConfiguration<StatusVaga>
    {
        public void Configure(EntityTypeBuilder<StatusVaga> builder)
        {
            builder.HasKey(sv => sv.IDStatusVaga);

            builder.Property(sv => sv.Descricao)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(sv => sv.DataHoraInclusao)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(sv => sv.UsuarioInclusao)
                   .IsRequired()
                   .HasMaxLength(80);

            builder.Property(sv => sv.DataHoraAlteracao)
                   .IsRequired();

            builder.Property(sv => sv.UsuarioAlteracao)
                   .HasMaxLength(80);

            builder.Property(sv => sv.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);
        }
    }
}
