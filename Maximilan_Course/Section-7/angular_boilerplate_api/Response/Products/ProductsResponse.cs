using System.ComponentModel;
using System.Text.Json.Serialization;

namespace BoilerPlate.Response.Products
{
    public class ProductsResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; } =DateTime.Now;

        [DefaultValue("0")]
        public byte Status { get; set; }
    }
}
