using InteriorDesign.Infrastructure.Data.Models.DataBaseModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InteriorDesign.Infrastructure.Data.Configuration
{
    internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        private readonly PasswordHasher<ApplicationUser> hasher = new();

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(SeedUsers());
        }

        private IEnumerable<ApplicationUser> SeedUsers()
        {
            var adminUser = new ApplicationUser
            {
                Id = "90b21bc9-9062-4142-b3f9-774e6797e080", // primary key
                UserName = "admin@mail.com",
                Email = "admin@mail.com",
                NormalizedUserName = "admin@mail.com".ToUpper(),
                NormalizedEmail = "admin@mail.com".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123456")
            };

            var employeeUser = new ApplicationUser
            {
                Id = "4feb248f-9f4a-4dd9-a8d5-1ed4ee14a188", // primary key
                UserName = "employee@mail.com",
                Email = "employee@mail.com",
                NormalizedUserName = "employee@mail.com".ToUpper(),
                NormalizedEmail = "employee@mail.com".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123456")
            };

            var userUser = new ApplicationUser
            {
                Id = "c623d98f-7ced-432f-8955-879f45c38420", // primary key
                UserName = "user@mail.com",
                Email = "user@mail.com",
                NormalizedUserName = "user@mail.com".ToUpper(),
                NormalizedEmail = "user@mail.com".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123456")
            };

            return new List<ApplicationUser>(){ adminUser, employeeUser, userUser};
        }
    }
}
