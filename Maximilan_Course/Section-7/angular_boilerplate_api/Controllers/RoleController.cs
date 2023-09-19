using BoilerPlate.Repository;
using BoilerPlate.Request.Role;
using BoilerPlate.Response.Role;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BoilerPlate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseController
    {
        private readonly IRoleRepository roleRepository;

        public RoleController(IRoleRepository _roleRepository)
        {
            roleRepository = _roleRepository;
        }

        /// <summary>
        /// Update Role
        /// </summary>
        /// <param name="id">Represents the Id of Role to be Updated</param>
        /// <param name="updateRoleBodyRequest">Represents the object of Update Role Body Request class</param>
        /// <returns>Returns the Update Role Response</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateRole(int id, [Required]UpdateRoleBodyRequest updateRoleBodyRequest)
        {
            BlockSuperAdminUserRoleUpdate(id);
            var updateRole = roleRepository.UpdateRole(id, updateRoleBodyRequest);
            return Ok(updateRole);
        }

        /// <summary>
        /// Delete the Role
        /// </summary>
        /// <param name="id">Represents the Id of the Role to be Deleted</param>
        /// <returns>Returns the Delete Role Response</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            BlockSuperAdminUserRoleUpdate(id);
            roleRepository.DeleteRole(id);
            return Ok(new DeleteRoleResponse()
            {
                Status = "Success",
                Message = "Role Deleted Successfully"
            });
        }

        /// <summary>
        /// Create Role
        /// </summary>
        /// <param name="createRoleRequest">Represents the object of Create Role Request class</param>
        /// <returns>Returns the Create Role Response</returns>
        [HttpPost]
        public IActionResult CreateRoles(CreateRoleRequest createRoleRequest)
        {
            var newRole = roleRepository.CreateRole(createRoleRequest);
            return Ok(newRole);
        }

        /// <summary>
        /// Get all the Roles
        /// </summary>
        /// <param name="limit">Represents the number of items to be shown in response</param>
        /// <param name="start">Represents the start number</param>
        /// <param name="search">Represents the field to be searched</param>
        /// <param name="order_col">Represents by which cloumn the data is to be sorted</param>
        /// <param name="order_by">Represents how the data is to be sorted (Asc/Desc)</param>
        /// <returns>Returns all the Roles</returns>
        [HttpGet]
        public IActionResult GetAllRoles([Required] int limit = 10, [Required] int start = 0, string? search = "", string order_col = "id", string order_by = "Asc")
        {
            var roles = roleRepository.GetRoles(limit, start, search, order_col, order_by);
            return Ok(roles);
        }

        /// <summary>
        /// Get Role By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the Role by Id</returns>
        [HttpGet("{id}")]
        public IActionResult GetRole(int id)
        {
            var role = roleRepository.GetRoleById(id);
            return Ok(role);
        }

        /// <summary>
        /// Update Role Status
        /// </summary>
        /// <param name="id">Represents the Id of Role to be Updated</param>
        /// <param name="updateRoleStatusRequest">Represents the object of Update Role Status Request class</param>
        /// <returns>Returns the Update Role Status Response</returns>
        [HttpPut("status/{id}")]
        public IActionResult UpdateRoleStatus(int id, [Required]UpdateRoleStatusRequest updateRoleStatusRequest)
        {
            BlockSuperAdminUserRoleUpdate(id);
            roleRepository.UpdateRoleStatus(id, updateRoleStatusRequest);
            return Ok(new UpdateRoleStatusResponse()
            {
                Status = "Success",
                Message = "Role status updated successfully"
            });
        }

        /// <summary>
        /// Get UserRole
        /// </summary>
        /// <returns>Returns the Get User Role Response</returns>
        [HttpGet("userRole")]
        public IActionResult GetUserRole()
        {
            var userRole = roleRepository.GetUserRole();
            return Ok(userRole);
        }
    }
}