using EDSystems.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDSystems.Persistence.EntityTypeConfigurations;

public class ParcelCostConfiguration : IEntityTypeConfiguration<ParcelCost>
{
    public void Configure(EntityTypeBuilder<ParcelCost> builder)
    {
        builder.HasKey(parcelcost => parcelcost.Id);
        builder.HasIndex(parcelcost => parcelcost.Id).IsUnique();
        builder.Property(parcelcost => parcelcost.CostDeliveryToBranch).HasColumnType("decimal(18,3)").IsRequired();
        builder.Property(parcelcost => parcelcost.CostDeliveryToPoint).HasColumnType("decimal(18,3)");
        builder.Property(parcelcost => parcelcost.CostPickingUp).HasColumnType("decimal(18,3)");
        builder.HasOne(parcelcost => parcelcost.Currency);
        builder.HasOne(parcelcost => parcelcost.Parcel);
    }
}