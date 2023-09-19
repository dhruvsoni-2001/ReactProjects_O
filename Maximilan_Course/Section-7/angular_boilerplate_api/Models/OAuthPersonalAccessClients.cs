using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BoilerPlate.Models
{
    public class OAuthPersonalAccessClients
    {
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("client_id")]
        public long ClientId { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; } 
    }
}
