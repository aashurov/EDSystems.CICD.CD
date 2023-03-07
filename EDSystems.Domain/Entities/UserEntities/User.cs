//using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EDSystems.Domain.Entities.UserEntities;

[Index(nameof(PhoneNumber), IsUnique = true)]
public class User : IdentityUser<int>
{

     
     
    public virtual string FirstName { get; set; }
    public virtual string LastName { get; set; }
    public virtual string Address { get; set; }
    public string UserNameT { get; set; } = "UserName";
    public virtual long ChatId { get; set; } = -1001663331836;

    [JsonIgnore]
    public virtual ICollection<UserRole> UserRoles { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }
}