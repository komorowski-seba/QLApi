using Domain.Entities.ProvinceContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Id).ValueGeneratedNever();

            var navi = builder.Metadata.FindNavigation(nameof(City.Stations));
            navi.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasOne(n => n.Commune)
                .WithMany(n => n.Cities)
                .HasForeignKey(n => n.CommuneId);
        }
    }
}