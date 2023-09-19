using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BoilerPlate.Models
{
    public class Role
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Title { get; set; }

        [DefaultValue("1")]
        public byte Status { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set;} 

        [JsonPropertyName("deleted_at")]
        public DateTime? DeletedAt { get; set; } 
    }
}