using ParkingDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingDB.Configurations
{
    public class EstadosBrasileirosConfiguration : IEntityTypeConfiguration<EstadosBrasileiros>
    {
        public void Configure(EntityTypeBuilder<EstadosBrasileiros> builder)
        {
            builder.HasKey(e => e.UF);
            builder.Property(e => e.Nome).IsRequired().HasMaxLength(50);
        }
    }
}
