using ParkingDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingDB.Configurations
{
    public class MetodoPagamentoConfiguration : IEntityTypeConfiguration<MetodoPagamento>
    {
        public void Configure(EntityTypeBuilder<MetodoPagamento> builder)
        {
            builder.HasKey(mp => mp.IDMetodoPagamento);

            builder.Property(mp => mp.Descricao)
                   .IsRequired()
                   .HasMaxLength(30);
        }
    }
}
