using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BoilerPlate.Models
{
    public class EmailTemplate
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        [JsonPropertyName("template_title")]
        public string TemplateTitle { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Content { get; set; }

        [StringLength(255)]
        [JsonPropertyName("file_name")]
        public string FileName { get; set; }

        [JsonPropertyName("creative_format_id")]
        public int CreativeFormatId { get; set; }

        public byte Status { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        [JsonPropertyName("deleted_at")]
        public DateTime? DeletedAt { get; set; } 
    }
}
