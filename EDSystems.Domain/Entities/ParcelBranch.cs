using Newtonsoft.Json;

//using System.Text.Json.Serialization;

namespace EDSystems.Domain.Entities;

public class ParcelBranch : BaseAuditableEntity
{
    public int ToBranchId { get; set; }

    public Branch ToBranch { get; set; }

    public int FromBranchId { get; set; }

    public Branch FromBranch { get; set; }

    [JsonIgnore]
    public int ParcelId { get; set; }

    [JsonIgnore]
    public virtual Parcel Parcel { get; set; }
}