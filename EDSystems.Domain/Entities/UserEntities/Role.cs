using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Collections.Generic;

//using System.Text.Json.Serialization;

namespace EDSystems.Domain.Entities.UserEntities;

public class Role : IdentityRole<int>
{
    [JsonIgnore]
    public virtual ICollection<UserRole> UserRoles { get; set; }

    [JsonIgnore]
    public override string NormalizedName { get; set; }

    [JsonIgnore]
    public override string ConcurrencyStamp { get; set; }
}