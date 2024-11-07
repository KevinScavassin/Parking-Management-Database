using ParkingDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingDB.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.IDCliente);

            builder.Property(c => c.CPF)
                   .IsRequired(false)
                   .HasMaxLength(11);

            builder.Property(c => c.CNPJ)
                   .IsRequired(false)
                   .HasMaxLength(14);
                    
            
        }
    }
}
