using EDSystems.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDSystems.Domain.Entities;

public class UserAccountHistory : BaseAuditableEntity
{
    public decimal Amount { get; set; }

    public bool JobType { get; set; }
    public int UserAccountId { get; set; }
    public UserAccount UserAccount { get; set; }
    public int CurrencyId { get; set; }
    public Currency Currency { get; set; }
    public int ParcelId { get; set; }
    public Parcel Parcel { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
}