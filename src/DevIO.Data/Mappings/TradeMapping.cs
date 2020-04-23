using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class TradeMapping : IEntityTypeConfiguration<Trade>
    {
        public void Configure(EntityTypeBuilder<Trade> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Value)
                .IsRequired();

            builder.Property(c => c.ClientSector)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.ToTable("Trades");
        }
    }
}