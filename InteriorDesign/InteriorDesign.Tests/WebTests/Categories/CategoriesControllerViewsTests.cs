namespace InteriorDesign.Tests.WebTests.Categories;
public class CategoriesControllerViewsTests : WebTest
{
    [Fact]
    public async Task IndexPageReturnsCorrectResult()
    {
        var response = await client.GetAsync("/Categories");
        var html = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("Categories", html);
        Assert.Contains("categories count:", html);
        Assert.Contains("<th>Category</th>", html);
        Assert.Contains("<th>Product types</th>", html);
        Assert.Contains("<th>Product models</th>", html);
        Assert.Contains("<th>Products</th>", html);
        Assert.Contains("<th>Open</th>", html);
    }

    [Fact]
    public async Task CategoryTypePageContainsCorrectText()
    {
        var response = await client.GetAsync("/Categories/Garden");
        var html = await response.Content.ReadAsStringAsync();

        Assert.Contains("Product types in category Garden", html);
        Assert.Contains("product types count:", html);
        Assert.Contains("<th>Type</th>", html);
        Assert.Contains("<th>Product models</th>", html);
        Assert.Contains("<th>Products</th>", html);
        Assert.Contains("<th>Open</th>", html);
    }
}