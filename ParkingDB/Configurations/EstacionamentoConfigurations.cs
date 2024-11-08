using ParkingDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingDB.Configurations
{
    public class EstacionamentoConfiguration : IEntityTypeConfiguration<Estacionamento>
    {
        public void Configure(EntityTypeBuilder<Estacionamento> builder)
        {
            builder.HasKey(e => e.IDEstacionamento);

            builder.HasOne(e => e.Endereco)
                   .WithMany()
                   .HasForeignKey(e => e.IDEndereco);

            builder.Property(e => e.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.Capacidade)
                   .IsRequired();

            builder.Property(e => e.DataHoraInclusão)
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
