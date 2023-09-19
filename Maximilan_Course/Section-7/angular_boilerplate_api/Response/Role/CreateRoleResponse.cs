using System.Text.Json.Serialization;

namespace BoilerPlate.Response.Role
{
    /// <summary>
    /// This Class is used for When User Creates Role Response
    /// </summary>
    public class CreateRoleResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}