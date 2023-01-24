using Newtonsoft.Json;

//using System.Text.Json.Serialization;

namespace EDSystems.Domain.Entities;

public class ParcelSize : BaseAuditableEntity
{
    public decimal Weight { get; set; }

    public int NumberOfPoint { get; set; } = 1;

    [JsonIgnore]
    public int ParcelId { get; set; }

    [JsonIgnore]
    public Parcel Parcel { get; set; }
}