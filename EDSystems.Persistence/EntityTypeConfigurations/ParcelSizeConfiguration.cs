using EDSystems.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDSystems.Persistence.EntityTypeConfigurations;

public class ParcelSizeConfiguration : IEntityTypeConfiguration<ParcelSize>
{
    public void Configure(EntityTypeBuilder<ParcelSize> builder)
    {
        builder.HasKey(parcelSize => parcelSize.Id);
        builder.HasIndex(parcelSize => parcelSize.Id).IsUnique();
        builder.Property(parcelSize => parcelSize.Weight).HasColumnType("decimal(18,3)").HasMaxLength(20).IsRequired();
        builder.Property(parcelSize => parcelSize.NumberOfPoint).HasColumnType("int").HasMaxLength(3).IsRequired();
        builder.HasOne(parcelSize => parcelSize.Parcel);
    }
}