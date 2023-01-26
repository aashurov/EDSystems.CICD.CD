using EDSystems.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDSystems.Persistence.EntityTypeConfigurations;

public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {
        builder.HasKey(userAccount => userAccount.Id);
        builder.HasIndex(userAccount => userAccount.Id).IsUnique();
        builder.Property(userAccount => userAccount.Name).HasColumnType("varchar").HasMaxLength(20);
        builder.Property(userAccount => userAccount.Number).HasColumnType("varchar").HasMaxLength(20);
        builder.Property(userAccount => userAccount.Balance).HasMaxLength(20);
        builder.HasOne(userAccount => userAccount.Currency);
        builder.HasOne(userAccount => userAccount.User);
    }
}