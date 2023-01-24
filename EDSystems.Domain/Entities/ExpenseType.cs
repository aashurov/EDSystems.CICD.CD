namespace EDSystems.Domain.Entities;

public class ExpenseType : BaseAuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
}