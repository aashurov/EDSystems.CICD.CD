using EDSystems.Domain.IdentityUserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDSystems.Persistence.EntityTypeConfigurations;

public class TokensConfiguration : IEntityTypeConfiguration<Tokens>
{
    public void Configure(EntityTypeBuilder<Tokens> builder)
    {
        builder.HasKey(tokens => tokens.Id);
        builder.HasIndex(tokens => tokens.Id).IsUnique();
    }
}