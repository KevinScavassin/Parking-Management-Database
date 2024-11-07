using ParkingDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingDB.Configurations
{
    public class StatusVagaConfiguration : IEntityTypeConfiguration<StatusVaga>
    {
        public void Configure(EntityTypeBuilder<StatusVaga> builder)
        {
            builder.HasKey(sv => sv.IDStatusVaga);
            builder.Property(sv => sv.Descricao).IsRequired().HasMaxLength(100);
        }
    }
}
