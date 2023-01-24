using EDSystems.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDSystems.Persistence.EntityTypeConfigurations;

public class ExpenseTypeConfiguration : IEntityTypeConfiguration<ExpenseType>
{
    public void Configure(EntityTypeBuilder<ExpenseType> builder)
    {
        builder.HasKey(account => account.Id);
        builder.HasIndex(account => account.Id).IsUnique();
        builder.Property(account => account.Name).HasColumnType("varchar").HasMaxLength(20);
        builder.Property(account => account.Description).HasColumnType("varchar").HasMaxLength(20);
    }
}