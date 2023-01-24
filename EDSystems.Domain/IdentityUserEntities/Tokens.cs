namespace EDSystems.Domain.IdentityUserEntities;

public class Tokens : BaseAuditableEntity
{
    public string TokenId { get; set; }
    public string RefreshToken { get; set; }
}