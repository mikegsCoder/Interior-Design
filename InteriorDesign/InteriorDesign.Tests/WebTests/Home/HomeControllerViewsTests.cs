namespace InteriorDesign.Tests.WebTests.Home;

public class HomeControllerViewsTests : WebTest
{
    [Fact]
    public async Task IndexPageReturnsCorrectResult()
    {
        var response = await client.GetAsync("/");
        var html = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("Interior Design", html);
        Assert.Contains("Furnishing your home".ToUpper(), html);
    }

    [Fact]
    public async Task NotFoundReturnsCorrectResult()
    {
        var response = await client.GetAsync("/NodFound404");
        var html = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        Assert.Contains("404", html);
        Assert.Contains("Page not found", html);
        Assert.Contains("back to Home Page", html);
    }

    [Fact]
    public async Task CookiesReturnsCorrectResult()
    {
        var response = await client.GetAsync("/Home/Cookies");
        var html = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("<h2>Cookie Policy</h2>", html);
        Assert.Contains("What are cookies?", html);
        Assert.Contains("Necessary cookies :", html);
        Assert.Contains("Functionality cookies :", html);
        Assert.Contains("Analytical cookies :", html);
        Assert.Contains("How to delete cookies?", html);
        Assert.Contains("Contacting us", html);
    }

    [Fact]
    public async Task ApplicationErrorReturnsCorrectResult()
    {
        var response = await client.GetAsync("/Home/ApplicationError");
        var html = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("Application Error", html);
        Assert.Contains("Something went wrong. Please try again later.", html);
        Assert.Contains("back to Home Page", html);
    }
}