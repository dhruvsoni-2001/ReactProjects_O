using BoilerPlate.Repository;
using BoilerPlate.Request.User;
using BoilerPlate.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoilerPlate.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;
        public AuthController(IUserRepository _userRepository, IRoleRepository _roleRepository)
        {
            userRepository = _userRepository;
            roleRepository = _roleRepository;
        }

        /// <summary>
        /// User Login
        /// </summary>
        /// <param name="credentialRequest">Represents the object of Credential Request class</param>
        /// <returns>Returns the Login Response</returns>
        [HttpPost("login")]
        public IActionResult UserLogin(CredentialRequest credentialRequest)
        {
            var user = userRepository.LoginUser(credentialRequest);
            user.Role = roleRepository.GetRoleByUserId(user.Id);
            return Ok(user);
        }

        /// <summary>
        /// Forgot Password
        /// </summary>
        /// <param name="forgotPasswordRequest">Represents the object of Forgot Password Request class</param>
        /// <returns>Returns the Forgot Password Response</returns>
        [HttpPost("forgotPassword")]
        public IActionResult ForgotPassword(ForgotPasswordRequest forgotPasswordRequest)
        {
            if (ModelState.IsValid)
            {
                return Ok(new CommonResponse<string> { Data = "Success" });
            }
            else
            {
                return Ok(new CommonResponse<string> { Data = "Email does not exist. Please enter valid Email" });
            }
        }


        /// <summary>
        /// Reset Password after Login
        /// </summary>
        /// <param name="passwordResetWithCurrentPasswordRequest">Represents the password reset parameter</param>
        /// <returns>Returns the Reset Password Response</returns>
        [HttpPost("change-password")]
        public IActionResult ChangePassword(PasswordResetWithCurrentPasswordRequest passwordResetWithCurrentPasswordRequest)
        {
            if (string.IsNullOrEmpty(passwordResetWithCurrentPasswordRequest.CurrentPassword) ||
                string.IsNullOrEmpty(passwordResetWithCurrentPasswordRequest.NewPassword) ||
                string.IsNullOrEmpty(passwordResetWithCurrentPasswordRequest.ConfirmPassword)
                )
            {
                throw new Exception("The password is invalid");
            }

            if (passwordResetWithCurrentPasswordRequest.NewPassword != passwordResetWithCurrentPasswordRequest.ConfirmPassword)
            {
                throw new Exception("The password does not match");
            }

            userRepository.ChangePassword(passwordResetWithCurrentPasswordRequest);

            return Ok(new CommonResponse<string> { Data = "The password changed successfully!" });
        }
    }
}
