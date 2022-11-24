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

            // Product Categories - Product Types:
            office.ProductTypes = new HashSet<ProductType>()
            {
                chair,
                desk,
                cabinet,
                shelf,
                wardrobe
            };
            livingRoom.ProductTypes = new HashSet<ProductType>()
            {
                chair,
                table,
                cabinet,
                sofa
            };
            bedRoom.ProductTypes = new HashSet<ProductType>()
            {
                bed,
                cabinet,
                wardrobe
            };
            youngRoom.ProductTypes = new HashSet<ProductType>()
            {
                chair,
                table,
                bed,
                cabinet,
                wardrobe
            };
            kitchen.ProductTypes = new HashSet<ProductType>()
            {
                chair,
                table,
                cabinet
            };
            garden.ProductTypes = new HashSet<ProductType>()
            {
                chair,
                table
            };

            // Product Colors:
            var white = new ProductColor()
            {
                Name = "White",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var grey = new ProductColor()
            {
                Name = "Grey",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var yellow = new ProductColor()
            {
                Name = "Yellow",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var brown = new ProductColor()
            {
                Name = "Brown",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var red = new ProductColor()
            {
                Name = "Red",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var green = new ProductColor()
            {
                Name = "Green",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var blue = new ProductColor()
            {
                Name = "Blue",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var black = new ProductColor()
            {
                Name = "Black",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var alder = new ProductColor()
            {
                Name = "Alder",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var oak = new ProductColor()
            {
                Name = "Oak",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var beech = new ProductColor()
            {
                Name = "Beech",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var walnut = new ProductColor()
            {
                Name = "Walnut",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
        }
    }
}
