using EDSystems.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDSystems.Persistence.EntityTypeConfigurations;

public class UserAccountHistoryConfiguration : IEntityTypeConfiguration<UserAccountHistory>
{
    public void Configure(EntityTypeBuilder<UserAccountHistory> builder)
    {
        builder.HasKey(userAccountHistory => userAccountHistory.Id);
        builder.HasIndex(userAccountHistory => userAccountHistory.Id).IsUnique();
        builder.Property(userAccountHistory => userAccountHistory.Amount).HasColumnType("decimal(18,3)").IsRequired();
        builder.Property(userAccountHistory => userAccountHistory.JobType).HasColumnType("bool").IsRequired();
        builder.HasOne(userAccountHistory => userAccountHistory.Currency);
        builder.HasOne(userAccountHistory => userAccountHistory.User);
    }
}