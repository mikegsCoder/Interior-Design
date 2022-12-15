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

        [Fact]
        public async Task BedRoom_Wardrobe_ReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.BedRoom_Wardrobe();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("CategoryTypeModels", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task Garden_Chair_ReturnsRedirectResultToApplicationError()
        {
            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Garden_Chair();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task Garden_Chair_ReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Garden_Chair();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("CategoryTypeModels", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task Garden_Table_ReturnsRedirectResultToApplicationError()
        {
            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Garden_Table();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task Garden_Table_ReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Garden_Table();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("CategoryTypeModels", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task Kitchen_Cabinet_ReturnsRedirectResultToApplicationError()
        {
            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Kitchen_Cabinet();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task Kitchen_Cabinet_ReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Kitchen_Cabinet();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("CategoryTypeModels", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task Kitchen_Chair_ReturnsRedirectResultToApplicationError()
        {
            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Kitchen_Chair();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task Kitchen_Chair_ReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Kitchen_Chair();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("CategoryTypeModels", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task Kitchen_Table_ReturnsRedirectResultToApplicationError()
        {
            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Kitchen_Table();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task Kitchen_Table_ReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Kitchen_Table();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("CategoryTypeModels", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task LivingRoom_Cabinet_ReturnsRedirectResultToApplicationError()
        {
            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.LivingRoom_Cabinet();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task LivingRoom_Cabinet_ReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.LivingRoom_Cabinet();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("CategoryTypeModels", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task LivingRoom_Chair_ReturnsRedirectResultToApplicationError()
        {
            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.LivingRoom_Chair();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task LivingRoom_Chair_ReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.LivingRoom_Chair();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("CategoryTypeModels", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task LivingRoom_Sofa_ReturnsRedirectResultToApplicationError()
        {
            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.LivingRoom_Sofa();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task LivingRoom_Sofa_ReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.LivingRoom_Sofa();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("CategoryTypeModels", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task LivingRoom_Table_ReturnsRedirectResultToApplicationError()
        {
            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.LivingRoom_Table();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task LivingRoom_Table_ReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.LivingRoom_Table();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("CategoryTypeModels", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task Office_Cabinet_ReturnsRedirectResultToApplicationError()
        {
            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Office_Cabinet();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task Office_Cabinet_ReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Office_Cabinet();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("CategoryTypeModels", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task Office_Chair_ReturnsRedirectResultToApplicationError()
        {
            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Office_Chair();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task Office_Chair_ReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Office_Chair();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("CategoryTypeModels", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task Office_Desk_ReturnsRedirectResultToApplicationError()
        {
            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Office_Desk();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task Office_Desk_ReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Office_Desk();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("CategoryTypeModels", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task Office_Shelf_ReturnsRedirectResultToApplicationError()
        {
            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Office_Shelf();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task Office_Shelf_ReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Office_Shelf();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("CategoryTypeModels", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task Office_Wardrobe_ReturnsRedirectResultToApplicationError()
        {
            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Office_Wardrobe();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task Office_Wardrobe_ReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.Office_Wardrobe();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("CategoryTypeModels", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task YoungRoom_Bed_ReturnsRedirectResultToApplicationError()
        {
            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.YoungRoom_Bed();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task YoungRoom_Bed_ReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.YoungRoom_Bed();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("CategoryTypeModels", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task YoungRoom_Cabinet_ReturnsRedirectResultToApplicationError()
        {
            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.YoungRoom_Cabinet();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task YoungRoom_Cabinet_ReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.YoungRoom_Cabinet();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("CategoryTypeModels", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task YoungRoom_Chair_ReturnsRedirectResultToApplicationError()
        {
            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.YoungRoom_Chair();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task YoungRoom_Chair_ReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.YoungRoom_Chair();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("CategoryTypeModels", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public async Task YoungRoom_Table_ReturnsRedirectResultToApplicationError()
        {
            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.YoungRoom_Table();

            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("/Home/ApplicationError", redirectResult.Url);
        }

        [Fact]
        public async Task YoungRoom_Table_ReturnsViewResultWhenGetModelFromCache()
        {
            cache.Setup(x => x.TryGetValue(It.IsAny<object>(), out testModel))
                .Returns(true);

            var controller = new ModelsController(
                service.Object,
                logger.Object,
                cache.Object);

            var result = await controller.YoungRoom_Table();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("CategoryTypeModels", viewResult.ViewName);
            Assert.Null(viewResult.Model);
        }
    }
}
