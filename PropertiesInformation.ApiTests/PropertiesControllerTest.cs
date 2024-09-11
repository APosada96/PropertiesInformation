using Microsoft.AspNetCore.Mvc;
using Moq;
using PropertiesInformation.Api.Controllers;
using PropertiesInformation.Domain.Dtos;
using PropertiesInformation.Domain.Interfaces.Properties;

namespace PropertiesInformation.ApiTests
{
    public class PropertiesControllerTest
    {
        private readonly Mock<IPropertyRepository> _propertyRepositoryMock = new Mock<IPropertyRepository>();
       
        [Fact]
        public async void GetTest()
        {
          
            var propertiesController = new PropertiesController(_propertyRepositoryMock.Object);

            IActionResult result = await propertiesController.Get();
            OkObjectResult okResult = result as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void PostTest()
        {
            var model = new PropertyDto { Name = "Test", Address = "Cra 43 #", Code = "1232134"};
            var propertiesController = new PropertiesController(_propertyRepositoryMock.Object);
            propertiesController.ModelState.AddModelError("test", "test");

            var result = await propertiesController.Post(model);
            BadRequestResult badrequest = result as BadRequestResult;

            Assert.NotNull(badrequest);
            Assert.Equal(400, badrequest.StatusCode);
        }

        [Fact]
        public async void PostTestNotFound()
        {
            var model = new PropertyDto { Name = "Test", Address = "Cra 43 #", Code = "1232134" };
            var propertiesController = new PropertiesController(_propertyRepositoryMock.Object);
            _propertyRepositoryMock.Setup(repo => repo.AddProperty(model)).ReturnsAsync(null!);


            IActionResult result = await propertiesController.Post(model);
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Object reference not set to an instance of an object.", notFoundObjectResult.Value);
        }

        [Fact]
        public async void PostTestOK()
        {
            var model = new PropertyDto { Name = "Test", Address = "Cra 43 #", Code = "1232134" };
            var propertiesController = new PropertiesController(_propertyRepositoryMock.Object);
            _propertyRepositoryMock.Setup(repo => repo.Get()).ReturnsAsync(GetList);


            var result = await propertiesController.Post(model);
            OkObjectResult Okresult = result as OkObjectResult;

            Assert.NotNull(Okresult);
            Assert.Equal(200, Okresult.StatusCode);
        }

        private static List<PropertyListDto> GetList()
        {
            return new List<PropertyListDto> { new PropertyListDto { Address = "Cr75 24 -31", Code = "2324", IdOwner = 1, Price = 230000 } };
        }
    }
}