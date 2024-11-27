using ParkingDB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingDB.Configurations
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(v => v.Id)
                   .IsClustered(true);

            builder.Property(v => v.Id)
                   .HasColumnName($"{nameof(Veiculo)}Id")
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.HasOne(v => v.Cliente) 
                   .WithMany(c => c.Veiculos) 
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(v => v.TipoVeiculo) 
                   .WithMany() 
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(v => v.Placa)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(v => v.Cor)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(v => v.Modelo)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(v => v.DataHoraInclusao)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(v => v.UsuarioInclusao)
                   .IsRequired()
                   .HasMaxLength(80);

            builder.Property(v => v.DataHoraAlteracao)
                   .IsRequired();

            builder.Property(v => v.UsuarioAlteracao)
                   .HasMaxLength(80);

            builder.Property(v => v.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);

        }
    }
}
