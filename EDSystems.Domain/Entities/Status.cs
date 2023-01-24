namespace EDSystems.Domain.Entities;

public class Status : BaseAuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
}