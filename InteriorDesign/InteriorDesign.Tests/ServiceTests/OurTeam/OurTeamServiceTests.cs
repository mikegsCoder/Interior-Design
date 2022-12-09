using InteriorDesign.Core.Services.Application.OurTeamService;
using InteriorDesign.Core.ViewModels.OurTeamViewModels;

namespace InteriorDesign.Tests.ServiceTests.OurTeam
{
    public class OurTeamServiceTests
    {
        private readonly TeamMember member;

        public OurTeamServiceTests()
        {
            member = new TeamMember()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Amanda",
                LastName = "Jepson",
                Position = "Designer",
                ImageUrl = "/img/team/team1.jpg",
                TwitterUrl = "https://twitter.com/",
                FacebookUrl = "https://www.facebook.com/",
                GooglePlusUrl = "https://plus.google.com",
                LinkedInUrl = "https://www.linkedin.com",
                CreatedOn = DateTime.Now
            };
        }

        [Fact]
        public async Task GetTeamAsyncReturnsListOfOurTeamViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var team = new EfDeletableEntityRepository<TeamMember>(dbContext);

            await dbContext.AddAsync(member);

            await dbContext.SaveChangesAsync();

            var expected = new List<OurTeamViewModel>();

            expected.Add(new OurTeamViewModel()
            {
                MemberId = member.Id,
                Name = member.FirstName + " " + member.LastName,
                Position = member.Position,
                ImageUrl = member.ImageUrl,
                TwitterUrl = member.TwitterUrl,
                FacebookUrl = member.FacebookUrl,
                GooglePlusUrl = member.GooglePlusUrl,
                LinkedInUrl = member.LinkedInUrl
            });

            var service = new OurTeamService(team);

            var actual = await service.GetTeamAsync();

            Assert.Single(actual);
            Assert.True(actual.Count() == expected.Count);
            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetTeamAsyncReturnsEmptyListOfOurTeamViewModel()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var team = new EfDeletableEntityRepository<TeamMember>(dbContext);

            var service = new OurTeamService(team);

            var actual = await service.GetTeamAsync();

            Assert.Empty(actual);
        }

        [Fact]
        public async Task GetMemberByIdAsyncWorksProperly()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var team = new EfDeletableEntityRepository<TeamMember>(dbContext);

            await dbContext.AddAsync(member);

            await dbContext.SaveChangesAsync();

            var expected = new OurTeamViewModel()
            {
                MemberId = member.Id,
                Name = member.FirstName + " " + member.LastName,
                Position = member.Position,
                ImageUrl = member.ImageUrl,
                TwitterUrl = member.TwitterUrl,
                FacebookUrl = member.FacebookUrl,
                GooglePlusUrl = member.GooglePlusUrl,
                LinkedInUrl = member.LinkedInUrl
            };

            var service = new OurTeamService(team);

            var actual = await service.GetMemberByIdAsync(member.Id);

            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task GetMemberByIdAsyncReturnsNull()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var team = new EfDeletableEntityRepository<TeamMember>(dbContext);

            var service = new OurTeamService(team);

            var actual = await service.GetMemberByIdAsync(member.Id);

            Assert.Null(actual);
        }

        [Fact]
        public async Task EditTeamMemeberAsyncWorksProperly()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var team = new EfDeletableEntityRepository<TeamMember>(dbContext);

            await dbContext.AddAsync(member);

            await dbContext.SaveChangesAsync();

            var expected = new OurTeamViewModel()
            {
                MemberId = member.Id,
                Name = member.FirstName + " " + member.LastName,
                Position = "test position",
                ImageUrl = "test image",
                TwitterUrl = "test twitter",
                FacebookUrl = "test facebook",
                GooglePlusUrl = "test google+",
                LinkedInUrl = "test linkedin"
            };

            var service = new OurTeamService(team);

            await service.EditTeamMemeberAsync(expected);

            var actual = await service.GetMemberByIdAsync(member.Id);

            expected.Should().BeEquivalentTo(actual);
        }

        [Fact]
        public async Task EditTeamMemeberAsyncThrowsError()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());

            await using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            using var team = new EfDeletableEntityRepository<TeamMember>(dbContext);

            var model = new OurTeamViewModel()
            {
                MemberId = "test",
                Name = "test",
                Position = "test position",
                ImageUrl = "test image",
                TwitterUrl = "test twitter",
                FacebookUrl = "test facebook",
                GooglePlusUrl = "test google+",
                LinkedInUrl = "test linkedin"
            };

            var service = new OurTeamService(team);

            await Assert.ThrowsAsync<NullReferenceException>(() => service.EditTeamMemeberAsync(model));
        }
    }
}
