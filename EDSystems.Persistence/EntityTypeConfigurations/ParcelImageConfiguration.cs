using EDSystems.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDSystems.Persistence.EntityTypeConfigurations;

public class ParcelImageConfiguration : IEntityTypeConfiguration<ParcelImage>
{
    public void Configure(EntityTypeBuilder<ParcelImage> builder)
    {
        builder.HasKey(parcelimage => parcelimage.Id);
        builder.HasIndex(parcelimage => parcelimage.Id).IsUnique();
        builder.Property(parcelimage => parcelimage.ImageName).HasColumnType("varchar").HasMaxLength(50);
        builder.Property(parcelimage => parcelimage.ImageBytes).HasColumnType("varchar");
        builder.HasOne(parcelimage => parcelimage.Parcel);
    }
}