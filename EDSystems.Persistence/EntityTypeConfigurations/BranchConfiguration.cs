using EDSystems.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDSystems.Persistence.EntityTypeConfigurations;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.HasKey(branch => branch.Id);
        builder.HasIndex(branch => branch.Id).IsUnique();
        builder.Property(branch => branch.Address).HasColumnType("varchar").HasMaxLength(500).IsRequired();
        builder.Property(branch => branch.City).HasColumnType("varchar").HasMaxLength(30).IsRequired();
        builder.Property(branch => branch.Country).HasColumnType("varchar").HasMaxLength(30).IsRequired();
        builder.Property(branch => branch.Email).HasColumnType("varchar").HasMaxLength(20);
        builder.Property(branch => branch.Name).HasColumnType("varchar").HasMaxLength(20).IsRequired();
        builder.Property(branch => branch.Phone).HasColumnType("varchar").HasMaxLength(20);
    }
}