namespace InteriorDesign.Tests.WebTests.Orders;
public class IdentityViewsTests : WebTest
{
    [Fact]
    public async Task LoginPageReturnsCorrectResult()
    {
        var response = await client.GetAsync("/Identity/Account/Login");
        var html = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("Sign in to start your session", html);
        Assert.Contains("Email", html);
        Assert.Contains("Password", html);
        Assert.Contains("Remember me?", html);
        Assert.Contains("Sign In", html);
    }

    [Fact]
    public async Task RegisterPageReturnsCorrectResult()
    {
        var response = await client.GetAsync("/Identity/Account/Register");
        var html = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("Create a new account", html);
        Assert.Contains("Email", html);
        Assert.Contains("Password", html);
        Assert.Contains("Retype password", html);
        Assert.Contains("Register", html);
    }

    [Fact]
    public async Task AccountManagePageRedirectsToLogin()
    {
        var response = await client.GetAsync("Identity/Account/Manage");
        var html = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("Sign in to start your session", html);
        Assert.Contains("Email", html);
        Assert.Contains("Password", html);
        Assert.Contains("Remember me?", html);
        Assert.Contains("Sign In", html);
    }
}