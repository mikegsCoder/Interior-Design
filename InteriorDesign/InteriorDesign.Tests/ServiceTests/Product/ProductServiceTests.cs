using InteriorDesign.Core.Services.Application.ProductService;
using InteriorDesign.Core.ViewModels.ProductViewModels;

namespace InterionDesign.Tests.ServiceTests.Products
{
    public class ProductServiceTests
    {
        private readonly ProductCategory bedRoom;

        private readonly ProductType bed;

        private readonly ProductModel boston103b;

        private readonly ProductColor oak;

        private readonly Product boston103bo;

        public ProductServiceTests()
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
        }

        [Fact]
        public async Task GetAllProductsAsyncReturnsListOfProductInfoViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var productCategories = new EfDeletableEntityRepository<ProductCategory>(dbContext);
            using var productTypes = new EfDeletableEntityRepository<ProductType>(dbContext);
            using var productModels = new EfDeletableEntityRepository<ProductModel>(dbContext);
            using var products = new EfDeletableEntityRepository<Product>(dbContext);
            using var productColors = new EfDeletableEntityRepository<ProductColor>(dbContext);
            var configuredProducts = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();

            await dbContext.AddAsync(boston103bo);

            await dbContext.SaveChangesAsync();

            var expected = new List<ProductInfoViewModel>();

            expected.Add(new ProductInfoViewModel()
            {
                Id = boston103bo.Id.ToString(),
                CategoryName = "Bed Room",
                TypeName = "Bed",
                ProductName = "Boston 103bo",
                ModelName = "Boston 103b",
                ColorName = "Oak",
                ProductPrice = 170,
                ImageUrl = "/storage/bedRoom/bed/boston-103-oak.jpg"
            });

            var service = new ProductService(
                productCategories,
                productTypes,
                productModels,
                products,
                productColors,
                configuredProducts.Object);

            var actual = await service.GetAllProductsAsync();

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetAllProductsAsyncReturnsEmptyListOfProductInfoViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var productCategories = new EfDeletableEntityRepository<ProductCategory>(dbContext);
            using var productTypes = new EfDeletableEntityRepository<ProductType>(dbContext);
            using var productModels = new EfDeletableEntityRepository<ProductModel>(dbContext);
            using var products = new EfDeletableEntityRepository<Product>(dbContext);
            using var productColors = new EfDeletableEntityRepository<ProductColor>(dbContext);
            var configuredProducts = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();

            var service = new ProductService(
                productCategories,
                productTypes,
                productModels,
                products,
                productColors,
                configuredProducts.Object);

            var actual = await service.GetAllProductsAsync();

