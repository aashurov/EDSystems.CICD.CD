//using System.Text.Json.Serialization;
using EDSystems.Domain.Entities.UserEntities;

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDSystems.Domain.Entities;

public class ParcelOwners : BaseAuditableEntity
{
    public string SenderId { get; set; }

    [JsonIgnore]
    public virtual User Sender { get; set; }
    public string RecepientId { get; set; }

    [JsonIgnore]
    public virtual User Recepient { get; set; }
    public string RecepientStaffId { get; set; }

    [JsonIgnore]
    public virtual User RecepientStaff { get; set; }
    public string SenderStaffId { get; set; }

    [JsonIgnore]
    public virtual User SenderStaff { get; set; }
    public string RecepientCourierId { get; set; }

    [JsonIgnore]
    public virtual User RecepientCourier { get; set; }
    public string SenderCourierId { get; set; }

    [JsonIgnore]
    public virtual User SenderCourier { get; set; }

    [JsonIgnore]
    public int ParcelId { get; set; }

    [JsonIgnore]
    public Parcel Parcel { get; set; }
}