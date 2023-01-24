using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDSystems.Domain.Entities;

public class SmsDetails : BaseEntity
{
    [Column(TypeName = "varchar(200)")]
    public string Code { get; set; }
    [Column(TypeName = "varchar(200)")]
    public string Recepient { get; set; }
    [Column(TypeName = "varchar(200)")]
    public string Sender { get; set; }
    [Column(TypeName = "varchar(200)")]
    public string PhoneNumber { get; set; }
    public int Status { get; set; }
}