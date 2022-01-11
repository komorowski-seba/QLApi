using Domain.Entities.ProvinceContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class CommuneConfiguration : IEntityTypeConfiguration<Commune>
    {
        public void Configure(EntityTypeBuilder<Commune> builder)
        {
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Id).ValueGeneratedNever();

            var navi = builder.Metadata.FindNavigation(nameof(Commune.Cities));
            navi.SetPropertyAccessMode(PropertyAccessMode.Field);
            
            builder.HasOne(n => n.Province)
                .WithMany(n => n.Communes)
                .HasForeignKey(n => n.ProvinceId);
        }
    }
}