using System;

namespace EDSystems.Domain.Entities.UserEntities
{
    public class RefreshToken
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Token { get; set; }

        public string JwtId { get; set; }

        public bool IsUsed { get; set; }

        public bool IsRevoked { get; set; }

        public DateTime AddedDateTime { get; set; } = DateTime.Now;

        public DateTime ExpiryDateTime { get; set; }
    }
}