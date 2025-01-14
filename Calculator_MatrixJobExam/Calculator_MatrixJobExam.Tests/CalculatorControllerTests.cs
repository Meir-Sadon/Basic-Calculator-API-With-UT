using Calculator_MatrixJobExam.Controllers;
using Calculator_MatrixJobExam.Enums;
using Calculator_MatrixJobExam.Models.CalculatorObjects;
using Microsoft.AspNetCore.Mvc;

namespace Calculator_MatrixJobExam.Tests
{
    public class CalculatorControllerTests
    {
        private readonly CalculatorController _controller;

        public CalculatorControllerTests()
        {
            _controller = new CalculatorController();
        }

        [Fact]
        public void Calculate_Returns_Correct_Result_For_Addition()
        {
            CalcRequest calcReq = new(1, 2);
            IActionResult calcRes = _controller.Calculate(calcReq, MathOperator.Plus);

            Assert.IsType<OkObjectResult>(calcRes);
            var result = ((OkObjectResult)calcRes).Value as CalcResponse;
            Assert.NotNull(result);
            Assert.Equal(3, result.CalcResult);
        }

        [Fact]
        public void Calculate_Returns_BadRequest_When_Invalid_Operator()
        {
            CalcRequest calcReq = new(20, 5);
            IActionResult calcRes = _controller.Calculate(calcReq, 0);

            Assert.IsType<BadRequestObjectResult>(calcRes);
        }

        [Fact]
        public void Calculate_Returns_BadRequest_When_Devide_By_Zero()
        {
            CalcRequest calcReq = new(1, 0);
            IActionResult calcRes = _controller.Calculate(calcReq, MathOperator.Divide);

            Assert.IsType<BadRequestObjectResult>(calcRes);
        }
    }
}
