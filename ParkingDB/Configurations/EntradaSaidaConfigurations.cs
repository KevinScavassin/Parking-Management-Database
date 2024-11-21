using ParkingDB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingDB.Configurations
{
    public class EntradaSaidaConfiguration : IEntityTypeConfiguration<EntradaSaida>
    {
        public void Configure(EntityTypeBuilder<EntradaSaida> builder)
        {
            builder.HasKey(es => es.Id)
                   .IsClustered(true);

            builder.Property(es => es.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.HasOne(es => es.Vaga) 
                   .WithMany() 
                   .HasForeignKey("IdVaga") 
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(es => es.Veiculo) 
                   .WithMany() 
                   .HasForeignKey("IdVeiculo")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(es => es.Cliente) 
                   .WithMany() 
                   .HasForeignKey("IdCliente")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(es => es.Pagamento) 
                   .WithMany() 
                   .HasForeignKey("IdPagamento") // FK no banco
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(es => es.DataHoraEntrada)
                   .IsRequired();

            builder.Property(es => es.DataHoraSaida)
                   .IsRequired(false);

            builder.Property(es => es.DataHoraInclusao)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(es => es.UsuarioInclusao)
                   .IsRequired()
                   .HasMaxLength(80);

            builder.Property(es => es.DataHoraAlteracao)
                   .IsRequired();

            builder.Property(es => es.UsuarioAlteracao)
                   .HasMaxLength(80);

            builder.Property(es => es.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);
        }
    }
}
