using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BoilerPlate.Request.CMS
{
    public class CreateUpdateCMSRequest
    {
        [Required]
        [StringLength(255)]
        [JsonPropertyName("page_name")]
        public string PageName { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Slug { get; set; }

        [Required]
        public string Description { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        [Required]
        [StringLength(255)]
        [JsonPropertyName("meta_title")]
        public string MetaTitle { get; set; }

        [Required]
        [StringLength(255)]
        [JsonPropertyName("meta_keyword")]
        public string MetaKeyword { get; set; }

        [Required]
        [JsonPropertyName("meta_description")]
        public string MetaDescription { get; set; }

    }
}
