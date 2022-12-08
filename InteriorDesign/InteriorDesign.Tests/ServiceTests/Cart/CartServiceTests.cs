using InteriorDesign.Core.Services.Application.CartService;
using InteriorDesign.Core.ViewModels.ConfiguredProductViewModels;

namespace InteriorDesign.Tests.ServiceTests.Cart
{
    public class CartServiceTests
    {
        private readonly ProductCategory bedRoom;

        private readonly ProductType bed;

        private readonly ProductModel boston103b;

        private readonly ProductColor oak;

        private readonly Product boston103bo;

        private readonly ConfiguredProduct product;

        public CartServiceTests()
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

            product = new ConfiguredProduct()
            {
                Id = Guid.NewGuid().ToString(),
                ProductId = boston103bo.Id,
                Product = boston103bo,
                Quantity = 1,
                Price = 123,
                UserId = Guid.NewGuid().ToString(),
                IsDeleted = false,
                IsOrdered = false
            };

            bedRoom.ProductTypes.Add(bed);
        }

        [Fact]
        public async Task DeleteProductByIdAsyncWorksProperly()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var configuredProducts = new EfDeletableEntityRepository<ConfiguredProduct>(dbContext);
            var categories = new Mock<IDeletableEntityRepository<ProductCategory>>();
            var types = new Mock<IDeletableEntityRepository<ProductType>>();
            var models = new Mock<IDeletableEntityRepository<ProductModel>>();
            var colors = new Mock<IDeletableEntityRepository<ProductColor>>();
            var products = new Mock<IDeletableEntityRepository<Product>>();

            await dbContext.AddAsync(product);

            await dbContext.SaveChangesAsync();

            var service = new CartService(
                categories.Object,
                types.Object,
                models.Object,
                products.Object,
                colors.Object,
                configuredProducts);

            await service.DeleteProductByIdAsync(product.Id.ToString());

            var actual = configuredProducts.AllWithDeleted();

