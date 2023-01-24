using EDSystems.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDSystems.Domain.Entities;

public class AccountHistory : BaseAuditableEntity
{
     
    public decimal Amount { get; set; }
    public bool JobType { get; set; } //if == false 0 rasxod else ==1 prixod
    public int BranchAccountId { get; set; }
    public Account BranchAccount { get; set; }
    public int CurrencyId { get; set; }
    public Currency Currency { get; set; }
    public int ParcelId { get; set; }
    public Parcel Parcel { get; set; }
    public string PayerId { get; set; }
    public User Payer { get; set; }
}