using ParkingDB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingDB.Configurations
{
    public class StatusReservaConfiguration : IEntityTypeConfiguration<StatusReserva>
    {
        public void Configure(EntityTypeBuilder<StatusReserva> builder)
        {
            builder.HasKey(sr => sr.Id)
                   .IsClustered(true);

            builder.Property(sr => sr.Id)
                   .HasColumnName($"{nameof(StatusReserva)}Id")
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(sr => sr.Descricao)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(sr => sr.DataHoraInclusao)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()"); 

            builder.Property(sr => sr.UsuarioInclusao)
                   .IsRequired()
                   .HasMaxLength(80); 

            builder.Property(sr => sr.DataHoraAlteracao)
                   .IsRequired(); 

            builder.Property(sr => sr.UsuarioAlteracao)
                   .HasMaxLength(80); 

            builder.Property(sr => sr.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);
        }
    }
}
