using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BoilerPlate.Models
{
    public class Permission
    {
        public int Id { get; set; }

        [StringLength(250)]
        [Required]
        public string Label { get; set; }

        [StringLength(250)]
        [Required]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [JsonPropertyName("module")]
        public int ModuleId { get; set; }

        [Required]
        public byte Status { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set;}

        [JsonPropertyName("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}
