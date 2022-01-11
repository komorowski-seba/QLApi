using Domain.Entities.AirAnalysisContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class AirTestHistoryConfiguration : IEntityTypeConfiguration<AirTestHistory>
    {
        public void Configure(EntityTypeBuilder<AirTestHistory> builder)
        {
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Id).HasDefaultValueSql("NEWID()");
            
            var nav = builder.Metadata.FindNavigation(nameof(AirTestHistory.AirTests));
            nav.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}