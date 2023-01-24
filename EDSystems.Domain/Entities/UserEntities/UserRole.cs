using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//using System.Text.Json.Serialization;

namespace EDSystems.Domain.Entities.UserEntities;

public class UserRole : IdentityUserRole<string>
{
    [JsonIgnore]
    public virtual User User { get; set; }

    [Key]
    public virtual Role Role { get; set; }

    [ForeignKey("AspNetUser")]
    [JsonIgnore]
    public override string UserId { get; set; }

    [ForeignKey("AspNetRole")]
    [JsonIgnore]
    public override string RoleId { get; set; }
}