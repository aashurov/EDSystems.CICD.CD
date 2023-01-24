using System.Collections.Generic;

namespace EDSystems.Domain.Entities;

public class Parcel : BaseAuditableEntity
{
    public int Code { get; set; }
    public virtual ParcelCost ParcelCost { get; set; }
    public virtual ParcelOwners ParcelOwners { get; set; }
    public virtual ParcelPlan ParcelPlan { get; set; }
    public virtual ParcelSize ParcelSize { get; set; }
    public virtual ParcelBranch ParcelBranch { get; set; }
    public virtual ICollection<ParcelStatus> ParcelStatus { get; set; }
    public virtual ICollection<ParcelImage> ParcelImage { get; set; }
    public virtual ICollection<ParcelSound> ParcelSound { get; set; }
    public virtual ICollection<ParcelItem> ParcelItem { get; set; }
    public virtual ParcelDescription ParcelDescription { get; set; }
}