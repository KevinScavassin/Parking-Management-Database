using ParkingDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingDB.Configurations
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(v => v.IDVeiculo);

            builder.HasOne<Cliente>()
                   .WithMany(c => c.Veiculos)
                   .HasForeignKey(v => v.IDCliente)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<TipoVeiculo>()
                   .WithMany(tp => tp.Veiculos)
                   .HasForeignKey(v => v.IDTipoVeiculo)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(v => v.Placa)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(v => v.Cor)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(v => v.Modelo)
                   .IsRequired()
                   .HasMaxLength(4);

        }
    }
}
