using InteriorDesign.Core.Services.Application.CategoryService;
using InteriorDesign.Core.ViewModels.CategoryViewModels;
using InteriorDesign.Core.ViewModels.CategoryTypeViewModels;

namespace InteriorDesign.Tests.ServiceTests.Category
{
    public class CategoryServiceTests
    {
        private readonly ProductCategory bedRoom;

        private readonly ProductType bed;

        private readonly ProductModel boston103b;

        private readonly ProductColor oak;

        private readonly Product boston103bo;

        public CategoryServiceTests()
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
        public async Task GetCategoriesInfoAsyncReturnsListOfCategoryViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var categories = new EfDeletableEntityRepository<ProductCategory>(dbContext);
            using var types = new EfDeletableEntityRepository<ProductType>(dbContext);
            using var models = new EfDeletableEntityRepository<ProductModel>(dbContext);
            using var products = new EfDeletableEntityRepository<Product>(dbContext);

            await dbContext.AddAsync(bedRoom);
            await dbContext.AddAsync(oak);
            await dbContext.AddAsync(bed);
            await dbContext.AddAsync(boston103b);
            await dbContext.AddAsync(boston103bo);

            await dbContext.SaveChangesAsync();

            var expected = new List<CategoryViewModel>();

            expected.Add(new CategoryViewModel()
            {
                Name = bedRoom.Name,
                ProductTypesCount = 1,
                ProductModelsCount = 1,
                ProductsCount = 1,
                ImageUrl = bedRoom.ImageUrl
            });

            var service = new CategoryService(
                categories,
                types,
                models,
                products);

            var actual = await service.GetCategoriesInfoAsync();

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetCategoriesInfoAsyncReturnsEmptyListOfCategoryViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var categories = new EfDeletableEntityRepository<ProductCategory>(dbContext);
            using var types = new EfDeletableEntityRepository<ProductType>(dbContext);
            using var models = new EfDeletableEntityRepository<ProductModel>(dbContext);
            using var products = new EfDeletableEntityRepository<Product>(dbContext);

            var expected = new List<CategoryViewModel>();

            var service = new CategoryService(
                categories,
                types,
                models,
                products);

            var actual = await service.GetCategoriesInfoAsync();

            Assert.Empty(actual);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetTypesByCategoryInfoAsyncReturnsListOfCategoryTypeViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var categories = new EfDeletableEntityRepository<ProductCategory>(dbContext);
            using var types = new EfDeletableEntityRepository<ProductType>(dbContext);
            using var models = new EfDeletableEntityRepository<ProductModel>(dbContext);
            using var products = new EfDeletableEntityRepository<Product>(dbContext);

            await dbContext.AddAsync(bedRoom);
            await dbContext.AddAsync(oak);
            await dbContext.AddAsync(bed);
            await dbContext.AddAsync(boston103b);
            await dbContext.AddAsync(boston103bo);

            await dbContext.SaveChangesAsync();

            var expected = new List<CategoryTypeViewModel>();

            expected.Add(new CategoryTypeViewModel()
            {
                CategoryName = bedRoom.Name,
                TypeName = bed.Name,
                ProductModelsCount = 1,
                ProductsCount = 1,
                CategoryImageUrl = bedRoom.ImageUrl,
                TypeImageUrl = boston103bo.ImageUrl
            });

            var service = new CategoryService(
                categories,
                types,
                models,
                products);

            var actual = await service.GetTypesByCategoryInfoAsync("Bed Room");

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetTypesByCategoryInfoAsyncReturnsEmptyListOfCategoryTypeViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var categories = new EfDeletableEntityRepository<ProductCategory>(dbContext);
            using var types = new EfDeletableEntityRepository<ProductType>(dbContext);
            using var models = new EfDeletableEntityRepository<ProductModel>(dbContext);
            using var products = new EfDeletableEntityRepository<Product>(dbContext);


            var expected = new List<CategoryTypeViewModel>();

            var service = new CategoryService(
                categories,
                types,
                models,
                products);

            var actual = await service.GetTypesByCategoryInfoAsync("Bed Room");

            Assert.Empty(actual);
            expected.Should().BeEquivalentTo(actual);
        }
    }
}
