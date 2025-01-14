using Calculator_MatrixJobExam.Attributes;
using Calculator_MatrixJobExam.Enums;
using Calculator_MatrixJobExam.Global;
using Calculator_MatrixJobExam.Models.LoginObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Calculator_MatrixJobExam.Controllers
{

    /// <summary>
    /// Controller for handling user authentication.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="AuthController"/> class.
    /// </remarks>
    /// <param name="configuration">The configuration instance.</param>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IConfiguration configuration) : ControllerBase, IAuthController
    {
        /// <summary>
        /// User login
        /// </summary>
        /// <param name="loginRequest">The login request containing username and password.</param>
        /// <response code="200">Successful login</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal server error: Secret key is not configured</response>
        [HttpPost]
        [Route("/login")]
        [ValidateModelState]
        [SwaggerOperation("Login")]
        [SwaggerResponse(statusCode: 200, type: typeof(LoginResponse), description: "Successful login")]
        public virtual IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            LoginResponse response = new();
            if (loginRequest?.Username == Constants.VALID_USER_NAME && loginRequest?.Password == Constants.VALID_PASSWORD)
            {
                return GenerateJwtToken(loginRequest);
            }

            return Unauthorized(response);
        }

        private IActionResult GenerateJwtToken(LoginRequest login)
        {
            ArgumentException.ThrowIfNullOrEmpty(login?.Username, nameof(login));
            LoginResponse response = new();

            string secretKey = configuration["Jwt:SecretKey"];
            if (string.IsNullOrEmpty(secretKey))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: Secret key is not configured.");
            }

            List<Claim> claims = new()
                {
                    new Claim(ClaimTypes.Name, login.Username),
                    new Claim(ClaimTypes.Role, RoleType.User.ToString())
                };
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(secretKey));
            SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );
            response.Token = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(response);
        }
    }
}
