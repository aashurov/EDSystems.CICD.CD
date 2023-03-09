using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace EDSystems.Domain.Entities;

[JsonSerializable(typeof(Branch))]
public class Branch : BaseAuditableEntity
{
    /// <summary>
    /// 
    /// </summary>
    //[JsonProperty("name")]
    public string Name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    //[JsonProperty("country")]
    public string Country { get; set; }
    /// <summary>
    /// 
    /// </summary>
    //[JsonProperty("code")]
    public string Code { get; set; }
    /// <summary>
    /// 
    /// </summary>
    //[JsonProperty("city")]
    public string City { get; set; }
    /// <summary>
    /// 
    /// </summary>
    //[JsonProperty("address")]
    public string Address { get; set; }
    /// <summary>
    /// 
    /// </summary>
    //[JsonProperty("email")]
    public string Email { get; set; }
    /// <summary>
    /// 
    /// </summary>
    //[JsonProperty("phone")]
    public string Phone { get; set; }
}