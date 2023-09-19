using System.ComponentModel.DataAnnotations;

namespace BoilerPlate.Request.EmailTemplate
{
    public class UpdateEmailTemplateStatusRequest
    {
            [Required]
            public byte Status { get; set; }
    }
}
