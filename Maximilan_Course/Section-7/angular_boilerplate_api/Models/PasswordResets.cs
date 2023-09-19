namespace BoilerPlate.Models
{
    public class PasswordResets
    {
        public string Email { get; set; }

        public string Token { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}