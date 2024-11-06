using ParkingDB.Models;
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
                   
        }
    }
}
