using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BoilerPlate.Request.EmailTemplate
{
    public class EmailTemplateRequest
    {
        [StringLength(255)]
        [Required]
        [JsonPropertyName("template_title")]
        public string TemplateTitle { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
