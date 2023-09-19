using System.ComponentModel.DataAnnotations;

namespace BoilerPlate.Models
{
    public class OauthAuthCodes
    {
        public int Id { get; set; }

        [Required]
        public long UserId { get; set; }

        [Required]
        public long ClientId { get; set; }

        public string Scopes { get; set; }

        [Required]
        public byte Revoked { get; set; }

        public DateTime ExpiresAt { get; set; }
    }
}