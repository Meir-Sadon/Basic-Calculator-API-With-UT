using Calculator_MatrixJobExam.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Calculator_MatrixJobExam.Attributes
{
    /// <summary>
    /// Action filter to validate the math operator provided in the request headers.
    /// </summary>
    public class OperatorValidationFilter : ActionFilterAttribute
    {
        /// <summary>
        /// Called before the action method is executed to validate the math operator.
        /// </summary>
        /// <param name="context">The context for the action.</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var operatorSymbol = context.HttpContext.Request.Headers["Math-Operator"];
            if (string.IsNullOrEmpty(operatorSymbol) || !Enum.TryParse(operatorSymbol, true, out MathOperator _))
            {
                context.Result = new BadRequestObjectResult($"Invalid math operator.\n the valid values for 'Math-Operator' header are: '{string.Join("', '", Enum.GetNames<MathOperator>())}'");
            }
        }
    }
}