            Assert.Empty(actual);
        }

        [Fact]
        public async Task GetProductByIdAsyncReturnsCorrectProduct()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var productCategories = new EfDeletableEntityRepository<ProductCategory>(dbContext);
            using var productTypes = new EfDeletableEntityRepository<ProductType>(dbContext);
            using var productModels = new EfDeletableEntityRepository<ProductModel>(dbContext);
            using var products = new EfDeletableEntityRepository<Product>(dbContext);
            using var productColors = new EfDeletableEntityRepository<ProductColor>(dbContext);
            var configuredProducts = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();

            await dbContext.AddAsync(boston103bo);

            await dbContext.SaveChangesAsync();

            var expected = new ProductViewModel()
            {
                ProductId = boston103bo.Id.ToString(),
                CategoryName = "Bed Room",
                ProductName = "Boston 103bo",
                TypeName = "Bed",
                ModelName = "Boston 103b",
                ColorName = "Oak",
                ProductPriceString = null,
                ProductPrice = 170,
                ImageUrl = "/storage/bedRoom/bed/boston-103-oak.jpg",
                UserId = "",
                Quantity = 1,
            };

            var service = new ProductService(
                productCategories,
                productTypes,
                productModels,
                products,
                productColors,
                configuredProducts.Object);

            var actual = await service.GetProductByIdAsync(boston103bo.Id.ToString());

            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetProductByIdAsyncThrowsError()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var productCategories = new EfDeletableEntityRepository<ProductCategory>(dbContext);
            using var productTypes = new EfDeletableEntityRepository<ProductType>(dbContext);
            using var productModels = new EfDeletableEntityRepository<ProductModel>(dbContext);
            using var products = new EfDeletableEntityRepository<Product>(dbContext);
            using var productColors = new EfDeletableEntityRepository<ProductColor>(dbContext);
            var configuredProducts = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();

            var service = new ProductService(
                productCategories,
                productTypes,
                productModels,
                products,
                productColors,
                configuredProducts.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() => service.GetProductByIdAsync("test"));
        }

        [Fact]
        public async Task GetProductsByModelIdAsyncReturnsCorrectProducts()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                   .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var productCategories = new EfDeletableEntityRepository<ProductCategory>(dbContext);
            using var productTypes = new EfDeletableEntityRepository<ProductType>(dbContext);
            using var productModels = new EfDeletableEntityRepository<ProductModel>(dbContext);
            using var products = new EfDeletableEntityRepository<Product>(dbContext);
            using var productColors = new EfDeletableEntityRepository<ProductColor>(dbContext);
            var configuredProducts = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();

            boston103bo.ModelId = boston103b.Id;

            await dbContext.AddAsync(boston103bo);

            await dbContext.SaveChangesAsync();

            var expected = new List<ProductInfoViewModel>();

            expected.Add( new ProductInfoViewModel()
            {
                Id = boston103bo.Id.ToString(),
                CategoryName = "Bed Room",
                TypeName = "Bed",
                ProductName = "Boston 103bo",
                ModelName = "Boston 103b",
                ColorName = "Oak",
                ProductPrice = 170,
                ImageUrl = "/storage/bedRoom/bed/boston-103-oak.jpg"
            });

            var service = new ProductService(
                productCategories,
                productTypes,
                productModels,
                products,
                productColors,
                configuredProducts.Object);

            var actual = await service.GetProductsByModelIdAsync(boston103b.Id.ToString());

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetProductsByModelIdAsyncThrowsError()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                   .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var productCategories = new EfDeletableEntityRepository<ProductCategory>(dbContext);
            using var productTypes = new EfDeletableEntityRepository<ProductType>(dbContext);
            using var productModels = new EfDeletableEntityRepository<ProductModel>(dbContext);
            using var products = new EfDeletableEntityRepository<Product>(dbContext);
            using var productColors = new EfDeletableEntityRepository<ProductColor>(dbContext);
            var configuredProducts = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();

            var service = new ProductService(
                productCategories,
                productTypes,
                productModels,
                products,
                productColors,
                configuredProducts.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() => service.GetProductsByModelIdAsync("test"));
        }

        [Fact]
        public async Task GetAddProductViewModelAsyncReturnsCorrectResult()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            
            var productCategories = new Mock<IDeletableEntityRepository<ProductCategory>>();
            var productTypes = new Mock<IDeletableEntityRepository<ProductType>>();
            using var productModels = new EfDeletableEntityRepository<ProductModel>(dbContext);
            var products = new Mock<IDeletableEntityRepository<Product>>();
            using var productColors = new EfDeletableEntityRepository<ProductColor>(dbContext);
            var configuredProducts = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();

            var model = boston103b;
            model.Type = null;
            model.Category = null;
            model.CategoryId = "";
            model.TypeId = "";

            await dbContext.AddAsync(oak);
            await dbContext.AddAsync(model);

            await dbContext.SaveChangesAsync();

            var expected = new AddProductViewModel()
            {
                ProductName = null,
                ModelId = null,
                ColorId = null,
                ProductPrice = null,
                ImageUrl = null,
                Colors = new List<ProductColor>() { oak },
                Models = new List<ProductModel>() { boston103b }
            };

            var service = new ProductService(
                productCategories.Object,
                productTypes.Object,
                productModels,
                products.Object,
                productColors,
                configuredProducts.Object);

            var actual = await service.GetAddProductViewModelAsync();

            Assert.Single(actual.Colors);
            Assert.Single(actual.Models);

            Assert.True(actual.Colors.Count() == expected.Colors.Count());
            Assert.True(actual.Models.Count() == expected.Models.Count());

            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetAddProductViewModelAsyncReturnsEmptyObject()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var productCategories = new Mock<IDeletableEntityRepository<ProductCategory>>();
            var productTypes = new Mock<IDeletableEntityRepository<ProductType>>();
            using var productModels = new EfDeletableEntityRepository<ProductModel>(dbContext);
            var products = new Mock<IDeletableEntityRepository<Product>>();
            using var productColors = new EfDeletableEntityRepository<ProductColor>(dbContext);
            var configuredProducts = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();

            var expected = new AddProductViewModel()
            {
                ProductName = null,
                ModelId = null,
                ColorId = null,
                ProductPrice = null,
                ImageUrl = null,
                Colors = new List<ProductColor>(),
                Models = new List<ProductModel>()
            };

            var service = new ProductService(
                productCategories.Object,
                productTypes.Object,
                productModels,
                products.Object,
                productColors,
                configuredProducts.Object);

            var actual = await service.GetAddProductViewModelAsync();

            Assert.Empty(actual.Colors);
            Assert.Empty(actual.Models);

            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task AddProductAsyncWorksProperly()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var productCategories = new Mock<IDeletableEntityRepository<ProductCategory>>();
            var productTypes = new Mock<IDeletableEntityRepository<ProductType>>();
            using var productModels = new EfDeletableEntityRepository<ProductModel>(dbContext);
            using var products = new EfDeletableEntityRepository<Product>(dbContext);
            using var productColors = new EfDeletableEntityRepository<ProductColor>(dbContext);
            var configuredProducts = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();

            await dbContext.AddAsync(boston103b);
            await dbContext.AddAsync(oak);

            await dbContext.SaveChangesAsync();

            var model = new AddProductViewModel()
            {
                ProductName = "test",
                ImageUrl = "test_url",
                ProductPrice = "123",
                ColorId = oak.Id.ToString(),
                ModelId = boston103b.Id.ToString(),
            };

            var service = new ProductService(
                productCategories.Object,
                productTypes.Object,
                productModels,
                products,
                productColors,
                configuredProducts.Object);

            await service.AddProductAsync(model);

            var actual = products.All().FirstOrDefault();

            Assert.Single(products.All());
            Assert.True(actual?.Name == model.ProductName);
            Assert.True(actual?.ImageUrl == model.ImageUrl);
            Assert.True(actual?.Price == Convert.ToDecimal(model.ProductPrice));
            Assert.True(actual?.ColorId.ToString() == model.ColorId);
            Assert.True(actual?.ModelId.ToString() == model.ModelId);
        }

        [Fact]
        public async Task AddProductAsyncThrowsErrorWithInvaidColorId()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var productCategories = new Mock<IDeletableEntityRepository<ProductCategory>>();
            var productTypes = new Mock<IDeletableEntityRepository<ProductType>>();
            using var productModels = new EfDeletableEntityRepository<ProductModel>(dbContext);
            using var products = new EfDeletableEntityRepository<Product>(dbContext);
            using var productColors = new EfDeletableEntityRepository<ProductColor>(dbContext);
            var configuredProducts = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();

            await dbContext.AddAsync(boston103b);
            await dbContext.AddAsync(oak);

            await dbContext.SaveChangesAsync();

            var model = new AddProductViewModel()
            {
                ProductName = "test",
                ImageUrl = "test_url",
                ProductPrice = "123",
                ColorId = "test",
                ModelId = boston103b.Id.ToString(),
            };

            var service = new ProductService(
                productCategories.Object,
                productTypes.Object,
                productModels,
                products,
                productColors,
                configuredProducts.Object);

            await Assert.ThrowsAsync<NullReferenceException>(() => service.AddProductAsync(model));
        }

        [Fact]
        public async Task AddProductAsyncThrowsErrorWithInvaidModelId()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var productCategories = new Mock<IDeletableEntityRepository<ProductCategory>>();
            var productTypes = new Mock<IDeletableEntityRepository<ProductType>>();
            using var productModels = new EfDeletableEntityRepository<ProductModel>(dbContext);
            using var products = new EfDeletableEntityRepository<Product>(dbContext);
            using var productColors = new EfDeletableEntityRepository<ProductColor>(dbContext);
            var configuredProducts = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();

            await dbContext.AddAsync(boston103b);
            await dbContext.AddAsync(oak);

            await dbContext.SaveChangesAsync();

            var model = new AddProductViewModel()
            {
                ProductName = "test",
                ImageUrl = "test_url",
                ProductPrice = "123",
                ColorId = oak.Id.ToString(),
                ModelId = "test",
            };

            var service = new ProductService(
                productCategories.Object,
                productTypes.Object,
                productModels,
                products,
                productColors,
                configuredProducts.Object);

            await Assert.ThrowsAsync<NullReferenceException>(() => service.AddProductAsync(model));
        }

        [Fact]
        public async Task AddProductAsyncThrowsExceptionWithInvalidPrice()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var productCategories = new Mock<IDeletableEntityRepository<ProductCategory>>();
            var productTypes = new Mock<IDeletableEntityRepository<ProductType>>();
            using var productModels = new EfDeletableEntityRepository<ProductModel>(dbContext);
            var products = new Mock<IDeletableEntityRepository<Product>>();
            using var productColors = new EfDeletableEntityRepository<ProductColor>(dbContext);
            var configuredProducts = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();

            var model = new AddProductViewModel()
            {
                ProductName = "test",
                ImageUrl = "test_url",
                ProductPrice = "invalid",
                ColorId = oak.Id.ToString(),
                ModelId = boston103b.Id.ToString(),
            };

            var service = new ProductService(
                productCategories.Object,
                productTypes.Object,
                productModels,
                products.Object,
                productColors,
                configuredProducts.Object);
           
            Func<Task> act = () => (service.AddProductAsync(model));

            var exception = await Assert.ThrowsAsync<InvalidDataException>(act);

            Assert.Equal("Invalid price provided.", exception.Message);
        }

        [Fact]
        public async Task EditProductAsyncWorksProperly()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var productCategories = new Mock<IDeletableEntityRepository<ProductCategory>>();
            var productTypes = new Mock<IDeletableEntityRepository<ProductType>>();
            var productModels = new Mock<IDeletableEntityRepository<ProductModel>>();
            using var products = new EfDeletableEntityRepository<Product>(dbContext);
            var productColors = new Mock<IDeletableEntityRepository<ProductColor>>();
            var configuredProducts = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();

            await dbContext.AddAsync(boston103bo);

            await dbContext.SaveChangesAsync();

            var editModel = new ProductViewModel()
            {
                CategoryName = "Bed Room",
                ColorName = "Oak",
                ImageUrl = "test_image",
                ModelName = "Boston 103b",
                ProductId = boston103bo.Id.ToString(),
                ProductName = "Boston 103bo",
                ProductPrice = 0,
                ProductPriceString = "250",
                Quantity = 1,
                TypeName = "Bed",
                UserId = null
            };
            
            var service = new ProductService(
                productCategories.Object,
                productTypes.Object,
                productModels.Object,
                products,
                productColors.Object,
                configuredProducts.Object);

            await service.EditProductAsync(editModel);

            var actual = products.All()
                .FirstOrDefault(x => x.Id.ToString() == editModel.ProductId);

            Assert.Single(products.All());
            Assert.True(actual?.ImageUrl == editModel.ImageUrl);
            Assert.True(actual?.Price == Convert.ToDecimal(editModel.ProductPriceString));
        }

        [Fact]
        public async Task EditProductAsyncThrowsExceptionWithInvalidProductId()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var productCategories = new Mock<IDeletableEntityRepository<ProductCategory>>();
            var productTypes = new Mock<IDeletableEntityRepository<ProductType>>();
            var productModels = new Mock<IDeletableEntityRepository<ProductModel>>();
            using var products = new EfDeletableEntityRepository<Product>(dbContext);
            var productColors = new Mock<IDeletableEntityRepository<ProductColor>>();
            var configuredProducts = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();

            var editModel = new ProductViewModel()
            {
                CategoryName = "Bed Room",
                ColorName = "Oak",
                ImageUrl = "test_image",
                ModelName = "Boston 103b",
                ProductId = "test",
                ProductName = "Boston 103bo",
                ProductPrice = 0,
                ProductPriceString = "250",
                Quantity = 1,
                TypeName = "Bed",
                UserId = null
            };

            var service = new ProductService(
                productCategories.Object,
                productTypes.Object,
                productModels.Object,
                products,
                productColors.Object,
                configuredProducts.Object);

            await Assert.ThrowsAsync<NullReferenceException>(() => service.EditProductAsync(editModel));
        }

        [Fact]
        public async Task EditProductAsyncThrowsExceptionWithInvalidPrice()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var productCategories = new Mock<IDeletableEntityRepository<ProductCategory>>();
            var productTypes = new Mock<IDeletableEntityRepository<ProductType>>();
            var productModels = new Mock<IDeletableEntityRepository<ProductModel>>();
            using var products = new EfDeletableEntityRepository<Product>(dbContext);
            var productColors = new Mock<IDeletableEntityRepository<ProductColor>>();
            var configuredProducts = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();

            var editModel = new ProductViewModel()
            {
                CategoryName = "Bed Room",
                ColorName = "Oak",
                ImageUrl = "test_image",
                ModelName = "Boston 103b",
                ProductId = boston103bo.Id.ToString(),
                ProductName = "Boston 103bo",
                ProductPrice = 0,
                ProductPriceString = "invalid",
                Quantity = 1,
                TypeName = "Bed",
                UserId = null
            };

            var service = new ProductService(
                productCategories.Object,
                productTypes.Object,
                productModels.Object,
                products,
                productColors.Object,
                configuredProducts.Object);

            Func<Task> act = () => (service.EditProductAsync(editModel));

            var exception = await Assert.ThrowsAsync<InvalidDataException>(act);

            Assert.Equal("Invalid price provided.", exception.Message);
        }

        [Fact]
        public async Task DeleteProductByIdAsyncWorksProperly()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var productCategories = new Mock<IDeletableEntityRepository<ProductCategory>>();
            var productTypes = new Mock<IDeletableEntityRepository<ProductType>>();
            var productModels = new Mock<IDeletableEntityRepository<ProductModel>>();
            using var products = new EfDeletableEntityRepository<Product>(dbContext);
            var productColors = new Mock<IDeletableEntityRepository<ProductColor>>();
            var configuredProducts = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();

            await dbContext.AddAsync(boston103bo);

            await dbContext.SaveChangesAsync();

            var service = new ProductService(
                productCategories.Object,
                productTypes.Object,
                productModels.Object,
                products,
                productColors.Object,
                configuredProducts.Object);

            await service.DeleteProductByIdAsync(boston103bo.Id.ToString());

            var actual = products.All();

            Assert.True(actual.Count() == 0);
        }

        [Fact]
        public async Task DeleteProductByIdAsyncThrowsException()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var productCategories = new Mock<IDeletableEntityRepository<ProductCategory>>();
            var productTypes = new Mock<IDeletableEntityRepository<ProductType>>();
            var productModels = new Mock<IDeletableEntityRepository<ProductModel>>();
            using var products = new EfDeletableEntityRepository<Product>(dbContext);
            var productColors = new Mock<IDeletableEntityRepository<ProductColor>>();
            var configuredProducts = new Mock<IDeletableEntityRepository<ConfiguredProduct>>();

            var service = new ProductService(
                productCategories.Object,
                productTypes.Object,
                productModels.Object,
                products,
                productColors.Object,
                configuredProducts.Object);

            await Assert.ThrowsAsync<NullReferenceException>(() => service.DeleteProductByIdAsync("test"));
        }

        [Fact]
        public async Task AddToCartAsyncWorksProperly()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var productCategories = new Mock<IDeletableEntityRepository<ProductCategory>>();
            var productTypes = new Mock<IDeletableEntityRepository<ProductType>>();
            var productModels = new Mock<IDeletableEntityRepository<ProductModel>>();
            using var products = new EfDeletableEntityRepository<Product>(dbContext);
            var productColors = new Mock<IDeletableEntityRepository<ProductColor>>();
            using var configuredProducts = new EfDeletableEntityRepository<ConfiguredProduct>(dbContext);

            await dbContext.AddAsync(boston103bo);

            await dbContext.SaveChangesAsync();

            var userId = Guid.NewGuid().ToString();

            var model = new ProductViewModel()
            {
                CategoryName = "Bed Room",
                ColorName = "Oak",
                ImageUrl = "/storage/bedRoom/bed/boston-103-oak.jpg",
                ModelName = "Boston 103b",
                ProductId = boston103bo.Id.ToString(),
                ProductName = "Boston 103bo",
                ProductPrice = 170,
                ProductPriceString = "10",
                Quantity = 1,
                TypeName = "Bed",
                UserId = userId
            };

            var service = new ProductService(
                productCategories.Object,
                productTypes.Object,
                productModels.Object,
                products,
                productColors.Object,
                configuredProducts);

            await service.AddToCartAsync(model);

            var actual = configuredProducts.All().FirstOrDefault();

            Assert.Single(configuredProducts.All());
            Assert.True(actual != null);
            Assert.True(actual?.UserId == userId);
            Assert.True(actual?.Price == model.ProductPrice);
            Assert.True(actual?.Quantity == model.Quantity);
        }

        [Fact]
        public async Task AddToCartAsyncThrowsExceptionWithInvalidProductId()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var productCategories = new Mock<IDeletableEntityRepository<ProductCategory>>();
            var productTypes = new Mock<IDeletableEntityRepository<ProductType>>();
            var productModels = new Mock<IDeletableEntityRepository<ProductModel>>();
            using var products = new EfDeletableEntityRepository<Product>(dbContext);
            var productColors = new Mock<IDeletableEntityRepository<ProductColor>>();
            using var configuredProducts = new EfDeletableEntityRepository<ConfiguredProduct>(dbContext);

            await dbContext.AddAsync(boston103bo);

            await dbContext.SaveChangesAsync();

            var userId = Guid.NewGuid().ToString();

            var model = new ProductViewModel()
            {
                CategoryName = "Bed Room",
                ColorName = "Oak",
                ImageUrl = "/storage/bedRoom/bed/boston-103-oak.jpg",
                ModelName = "Boston 103b",
                ProductId = "invalid",
                ProductName = "Boston 103bo",
                ProductPrice = 170,
                ProductPriceString = "10",
                Quantity = 1,
                TypeName = "Bed",
                UserId = userId
            };

            var service = new ProductService(
                productCategories.Object,
                productTypes.Object,
                productModels.Object,
                products,
                productColors.Object,
                configuredProducts);

            await Assert.ThrowsAsync<NullReferenceException>(() => service.AddToCartAsync(model));
        }
    }
}
