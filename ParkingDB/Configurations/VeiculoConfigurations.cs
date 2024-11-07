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
                   .HasMaxLength(50);

            builder.Property(v => v.Modelo)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(v => v.DataHoraInclusão)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(v => v.UsuarioInclusao)
                   .IsRequired()
                   .HasMaxLength(80);

            builder.Property(v => v.DataHoraAlteracao)
                   .IsRequired();

            builder.Property(v => v.DataHoraAlteracao)
                   .HasMaxLength(80);

            builder.Property(v => v.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);

        }
    }
}
