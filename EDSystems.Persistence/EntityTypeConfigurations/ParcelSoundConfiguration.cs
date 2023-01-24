using EDSystems.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDSystems.Persistence.EntityTypeConfigurations;

public class ParcelSoundConfiguration : IEntityTypeConfiguration<ParcelSound>
{
    public void Configure(EntityTypeBuilder<ParcelSound> builder)
    {
        builder.HasKey(parcelSound => parcelSound.Id);
        builder.HasIndex(parcelSound => parcelSound.Id).IsUnique();
        builder.Property(parcelSound => parcelSound.SoundName).HasColumnType("varchar").HasMaxLength(20);
        builder.Property(parcelSound => parcelSound.SoundBytes).HasColumnType("varchar");
        builder.HasOne(parcelSound => parcelSound.Parcel);
    }
}