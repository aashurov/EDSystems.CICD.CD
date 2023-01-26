//using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDSystems.Domain.Entities;

public class ParcelImage : BaseAuditableEntity
{
    [JsonIgnore]
    public string ImageName { get; set; }
    public string ImageBytes { get; set; }
    [JsonIgnore]
    public Parcel Parcel { get; set; }
}