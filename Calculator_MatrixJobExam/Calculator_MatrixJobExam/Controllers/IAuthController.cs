using Calculator_MatrixJobExam.Models.LoginObjects;
using Microsoft.AspNetCore.Mvc;

namespace Calculator_MatrixJobExam.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAuthController
    {
        /// <summary>
        /// User login
        /// </summary>

        /// <param name="body"></param>
        /// <response code="200">Successful login</response>
        /// <response code="401">Unauthorized</response>
        IActionResult Login([FromBody] LoginRequest body);
    }
}
