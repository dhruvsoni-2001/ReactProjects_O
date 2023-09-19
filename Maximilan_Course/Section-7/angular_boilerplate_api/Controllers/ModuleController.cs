using BoilerPlate.Repository;
using BoilerPlate.Request.Module;
using BoilerPlate.Response.Module;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BoilerPlate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : BaseController
    {
        private readonly IModuleRepository moduleRepository;

        public ModuleController(IModuleRepository _moduleRepository)
        {
            moduleRepository = _moduleRepository;
        }

        /// <summary>
        /// Update the Modules
        /// </summary>
        /// <param name="id">Represents the Id of Module to be Updated</param>
        /// <param name="updateModuleRequest">Represents the object of Update Module Request Class</param>
        /// <returns>Returns the Updated Module</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateModule(int id, [Required] UpdateModuleRequest updateModuleRequest)
        {
            var updatedModule = moduleRepository.UpdateModule(id, updateModuleRequest);
            return Ok(updatedModule);
        }

        /// <summary>
        /// Delete the Modules
        /// </summary>
        /// <param name="id">Represents the Id of Module to be Deleted</param>
        /// <returns>Returns the Deleted Module</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteModule(int id)
        {
            moduleRepository.DeleteModule(id);
            return Ok(new DeleteModuleResponse()
            {
                Status = "Success",
                Message = "Module Deleted Successfully"
            }) ;
        }

        /// <summary>
        /// Create Modules
        /// </summary>
        /// <param name="createModuleRequest">Represents the object of Create Module Request</param>
        /// <returns>Returns the Created Module Response</returns>
        [HttpPost]
        public IActionResult CreateModule(CreateModuleRequest createModuleRequest)
        {
            var newModule = moduleRepository.CreateModule(createModuleRequest);
            return Ok(newModule);
        }

        /// <summary>
        /// Get All Modules
        /// </summary>
        /// <returns>Returns the list of response of all the Modules</returns>
        [HttpGet]
        public IActionResult GetAllModules()
        {
            var modules = moduleRepository.GetModules();
            return Ok(modules);
        }

        /// <summary>
        /// Get Module By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the module by id </returns>
        [HttpGet("{id}")]
        public IActionResult GetModule(int id) 
        {
            var module = moduleRepository.GetModuleById(id);
            return Ok(module);
        }
    }   
}