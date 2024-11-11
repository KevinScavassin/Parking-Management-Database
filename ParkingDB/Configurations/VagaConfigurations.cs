using ParkingDB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace ParkingDB.Configurations
{
    public class VagaConfiguration : IEntityTypeConfiguration<Vaga>
    {
        public void Configure(EntityTypeBuilder<Vaga> builder)
        {
            builder.HasKey(v => v.IDVaga);

            builder.HasOne(v => v.Estacionamento)
                   .WithMany()
                   .HasForeignKey(v => v.IDEstacionamento);

            builder.HasOne<TipoVeiculo>()
                   .WithMany(tp => tp.Vagas)
                   .HasForeignKey(v => v.IDTipoVeiculo)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<StatusVaga>()
                   .WithMany(sv => sv.Vagas)
                   .HasForeignKey(v => v.IDStatusVaga)
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
