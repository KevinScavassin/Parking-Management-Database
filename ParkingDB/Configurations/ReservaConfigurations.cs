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

            builder.Property(r => r.DataHoraReserva)
                   .IsRequired();

            builder.Property(r => r.DataHoraInclusão)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(r => r.UsuarioInclusao)
                   .IsRequired()
                   .HasMaxLength(80);

            builder.Property(r => r.DataHoraAlteracao)
                   .IsRequired();

            builder.Property(r => r.UsuarioAlteracao)
                   .HasMaxLength(80);

            builder.Property(r => r.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);



        }
    }
}
