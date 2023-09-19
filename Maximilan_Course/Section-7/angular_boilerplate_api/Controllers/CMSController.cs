using BoilerPlate.Repository;
using BoilerPlate.Request.CMS;
using BoilerPlate.Response.CMS;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BoilerPlate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CMSController : ControllerBase
    {
        private readonly ICMSRepository cmsRepository;

        public CMSController(ICMSRepository _cmsRepository)
        {
            cmsRepository = _cmsRepository;  
        }

        /// <summary>
        /// Create CMS
        /// </summary>
        /// <param name="createUpdateCMSRequest">Represents the object of Create CMS Request class</param>
        /// <returns>Returns the Create CMS Response</returns>
        [HttpPost]
        public IActionResult CreateCMS([Required] CreateUpdateCMSRequest createUpdateCMSRequest)
        {
            var newCMS = cmsRepository.CreateCMS(createUpdateCMSRequest);
            return Ok(newCMS);
        }

        /// <summary>
        /// Get all the CMS
        /// </summary>
        /// <param name="limit">Represents the number of items to be shown in response</param>
        /// <param name="start">Represents the start number</param>
        /// <param name="search">Represents the field to be searched</param>
        /// <param name="order_col">Represents by which cloumn the data is to be sorted</param>
        /// <param name="order_by">Represents how the data is to be sorted (Asc/Desc)</param>
        /// <returns>Returns all the CMS</returns>
        [HttpGet]
        public IActionResult GetAllCMS([Required] int limit = 10, [Required] int start = 0, string? search = "", string order_col = "id", string order_by = "Asc")
        {
            var cms = cmsRepository.GetAllCMS(limit, start, search, order_col, order_by);
            return Ok(cms);
        }

        /// <summary>
        /// Get CMS By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the CMS by Id</returns>
        [HttpGet("{id}")]
        public IActionResult GetCMS([Required] int id)
        {
            var cms = cmsRepository.GetCMSById(id);
            return Ok(cms);
        }

        /// <summary>
        /// Update the CMS
        /// </summary>
        /// <param name="id">Represents the Id of CMS to be Updated</param>
        /// <param name="updateCMSRequest">Represents the object of Update CMS Request Class</param>
        /// <returns>Returns the Updated CMS</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateCMS([Required] int id, [Required] CreateUpdateCMSRequest updateCMSRequest)
        {
            var updateCMS = cmsRepository.UpdateCMS(id, updateCMSRequest);
            return Ok(updateCMS);
        }

        /// <summary>
        /// Delete the CMS
        /// </summary>
        /// <param name="id">Represents the Id of the CMS to be Deleted</param>
        /// <returns>Returns the Delete CMS Response</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteCMS([Required] int id)
        {
            cmsRepository.DeleteCMS(id);
            return Ok(new DeleteCMSResponse()
            {
                Status = "success",
                Message = "CMS Deleted Successfully",
            });
        }

        /// <summary>
        /// Update CMS Status
        /// </summary>
        /// <param name="id">Represents the Id of CMS to be Updated</param>
        /// <param name="updateCMSStatusRequest">Represents the object of Update CMS Status Request class</param>
        /// <returns>Returns the Update CMS Status Response</returns>
        [HttpPut("status/{id}")]
        public IActionResult UpdateCMSStatus([Required] int id, [Required] UpdateCMSStatusRequest updateCMSStatusRequest)
        {
            cmsRepository.UpdateCMSStatus(id, updateCMSStatusRequest);
            return Ok(new UpdateCMSStatusResponse()
            {
                Status = "Success",
                Message = "CMS status updated successfully"
            });
        }
    }
}
