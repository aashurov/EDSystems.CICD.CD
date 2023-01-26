using EDSystems.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDSystems.Persistence.EntityTypeConfigurations;

public class PlanConfiguration : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.HasKey(plan => plan.Id);
        builder.HasIndex(plan => plan.Id).IsUnique();
        builder.Property(plan => plan.Name).HasColumnType("varchar").HasMaxLength(255);
        builder.Property(plan => plan.Cost).HasColumnType("decimal(18,3)").HasMaxLength(5).IsRequired();
        builder.Property(plan => plan.Description).HasColumnType("varchar").HasMaxLength(500).IsRequired();
    }
}