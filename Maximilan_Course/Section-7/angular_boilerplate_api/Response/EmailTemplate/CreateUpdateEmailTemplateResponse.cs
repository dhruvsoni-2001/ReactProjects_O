using System.Text.Json.Serialization;

namespace BoilerPlate.Response.EmailTemplate
{
    public class CreateUpdateEmailTemplateResponse
    {
        public int Id { get; set; }

        [JsonPropertyName("template_title")]
        public string TemplateTitle { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public byte Status { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
