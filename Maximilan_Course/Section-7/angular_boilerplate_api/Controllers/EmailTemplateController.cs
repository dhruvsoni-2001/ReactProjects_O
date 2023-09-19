using BoilerPlate.Repository;
using BoilerPlate.Request.EmailTemplate;
using BoilerPlate.Response.EmailTemplate;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BoilerPlate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailTemplateController : ControllerBase
    {
        private readonly IEmailTemplateRepository emailTemplateRepository;

        public EmailTemplateController(IEmailTemplateRepository _emailTemplateRepository)
        {
            emailTemplateRepository = _emailTemplateRepository;
        }

        /// <summary>
        /// Create EmailTemplate
        /// </summary>
        /// <param name="createEmailTemplateRequest">Represents the object of Create EmailTemplate Request class</param>
        /// <returns>Returns the Create EmailTemplate Response</returns>
        [HttpPost]
        public IActionResult CreateEmailTemplate([Required]EmailTemplateRequest createEmailTemplateRequest)
        {
            var newEmailTemplate = emailTemplateRepository.CreateEmailTemplate(createEmailTemplateRequest);
            return Ok(newEmailTemplate);
        }

        /// <summary>
        /// Get all the EmailTemplate
        /// </summary>
        /// <param name="limit">Represents the number of items to be shown in response</param>
        /// <param name="start">Represents the start number</param>
        /// <param name="search">Represents the field to be searched</param>
        /// <param name="order_col">Represents by which cloumn the data is to be sorted</param>
        /// <param name="order_by">Represents how the data is to be sorted (Asc/Desc)</param>
        /// <returns>Returns all the EmailTemplate</returns>
        [HttpGet]
        public IActionResult GetAllEmailTemplates([Required] int limit = 10, [Required] int start = 0, string? search = "", string order_col = "id", string order_by = "Asc")
        {
            var emailTemplates = emailTemplateRepository.GetEmailTemplates(limit, start, search, order_col, order_by);
            return Ok(emailTemplates);
        }

        /// <summary>
        /// Get EmailTemplate By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the EmailTemplate by Id</returns>
        [HttpGet("{id}")]
        public IActionResult GetEmailTemplate([Required]int id)
        {
            var emailTemplate = emailTemplateRepository.GetEmailTemplateById(id);
            return Ok(emailTemplate);
        }

        /// <summary>
        /// Update the EmailTemplate
        /// </summary>
        /// <param name="id">Represents the Id of EmailTemplate to be Updated</param>
        /// <param name="emailTemplateRequest">Represents the object of Update EmailTemplate Request Class</param>
        /// <returns>Returns the Updated EmailTemplate</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateEmailTemplate([Required]int id, [Required] EmailTemplateRequest emailTemplateRequest)
        {
            var updateEmailTemplate = emailTemplateRepository.UpdateEmailTemplate(id, emailTemplateRequest);
            return Ok(updateEmailTemplate);
        }

        /// <summary>
        /// Delete the EmailTemplate
        /// </summary>
        /// <param name="id">Represents the Id of the EmailTemplate to be Deleted</param>
        /// <returns>Returns the Delete EmailTemplate Response</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteEmailTemplate([Required]int id)
        {
            emailTemplateRepository.DeleteEmailTemplate(id);
            return Ok(new DeleteEmailTemplateResponse()
            {
                Status = "success",
                Message = "EmailTemplate Deleted Successfully",
            });
        }

        /// <summary>
        /// Update EmailTemplate Status
        /// </summary>
        /// <param name="id">Represents the Id of EmailTemplate to be Updated</param>
        /// <param name="updateEmailTemplateStatusRequest">Represents the object of Update EmailTemplate Status Request class</param>
        /// <returns>Returns the Update EmailTemplate Status Response</returns>
        [HttpPut("status/{id}")]
        public IActionResult UpdateEmailTemplateStatus([Required] int id, [Required] UpdateEmailTemplateStatusRequest updateEmailTemplateStatusRequest)
        {
            emailTemplateRepository.UpdateEmailTemplateStatus(id, updateEmailTemplateStatusRequest);
            return Ok(new UpdateEmailTemplateStatusResponse()
            {
                Status = "Success",
                Message = "EmailTemplate status updated successfully"
            });
        }
    }
}
