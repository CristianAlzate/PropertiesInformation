using API.Controllers;
using AutoMapper;
using Core.DTO.Property;
using Core.Interfaces.Services;
using FakeItEasy;
using FluentAssertions;
using Infrastructure.Persistence.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Moq;

namespace UnitTest.Controller
{
    public class PropertyTest
    {
        private Mock<IPropertyService> _propertyServiceMock;

        [SetUp]
        public void Setup()
        {
            _propertyServiceMock = new Mock<IPropertyService>();
            _propertyServiceMock.Setup(x => x.InsertPropertyAsync(It.IsAny<CreatePropertyDTO>(),It.IsAny<CancellationToken>())).ReturnsAsync(new CreatePropertyDTO());
            _propertyServiceMock.Setup(x => x.GetProperties(It.IsAny<CancellationToken>())).ReturnsAsync(new List<PropertyDTO>());
            _propertyServiceMock.Setup(x => x.UpdatePropertyAsync(It.IsAny<UpdatePropertyDTO>(), It.IsAny<CancellationToken>())).ReturnsAsync(new UpdatePropertyDTO());
        }

        [Test] 
        public async Task CreateProperty_ReturnOkResponse_WhenModelIsValid() 
        {
            //Arrange
            var controller = new PropertiesController(_propertyServiceMock.Object);

            //Act
            var result = await controller.Post(new CreatePropertyDTO());

            //Assert
            Assert.IsNotNull(result);
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }

        [Test]
        public async Task GetProperties_ReturnOkResponse()
        {
            //Arrange
            var controller = new PropertiesController(_propertyServiceMock.Object);

            //Act
            var result = await controller.Get();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }


        [Test]
        public async Task UpdateProperties_ReturnOkResponse_WhenModelIsValid()
        {
            //Arrange
            var controller = new PropertiesController(_propertyServiceMock.Object);

            //Act
            var result = await controller.Put(new UpdatePropertyDTO());

            //Assert
            Assert.IsNotNull(result);
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }

    }
}