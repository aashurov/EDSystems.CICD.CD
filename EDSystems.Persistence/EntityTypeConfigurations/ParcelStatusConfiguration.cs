using EDSystems.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDSystems.Persistence.EntityTypeConfigurations;

public class ParcelStatusConfiguration : IEntityTypeConfiguration<ParcelStatus>
{
    public void Configure(EntityTypeBuilder<ParcelStatus> builder)
    {
        builder.HasKey(parcelStatus => parcelStatus.Id);
        builder.HasIndex(parcelStatus => parcelStatus.Id).IsUnique();
        builder.HasOne(c => c.Status);
        builder.HasOne(parcelStatus => parcelStatus.Parcel);
    }
}