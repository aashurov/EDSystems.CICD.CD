using EDSystems.Domain.Entities.UserEntities;
using System.Collections.Generic;

namespace EDSystems.Domain.Entities;

public class ParcelJob : BaseAuditableEntity
{
    public decimal Cost { get; set; }
    public ICollection<User> Courier { get; set; }
    public string CourierId { get; set; }
    public string JobType { get; set; }
    public int ParcelId { get; set; }
    public Parcel Parcel { get; set; }

    //zabor dostavka
    public bool PaymentState { get; set; } //zabor dostavka
}