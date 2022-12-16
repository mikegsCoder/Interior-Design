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
    }
}
