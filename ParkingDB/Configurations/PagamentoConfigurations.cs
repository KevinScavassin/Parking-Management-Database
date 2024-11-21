using ParkingDB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingDB.Configurations
{
    public class PagamentoConfiguration : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.HasKey(p => p.Id)
                   .IsClustered(true);

            builder.Property(p => p.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.HasOne(p => p.MetodoPagamento) 
                   .WithMany()
                   .HasForeignKey("IdMetodoPagamento") 
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.Valor)
                   .IsRequired()
                   .HasColumnType("decimal(6,2)");

            builder.Property(p => p.DataHoraInclusao)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(p => p.UsuarioInclusao)
                   .IsRequired()
                   .HasMaxLength(80);

            builder.Property(p => p.DataHoraAlteracao)
                   .IsRequired();

            builder.Property(p => p.UsuarioAlteracao)
                   .HasMaxLength(80);

            builder.Property(p => p.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);
        }
    }
}
