using EDSystems.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDSystems.Persistence.EntityTypeConfigurations;

public class ParcelConfiguration : IEntityTypeConfiguration<Parcel>
{
    public void Configure(EntityTypeBuilder<Parcel> builder)
    {
        builder.HasKey(parcel => parcel.Id);
        builder.HasIndex(parcel => parcel.Id).IsUnique();
        builder.HasMany(parcel => parcel.ParcelImage).WithOne(e => e.Parcel).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(parcel => parcel.ParcelSound).WithOne(e => e.Parcel).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(parcel => parcel.ParcelItem).WithOne(e => e.Parcel).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(parcel => parcel.ParcelStatus).WithOne(e => e.Parcel).OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(parcel => parcel.ParcelBranch).WithOne(e => e.Parcel).HasForeignKey<ParcelBranch>(e => e.ParcelId).OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(parcel => parcel.ParcelCost).WithOne(e => e.Parcel).HasForeignKey<ParcelCost>(e => e.ParcelId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(parcel => parcel.ParcelDescription).WithOne(e => e.Parcel).HasForeignKey<ParcelDescription>(e => e.ParcelId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(parcel => parcel.ParcelPlan).WithOne(e => e.Parcel).HasForeignKey<ParcelPlan>(e => e.ParcelId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(parcel => parcel.ParcelSize).WithOne(e => e.Parcel).HasForeignKey<ParcelSize>(e => e.ParcelId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(parcel => parcel.ParcelOwners).WithOne(e => e.Parcel).HasForeignKey<ParcelOwners>(e => e.ParcelId).OnDelete(DeleteBehavior.Cascade);
        builder.Property(parcel => parcel.Code).HasMaxLength(255);
    }
}