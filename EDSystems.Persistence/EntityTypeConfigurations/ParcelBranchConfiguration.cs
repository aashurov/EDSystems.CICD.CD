using EDSystems.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDSystems.Persistence.EntityTypeConfigurations;

public class ParcelBranchConfiguration : IEntityTypeConfiguration<ParcelBranch>
{
    public void Configure(EntityTypeBuilder<ParcelBranch> builder)
    {
        builder.HasKey(parcelbranch => parcelbranch.Id);
        builder.HasIndex(parcelbranch => parcelbranch.Id).IsUnique();
        builder.HasOne(parcelbranch => parcelbranch.FromBranch);
        builder.HasOne(parcelbranch => parcelbranch.ToBranch);
        builder.HasOne(parcelbranch => parcelbranch.Parcel).WithOne(w => w.ParcelBranch).OnDelete(DeleteBehavior.Cascade);
    }
}