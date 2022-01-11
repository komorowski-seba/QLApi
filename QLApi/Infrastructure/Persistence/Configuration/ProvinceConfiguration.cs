using Domain.Entities.ProvinceContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Id).HasDefaultValueSql("NEWID()");

            var nav = builder.Metadata.FindNavigation(nameof(Province.Communes));
            nav.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}