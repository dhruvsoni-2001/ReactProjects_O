using System.ComponentModel.DataAnnotations;

namespace BoilerPlate.Models
{
    public class OauthClients
    {
        [Key]
        public long Id { get; set; }

        public long UserId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Secret { get; set; }

        public string Provider { get; set; }

        [Required]
        public string Redirect { get; set; }

        [Required]
        public byte PersonalAccessClient { get; set; }

        [Required]
        public byte PasswordClient { get; set; }

        [Required]
        public short Revoked { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }
    }
}