using InteriorDesign.Core.Services.Application.CategoryService;
using InteriorDesign.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace InteriorDesign.Tests.ControllerTests.CategoriesControllerTests
{
    public class CategoriesControllerTests
    {
        private readonly Mock<ILogger<CategoriesController>> logger;

        private readonly Mock<IMemoryCache> cache;

        private readonly Mock<ICategoryService> service;

        private object testModel;

        public CategoriesControllerTests()
        {
            logger = new Mock<ILogger<CategoriesController>>();

            cache = new Mock<IMemoryCache>();

            service = new Mock<ICategoryService>();
        }

        [Fact]
        public async Task IndexReturnsRedirectResultToApplicationError()
        {
            var controller = new CategoriesController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Index();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task IndexReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new CategoriesController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task GardenReturnsRedirectResultToApplicationError()
        {
            var controller = new CategoriesController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Garden();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task GardenReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new CategoriesController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Garden();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("CategoryType", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task KitchenReturnsRedirectResultToApplicationError()
        {
            var controller = new CategoriesController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Kitchen();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task KitchenReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new CategoriesController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Kitchen();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("CategoryType", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task OfficeReturnsRedirectResultToApplicationError()
        {
            var controller = new CategoriesController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Office();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task OfficeReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new CategoriesController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Office();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("CategoryType", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task BedRoomReturnsRedirectResultToApplicationError()
        {
            var controller = new CategoriesController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.BedRoom();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task BedRoomReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new CategoriesController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.BedRoom();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("CategoryType", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task LivingRoomReturnsRedirectResultToApplicationError()
        {
            var controller = new CategoriesController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.LivingRoom();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }
    }
}
