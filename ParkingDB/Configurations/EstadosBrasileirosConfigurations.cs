using ParkingDB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingDB.Configurations
{
    public class EstadosBrasileirosConfiguration : IEntityTypeConfiguration<EstadosBrasileiros>
    {
        public void Configure(EntityTypeBuilder<EstadosBrasileiros> builder)
        {
            builder.HasKey(eb => eb.UF);

            builder.Property(eb => eb.Nome)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(eb => eb.DataHoraInclusao)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(eb => eb.UsuarioInclusao)
                   .IsRequired()
                   .HasMaxLength(80);

            builder.Property(eb => eb.DataHoraAlteracao)
                   .IsRequired();

            builder.Property(eb => eb.UsuarioAlteracao)
                   .HasMaxLength(80);

            builder.Property(eb => eb.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);
        }
    }
}
