using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class SectorMapping : IEntityTypeConfiguration<Sector>
    {
        public void Configure(EntityTypeBuilder<Sector> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Description)
                .IsRequired(false)
                .HasColumnType("varchar(200)");

            builder.ToTable("Sectors");
        }
    }
}