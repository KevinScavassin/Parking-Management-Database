using ParkingDB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingDB.Configurations
{
    public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(t  => t.Id)
                   .IsClustered(true);

            builder.Property(t => t.Id)
                   .HasColumnName($"{nameof(Telefone)}Id")
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.HasOne(t => t.Cliente) 
                   .WithMany(c => c.Telefones)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(t => t.DDD)
                   .IsRequired()
                   .HasMaxLength(3);

            builder.Property(t => t.NumeroTelefone)
                   .IsRequired()
                   .HasMaxLength(15);

            builder.Property(t => t.DataHoraInclusao)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(t => t.UsuarioInclusao)
                   .IsRequired()
                   .HasMaxLength(80);

            builder.Property(t => t.DataHoraAlteracao)
                   .IsRequired();

            builder.Property(t => t.UsuarioAlteracao)
                   .HasMaxLength(80);

            builder.Property(t => t.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);

        }
    }
}
