using System.ComponentModel.DataAnnotations;

namespace BoilerPlate.Request.Module
{
    /// <summary>
    /// This Class is used for Creating Module Requests
    /// </summary>
    public class CreateModuleRequest
    {
        [Required]
        public string Label { get; set; }

        [Required]
        public string Name { get; set; }

        public byte Status { get; set; }
    }
}