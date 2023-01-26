//using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace EDSystems.Domain.Entities;

public class ParcelDescription : BaseAuditableEntity
{
    public string Description { get; set; }

    [JsonIgnore]
    public int ParcelId { get; set; }

    [JsonIgnore]
    public Parcel Parcel { get; set; }
}