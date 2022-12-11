using InteriorDesign.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace InteriorDesign.Tests.ControllerTests.AboutUs
{
    public class AboutUsControllerTests
    {
        [Fact]
        public void IndexReturnsViewResult()
        {
            var controller = new AboutUsController();

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
            Assert.Null(viewResult.ViewData.Model);
            Assert.Null(viewResult.ViewName);
            Assert.Null(viewResult.StatusCode);
        }
    }
}
