namespace InteriorDesign.Tests.WebTests.OurTeam;

public class OurTeamControllerViewsTests : WebTest
{
    [Fact]
    public async Task IndexPageContainsReturnsCorrectResult()
    {
        var response = await client.GetAsync("/OurTeam");
        var html = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("<h2>Our Team</h2>", html);
        Assert.Contains("<h4>French Lincon</h4>", html);
        Assert.Contains("<h4>Amanda Jepson</h4>", html);
        Assert.Contains("<h4>Michell Kellon</h4>", html);
        Assert.Contains("<h4>James Smith</h4>", html);
        Assert.Contains("Chief Executive Officer", html);
        Assert.Contains("Designer", html);
    }
}