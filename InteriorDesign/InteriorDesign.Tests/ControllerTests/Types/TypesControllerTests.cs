using InteriorDesign.Core.Services.Application.TypeService;
using InteriorDesign.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace InteriorDesign.Tests.ControllerTests.TypesControllerTests
{
    public class TypesControllerTests
    {
        private readonly Mock<ILogger<TypesController>> logger;

        private readonly Mock<IMemoryCache> cache;

        private readonly Mock<ITypeService> service;

        private object testModel;

        public TypesControllerTests()
        {
            logger = new Mock<ILogger<TypesController>>();

            cache = new Mock<IMemoryCache>();

            service = new Mock<ITypeService>();
        }

        [Fact]
        public async Task IndexReturnsRedirectResultToApplicationError()
        {
            var controller = new TypesController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Index();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task BedRoom_Bed_ReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new TypesController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task WardrobeReturnsRedirectResultToApplicationError()
        {
            var controller = new TypesController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Wardrobe();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task WardrobeReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new TypesController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Wardrobe();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("TypeCategory", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task DeskReturnsRedirectResultToApplicationError()
        {
            var controller = new TypesController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Desk();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task DeskReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new TypesController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Desk();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("TypeCategory", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task ChairReturnsRedirectResultToApplicationError()
        {
            var controller = new TypesController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Chair();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task ChairReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new TypesController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Chair();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("TypeCategory", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }
    }
}
