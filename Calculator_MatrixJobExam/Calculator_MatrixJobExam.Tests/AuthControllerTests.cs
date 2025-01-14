using Calculator_MatrixJobExam.Controllers;
using Calculator_MatrixJobExam.Global;
using Calculator_MatrixJobExam.Models;
using Calculator_MatrixJobExam.Models.LoginObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_MatrixJobExam.Tests
{
    public class AuthControllerTests
    {
        private readonly AuthController _controller;

        public AuthControllerTests()
        {
            //Using Mock was less suitable for me because I had to manage the file twice, and with every change I made in the main project, I also had to ensure it was updated in the test project.
            //Mock<IConfiguration> mockConfiguration = new();
            //mockConfiguration.Setup(config => config["Jwt:SecretKey"]).Returns("YourValue");
            //_controller = new Mock<AuthController>();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            _controller = new AuthController(configuration);
        }

        [Fact]
        public void Login_Returns_Token_When_Credentials_Are_Valid()
        {
            IActionResult result = _controller.Login(new LoginRequest { Username = Constants.VALID_USER_NAME, Password = Constants.VALID_PASSWORD });
            OkObjectResult? okResult = result as OkObjectResult;
            LoginResponse? loginRes = okResult?.Value as LoginResponse;

            Assert.NotNull(okResult);
            Assert.False(string.IsNullOrEmpty(loginRes?.Token));
        }

        [Fact]
        public void Login_Returns_Unauthorized_When_Credentials_Are_Invalid()
        {
            IActionResult result = _controller.Login(new LoginRequest { Username = "matrix", Password = "matrix" });

            Assert.IsType<UnauthorizedObjectResult>(result);
        }
    }
}
