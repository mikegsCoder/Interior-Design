using InteriorDesign.Core.ViewModels.ConfiguredProductViewModels;
using InteriorDesign.Infrastructure.Data.Models.DataBaseModels;
using InteriorDesign.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InteriorDesign.Core.Services.Application.CartService
{
    public class CartService : ICartService
    {
        private readonly IDeletableEntityRepository<ProductCategory> _categories;
        private readonly IDeletableEntityRepository<ProductType> _types;
        private readonly IDeletableEntityRepository<ProductModel> _models;
        private readonly IDeletableEntityRepository<Product> _products;
        private readonly IDeletableEntityRepository<ProductColor> _colors;
        private readonly IDeletableEntityRepository<ConfiguredProduct> _configuredProducts;

        public CartService(
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

        public async Task<IEnumerable<ConfiguredProductViewModel>> GetAllProductsByUserIdAsync(string userId)
        {
            var productModels = new List<ConfiguredProductViewModel>();

            var configuredProducts = await _configuredProducts.AllAsNoTracking()
                .Where(cp => cp.UserId == userId && !cp.IsOrdered)
                .ToListAsync();

            foreach (var configuredProduct in configuredProducts)
            {
                var product = await _products.AllAsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id == configuredProduct.ProductId);

                var color = await _colors.AllAsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == product.ColorId);

                var model = await _models.AllAsNoTracking()
                    .FirstOrDefaultAsync(m => m.Id == product.ModelId);

                var category = await _categories.AllAsNoTracking()
                    .FirstOrDefaultAsync(c => c.Id == model.CategoryId);

                var type = await _types.AllAsNoTracking()
                    .FirstOrDefaultAsync(t => t.Id == model.TypeId);

                var productModel = new ConfiguredProductViewModel
                {
                    Id = configuredProduct.Id,
                    ProductId = product.Id,
                    CategoryName = category.Name,
                    TypeName = type.Name,
                    ProductName = product.Name,
                    ModelName = model.Name,
                    ColorName = color.Name,
                    ProductPrice = configuredProduct.Price,
                    SinglePrice = product.Price,
                    ImageUrl = product.ImageUrl,
                    UserId = userId,
                    Quantity = configuredProduct.Quantity
                };

                productModels.Add(productModel);
            }

            return productModels;
        }

        public async Task<ConfiguredProductViewModel> GetProductByIdAsync(string productId)
        {
            var configuredProduct = await _configuredProducts.AllAsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == productId);

            var product = await _products.AllAsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id == configuredProduct.ProductId);

            var color = await _colors.AllAsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == product.ColorId);

            var model = await _models.AllAsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == product.ModelId);

            var category = await _categories.AllAsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == model.CategoryId);

            var type = await _types.AllAsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == model.TypeId);

            var productModel = new ConfiguredProductViewModel()
            {
                Id = configuredProduct.Id,
                ProductId = product.Id,
                CategoryName = category.Name,
                TypeName = type.Name,
                ProductName = product.Name,
                ModelName = model.Name,
                ColorName = color.Name,
                ProductPrice = configuredProduct.Price,
                SinglePrice = product.Price,
                ImageUrl = product.ImageUrl,
                UserId = configuredProduct.UserId,
                Quantity = configuredProduct.Quantity
            };

            return productModel;
        }
    }
}
