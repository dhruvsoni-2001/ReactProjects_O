using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BoilerPlate.Models
{
    public class OAuthRefreshTokens
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        [JsonPropertyName("access_token_id")]
        public string AccessTokenId { get; set; }

        [Required]
        public byte Revoked { get; set; }

        [JsonPropertyName("expires_at")]
        public DateTime? ExpiresAt { get; set; }
    }
}
