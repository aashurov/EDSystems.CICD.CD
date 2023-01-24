using Newtonsoft.Json;

//using System.Text.Json.Serialization;

namespace EDSystems.Domain.Entities;

public class ParcelStatus : BaseAuditableEntity
{
    public Status Status { get; set; }

    [JsonIgnore]
    public Parcel Parcel { get; set; }
}