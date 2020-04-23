using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Initials)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.Property(c => c.Description)
                .IsRequired(false)
                .HasColumnType("varchar(200)");

            builder.ToTable("Categories");
        }
    }
}