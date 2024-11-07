using ParkingDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingDB.Configurations
{
    public class TipoVeiculoConfiguration : IEntityTypeConfiguration<TipoVeiculo>
    {
        public void Configure(EntityTypeBuilder<TipoVeiculo> builder)
        {
            builder.HasKey(tv => tv.IDTipoVeiculo);

            builder.Property(tv => tv.Descricao)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(tv => tv.DataHoraInclusão)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(tv => tv.UsuarioInclusao)
                   .IsRequired()
                   .HasMaxLength(80);

            builder.Property(tv => tv.DataHoraAlteracao)
                   .IsRequired();

            builder.Property(tv => tv.UsuarioAlteracao)
                   .HasMaxLength(80);

            builder.Property(tv => tv.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);
        }
    }
}
