using ParkingDB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingDB.Configurations
{
    public class ReservaConfiguration : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.HasKey(r => r.Id)
                   .IsClustered(true);

            builder.Property(r => r.Id)
                   .HasColumnName($"{nameof(Reserva)}Id")
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.HasOne(r => r.Cliente) 
                   .WithMany(c => c.Reservas)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Vaga) 
                   .WithMany() 
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.StatusReserva) 
                   .WithMany() 
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(r => r.DataHoraReserva)
                   .IsRequired();

            builder.Property(r => r.DataHoraInclusao)
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
