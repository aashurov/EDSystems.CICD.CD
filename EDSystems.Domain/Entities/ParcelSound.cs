using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDSystems.Domain.Entities
{
    public class ParcelSound : BaseAuditableEntity
    {
        public string SoundName { get; set; }

        public string SoundBytes { get; set; }

        [JsonIgnore]
        public Parcel Parcel { get; set; }
    }
}