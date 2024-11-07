using ParkingDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingDB.Configurations
{
    public class ReservaConfiguration : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.HasKey(r => r.IDReserva);

            builder.HasOne<Cliente>()
                   .WithMany(c => c.Reservas)
                   .HasForeignKey(r => r.IDCliente)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Vaga>()
                   .WithMany(v => v.Reservas)
                   .HasForeignKey(r => r.IDVaga)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<StatusReserva>()
                   .WithMany(sr => sr.Reservas)
                   .HasForeignKey(r => r.IDStatusReserva)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(r => r.DataHoraReserva).IsRequired();

        }
    }
}
