using BoilerPlate.Repository;
using BoilerPlate.Request.Permission;
using BoilerPlate.Response.Permission;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BoilerPlate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : BaseController
    {
        private readonly IPermissionRepository permissionRepository;

        public PermissionsController(IPermissionRepository _permissionRepository)
        {
            permissionRepository = _permissionRepository;
        }

        /// <summary>
        /// Create Permission
        /// </summary>
        /// <param name="createPermissionRequest">Represents the object of Create Permission Request class</param>
        /// <returns>Returns the Create Permission Response</returns>
        [HttpPost]
        public IActionResult CreatePermission([Required]CreatePermissionRequest createPermissionRequest)
        {
            var newPermission = permissionRepository.CreatePermission(createPermissionRequest);
            return Ok(newPermission);
        }

        /// <summary>
        /// Get All Permissions
        /// </summary>
        /// <returns>Returns List of the Permission Response</returns>
        [HttpGet]
        public IActionResult GetPermissions()
        {
            var permissions = permissionRepository.GetPermissions();
            return Ok(permissions);
        }

        /// <summary>
        /// Get Permission By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the Permission by Id</returns>
        [HttpGet("{id}")]
        public IActionResult GetPermission(int id)
        {
            var permission = permissionRepository.GetPermissionById(id);
            return Ok(permission);
        }

        /// <summary>
        /// Update Permission
        /// </summary>
        /// <param name="id">Represents the Id of Permission to be Updated</param>
        /// <param name="updatePermissionRequest">Represents the object of Update Permission Request class</param>
        /// <returns>Returns the Updated Permission</returns>
        [HttpPut("{id}")]
        public IActionResult UpdatePermissions(int id, [Required] UpdatePermissionRequest updatePermissionRequest)
        {
            var updatedPermission = permissionRepository.UpdatePermission(id, updatePermissionRequest);
            return Ok(updatedPermission);
        }

        /// <summary>
        /// Delete Permission
        /// </summary>
        /// <param name="id">Represents the Id of the Permission to be Deleted</param>
        /// <returns>Returns the Delete Permission Response</returns>
        [HttpDelete("{id}")]
        public IActionResult DeletePermissions(int id)
        {
            permissionRepository.DeletePermission(id);
            return Ok(new DeletePermissionResponse()
            {
                Status = "Success",
                Message = "Permission Deleted Successfully"
            });
        }
    }
}