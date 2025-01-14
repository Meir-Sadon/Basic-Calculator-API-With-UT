using Calculator_MatrixJobExam.Enums;
using Calculator_MatrixJobExam.Models.CalculatorObjects;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Calculator_MatrixJobExam.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICalculatorController
    {
        /// <summary>
        /// Perform a calculation
        /// </summary>

        /// <param name="body"></param>
        /// <param name="mathOperator"></param>
        /// <response code="200">Calculation result</response>
        /// <response code="400">Invalid input</response>
        IActionResult Calculate([FromBody] CalcRequest body, [FromHeader][Required()] MathOperator mathOperator);
    }
}
