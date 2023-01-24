using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDSystems.Domain.Entities;

public class Currency : BaseAuditableEntity
{
    [Column(TypeName = "varchar(200)")]
    public string Name { get; set; }
    [Column(TypeName = "varchar(200)")]
    public string Code { get; set; }
    public int Number { get; set; }
    [Column(TypeName = "varchar(200)")]
    public string Country { get; set; }
}