namespace InteriorDesign.Tests.WebTests.Types;

public class TypesControllerViewsTests : WebTest
{
    [Fact]
    public async Task IndexPageReturnsCorrectResult()
    {
        var response = await client.GetAsync("/Types");
        var html = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("Product types", html);
        Assert.Contains("product types count:", html);
        Assert.Contains("<th>Type</th>", html);
        Assert.Contains("<th>Product categories</th>", html);
        Assert.Contains("<th>Product models</th>", html);
        Assert.Contains("<th>Products</th>", html);
        Assert.Contains("<th>Open</th>", html);
    }

    [Fact]
    public async Task CategoryTypePageReturnsCorrectResult()
    {
        var response = await client.GetAsync("/Types/Bed");
        var html = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("Categories in product type Bed:", html);
        Assert.Contains("categories count:", html);
        Assert.Contains("<th>Category</th>", html);
        Assert.Contains("<th>Product models</th>", html);
        Assert.Contains("<th>Products</th>", html);
        Assert.Contains("<th>Open</th>", html);
    }
}