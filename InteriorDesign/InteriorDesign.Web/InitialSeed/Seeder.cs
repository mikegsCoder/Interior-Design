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

            // Product Models:
            var boston103b = new ProductModel()
            {
                Name = "Boston 103b",
                Type = bed,
                Category = bedRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var boston128b = new ProductModel()
            {
                Name = "Boston 128b",
                Type = bed,
                Category = bedRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var boston214b = new ProductModel()
            {
                Name = "Boston 214b",
                Type = bed,
                Category = bedRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var boston102c = new ProductModel()
            {
                Name = "Boston 102c",
                Type = cabinet,
                Category = bedRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var houston312c = new ProductModel()
            {
                Name = "Houston 312c",
                Type = cabinet,
                Category = bedRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var boston103c = new ProductModel()
            {
                Name = "Boston 103c",
                Type = cabinet,
                Category = bedRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var atlanta100w = new ProductModel()
            {
                Name = "Atlanta 100w",
                Type = wardrobe,
                Category = bedRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var atlanta131w = new ProductModel()
            {
                Name = "Atlanta 131w",
                Type = wardrobe,
                Category = bedRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var chicago1805c = new ProductModel()
            {
                Name = "Chicago 1805c",
                Type = chair,
                Category = garden,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var comfort1203c = new ProductModel()
            {
                Name = "Comfort 1203c",
                Type = chair,
                Category = garden,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var dallas740c = new ProductModel()
            {
                Name = "Dallas 740c",
                Type = chair,
                Category = garden,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var dallas2813t = new ProductModel()
            {
                Name = "Dallas 2813t",
                Type = table,
                Category = garden,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var richmond619t = new ProductModel()
            {
                Name = "Richmond 619t",
                Type = table,
                Category = garden,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var riverside164t = new ProductModel()
            {
                Name = "Riverside 164t",
                Type = table,
                Category = garden,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var upa106c = new ProductModel()
            {
                Name = "Upa 106c",
                Type = cabinet,
                Category = kitchen,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var upa116c = new ProductModel()
            {
                Name = "Upa 116c",
                Type = cabinet,
                Category = kitchen,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var charleston185c = new ProductModel()
            {
                Name = "Charleston 185c",
                Type = chair,
                Category = kitchen,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var charleston196c = new ProductModel()
            {
                Name = "Charleston 196c",
                Type = chair,
                Category = kitchen,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var springfield167c = new ProductModel()
            {
                Name = "Springfield 167c",
                Type = chair,
                Category = kitchen,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var boston306t = new ProductModel()
            {
                Name = "Boston 306t",
                Type = table,
                Category = kitchen,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var victorville111t = new ProductModel()
            {
                Name = "Victorville 111t",
                Type = table,
                Category = kitchen,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var nashville114c = new ProductModel()
            {
                Name = "Nashville 114c",
                Type = cabinet,
                Category = livingRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var providence123c = new ProductModel()
            {
                Name = "Providence 123c",
                Type = cabinet,
                Category = livingRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var providence103c = new ProductModel()
            {
                Name = "Providence 103c",
                Type = cabinet,
                Category = bedRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var armchairsb685c = new ProductModel()
            {
                Name = "SB 685c",
                Type = chair,
                Category = livingRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var houston1105c = new ProductModel()
            {
                Name = "Houston 1105c",
                Type = chair,
                Category = livingRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var houston828c = new ProductModel()
            {
                Name = "Houston 828c",
                Type = chair,
                Category = livingRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var columbus116s = new ProductModel()
            {
                Name = "Columbus 116s",
                Type = sofa,
                Category = livingRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var richmond634s = new ProductModel()
            {
                Name = "Richmond 634s",
                Type = sofa,
                Category = livingRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var boston234t = new ProductModel()
            {
                Name = "Boston 234t",
                Type = table,
                Category = livingRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var charlote146t = new ProductModel()
            {
                Name = "Charlote 146t",
                Type = table,
                Category = livingRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var glendale100t = new ProductModel()
            {
                Name = "Glendale 100t",
                Type = table,
                Category = livingRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var bristol126c = new ProductModel()
            {
                Name = "Bristol 126c",
                Type = cabinet,
                Category = office,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var providence111c = new ProductModel()
            {
                Name = "Providence 111c",
                Type = cabinet,
                Category = office,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var miami279c = new ProductModel()
            {
                Name = "Miami 279c",
                Type = chair,
                Category = office,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var miami280c = new ProductModel()
            {
                Name = "Miami 280c",
                Type = chair,
                Category = office,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var murrieta118d = new ProductModel()
            {
                Name = "Murrieta 118d",
                Type = desk,
                Category = office,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var murrieta121d = new ProductModel()
            {
                Name = "Murrieta 121d",
                Type = desk,
                Category = office,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var boston296s = new ProductModel()
            {
                Name = "Boston 296s",
                Type = shelf,
                Category = office,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var miami156s = new ProductModel()
            {
                Name = "Miami 156s",
                Type = shelf,
                Category = office,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var saratosa111s = new ProductModel()
            {
                Name = "Saratosa 111s",
                Type = shelf,
                Category = office,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var bedford103w = new ProductModel()
            {
                Name = "Bedford 103w",
                Type = wardrobe,
                Category = office,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var bedford742w = new ProductModel()
            {
                Name = "Bedford 742w",
                Type = wardrobe,
                Category = office,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var murrieta101w = new ProductModel()
            {
                Name = "Murrieta 101w",
                Type = wardrobe,
                Category = office,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var renton101b = new ProductModel()
            {
                Name = "Renton 101b",
                Type = bed,
                Category = youngRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var renton106b = new ProductModel()
            {
                Name = "Renton 106b",
                Type = bed,
                Category = youngRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var boston104c = new ProductModel()
            {
                Name = "Boston 104c",
                Type = cabinet,
                Category = youngRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var omaha108c = new ProductModel()
            {
                Name = "Omaha 108c",
                Type = cabinet,
                Category = youngRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var omaha116c = new ProductModel()
            {
                Name = "Omaha 116c",
                Type = cabinet,
                Category = youngRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var houston100c = new ProductModel()
            {
                Name = "Houston 100c",
                Type = chair,
                Category = youngRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var houston1127c = new ProductModel()
            {
                Name = "Houston 1127c",
                Type = chair,
                Category = youngRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var houston204c = new ProductModel()
            {
                Name = "Houston 204c",
                Type = chair,
                Category = youngRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var houston396c = new ProductModel()
            {
                Name = "Houston 396c",
                Type = chair,
                Category = youngRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var columbia101t = new ProductModel()
            {
                Name = "Columbia 101t",
                Type = table,
                Category = youngRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var renton100t = new ProductModel()
            {
                Name = "Renton 100t",
                Type = table,
                Category = youngRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var aurora111w = new ProductModel()
            {
                Name = "Aurora 111w",
                Type = wardrobe,
                Category = youngRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var boston104w = new ProductModel()
            {
                Name = "Boston 104w",
                Type = wardrobe,
                Category = youngRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var columbia102w = new ProductModel()
            {
                Name = "Columbia 102w",
                Type = wardrobe,
                Category = youngRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var renton105w = new ProductModel()
            {
                Name = "Renton 105w",
                Type = wardrobe,
                Category = youngRoom,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
        }
    }
}
