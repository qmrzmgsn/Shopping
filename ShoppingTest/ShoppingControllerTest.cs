using Microsoft.AspNetCore.Mvc;
using Moq;
using Shopping.Controllers;
using Shopping.Models;
using Shopping.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;

namespace ShoppingTest
{
    public class ShoppingControllerTest : Controller
    {
        private readonly Mock<IRepository> _mock;
        private readonly ShoppingController _controller;
        public ShoppingControllerTest()
        {
            _mock = new Mock<IRepository>();
            _controller = new ShoppingController(_mock.Object);
        }

        [Fact]
        public async Task GetAllEmployees()
        {
            var employees = await _controller.GetAllEmployees();

            Assert.IsType<OkObjectResult>(employees);
        }
    }
}
