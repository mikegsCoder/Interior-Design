using InteriorDesign.Core.Services.Application.ModelService;
using InteriorDesign.Core.ViewModels.ProductModelViewModels;
using InteriorDesign.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace InteriorDesign.Tests.ControllerTests.ModelsControllerTests
{
    public class ModelsControllerTests
    {
        private readonly List<ProductModelInfoViewModel> model;

        private readonly Mock<ILogger<ModelsController>> logger;

        private readonly Mock<IMemoryCache> cache;

        private readonly Mock<IModelService> service;

        private object testModel;

        public ModelsControllerTests()
        {
            logger = new Mock<ILogger<ModelsController>>();

            cache = new Mock<IMemoryCache>();

            service = new Mock<IModelService>();
        }

        [Fact]
        public async Task BedRoom_Bed_ReturnsRedirectResultToApplicationError()
        {
            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.BedRoom_Bed();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task BedRoom_Bed_ReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.BedRoom_Bed();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("CategoryTypeModels", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task BedRoom_Cabinet_ReturnsRedirectResultToApplicationError()
        {
            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.BedRoom_Cabinet();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task BedRoom_Cabinet_ReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.BedRoom_Cabinet();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("CategoryTypeModels", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task BedRoom_Wardrobe_ReturnsRedirectResultToApplicationError()
        {
            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.BedRoom_Wardrobe();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }
    }
}
