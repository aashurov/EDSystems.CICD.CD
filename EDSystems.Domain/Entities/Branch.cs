namespace EDSystems.Domain.Entities;

public class Branch : BaseAuditableEntity
{
    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Country { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Code { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string City { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Address { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Phone { get; set; }
}