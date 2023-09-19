using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BoilerPlate.Models
{
    [Table("products")]
    public class Products
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DefaultValue("0")]
        public int Status { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonPropertyName("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}