            Assert.Single(actual);
            Assert.True(actual.First().IsDeleted);
        }

        [Fact]
        public async Task DeleteProductByIdAsyncThrowsError()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var configuredProducts = new EfDeletableEntityRepository<ConfiguredProduct>(dbContext);
            var categories = new Mock<IDeletableEntityRepository<ProductCategory>>();
            var types = new Mock<IDeletableEntityRepository<ProductType>>();
            var models = new Mock<IDeletableEntityRepository<ProductModel>>();
            var colors = new Mock<IDeletableEntityRepository<ProductColor>>();
            var products = new Mock<IDeletableEntityRepository<Product>>();

            var service = new CartService(
                categories.Object,
                types.Object,
                models.Object,
                products.Object,
                colors.Object,
                configuredProducts);

            await Assert.ThrowsAsync<NullReferenceException>(() => service.DeleteProductByIdAsync("test"));
        }

        [Fact]
        public async Task EditAsyncWorksProperly()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var configuredProducts = new EfDeletableEntityRepository<ConfiguredProduct>(dbContext);
            var categories = new Mock<IDeletableEntityRepository<ProductCategory>>();
            var types = new Mock<IDeletableEntityRepository<ProductType>>();
            var models = new Mock<IDeletableEntityRepository<ProductModel>>();
            var colors = new Mock<IDeletableEntityRepository<ProductColor>>();
            using var products = new EfDeletableEntityRepository<Product>(dbContext);

            await dbContext.AddAsync(boston103bo);
            await dbContext.AddAsync(product);

            await dbContext.SaveChangesAsync();

            var model = new ConfiguredProductViewModel()
            {
                Id = product.Id.ToString(),
                ProductId = boston103bo.Id.ToString(),
                CategoryName = bedRoom.Name,
                TypeName = bed.Name,
                ProductName = boston103bo.Name,
                ModelName = boston103b.Name,
                ColorName = oak.Name,
                ProductPrice = 170,
                SinglePrice = 170,
                ImageUrl = boston103bo.ImageUrl,
                UserId = null,
                Quantity = 2
            };

            var service = new CartService(
                categories.Object,
                types.Object,
                models.Object,
                products,
                colors.Object,
                configuredProducts);

            await service.EditAsync(model);

            var actual = configuredProducts.All();

            Assert.Single(actual);
            Assert.True(actual.First().Quantity == 2);
            Assert.True(actual.First().Price == 340);
            Assert.NotNull(actual.First().ModifiedOn);
        }

        [Fact]
        public async Task EditAsyncWorksThrowsError()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var configuredProducts = new EfDeletableEntityRepository<ConfiguredProduct>(dbContext);
            var categories = new Mock<IDeletableEntityRepository<ProductCategory>>();
            var types = new Mock<IDeletableEntityRepository<ProductType>>();
            var models = new Mock<IDeletableEntityRepository<ProductModel>>();
            var colors = new Mock<IDeletableEntityRepository<ProductColor>>();
            using var products = new EfDeletableEntityRepository<Product>(dbContext);

            var model = new ConfiguredProductViewModel()
            {
                Id = "test",
                ProductId = boston103bo.Id.ToString(),
                CategoryName = bedRoom.Name,
                TypeName = bed.Name,
                ProductName = boston103bo.Name,
                ModelName = boston103b.Name,
                ColorName = oak.Name,
                ProductPrice = 170,
                SinglePrice = 170,
                ImageUrl = boston103bo.ImageUrl,
                UserId = null,
                Quantity = 2
            };

            var service = new CartService(
                categories.Object,
                types.Object,
                models.Object,
                products,
                colors.Object,
                configuredProducts);

            await Assert.ThrowsAsync<InvalidOperationException>(() => service.EditAsync(model));
        }

        [Fact]
        public async Task GetAllProductsByUserIdAsyncReturnsListOfConfiguredProductViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var configuredProducts = new EfDeletableEntityRepository<ConfiguredProduct>(dbContext);
            using var categories = new EfDeletableEntityRepository<ProductCategory>(dbContext);
            using var types = new EfDeletableEntityRepository<ProductType>(dbContext);
            using var models = new EfDeletableEntityRepository<ProductModel>(dbContext);
            using var colors = new EfDeletableEntityRepository<ProductColor>(dbContext);
            using var products = new EfDeletableEntityRepository<Product>(dbContext);

            await dbContext.AddAsync(oak);
            await dbContext.AddAsync(bed);
            await dbContext.AddAsync(boston103b);
            await dbContext.AddAsync(boston103bo);
            await dbContext.AddAsync(bedRoom);
            await dbContext.AddAsync(product);

            await dbContext.SaveChangesAsync();

            var expected = new List<ConfiguredProductViewModel>();

            expected.Add( new ConfiguredProductViewModel()
            {
                Id = product.Id.ToString(),
                ProductId = boston103bo.Id.ToString(),
                CategoryName = bedRoom.Name,
                TypeName = bed.Name,
                ProductName = boston103bo.Name,
                ModelName = boston103b.Name,
                ColorName = oak.Name,
                ProductPrice = product.Price,
                SinglePrice = boston103bo.Price,
                ImageUrl = boston103bo.ImageUrl,
                UserId = product.UserId.ToString(),
                Quantity = product.Quantity
            });

            var service = new CartService(
                categories,
                types,
                models,
                products,
                colors,
                configuredProducts);

            var actual = await service.GetAllProductsByUserIdAsync(product.UserId.ToString());

            Assert.Single(actual);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetAllProductsByUserIdAsyncReturnsEmptyListOfConfiguredProductViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var configuredProducts = new EfDeletableEntityRepository<ConfiguredProduct>(dbContext);
            using var categories = new EfDeletableEntityRepository<ProductCategory>(dbContext);
            using var types = new EfDeletableEntityRepository<ProductType>(dbContext);
            using var models = new EfDeletableEntityRepository<ProductModel>(dbContext);
            using var colors = new EfDeletableEntityRepository<ProductColor>(dbContext);
            using var products = new EfDeletableEntityRepository<Product>(dbContext);

            var expected = new List<ConfiguredProductViewModel>();

            var service = new CartService(
                categories,
                types,
                models,
                products,
                colors,
                configuredProducts);

            var actual = await service.GetAllProductsByUserIdAsync(product.UserId.ToString());

            Assert.Empty(actual);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetProductByIdAsyncWorksProperly()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var configuredProducts = new EfDeletableEntityRepository<ConfiguredProduct>(dbContext);
            using var categories = new EfDeletableEntityRepository<ProductCategory>(dbContext);
            using var types = new EfDeletableEntityRepository<ProductType>(dbContext);
            using var models = new EfDeletableEntityRepository<ProductModel>(dbContext);
            using var colors = new EfDeletableEntityRepository<ProductColor>(dbContext);
            using var products = new EfDeletableEntityRepository<Product>(dbContext);

            await dbContext.AddAsync(oak);
            await dbContext.AddAsync(bed);
            await dbContext.AddAsync(boston103b);
            await dbContext.AddAsync(boston103bo);
            await dbContext.AddAsync(bedRoom);
            await dbContext.AddAsync(product);

            await dbContext.SaveChangesAsync();

            var expected = new ConfiguredProductViewModel()
            {
                Id = product.Id.ToString(),
                ProductId = boston103bo.Id.ToString(),
                CategoryName = bedRoom.Name,
                TypeName = bed.Name,
                ProductName = boston103bo.Name,
                ModelName = boston103b.Name,
                ColorName = oak.Name,
                ProductPrice = product.Price,
                SinglePrice = boston103bo.Price,
                ImageUrl = boston103bo.ImageUrl,
                UserId = product.UserId.ToString(),
                Quantity = product.Quantity
            };

            var service = new CartService(
                categories,
                types,
                models,
                products,
                colors,
                configuredProducts);

            var actual = await service.GetProductByIdAsync(product.Id.ToString());

            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetProductByIdAsyncThrowsError()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var configuredProducts = new EfDeletableEntityRepository<ConfiguredProduct>(dbContext);
            using var categories = new EfDeletableEntityRepository<ProductCategory>(dbContext);
            using var types = new EfDeletableEntityRepository<ProductType>(dbContext);
            using var models = new EfDeletableEntityRepository<ProductModel>(dbContext);
            using var colors = new EfDeletableEntityRepository<ProductColor>(dbContext);
            using var products = new EfDeletableEntityRepository<Product>(dbContext);

            var service = new CartService(
                categories,
                types,
                models,
                products,
                colors,
                configuredProducts);

            await Assert.ThrowsAsync<InvalidOperationException>(() => service.GetProductByIdAsync("test"));
        }

        [Fact]
        public async Task ProductExistsInCartAsyncReturnsTrue()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var configuredProducts = new EfDeletableEntityRepository<ConfiguredProduct>(dbContext);
            var categories = new Mock<IDeletableEntityRepository<ProductCategory>>();
            var types = new Mock<IDeletableEntityRepository<ProductType>>();
            var models = new Mock<IDeletableEntityRepository<ProductModel>>();
            var colors = new Mock<IDeletableEntityRepository<ProductColor>>();
            var products = new Mock<IDeletableEntityRepository<Product>>();

            await dbContext.AddAsync(boston103bo);
            await dbContext.AddAsync(product);

            await dbContext.SaveChangesAsync();

            var service = new CartService(
                categories.Object,
                types.Object,
                models.Object,
                products.Object,
                colors.Object,
                configuredProducts);

            var actual = await service.ProductExistsInCartAsync(boston103bo.Id.ToString());

            actual.Should().BeTrue();
        }

        [Fact]
        public async Task ProductExistsInCartAsyncReturnsFalse()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var configuredProducts = new EfDeletableEntityRepository<ConfiguredProduct>(dbContext);
            var categories = new Mock<IDeletableEntityRepository<ProductCategory>>();
            var types = new Mock<IDeletableEntityRepository<ProductType>>();
            var models = new Mock<IDeletableEntityRepository<ProductModel>>();
            var colors = new Mock<IDeletableEntityRepository<ProductColor>>();
            var products = new Mock<IDeletableEntityRepository<Product>>();

            await dbContext.AddAsync(boston103bo);
            await dbContext.AddAsync(product);

            await dbContext.SaveChangesAsync();

            var service = new CartService(
                categories.Object,
                types.Object,
                models.Object,
                products.Object,
                colors.Object,
                configuredProducts);

            var actual = await service.ProductExistsInCartAsync(Guid.NewGuid().ToString());

            actual.Should().BeFalse();
        }
    }
}
