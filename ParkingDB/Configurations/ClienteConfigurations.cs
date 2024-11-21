using ParkingDB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingDB.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id)
                   .IsClustered(true);

            builder.Property(c => c.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(c => c.CPF)
                    .IsRequired(false)
                    .HasMaxLength(11);

            builder.Property(c => c.CNPJ)
                   .IsRequired(false)
                   .HasMaxLength(14);

            builder.Property(c => c.DataHoraInclusao)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()"); 

            builder.Property(c => c.UsuarioInclusao)
                   .IsRequired()
                   .HasMaxLength(80); 

            builder.Property(c => c.DataHoraAlteracao)
                   .IsRequired(); 

            builder.Property(c => c.UsuarioAlteracao)
                   .HasMaxLength(80); 

            builder.Property(c => c.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);

        }
    }
}
