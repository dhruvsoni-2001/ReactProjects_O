using System.Text.Json.Serialization;

namespace BoilerPlate.Response.Module
{
    /// <summary>
    /// This Class is used for Base Module Response
    /// </summary>
    public abstract class BaseModuleResponse
    {
        public int Id { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime created_at { get; set; } = DateTime.Now;
    }
}