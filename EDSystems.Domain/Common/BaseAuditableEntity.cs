using System;

namespace EDSystems.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
    public string CreatedBy { get; set; }
    public string ModifiedBy { get; set; }
}