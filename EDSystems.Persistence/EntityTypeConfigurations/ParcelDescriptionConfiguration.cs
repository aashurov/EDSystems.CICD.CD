using EDSystems.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDSystems.Persistence.EntityTypeConfigurations;

public class ParcelDescriptionConfiguration : IEntityTypeConfiguration<ParcelDescription>
{
    public void Configure(EntityTypeBuilder<ParcelDescription> builder)
    {
        builder.HasKey(parceldescription => parceldescription.Id);
        builder.HasIndex(parceldescription => parceldescription.Id).IsUnique();
        builder.Property(parceldescription => parceldescription.Description).HasColumnType("varchar").HasMaxLength(500);
        builder.HasOne(parceldescription => parceldescription.Parcel);
    }
}