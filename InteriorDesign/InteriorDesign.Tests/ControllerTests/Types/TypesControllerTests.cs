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

        [Fact]
        public async Task BedReturnsRedirectResultToApplicationError()
        {
            var controller = new TypesController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Bed();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task BedReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new TypesController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Bed();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("TypeCategory", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task TableReturnsRedirectResultToApplicationError()
        {
            var controller = new TypesController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Table();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task TableReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new TypesController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Table();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("TypeCategory", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task SofaReturnsRedirectResultToApplicationError()
        {
            var controller = new TypesController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Sofa();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task SofaReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new TypesController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Sofa();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("TypeCategory", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task CabinetReturnsRedirectResultToApplicationError()
        {
            var controller = new TypesController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Cabinet();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task CabinetReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new TypesController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Cabinet();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("TypeCategory", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }
    }
}
