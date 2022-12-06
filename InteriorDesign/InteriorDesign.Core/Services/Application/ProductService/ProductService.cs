using InteriorDesign.Core.ViewModels.ProductViewModels;
using InteriorDesign.Infrastructure.Data.Models.DataBaseModels;
using InteriorDesign.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace InteriorDesign.Core.Services.Application.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IDeletableEntityRepository<ProductCategory> _categories;
        private readonly IDeletableEntityRepository<ProductType> _types;
        private readonly IDeletableEntityRepository<ProductModel> _models;
        private readonly IDeletableEntityRepository<Product> _products;
        private readonly IDeletableEntityRepository<ProductColor> _colors;
        private readonly IDeletableEntityRepository<ConfiguredProduct> _configuredProducts;

        public ProductService(
            IDeletableEntityRepository<ProductCategory> categories,
            IDeletableEntityRepository<ProductType> types,
            IDeletableEntityRepository<ProductModel> models,
            IDeletableEntityRepository<Product> products,
            IDeletableEntityRepository<ProductColor> colors,
            IDeletableEntityRepository<ConfiguredProduct> configuredProducts)
        {
            _categories = categories;
            _types = types;
            _models = models;
            _products = products;
            _colors = colors;
            _configuredProducts = configuredProducts;
        }

        public async Task<IEnumerable<ProductInfoViewModel>> GetAllProductsAsync()
        {
            var productsInfo = new List<ProductInfoViewModel>();

            var products = await _products.AllAsNoTracking()
                .Where(p => !p.IsDeleted)
                .OrderBy(p => p.Model.Category.Name)
                .ThenBy(p => p.Model.Type.Name)
                .ThenBy(p => p.Model.Name)
                .ThenBy(p => p.Name)
                .ToListAsync();

            foreach (var product in products)
            {
                var color = await _colors.AllAsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == product.ColorId);

                var model = await _models.AllAsNoTracking()
                    .FirstOrDefaultAsync(m => m.Id == product.ModelId);

                var category = await _categories.AllAsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == model.CategoryId);

                var type = await _types.AllAsNoTracking()
                    .FirstOrDefaultAsync(t => t.Id == model.TypeId);

                var productInfo = new ProductInfoViewModel
                {
                    Id = product.Id,
                    CategoryName = category.Name,
                    TypeName = type.Name,
                    ProductName = product.Name,
                    ModelName = model.Name,
                    ColorName = color.Name,
                    ProductPrice = product.Price,
                    ImageUrl = product.ImageUrl
                };

                productsInfo.Add(productInfo);
            }

            return productsInfo;
        }

        public async Task<IEnumerable<ProductInfoViewModel>> GetProductsByModelIdAsync(string modelId)
        {
            var modelInfo = new List<ProductInfoViewModel>();

            var model = await _models.AllAsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == modelId);

            var category = await _categories.AllAsNoTracking()
                   .FirstOrDefaultAsync(c => c.Id == model.CategoryId);

            var type = await _types.AllAsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == model.TypeId);

            var products = await _products.AllAsNoTracking()
                .Where(p => p.ModelId == modelId)
                .ToListAsync();

            foreach (var product in products)
            {
                var color = await _colors.AllAsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == product.ColorId);

                var productInfo = new ProductInfoViewModel
                {
                    Id = product.Id,
                    CategoryName = category.Name,
                    TypeName = type.Name,
                    ProductName = product.Name,
                    ModelName = model.Name,
                    ColorName = color.Name,
                    ProductPrice = product.Price,
                    ImageUrl = product.ImageUrl
                };

                modelInfo.Add(productInfo);
            }

            return modelInfo;
        }

        public async Task<ProductViewModel> GetProductByIdAsync(string productId)
        {
            var product = await _products.AllAsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == productId);

            var color = await _colors.AllAsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == product.ColorId);

            var model = await _models.AllAsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == product.ModelId);

            var category = await _categories.AllAsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == model.CategoryId);

            var type = await _types.AllAsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == model.TypeId);

            var productModel = new ProductViewModel
            {
                ProductId = product.Id,
                CategoryName = category.Name,
                TypeName = type.Name,
                ProductName = product.Name,
                ModelName = model.Name,
                ColorName = color.Name,
                ProductPrice = product.Price,
                ImageUrl = product.ImageUrl,
                UserId = "",
                Quantity = 1,
            };

            return productModel;
        }

        public async Task AddToCartAsync(ProductViewModel model)
        {
            var product = await _products.AllAsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == model.ProductId);

            var configuredProduct = new ConfiguredProduct
            {
                ProductId = product.Id,
                Quantity = model.Quantity,
                Price = product.Price * model.Quantity,
                UserId = model.UserId,
                CreatedOn = DateTime.UtcNow,
                IsOrdered = false,
                IsDeleted = false
            };

            await _configuredProducts.AddAsync(configuredProduct);
            await _configuredProducts.SaveChangesAsync();
        }

        public async Task EditProductAsync(ProductViewModel model)
        {
            var product = await _products.All()
                .Where(p => p.Id == model.ProductId)
                .FirstOrDefaultAsync();

            decimal price = 0;

            if (!decimal.TryParse(model.ProductPriceString, NumberStyles.Float, CultureInfo.InvariantCulture, out price)
                || price < 5.00M || price > 2000.00M)
            {
                throw new InvalidDataException("Invalid price provided.");
            }

            product.ImageUrl = model.ImageUrl;
            product.Price = price;

            _products.Update(product);

            await _products.SaveChangesAsync();
        }
    }
}
