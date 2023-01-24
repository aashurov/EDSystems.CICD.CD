using Newtonsoft.Json;

namespace EDSystems.Domain.Entities;

public class ExchangeRate
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("Code")]
    public string Code { get; set; }

    [JsonProperty("Ccy")]
    public string Ccy { get; set; }

    [JsonProperty("CcyNm_RU")]
    public string CcyNm_RU { get; set; }

    [JsonProperty("CcyNm_UZ")]
    public string CcyNm_UZ { get; set; }

    [JsonProperty("CcyNm_UZC")]
    public string CcyNm_UZC { get; set; }

    [JsonProperty("CcyNm_EN")]
    public string CcyNm_EN { get; set; }

    [JsonProperty("Nominal")]
    public string Nominal { get; set; }

    [JsonProperty("Rate")]
    public string Rate { get; set; }

    [JsonProperty("Diff")]
    public string Diff { get; set; }

    [JsonProperty("Date")]
    public string Date { get; set; }
}