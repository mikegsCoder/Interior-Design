using InteriorDesign.Infrastructure.Data.Models.DataBaseModels;
using InteriorDesign.Infrastricture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace InteriorDesign.Web.InitialSeed
{
    public class Seeder
    {
        public static async Task SeedAsync(IApplicationBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            using var serviceScope = builder.ApplicationServices.CreateScope();

            var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            
            dbContext.Database.Migrate();

            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Product Categories:
            var office = new ProductCategory()
            {
                Name = "Office",
                ImageUrl = "/storage/office/office.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var livingRoom = new ProductCategory()
            {
                Name = "Living Room",
                ImageUrl = "/storage/livingRoom/livingRoom.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var bedRoom = new ProductCategory()
            {
                Name = "Bed Room",
                ImageUrl = "/storage/bedRoom/bedRoom.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var youngRoom = new ProductCategory()
            {
                Name = "Young Room",
                ImageUrl = "/storage/youngRoom/youngRoom.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var kitchen = new ProductCategory()
            {
                Name = "Kitchen",
                ImageUrl = "/storage/kitchen/kitchen.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var garden = new ProductCategory()
            {
                Name = "Garden",
                ImageUrl = "/storage/garden/garden.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };

            // Product Types:
            var chair = new ProductType()
            {
                Name = "Chair",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var table = new ProductType()
            {
                Name = "Table",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var bed = new ProductType()
            {
                Name = "Bed",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var desk = new ProductType()
            {
                Name = "Desk",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var cabinet = new ProductType()
            {
                Name = "Cabinet",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var shelf = new ProductType()
            {
                Name = "Shelf",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var sofa = new ProductType()
            {
                Name = "Sofa",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var wardrobe = new ProductType()
            {
                Name = "Wardrobe",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
        }
    }
}
