using ParkingDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingDB.Configurations
{
    public class StatusReservaConfiguration : IEntityTypeConfiguration<StatusReserva>
    {
        public void Configure(EntityTypeBuilder<StatusReserva> builder)
        {
            builder.HasKey(sr => sr.IDStatusReserva);

            builder.Property(sr => sr.Descricao)
                   .IsRequired()
                   .HasMaxLength(20);
        }
    }
}
