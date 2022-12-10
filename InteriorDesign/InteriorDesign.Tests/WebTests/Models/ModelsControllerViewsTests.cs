namespace InteriorDesign.Tests.WebTests.Models;

public class ModelsControllerViewsTests : WebTest
{
    [Fact]
    public async Task CategoryTypeModelsReturnsCorrectResult()
    {
        var response = await client.GetAsync("/Models/BedRoom_Bed");
        var html = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("Models in category Bed Room of product type Bed:", html);
        Assert.Contains("models count:", html);
        Assert.Contains("<th>Model</th>", html);
        Assert.Contains("<th>Category</th>", html);
        Assert.Contains("<th>Type</th>", html);
        Assert.Contains("<th>Products</th>", html);
        Assert.Contains("<th>Open</th>", html);
    }
}