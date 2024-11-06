using ParkingDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingDB.Configurations
{
    public class PagamentoConfiguration : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.HasKey(p => p.IDPagamento);
            builder.Property(p => p.Valor).IsRequired()
                   .HasColumnType("decimal(6,2)");

            builder.HasOne<Cliente>()
                   .WithMany(c => c.Pagamentos)
                   .HasForeignKey(p => p.IDCliente)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<MetodoPagamento>()
                   .WithMany(mp => mp.Pagamentos)
                   .HasForeignKey(p => p.IDMetodoPagamento)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.EntradaSaida)
                   .WithMany()
                   .HasForeignKey(p => p.IDEntradaSaida);
        }
    }
}
