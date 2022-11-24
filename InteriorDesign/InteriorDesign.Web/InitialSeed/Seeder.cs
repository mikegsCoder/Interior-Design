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

            // Products:
            var boston103bo = new Product()
            {
                Name = "Boston 103bo",
                Model = boston103b,
                Color = oak,
                Price = 170,
                ImageUrl = "/storage/bedRoom/bed/boston-103-oak.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var boston128bo = new Product()
            {
                Name = "Boston 128bo",
                Model = boston128b,
                Color = oak,
                Price = 180,
                ImageUrl = "/storage/bedRoom/bed/boston-128-oak.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var boston128bw = new Product()
            {
                Name = "Boston 128bw",
                Model = boston128b,
                Color = white,
                Price = 180,
                ImageUrl = "/storage/bedRoom/bed/boston-128-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var boston214bo = new Product()
            {
                Name = "Boston 214bo",
                Model = boston214b,
                Color = oak,
                Price = 310,
                ImageUrl = "/storage/bedRoom/bed/boston-214-oak.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var boston214bw = new Product()
            {
                Name = "Boston 214bw",
                Model = boston214b,
                Color = white,
                Price = 310,
                ImageUrl = "/storage/bedRoom/bed/boston-214-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var boston102co = new Product()
            {
                Name = "Boston 102co",
                Model = boston102c,
                Color = oak,
                Price = 180,
                ImageUrl = "/storage/bedRoom/cabinet/boston-102-oak.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var boston102cw = new Product()
            {
                Name = "Boston 102cw",
                Model = boston102c,
                Color = white,
                Price = 180,
                ImageUrl = "/storage/bedRoom/cabinet/boston-102-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var houston312cg = new Product()
            {
                Name = "Houston 312cg",
                Model = houston312c,
                Color = grey,
                Price = 140,
                ImageUrl = "/storage/bedRoom/cabinet/houston-312-grey.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var providence103co = new Product()
            {
                Name = "Providence 103co",
                Model = providence103c,
                Color = oak,
                Price = 180,
                ImageUrl = "/storage/bedRoom/cabinet/providence-103-oak.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var providence103cw = new Product()
            {
                Name = "Providence 103cw",
                Model = providence103c,
                Color = white,
                Price = 180,
                ImageUrl = "/storage/bedRoom/cabinet/providence-103-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var atlanta100wb = new Product()
            {
                Name = "Atlanta 100wb",
                Model = atlanta100w,
                Color = black,
                Price = 330,
                ImageUrl = "/storage/bedRoom/wardrobe/atlanta-100-black.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var atlanta100wo = new Product()
            {
                Name = "Atlanta 100wo",
                Model = atlanta100w,
                Color = oak,
                Price = 330,
                ImageUrl = "/storage/bedRoom/wardrobe/atlanta-100-oak.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var atlanta100ww = new Product()
            {
                Name = "Atlanta 100ww",
                Model = atlanta100w,
                Color = white,
                Price = 330,
                ImageUrl = "/storage/bedRoom/wardrobe/atlanta-100-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var atlanta131wb = new Product()
            {
                Name = "Atlanta 131wb",
                Model = atlanta131w,
                Color = black,
                Price = 420,
                ImageUrl = "/storage/bedRoom/wardrobe/atlanta-131-black.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var atlanta131wo = new Product()
            {
                Name = "Atlanta 131wo",
                Model = atlanta131w,
                Color = oak,
                Price = 420,
                ImageUrl = "/storage/bedRoom/wardrobe/atlanta-131-oak.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var atlanta131ww = new Product()
            {
                Name = "Atlanta 131ww",
                Model = atlanta131w,
                Color = white,
                Price = 420,
                ImageUrl = "/storage/bedRoom/wardrobe/atlanta-131-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var chikago1805cb = new Product()
            {
                Name = "Chikago 1805cb",
                Model = chicago1805c,
                Color = black,
                Price = 250,
                ImageUrl = "/storage/garden/chair/chikago-1805-black.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var chikago1805cg = new Product()
            {
                Name = "Chikago 1805cg",
                Model = chicago1805c,
                Color = green,
                Price = 250,
                ImageUrl = "/storage/garden/chair/chikago-1805-green.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var chikago1805cgy = new Product()
            {
                Name = "Chikago 1805cgy",
                Model = chicago1805c,
                Color = grey,
                Price = 250,
                ImageUrl = "/storage/garden/chair/chikago-1805-grey.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var comfort1203cb = new Product()
            {
                Name = "Comfort 1203cb",
                Model = comfort1203c,
                Color = black,
                Price = 75,
                ImageUrl = "/storage/garden/chair/comfort-1203-black.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var dallas740cb = new Product()
            {
                Name = "Dallas 740cb",
                Model = dallas740c,
                Color = black,
                Price = 70,
                ImageUrl = "/storage/garden/chair/dallas-740-black.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var dallas740cgy = new Product()
            {
                Name = "Dallas 740cgy",
                Model = dallas740c,
                Color = grey,
                Price = 70,
                ImageUrl = "/storage/garden/chair/dallas-740-grey.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var dallas2813tb = new Product()
            {
                Name = "Dallas 2813tb",
                Model = dallas2813t,
                Color = black,
                Price = 900,
                ImageUrl = "/storage/garden/table/dallas-2813-black.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var dallas2813tw = new Product()
            {
                Name = "Dallas 2813tw",
                Model = dallas2813t,
                Color = white,
                Price = 910,
                ImageUrl = "/storage/garden/table/dallas-2813-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var richmond619tbr = new Product()
            {
                Name = "Richmond 619tbr",
                Model = richmond619t,
                Color = brown,
                Price = 420,
                ImageUrl = "/storage/garden/table/richmond-619-brown.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var richmond619tw = new Product()
            {
                Name = "Richmond 619tw",
                Model = richmond619t,
                Color = white,
                Price = 410,
                ImageUrl = "/storage/garden/table/richmond-619-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var riverside164tb = new Product()
            {
                Name = "Riverside 164tb",
                Model = riverside164t,
                Color = black,
                Price = 240,
                ImageUrl = "/storage/garden/table/riverside-164-black.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var riverside164tgy = new Product()
            {
                Name = "Riverside 164tgy",
                Model = riverside164t,
                Color = grey,
                Price = 240,
                ImageUrl = "/storage/garden/table/riverside-164-grey.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var upa106cgy = new Product()
            {
                Name = "Upa 106cgy",
                Model = upa106c,
                Color = grey,
                Price = 75,
                ImageUrl = "/storage/kitchen/cabinet/upa-106-grey.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var upa106cr = new Product()
            {
                Name = "Upa 106cr",
                Model = upa106c,
                Color = red,
                Price = 75,
                ImageUrl = "/storage/kitchen/cabinet/upa-106-red.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var upa106cw = new Product()
            {
                Name = "Upa 106cw",
                Model = upa106c,
                Color = red,
                Price = 70,
                ImageUrl = "/storage/kitchen/cabinet/upa-106-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var upa116cgy = new Product()
            {
                Name = "Upa 116cgy",
                Model = upa116c,
                Color = grey,
                Price = 105,
                ImageUrl = "/storage/kitchen/cabinet/upa-116-grey.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var upa116cr = new Product()
            {
                Name = "Upa 116cr",
                Model = upa116c,
                Color = red,
                Price = 105,
                ImageUrl = "/storage/kitchen/cabinet/upa-116-red.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var upa116cw = new Product()
            {
                Name = "Upa 116cw",
                Model = upa116c,
                Color = white,
                Price = 100,
                ImageUrl = "/storage/kitchen/cabinet/upa-116-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var charleston185cb = new Product()
            {
                Name = "Charleston 185cb",
                Model = charleston185c,
                Color = black,
                Price = 65,
                ImageUrl = "/storage/kitchen/chair/charleston-185-black.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var charleston185cbu = new Product()
            {
                Name = "Charleston 185cbu",
                Model = charleston185c,
                Color = blue,
                Price = 65,
                ImageUrl = "/storage/kitchen/chair/charleston-185-blue.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var charleston185cg = new Product()
            {
                Name = "Charleston 185cg",
                Model = charleston185c,
                Color = green,
                Price = 65,
                ImageUrl = "/storage/kitchen/chair/charleston-185-green.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var charleston185cgy = new Product()
            {
                Name = "Charleston 185cgy",
                Model = charleston185c,
                Color = grey,
                Price = 70,
                ImageUrl = "/storage/kitchen/chair/charleston-185-grey.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var charleston196cb = new Product()
            {
                Name = "Charleston 196cb",
                Model = charleston196c,
                Color = black,
                Price = 60,
                ImageUrl = "/storage/kitchen/chair/charleston-196-black.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var charleston196cg = new Product()
            {
                Name = "Charleston 196cg",
                Model = charleston196c,
                Color = green,
                Price = 60,
                ImageUrl = "/storage/kitchen/chair/charleston-196-green.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var charleston196cgy = new Product()
            {
                Name = "Charleston 196cgy",
                Model = charleston196c,
                Color = grey,
                Price = 65,
                ImageUrl = "/storage/kitchen/chair/charleston-196-grey.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var springfield167cb = new Product()
            {
                Name = "Springfield 167cb",
                Model = springfield167c,
                Color = black,
                Price = 50,
                ImageUrl = "/storage/kitchen/chair/springfield-167-black.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var springfield167cgy = new Product()
            {
                Name = "Springfield 167cgy",
                Model = springfield167c,
                Color = grey,
                Price = 50,
                ImageUrl = "/storage/kitchen/chair/springfield-167-grey.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var boston306to = new Product()
            {
                Name = "Boston 306to",
                Model = boston306t,
                Color = oak,
                Price = 65,
                ImageUrl = "/storage/kitchen/table/boston-306-oak.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var boston306tw = new Product()
            {
                Name = "Boston 306tw",
                Model = boston306t,
                Color = white,
                Price = 60,
                ImageUrl = "/storage/kitchen/table/boston-306-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var victorville111ta = new Product()
            {
                Name = "Victorville 111ta",
                Model = victorville111t,
                Color = alder,
                Price = 170,
                ImageUrl = "/storage/kitchen/table/victorville-111-alder.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var victorville111to = new Product()
            {
                Name = "Victorville 111to",
                Model = victorville111t,
                Color = oak,
                Price = 170,
                ImageUrl = "/storage/kitchen/table/victorville-111-oak.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var victorville111tw = new Product()
            {
                Name = "Victorville 111tw",
                Model = victorville111t,
                Color = white,
                Price = 165,
                ImageUrl = "/storage/kitchen/table/victorville-111-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var nashville114co = new Product()
            {
                Name = "Nashville 114co",
                Model = nashville114c,
                Color = oak,
                Price = 140,
                ImageUrl = "/storage/livingRoom/cabinet/nashville-114-oak.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var nashville114cw = new Product()
            {
                Name = "Nashville 114cw",
                Model = nashville114c,
                Color = white,
                Price = 135,
                ImageUrl = "/storage/livingRoom/cabinet/nashville-114-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var providence123co = new Product()
            {
                Name = "Providence 123co",
                Model = providence123c,
                Color = oak,
                Price = 115,
                ImageUrl = "/storage/livingRoom/cabinet/providence-123-oak.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var providence123cw = new Product()
            {
                Name = "Providence 123cw",
                Model = providence123c,
                Color = white,
                Price = 110,
                ImageUrl = "/storage/livingRoom/cabinet/providence-123-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var armchair685cgy = new Product()
            {
                Name = "SB 685cgy",
                Model = armchairsb685c,
                Color = grey,
                Price = 175,
                ImageUrl = "/storage/livingRoom/chair/armchair-sb685-grey.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var houston1105cb = new Product()
            {
                Name = "Houston 1105cb",
                Model = houston1105c,
                Color = blue,
                Price = 290,
                ImageUrl = "/storage/livingRoom/chair/houston-1105-blue.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var houston1105cg = new Product()
            {
                Name = "Houston 1105cg",
                Model = houston1105c,
                Color = green,
                Price = 290,
                ImageUrl = "/storage/livingRoom/chair/houston-1105-green.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var houston1105cgy = new Product()
            {
                Name = "Houston 1105cgy",
                Model = houston1105c,
                Color = grey,
                Price = 295,
                ImageUrl = "/storage/livingRoom/chair/houston-1105-grey.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var houston1105cy = new Product()
            {
                Name = "Houston 1105cy",
                Model = houston1105c,
                Color = yellow,
                Price = 290,
                ImageUrl = "/storage/livingRoom/chair/houston-1105-yellow.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var houston828cb = new Product()
            {
                Name = "Houston 828cb",
                Model = houston828c,
                Color = blue,
                Price = 270,
                ImageUrl = "/storage/livingRoom/chair/houston-828-blue.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var houston828cg = new Product()
            {
                Name = "Houston 828cg",
                Model = houston828c,
                Color = green,
                Price = 270,
                ImageUrl = "/storage/livingRoom/chair/houston-828-green.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var houston828cgy = new Product()
            {
                Name = "Houston 828cgy",
                Model = houston828c,
                Color = grey,
                Price = 270,
                ImageUrl = "/storage/livingRoom/chair/houston-828-grey.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var columbus116sb = new Product()
            {
                Name = "Columbus 116sb",
                Model = columbus116s,
                Color = blue,
                Price = 380,
                ImageUrl = "/storage/livingRoom/sofa/columbus-116-blue.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var columbus116sr = new Product()
            {
                Name = "Columbus 116sr",
                Model = columbus116s,
                Color = red,
                Price = 380,
                ImageUrl = "/storage/livingRoom/sofa/columbus-116-red.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var columbus116sgy = new Product()
            {
                Name = "Columbus 116sgy",
                Model = columbus116s,
                Color = grey,
                Price = 385,
                ImageUrl = "/storage/livingRoom/sofa/columbus-116-grey.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var columbus116sy = new Product()
            {
                Name = "Columbus 116sy",
                Model = columbus116s,
                Color = yellow,
                Price = 385,
                ImageUrl = "/storage/livingRoom/sofa/columbus-116-yellow.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var richmond634sb = new Product()
            {
                Name = "Richmond 634sb",
                Model = richmond634s,
                Color = black,
                Price = 800,
                ImageUrl = "/storage/livingRoom/sofa/richmond-634-black.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var richmond634sgy = new Product()
            {
                Name = "Richmond 634sgy",
                Model = richmond634s,
                Color = grey,
                Price = 800,
                ImageUrl = "/storage/livingRoom/sofa/richmond-634-grey.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var boston234to = new Product()
            {
                Name = "Boston 234to",
                Model = boston234t,
                Color = oak,
                Price = 165,
                ImageUrl = "/storage/livingRoom/table/boston-234-oak.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var boston234tw = new Product()
            {
                Name = "Boston 234tw",
                Model = boston234t,
                Color = white,
                Price = 160,
                ImageUrl = "/storage/livingRoom/table/boston-234-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var charlote146to = new Product()
            {
                Name = "Charlote 146to",
                Model = charlote146t,
                Color = oak,
                Price = 100,
                ImageUrl = "/storage/livingRoom/table/charlote-146-oak.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var glendale100tgy = new Product()
            {
                Name = "Glendale 100tgy",
                Model = glendale100t,
                Color = grey,
                Price = 290,
                ImageUrl = "/storage/livingRoom/table/glendale-100-grey.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var glendale100to = new Product()
            {
                Name = "Glendale 100to",
                Model = glendale100t,
                Color = oak,
                Price = 295,
                ImageUrl = "/storage/livingRoom/table/glendale-100-oak.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var bristol126co = new Product()
            {
                Name = "Bristol 126co",
                Model = bristol126c,
                Color = oak,
                Price = 60,
                ImageUrl = "/storage/office/cabinet/bristol-126-oak.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var bristol126cw = new Product()
            {
                Name = "Bristol 126cw",
                Model = bristol126c,
                Color = white,
                Price = 55,
                ImageUrl = "/storage/office/cabinet/bristol-126-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var providence111co = new Product()
            {
                Name = "Providence 111co",
                Model = providence111c,
                Color = oak,
                Price = 70,
                ImageUrl = "/storage/office/cabinet/providence-111-oak.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var providence111cw = new Product()
            {
                Name = "Providence 111cw",
                Model = providence111c,
                Color = white,
                Price = 65,
                ImageUrl = "/storage/office/cabinet/providence-111-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var miami279cb = new Product()
            {
                Name = "Miami 279cb",
                Model = miami279c,
                Color = black,
                Price = 100,
                ImageUrl = "/storage/office/chair/miami-279-black.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var miami279cw = new Product()
            {
                Name = "Miami 279cw",
                Model = miami279c,
                Color = white,
                Price = 100,
                ImageUrl = "/storage/office/chair/miami-279-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var miami280cb = new Product()
            {
                Name = "Miami 280cb",
                Model = miami280c,
                Color = blue,
                Price = 180,
                ImageUrl = "/storage/office/chair/miami-280-blue.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var miami280cgy = new Product()
            {
                Name = "Miami 280cgy",
                Model = miami280c,
                Color = grey,
                Price = 180,
                ImageUrl = "/storage/office/chair/miami-280-grey.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var murrieta118da = new Product()
            {
                Name = "Murrieta 118da",
                Model = murrieta118d,
                Color = alder,
                Price = 80,
                ImageUrl = "/storage/office/desk/murrieta-118-alder.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var murrieta118db = new Product()
            {
                Name = "Murrieta 118db",
                Model = murrieta118d,
                Color = beech,
                Price = 80,
                ImageUrl = "/storage/office/desk/murrieta-118-beech.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var murrieta118dwt = new Product()
            {
                Name = "Murrieta 118dwt",
                Model = murrieta118d,
                Color = walnut,
                Price = 80,
                ImageUrl = "/storage/office/desk/murrieta-118-walnut.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var murrieta121da = new Product()
            {
                Name = "Murrieta 121da",
                Model = murrieta121d,
                Color = alder,
                Price = 120,
                ImageUrl = "/storage/office/desk/murrieta-121-alder.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var murrieta121db = new Product()
            {
                Name = "Murrieta 121db",
                Model = murrieta121d,
                Color = beech,
                Price = 120,
                ImageUrl = "/storage/office/desk/murrieta-121-beech.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var murrieta121dwt = new Product()
            {
                Name = "Murrieta 121dwt",
                Model = murrieta121d,
                Color = walnut,
                Price = 120,
                ImageUrl = "/storage/office/desk/murrieta-121-walnut.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var boston296so = new Product()
            {
                Name = "Boston 296so",
                Model = boston296s,
                Color = oak,
                Price = 185,
                ImageUrl = "/storage/office/shelf/boston-296-oak.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var boston296sw = new Product()
            {
                Name = "Boston 296sw",
                Model = boston296s,
                Color = white,
                Price = 180,
                ImageUrl = "/storage/office/shelf/boston-296-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var miami156sb = new Product()
            {
                Name = "Miani 156sb",
                Model = miami156s,
                Color = black,
                Price = 75,
                ImageUrl = "/storage/office/shelf/miami-156-black.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var miami156so = new Product()
            {
                Name = "Miani 156so",
                Model = miami156s,
                Color = oak,
                Price = 75,
                ImageUrl = "/storage/office/shelf/miami-156-oak.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var miami156sw = new Product()
            {
                Name = "Miani 156sw",
                Model = miami156s,
                Color = white,
                Price = 70,
                ImageUrl = "/storage/office/shelf/miami-156-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var saratosa111so = new Product()
            {
                Name = "Saratosa 111so",
                Model = saratosa111s,
                Color = oak,
                Price = 105,
                ImageUrl = "/storage/office/shelf/saratosa-111-oak.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var saratosa111sw = new Product()
            {
                Name = "Saratosa 111sw",
                Model = saratosa111s,
                Color = white,
                Price = 100,
                ImageUrl = "/storage/office/shelf/saratosa-111-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var bedford103ww = new Product()
            {
                Name = "Bedford 103ww",
                Model = bedford103w,
                Color = white,
                Price = 200,
                ImageUrl = "/storage/office/wardrobe/bedford-103-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var bedford742wo = new Product()
            {
                Name = "Bedford 742wo",
                Model = bedford742w,
                Color = oak,
                Price = 210,
                ImageUrl = "/storage/office/wardrobe/bedford-742-oak.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var murrieta101wo = new Product()
            {
                Name = "Murrieta 101wo",
                Model = murrieta101w,
                Color = oak,
                Price = 470,
                ImageUrl = "/storage/office/wardrobe/murrieta-101-oak.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var murrieta101ww = new Product()
            {
                Name = "Murrieta 101ww",
                Model = murrieta101w,
                Color = white,
                Price = 470,
                ImageUrl = "/storage/office/wardrobe/murrieta-101-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var renton101bb = new Product()
            {
                Name = "Renton 101bb",
                Model = renton101b,
                Color = blue,
                Price = 185,
                ImageUrl = "/storage/youngRoom/bed/renton-101-blue.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var renton101bgy = new Product()
            {
                Name = "Renton 101bgy",
                Model = renton101b,
                Color = grey,
                Price = 185,
                ImageUrl = "/storage/youngRoom/bed/renton-101-grey.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var renton101bgr = new Product()
            {
                Name = "Renton 101bgr",
                Model = renton101b,
                Color = red,
                Price = 185,
                ImageUrl = "/storage/youngRoom/bed/renton-101-red.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var renton106bw = new Product()
            {
                Name = "Renton 106bw",
                Model = renton106b,
                Color = white,
                Price = 165,
                ImageUrl = "/storage/youngRoom/bed/renton-106-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var boston104co = new Product()
            {
                Name = "Boston 104co",
                Model = boston104c,
                Color = oak,
                Price = 140,
                ImageUrl = "/storage/youngRoom/cabinet/boston-104-oak.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var omaha108cw = new Product()
            {
                Name = "Omaha 108cw",
                Model = omaha108c,
                Color = white,
                Price = 190,
                ImageUrl = "/storage/youngRoom/cabinet/omaha-108-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var omaha116cb = new Product()
            {
                Name = "Omaha 116cb",
                Model = omaha116c,
                Color = blue,
                Price = 140,
                ImageUrl = "/storage/youngRoom/cabinet/omaha-116-blue.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var omaha116cy = new Product()
            {
                Name = "Omaha 116cy",
                Model = omaha116c,
                Color = yellow,
                Price = 140,
                ImageUrl = "/storage/youngRoom/cabinet/omaha-116-yellow.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var houston100cy = new Product()
            {
                Name = "Houston 100cy",
                Model = houston100c,
                Color = yellow,
                Price = 95,
                ImageUrl = "/storage/youngRoom/chair/houston-100-yellow.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var houston1127cg = new Product()
            {
                Name = "Houston 1127cg",
                Model = houston1127c,
                Color = green,
                Price = 175,
                ImageUrl = "/storage/youngRoom/chair/houston-1127-green.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var houston1127cgy = new Product()
            {
                Name = "Houston 1127cgy",
                Model = houston1127c,
                Color = grey,
                Price = 175,
                ImageUrl = "/storage/youngRoom/chair/houston-1127-grey.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var houston204cw = new Product()
            {
                Name = "Houston 204cw",
                Model = houston204c,
                Color = white,
                Price = 105,
                ImageUrl = "/storage/youngRoom/chair/houston-204-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var houston396cgy = new Product()
            {
                Name = "Houston 396cgy",
                Model = houston396c,
                Color = grey,
                Price = 75,
                ImageUrl = "/storage/youngRoom/chair/houston-396-grey.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var columbia101tw = new Product()
            {
                Name = "Columbia 101tw",
                Model = columbia101t,
                Color = white,
                Price = 230,
                ImageUrl = "/storage/youngRoom/table/columbia-101-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var renton100tw = new Product()
            {
                Name = "Renton 100tw",
                Model = renton100t,
                Color = white,
                Price = 180,
                ImageUrl = "/storage/youngRoom/table/renton-100-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var aurora111ww = new Product()
            {
                Name = "Aurora 111ww",
                Model = aurora111w,
                Color = white,
                Price = 410,
                ImageUrl = "/storage/youngRoom/wardrobe/aurora-111-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var boston104ww = new Product()
            {
                Name = "Boston 104ww",
                Model = boston104w,
                Color = white,
                Price = 390,
                ImageUrl = "/storage/youngRoom/wardrobe/boston-104-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var columbia102ww = new Product()
            {
                Name = "Columbia 102ww",
                Model = columbia102w,
                Color = white,
                Price = 405,
                ImageUrl = "/storage/youngRoom/wardrobe/columbia-102-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
            var renton105ww = new Product()
            {
                Name = "Renton 105ww",
                Model = renton105w,
                Color = white,
                Price = 385,
                ImageUrl = "/storage/youngRoom/wardrobe/renton-105-white.jpg",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };
        }
    }
}
