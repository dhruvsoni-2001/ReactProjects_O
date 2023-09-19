using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BoilerPlate.Models
{
    public class CMS
    {
        public int Id { get; set; }

        [StringLength(255)]
        [JsonPropertyName("page_name")]
        public string PageName { get; set; }

        [StringLength(255)]
        public string Slug { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        [StringLength(255)]
        [JsonPropertyName("meta_title")]
        public string MetaTitle { get; set; }

        [StringLength(255)]
        [JsonPropertyName("meta_keyword")]
        public string MetaKeyword { get; set; }

        [JsonPropertyName("meta_description")]
        public string MetaDescription { get; set; }

        public byte Status { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; } 

        [JsonPropertyName("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}
