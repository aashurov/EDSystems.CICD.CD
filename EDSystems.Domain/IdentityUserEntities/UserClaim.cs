//using System.Text.Json.Serialization;

using EDSystems.Domain.Entities.UserEntities;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace EDSystems.Domain.IdentityUserEntities;

public class UserClaim : IdentityUserClaim<int>
{
    [JsonIgnore]
    public virtual User User { get; set; }
}