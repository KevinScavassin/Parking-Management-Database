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
            builder.Property(e => e.Nome).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Capacidade).IsRequired();

            builder.HasOne(e => e.Endereco)
                   .WithMany()
                   .HasForeignKey(e => e.IDEndereco);
        }
    }
}
