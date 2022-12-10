namespace InteriorDesign.Tests.WebTests.Gallery;

public class GalleryControllerViewsTests : WebTest
{
    [Fact]
    public async Task IndexPageReturnsCorrectResult()
    {
        var response = await client.GetAsync("/Gallery");
        var html = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("Here you can see some examples of rooms furnished with our products.", html);
        Assert.Contains("Enjoy the art of Interior Design.", html);
    }
}