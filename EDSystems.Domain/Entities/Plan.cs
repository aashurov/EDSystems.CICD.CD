using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDSystems.Domain.Entities;

public class Plan : BaseAuditableEntity
{
    [Column(TypeName = "varchar(200)")]
    public string Name { get; set; }
    public decimal Cost { get; set; }
    public string Description { get; set; }
}