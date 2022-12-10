namespace InteriorDesign.Tests.WebTests.AboutUs;
public class AboutUsControllerViewsTests : WebTest
{
    [Fact]
    public async Task IndexPageReturnsCorrectResult()
    {
        var response = await client.GetAsync("/AboutUs");
        var html = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("<h2>WHO WE ARE?</h2>", html);
        Assert.Contains("about-img.png", html);
        Assert.Contains("Our company takes care of your comfort and tranquility to deliver you the dream home you want.", html);
        Assert.Contains("<h2>Оur mission is to bring comfort to your home.</h2>", html);
        Assert.Contains("We are happy to offer to our customers:", html);
        Assert.Contains("Ready to use solutions for your home interior design.", html);
        Assert.Contains("Individual consultation with our designers.", html);
        Assert.Contains("Individual interior design project for you.", html);
        Assert.Contains("Large scale of ready to use furniture in our showroom.", html);
        Assert.Contains("<h2>Testimonials</h2>", html);
        Assert.Contains("<p>See feedback from our customers:</p>", html);
        Assert.Contains("Customer", html);
    }
}