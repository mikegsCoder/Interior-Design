namespace InteriorDesign.Tests.WebTests;
public class WebTest : WebApplicationFactory<Program>
{
    private readonly WebApplicationFactory<Program> application;
    internal readonly HttpClient client;

    public WebTest()
    {
        application = new WebApplicationFactory<Program>();
        client = application.CreateClient();
    }
}