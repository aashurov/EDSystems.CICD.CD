using EDSystems.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDSystems.Persistence.EntityTypeConfigurations;

public class ParcelPlanConfiguration : IEntityTypeConfiguration<ParcelPlan>
{
    public void Configure(EntityTypeBuilder<ParcelPlan> builder)
    {
        builder.HasKey(parcelPlan => parcelPlan.Id);
        builder.HasIndex(parcelPlan => parcelPlan.Id).IsUnique();
        builder.HasOne(parcelPlan => parcelPlan.Parcel);
    }
}