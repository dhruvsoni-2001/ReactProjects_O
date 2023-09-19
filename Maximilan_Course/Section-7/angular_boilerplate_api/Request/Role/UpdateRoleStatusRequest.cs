using System.ComponentModel.DataAnnotations;

namespace BoilerPlate.Request.Role
{
    /// <summary>
    /// This Class is used for Creating Role Status Requests
    /// </summary>
    public class UpdateRoleStatusRequest
    {
        [Required]
        public byte Status { get; set; }
    }
}