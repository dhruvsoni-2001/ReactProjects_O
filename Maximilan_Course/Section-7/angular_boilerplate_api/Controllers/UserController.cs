using BoilerPlate.Repository;
using BoilerPlate.Request.User;
using BoilerPlate.Response.User;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BoilerPlate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;

        public UserController(IUserRepository _userRepository, IRoleRepository _roleRepository)
        {
            userRepository = _userRepository;
            roleRepository = _roleRepository;
        }

        /// <summary>
        /// Create Users
        /// </summary>
        /// <param name="createUserRequest">Represents the object of Create User Request class</param>
        /// <returns>Returns the Create User Response</returns>
        [HttpPost]
        public IActionResult CreateUser(CreateUserRequest createUserRequest)
        {
            var user = userRepository.CreateUser(createUserRequest);
            return Ok(user);
        }

        /// <summary>
        /// Get Users
        /// </summary>
        /// <param name="limit">Represents the number of items to be shown in response</param>
        /// <param name="start">Represents the start number</param>
        /// <param name="search">Represents the field to be searched</param>
        /// <param name="order_col">Represents by which cloumn the data is to be sorted</param>
        /// <param name="order_by">Represents how the data is to be sorted (Ascending/Descending)</param>
        /// <returns>Returns the list of all Users</returns>
        [HttpGet]
        public IActionResult GetUser([Required] int limit = 10, [Required] int start = 0, string? search = "", [Required] string order_col = "id", [Required] string order_by = "Desc")
        {
            var users = userRepository.GetUsers(limit, start, search, order_col, order_by);
            return Ok(users);
        }

        /// <summary>
        /// Update Users
        /// </summary>
        /// <param name="id">Represents the Id of User to Updated</param>
        /// <param name="updateUserRequest">Represents the object of Update User Request class</param>
        /// <returns>Returns the Update User Response</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [Required] UpdateUserRequest updateUserRequest)
        {
            BlockSuperAdminUserRoleUpdate(id);
            var user = userRepository.UpdateUser(id, updateUserRequest);
            return Ok(user);
        }

        /// <summary>
        /// Delete Users
        /// </summary>
        /// <param name="id">Represents the Id of User to be Deleted</param>
        /// <returns>Returns the Delete User Response</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            BlockSuperAdminUserRoleUpdate(id);
            userRepository.DeleteUser(id);
            return Ok(new DeleteUserResponse()
            {
                Status = "Success",
                Message = "User Deleted Successfully"
            });
        }

        /// <summary>
        /// Update Status
        /// </summary>
        /// <param name="id">Represents the Id of User to be Updated</param>
        /// <param name="updatedStatusRequest">Represents the object of Update Status Request class</param>
        /// <returns>Returns the Update Status Response</returns>
        [HttpPut("status/{id}")]
        public IActionResult UpdateStatus(int id, [Required] UpdatedStatusRequest updatedStatusRequest)
        {
            var status = userRepository.UpdateStatus(id, updatedStatusRequest);
            return Ok(status);
        }

        /// <summary>
        /// Get Roles for Users
        /// </summary>
        /// <returns>Returns the list of all User Roles</returns>
        [HttpGet("role")]
        public IActionResult GetRoles()
        {
            var users = userRepository.GetRoles();
            return Ok(users);
        }

        /// <summary>
        /// Get User Profile
        /// </summary>
        /// <param name="id">Represents the Id of the User Profile to be fetched</param>
        /// <returns>Returns the Profile Response</returns>
        [HttpGet("profile/{id}")]
        public IActionResult GetProfile(int id)
        {
            var profile = userRepository.GetProfile(id);
            return Ok(profile);
        }

        /// <summary>
        /// Update User Profile
        /// </summary>
        /// <param name="id">Represents the Id of the User Profile to be Updated</param>
        /// <param name="updateProfileRequest">Represents the object of Update Profile Request class</param>
        /// <returns>Returns the Update Profile Response</returns>
        [HttpPut("profile/{id}")]
        public IActionResult UpdateProfile(int id, [Required] UpdateProfileRequest updateProfileRequest)
        {
            var profile = userRepository.UpdateProfile(id, updateProfileRequest);
            return Ok(profile);
        }
    }
}