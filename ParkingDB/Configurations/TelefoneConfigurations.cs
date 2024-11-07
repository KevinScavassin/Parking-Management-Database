using ParkingDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingDB.Configurations
{
    public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(t => t.IDTelefone);

            builder.HasOne<Cliente>()
                   .WithMany(c => c.Telefones)
                   .HasForeignKey(t => t.IDCliente)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(t => t.DDD)
                   .IsRequired()
                   .HasMaxLength(3);

            builder.Property(t => t.NumeroTelefone)
                   .IsRequired()
                   .HasMaxLength(12);

        }
    }
}
