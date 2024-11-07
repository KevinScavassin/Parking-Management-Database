﻿using ParkingDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingDB.Configurations
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.IDEndereco);

            builder.HasOne<EstadosBrasileiros>() 
                   .WithMany(uf => uf.Enderecos)
                   .HasForeignKey(e => e.UF)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.Rua)
                   .IsRequired()
                   .HasMaxLength(40);

            builder.Property(e => e.Numero)
                   .IsRequired();

            builder.Property(e => e.Cidade)
                   .IsRequired()
                   .HasMaxLength(40);

            builder.Property(e => e.CEP)
                   .IsRequired()
                   .HasMaxLength(8);

            builder.Property(e => e.Complemento)
                   .IsRequired(false)
                   .HasMaxLength(40);

        }
    }
}
