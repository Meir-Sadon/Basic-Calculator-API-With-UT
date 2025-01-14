using Calculator_MatrixJobExam.Attributes;
using Calculator_MatrixJobExam.Enums;
using Calculator_MatrixJobExam.Models.CalculatorObjects;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Calculator_MatrixJobExam.Controllers
{
    /// <summary>
    /// Controller for performing calculations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase, ICalculatorController
    {
        /// <summary>
        /// Perform a calculation
        /// </summary>
        /// <param name="calcRequest">The calculation request containing the numbers.</param>
        /// <param name="operatorSymbol">The operator to be used for the calculation.</param>
        /// <response code="200">Calculation result</response>
        /// <response code="400">Invalid input</response>
        /// <response code="400">Cannot divide by zero</response>
        /// <response code="400">Unsupported operator</response>
        [HttpPost]
        [Route("/calculate")]
        [ValidateModelState]
        [SwaggerOperation("Calculate")]
        [SwaggerResponse(statusCode: 200, type: typeof(CalcResponse), description: "Calculation result")]
        public virtual IActionResult Calculate(CalcRequest calcRequest, [FromHeader(Name = "Math-Operator")][Required()] MathOperator operatorSymbol)
        {
            CalcResponse response = new();

            switch (operatorSymbol)
            {
                case MathOperator.Plus:
                    response.CalcResult = calcRequest.Number1 + calcRequest.Number2;
                    break;
                case MathOperator.Minus:
                    response.CalcResult = calcRequest.Number1 - calcRequest.Number2;
                    break;
                case MathOperator.Multiple:
                    response.CalcResult = calcRequest.Number1 * calcRequest.Number2;
                    break;
                case MathOperator.Divide:
                    if (calcRequest.Number2 == 0)
                    {
                        return BadRequest("Cannot divide by zero");
                    }
                    response.CalcResult = calcRequest.Number1 / calcRequest.Number2;
                    break;
                default:
                    return BadRequest("Unsupported operator");
            }

            return Ok(response);
        }
    }
}
