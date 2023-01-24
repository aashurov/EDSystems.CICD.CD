using Newtonsoft.Json;

namespace EDSystems.Domain.Entities.UserEntities;

public class UserDto : User
{
    [JsonIgnore]
    public override string PasswordHash { get; set; }
}