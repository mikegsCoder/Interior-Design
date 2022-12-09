namespace InteriorDesign.Tests.RepositoryTests
{
    public class EfDeletableEntityRepositoryTests
    {
        private readonly ProductType bed;

        public EfDeletableEntityRepositoryTests()
        {
            bed = new ProductType()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Bed",
                CreatedOn = DateTime.Now,
                IsDeleted = false
            };
        }

        [Fact]
        public async Task AllWithDeletedWorks()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            bed.IsDeleted = true;

            await dbContext.AddAsync(bed);

            await dbContext.SaveChangesAsync();

            using var types = new EfDeletableEntityRepository<ProductType>(dbContext);

            var expected = new ProductType
            {
                Id = bed.Id,
                Name = bed.Name,
                IsDeleted = true,
                CreatedOn = bed.CreatedOn
            };

            var actual = types.AllWithDeleted();

            Assert.True(actual.Count() == 1);
            expected.Should().BeEquivalentTo(actual.ToList().FirstOrDefault());
        }

        [Fact]
        public async Task AllAsNoTrackingWithDeletedWorks()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            bed.IsDeleted = true;

            await dbContext.AddAsync(bed);

            await dbContext.SaveChangesAsync();

            using var types = new EfDeletableEntityRepository<ProductType>(dbContext);

            var actual = types.AllAsNoTrackingWithDeleted();

            var expected = new ProductType
            {
                Id = bed.Id,
                Name = bed.Name,
                IsDeleted = true,
                CreatedOn = bed.CreatedOn
            };

            Assert.True(actual.Count() == 1);
            expected.Should().BeEquivalentTo(actual.ToList().FirstOrDefault());
        }

        [Fact]
        public async Task HardDeleteWorks()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            await dbContext.AddAsync(bed);

            await dbContext.SaveChangesAsync();

            using var types = new EfDeletableEntityRepository<ProductType>(dbContext);

            types.HardDelete(bed);

            var result = types.All();

            Assert.False(result.ToList().Count == 0);
        }

        [Fact]
        public async Task DeleteWorks()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            await dbContext.AddAsync(bed);

            await dbContext.SaveChangesAsync();

            using var types = new EfDeletableEntityRepository<ProductType>(dbContext);

            types.Delete(bed);

            var result = types.All();

            Assert.Single(result);
            Assert.True(result.First().IsDeleted);
            Assert.NotNull(result.First().DeletedOn);
        }

        [Fact]
        public async Task UnDeleteWorks()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            bed.IsDeleted = true;

            await dbContext.AddAsync(bed);

            await dbContext.SaveChangesAsync();

            using var types = new EfDeletableEntityRepository<ProductType>(dbContext);

            types.Undelete(bed);

            Assert.False(bed.IsDeleted);
        }
    }
}
