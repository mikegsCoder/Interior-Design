using InteriorDesign.Core.Services.Application.GalleryService;
using InteriorDesign.Core.ViewModels.DesignImageViewModels;

namespace InteriorDesign.Tests.ServiceTests.Gallery
{
    public class GalleryServiceTests
    {
        private readonly DesignImage image;

        public GalleryServiceTests()
        {
            image = new DesignImage()
            {
                ImageUrl = "/img/portfolio/1.jpg",
                Name = "Modern bedroom in blue",
                CreatedOn = DateTime.Now,
                IsActive = true
            };
        }

        [Fact]
        public async Task GetActiveImagesAsyncReturnsListOfDesignImageViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var images = new EfDeletableEntityRepository<DesignImage>(dbContext);

            await dbContext.AddAsync(image);

            await dbContext.SaveChangesAsync();

            var expected = new List<DesignImageViewModel>();

            expected.Add(new DesignImageViewModel()
            {
                ImageId = image.Id,
                ImageUrl = image.ImageUrl,
                Name = image.Name,
                IsActive = image.IsActive,
            });

            var service = new GalleryService(images);

            var actual = await service.GetActiveImagesAsync();

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetActiveImagesAsyncReturnsEmptyListOfDesignImageViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var images = new EfDeletableEntityRepository<DesignImage>(dbContext);

            var service = new GalleryService(images);

            var actual = await service.GetActiveImagesAsync();

            Assert.Empty(actual);
        }

        [Fact]
        public async Task GetAllImagesAsyncReturnsListOfDesignImageViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var images = new EfDeletableEntityRepository<DesignImage>(dbContext);

            image.IsActive = false;

            await dbContext.AddAsync(image);

            await dbContext.SaveChangesAsync();

            var expected = new List<DesignImageViewModel>();

            expected.Add(new DesignImageViewModel()
            {
                ImageId = image.Id,
                ImageUrl = image.ImageUrl,
                Name = image.Name,
                IsActive = image.IsActive,
            });

            var service = new GalleryService(images);

            var actual = await service.GetAllImagesAsync();

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetAllImagesAsyncReturnsEmptyListOfDesignImageViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var images = new EfDeletableEntityRepository<DesignImage>(dbContext);

            var service = new GalleryService(images);

            var actual = await service.GetAllImagesAsync();

            Assert.Empty(actual);
        }

        [Fact]
        public async Task ActivateImageAsyncWorksProperly()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var images = new EfDeletableEntityRepository<DesignImage>(dbContext);

            image.IsActive = false;

            await dbContext.AddAsync(image);

            await dbContext.SaveChangesAsync();

            var expected = new List<DesignImageViewModel>();

            expected.Add(new DesignImageViewModel()
            {
                ImageId = image.Id,
                ImageUrl = image.ImageUrl,
                Name = image.Name,
                IsActive = true
            });

            var service = new GalleryService(images);

            await service.ActivateImageAsync(image.Id);

            var actual = await service.GetActiveImagesAsync();

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task ActivateImageAsyncThrowsError()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var images = new EfDeletableEntityRepository<DesignImage>(dbContext);

            var service = new GalleryService(images);

            await Assert.ThrowsAsync<NullReferenceException>(() => service.ActivateImageAsync("test"));
        }

        [Fact]
        public async Task DeactivateImageAsyncWorksProperly()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var images = new EfDeletableEntityRepository<DesignImage>(dbContext);

            await dbContext.AddAsync(image);

            await dbContext.SaveChangesAsync();

            var expected = new List<DesignImageViewModel>();

            expected.Add(new DesignImageViewModel()
            {
                ImageId = image.Id,
                ImageUrl = image.ImageUrl,
                Name = image.Name,
                IsActive = false
            });

            var service = new GalleryService(images);

            await service.DeactivateImageAsync(image.Id);

            var actual = await service.GetAllImagesAsync();

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task DeactivateImageAsyncThrowsError()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var images = new EfDeletableEntityRepository<DesignImage>(dbContext);

            var service = new GalleryService(images);

            await Assert.ThrowsAsync<NullReferenceException>(() => service.DeactivateImageAsync("test"));
        }
    }
}
