using System.Text.Json.Serialization;

namespace EDSystems.Domain.Entities;

public class ParcelCost : BaseAuditableEntity
{
    public bool StateDeliveryToBranch { get; set; } = false;
    public bool StatePickingUp { get; set; } = false;
    public bool StateDeliveryToPoint { get; set; } = false;
    public bool StateBuyout { get; set; } = false;
    public decimal CostPickingUp { get; set; }
    public decimal CostDeliveryToPoint { get; set; }
    public decimal CostDeliveryToBranch { get; set; }
    public decimal CostBuyout { get; set; }

    public int CurrencyId { get; set; }

    [JsonIgnore]
    public Currency Currency { get; set; }

    [JsonIgnore]
    public int ParcelId { get; set; }

    [JsonIgnore]
    public Parcel Parcel { get; set; }
}