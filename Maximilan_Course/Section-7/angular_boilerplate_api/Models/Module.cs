using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BoilerPlate.Models
{
    public class Module
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Label { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        public byte Status { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; } 

        [JsonPropertyName("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}
