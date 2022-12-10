namespace InteriorDesign.Tests.WebTests.Products;

public class ProductsControllerViewsTests : WebTest
{
    [Fact]
    public async Task IndexPageReturnsCorrectResult()
    {
        var response = await client.GetAsync("/Products");
        var html = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("All Products", html);
        Assert.Contains("products count:", html);
        Assert.Contains("<th>Product</th>", html);
        Assert.Contains("<th>Category</th>", html);
        Assert.Contains("<th>Type</th>", html);
        Assert.Contains("<th>Model</th>", html);
        Assert.Contains("<th>Color</th>", html);
        Assert.Contains("<th>Price</th>", html);
        Assert.Contains("<th>Details</th>", html);
    }
}