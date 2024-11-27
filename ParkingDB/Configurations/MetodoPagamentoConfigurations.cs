using ParkingDB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingDB.Configurations
{
    public class MetodoPagamentoConfiguration : IEntityTypeConfiguration<MetodoPagamento>
    {
        public void Configure(EntityTypeBuilder<MetodoPagamento> builder)
        {
            builder.HasKey(mp => mp.Id)
                   .IsClustered(true);

            builder.Property(mp => mp.Id)
                   .HasColumnName($"{nameof(MetodoPagamento)}Id")
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(mp => mp.Descricao)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(mp => mp.DataHoraInclusao)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(mp => mp.UsuarioInclusao)
                   .IsRequired()
                   .HasMaxLength(80);

            builder.Property(mp => mp.DataHoraAlteracao)
                   .IsRequired();

            builder.Property(mp => mp.UsuarioAlteracao)
                   .HasMaxLength(80);

            builder.Property(mp => mp.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);
        }
    }
}
