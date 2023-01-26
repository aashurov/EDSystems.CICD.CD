using EDSystems.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDSystems.Persistence.EntityTypeConfigurations;

public class ParcelOwnersConfiguration : IEntityTypeConfiguration<ParcelOwners>
{
    public void Configure(EntityTypeBuilder<ParcelOwners> builder)
    {
        builder.HasKey(parcelowners => parcelowners.Id);
        builder.HasIndex(parcelowners => parcelowners.Id).IsUnique();
        builder.HasOne(parcelowners => parcelowners.Recepient);
        builder.HasOne(parcelowners => parcelowners.RecepientStaff);
        builder.HasOne(parcelowners => parcelowners.Sender);
        builder.HasOne(parcelowners => parcelowners.SenderCourier);
        builder.HasOne(parcelowners => parcelowners.SenderStaff);
        builder.HasOne(parcelowners => parcelowners.Parcel);
    }
}