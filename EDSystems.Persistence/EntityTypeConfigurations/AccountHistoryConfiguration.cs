using EDSystems.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDSystems.Persistence.EntityTypeConfigurations;

public class AccountHistoryConfiguration : IEntityTypeConfiguration<AccountHistory>
{
    public void Configure(EntityTypeBuilder<AccountHistory> builder)
    {
        builder.HasKey(accountHistory => accountHistory.Id);
        builder.HasIndex(accountHistory => accountHistory.Id).IsUnique();
        builder.Property(accountHistory => accountHistory.Amount).HasColumnType("decimal(18,3)").IsRequired();
        builder.Property(accountHistory => accountHistory.JobType).HasColumnType("bool").IsRequired();
        builder.HasOne(accountHistory => accountHistory.Currency);
        builder.HasOne(accountHistory => accountHistory.BranchAccount);
        builder.HasOne(accountHistory => accountHistory.Payer);
        builder.HasOne(accountHistory => accountHistory.Parcel);
    }
}