using ParkingDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingDB.Configurations
{
    public class EntradaSaidaConfiguration : IEntityTypeConfiguration<EntradaSaida>
    {
        public void Configure(EntityTypeBuilder<EntradaSaida> builder)
        {
            builder.HasKey(es => es.IDEntradaSaida);

            builder.HasOne<Vaga>()
                   .WithMany(v => v.EntradaSaidas)
                   .HasForeignKey(es => es.IDVaga)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Veiculo>()
                   .WithMany(v => v.EntradaSaidas)
                   .HasForeignKey(es => es.IDVeiculo)
                   .OnDelete(DeleteBehavior.Restrict);
            
            builder.Property(es => es.DataHoraEntrada)
                   .IsRequired();

            builder.Property(es => es.DataHoraSaida)
                   .IsRequired(false);

        }
    }
}
