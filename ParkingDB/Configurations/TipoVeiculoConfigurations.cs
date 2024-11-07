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
            builder.Property(tv => tv.Descricao).IsRequired().HasMaxLength(100);
        }
    }
}
