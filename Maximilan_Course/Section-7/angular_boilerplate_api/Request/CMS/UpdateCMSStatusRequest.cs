using System.ComponentModel.DataAnnotations;

namespace BoilerPlate.Request.CMS
{
    public class UpdateCMSStatusRequest
    {
        [Required]
        public byte Status { get; set; }
    }
}
