using ParkingDB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingDB.Configurations
{
    public class EstacionamentoConfiguration : IEntityTypeConfiguration<Estacionamento>
    {
        public void Configure(EntityTypeBuilder<Estacionamento> builder)
        {
            builder.HasKey(e => e.Id)
                   .IsClustered(true);

            builder.Property(e => e.Id)
                   .HasColumnName($"{nameof(Estacionamento)}Id") 
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.HasOne(e => e.Endereco) 
                   .WithMany()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.Capacidade)
                   .IsRequired();

            builder.Property(e => e.DataHoraInclusao)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(e => e.UsuarioInclusao)
                   .IsRequired()
                   .HasMaxLength(80);

            builder.Property(e => e.DataHoraAlteracao)
                   .IsRequired();

            builder.Property(e => e.UsuarioAlteracao)
                   .HasMaxLength(80);

            builder.Property(e => e.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);
        }
    }
}
