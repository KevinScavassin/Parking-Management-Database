using ParkingDB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingDB.Configurations
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.Id)
                   .IsClustered(true);

            builder.Property(e => e.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.HasOne(e => e.Estados) 
                   .WithMany(eb => eb.Enderecos) 
                   .HasForeignKey("IdEstado") 
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.Rua)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.Numero)
                   .IsRequired();

            builder.Property(e => e.Cidade)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(e => e.CEP)
                   .IsRequired()
                   .HasMaxLength(8);

            builder.Property(e => e.Complemento)
                   .IsRequired(false)
                   .HasMaxLength(50);

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
