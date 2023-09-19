using System.Text.Json.Serialization;

namespace BoilerPlate.Response.CMS
{
    public class CMSResponse
    {
        public int Id { get; set; }

        [JsonPropertyName("page_name")]
        public string PageName { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        [JsonPropertyName("meta_title")]
        public string MetaTitle { get; set; }

        [JsonPropertyName("meta_keyword")]
        public string MetaKeyword { get; set; }

        [JsonPropertyName("meta_description")]
        public string MetaDescription { get; set; }

        public byte Status { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonPropertyName("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}
