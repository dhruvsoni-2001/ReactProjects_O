namespace BoilerPlate.Models
{
    public class OuthAccessTokens
    {
        public int Id { get; set; }

        public long UserId { get; set; }

        public long ClientId { get; set; }

        public string Name { get; set; }

        public string Scopes { get; set; }

        public byte Revoked { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        public DateTime ExpiresAt { get; set; }
    }
}