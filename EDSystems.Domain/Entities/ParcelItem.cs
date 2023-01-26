using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDSystems.Domain.Entities
{
    public class ParcelItem : BaseAuditableEntity
    {
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Cost { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }

        [JsonIgnore]
        public Parcel Parcel { get; set; }
    }
}