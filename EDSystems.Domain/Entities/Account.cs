using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
namespace EDSystems.Domain.Entities;

public class Account : BaseAuditableEntity
{
    public string Number { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public int BranchId { get; set; }
    public Branch Branch { get; set; }
    public int CurrencyId { get; set; }
    public Currency Currency { get; set; }
    public ICollection<AccountHistory> AccountHistory { get; set; }
}