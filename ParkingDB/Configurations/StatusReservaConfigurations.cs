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
                   .HasMaxLength(100);

            builder.Property(sr => sr.DataHoraInclusão)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()"); 

            builder.Property(sr => sr.UsuarioInclusao)
                   .IsRequired()
                   .HasMaxLength(80); 

            builder.Property(sr => sr.DataHoraAlteracao)
                   .IsRequired(); 

            builder.Property(sr => sr.DataHoraAlteracao)
                   .HasMaxLength(80); 

            builder.Property(sr => sr.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);
        }
    }
}
