using Newtonsoft.Json;

//using System.Text.Json.Serialization;

namespace EDSystems.Domain.Entities;

public class ParcelPlan : BaseAuditableEntity
{
    public int PlanId { get; set; }
    public Plan Plan { get; set; }

    [JsonIgnore]
    public int ParcelId { get; set; }

    [JsonIgnore]
    public Parcel Parcel { get; set; }
}