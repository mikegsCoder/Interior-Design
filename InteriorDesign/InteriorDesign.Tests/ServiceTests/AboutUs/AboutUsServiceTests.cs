using InteriorDesign.Core.Services.Application.AboutUsService;
using InteriorDesign.Core.ViewModels.TestimonialViewModels;

namespace InteriorDesign.Tests.ServiceTests.AboutUs
{
    public class AboutUsServiceTests
    {
        private readonly Testimonial testimonial;

        public AboutUsServiceTests()
        {
            testimonial = new Testimonial()
            {
                Author = "Kelly Adams",
                Title = "Long time Customer",
                Content = "Test content",
                CreatedOn = DateTime.Now,
                IsActive = true
            };
        }

        [Fact]
        public async Task GetAllTestimonialsAsyncReturnsListOfTestimonialViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var testimonials = new EfDeletableEntityRepository<Testimonial>(dbContext);

            testimonial.IsActive = false;

            await dbContext.AddAsync(testimonial);

            await dbContext.SaveChangesAsync();

            var expected = new List<TestimonialViewModel>();

            expected.Add(new TestimonialViewModel()
            {
                TestimonialId = testimonial.Id,
                Author = testimonial.Author,
                Title = testimonial.Title,
                Content = testimonial.Content,
                IsActive = testimonial.IsActive
            });

            var service = new AboutUsService(testimonials);

            var actual = await service.GetAllTestimonialsAsync();

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetAllTestimonialsAsyncReturnsEmptyListOfTestimonialViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var testimonials = new EfDeletableEntityRepository<Testimonial>(dbContext);

            var expected = new List<TestimonialViewModel>();

            var service = new AboutUsService(testimonials);

            var actual = await service.GetAllTestimonialsAsync();

            Assert.Empty(actual);
            Assert.True(actual.Count() == 0);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetActiveTestimonialsAsyncReturnsListOfTestimonialViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var testimonials = new EfDeletableEntityRepository<Testimonial>(dbContext);

            await dbContext.AddAsync(testimonial);

            await dbContext.SaveChangesAsync();

            var expected = new List<TestimonialViewModel>();

            expected.Add(new TestimonialViewModel()
            {
                TestimonialId = testimonial.Id,
                Author = testimonial.Author,
                Title = testimonial.Title,
                Content = testimonial.Content,
                IsActive = testimonial.IsActive
            });

            var service = new AboutUsService(testimonials);

            var actual = await service.GetActiveTestimonialsAsync();

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetActiveTestimonialsAsyncReturnsEmptyListOfTestimonialViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var testimonials = new EfDeletableEntityRepository<Testimonial>(dbContext);

            testimonial.IsActive = false;

            await dbContext.AddAsync(testimonial);

            await dbContext.SaveChangesAsync();

            var expected = new List<TestimonialViewModel>();

            var service = new AboutUsService(testimonials);

            var actual = await service.GetActiveTestimonialsAsync();

            Assert.Empty(actual);
            Assert.True(actual.Count() == 0);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task DeactivateTestimonialAsyncWorksProperly()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var testimonials = new EfDeletableEntityRepository<Testimonial>(dbContext);

            await dbContext.AddAsync(testimonial);

            await dbContext.SaveChangesAsync();

            var expected = new List<TestimonialViewModel>();

            expected.Add(new TestimonialViewModel()
            {
                TestimonialId = testimonial.Id,
                Author = testimonial.Author,
                Title = testimonial.Title,
                Content = testimonial.Content,
                IsActive = !testimonial.IsActive
            });

            var service = new AboutUsService(testimonials);

            await service.DeactivateTestimonialAsync(testimonial.Id);

            var active = await service.GetActiveTestimonialsAsync();
            var all = await service.GetAllTestimonialsAsync();

            Assert.Empty(active);
            Assert.Single(all);
            Assert.True(all.Count() == expected.Count);
            expected.Should().BeEquivalentTo(all);
        }

        [Fact]
        public async Task DeactivateTestimonialAsyncThrowsError()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var testimonials = new EfDeletableEntityRepository<Testimonial>(dbContext);

            var service = new AboutUsService(testimonials);
            
            await Assert.ThrowsAsync<NullReferenceException>(() => service.DeactivateTestimonialAsync("test"));
        }

        [Fact]
        public async Task ActivateTestimonialAsyncWorksProperly()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var testimonials = new EfDeletableEntityRepository<Testimonial>(dbContext);

            testimonial.IsActive = false;

            await dbContext.AddAsync(testimonial);

            await dbContext.SaveChangesAsync();

            var expected = new List<TestimonialViewModel>();

            expected.Add(new TestimonialViewModel()
            {
                TestimonialId = testimonial.Id,
                Author = testimonial.Author,
                Title = testimonial.Title,
                Content = testimonial.Content,
                IsActive = true
            });

            var service = new AboutUsService(testimonials);

            await service.ActivateTestimonialAsync(testimonial.Id);

            var active = await service.GetActiveTestimonialsAsync();
            var all = await service.GetAllTestimonialsAsync();

            Assert.Single(active);
            Assert.Single(all);
            Assert.True(all.Count() == expected.Count);
            expected.Should().BeEquivalentTo(active);
            all.Should().BeEquivalentTo(active);
        }

        [Fact]
        public async Task ActivateTestimonialAsyncThrowsError()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var testimonials = new EfDeletableEntityRepository<Testimonial>(dbContext);

            var service = new AboutUsService(testimonials);

            await Assert.ThrowsAsync<NullReferenceException>(() => service.ActivateTestimonialAsync("test"));
        }
    }
}
