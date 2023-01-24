using EDSystems.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDSystems.Persistence.EntityTypeConfigurations;

public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.HasKey(currency => currency.Id);
        builder.HasIndex(currency => currency.Id).IsUnique();
        builder.Property(currency => currency.Code).HasColumnType("varchar").HasMaxLength(4);
        builder.Property(currency => currency.Number).HasColumnType("integer").HasMaxLength(10);
        builder.Property(currency => currency.Country).HasColumnType("varchar").HasMaxLength(250);
        builder.Property(currency => currency.Name).HasColumnType("varchar").HasMaxLength(20);
    }
}