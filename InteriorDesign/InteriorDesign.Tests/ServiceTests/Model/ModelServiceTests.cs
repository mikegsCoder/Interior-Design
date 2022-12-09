using InteriorDesign.Core.Services.Application.ModelService;
using InteriorDesign.Core.ViewModels.ProductModelViewModels;

namespace InteriorDesign.Tests.ServiceTests.Model
{
    public class ModelServiceTests
    {
        private readonly ProductCategory bedRoom;

        private readonly ProductType bed;

        private readonly ProductModel boston103b;

        private readonly ProductColor oak;

        private readonly Product boston103bo;

        public ModelServiceTests()
        {
            bedRoom = new ProductCategory()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Bed Room",
                ImageUrl = "/storage/bedRoom/bedRoom.jpg",
                CreatedOn = DateTime.Now,
                IsDeleted = false
            };

            bed = new ProductType()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Bed",
                CreatedOn = DateTime.Now,
                IsDeleted = false
            };

            boston103b = new ProductModel()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Boston 103b",
                Type = bed,
                Category = bedRoom,
                CreatedOn = DateTime.Now,
                IsDeleted = false
            };

            oak = new ProductColor()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Oak",
                CreatedOn = DateTime.Now,
                IsDeleted = false
            };

            boston103bo = new Product()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Boston 103bo",
                Model = boston103b,
                Color = oak,
                Price = 170,
                ImageUrl = "/storage/bedRoom/bed/boston-103-oak.jpg",
                CreatedOn = DateTime.Now,
                IsDeleted = false
            };

            bedRoom.ProductTypes.Add(bed);
        }

        [Fact]
        public async Task GetModelsInfoAsyncReturnsListOfProductModelInfoViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var models = new EfDeletableEntityRepository<ProductModel>(dbContext);
            using var products = new EfDeletableEntityRepository<Product>(dbContext);

            await dbContext.AddAsync(bedRoom);
            await dbContext.AddAsync(oak);
            await dbContext.AddAsync(bed);
            await dbContext.AddAsync(boston103b);
            await dbContext.AddAsync(boston103bo);

            await dbContext.SaveChangesAsync();

            var expected = new List<ProductModelInfoViewModel>();

            expected.Add(new ProductModelInfoViewModel()
            {
                Id = boston103b.Id.ToString(),
                ModelName = boston103b.Name,
                CategoryName = bedRoom.Name,
                TypeName = bed.Name,
                ProductsCount = 1,
                ImageUrl = boston103bo.ImageUrl
            });

            var service = new ModelService(
                models,
                products);

            var actual = await service.GetModelsInfoAsync("Bed Room", "Bed");

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count());
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetModelsInfoAsyncReturnsEmptyListOfProductModelInfoViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var models = new EfDeletableEntityRepository<ProductModel>(dbContext);
            using var products = new EfDeletableEntityRepository<Product>(dbContext);

            var service = new ModelService(
                models,
                products);

            var actual = await service.GetModelsInfoAsync("Bed Room", "Bed");

            Assert.Empty(actual);
        }
    }
}
