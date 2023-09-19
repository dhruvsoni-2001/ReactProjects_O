using System.Text.Json.Serialization;

namespace BoilerPlate.Response.Menu
{
    /// <summary>
    /// This Class is used for Create Menu Response
    /// </summary>
    public class CreateMenuResponse : MenuResponse
    {
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}