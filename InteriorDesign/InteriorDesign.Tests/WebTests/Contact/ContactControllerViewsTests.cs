namespace InteriorDesign.Tests.WebTests.Contact;
public class ContactControllerViewsTests : WebTest
{
    [Fact]
    public async Task IndexPageReturnsCorrectResult()
    {
        var response = await client.GetAsync("/Contact");
        var html = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("<h2>Contact Us</h2>", html);
        Assert.Contains("If you have some questions about our products don't hesitate to contact us.", html);
        Assert.Contains("Varna 9010, Bulgaria", html);
        Assert.Contains("359 123 456 789", html);
        Assert.Contains("InteriorDesign@mail.com", html);
        Assert.Contains("Your Email", html);
        Assert.Contains("Subject", html);
        Assert.Contains("Your message ...", html);
        Assert.Contains("Send", html);
    }
}