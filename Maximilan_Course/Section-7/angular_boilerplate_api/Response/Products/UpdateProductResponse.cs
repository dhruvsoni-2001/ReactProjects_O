using System.ComponentModel;
using System.Text.Json.Serialization;

namespace BoilerPlate.Response.Products
{
    public class UpdateProductResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [DefaultValue("0")]
        public byte Status { get; set; }
    }
}
