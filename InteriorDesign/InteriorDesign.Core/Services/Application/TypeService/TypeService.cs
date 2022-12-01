using InteriorDesign.Core.ViewModels.CategoryTypeViewModels;
using InteriorDesign.Core.ViewModels.TypeViewModels;
using InteriorDesign.Infrastructure.Data.Models.DataBaseModels;
using InteriorDesign.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InteriorDesign.Core.Services.Application.TypeService
{
    public class TypeService : ITypeService
    {
        private readonly IDeletableEntityRepository<ProductCategory> _categories;
        private readonly IDeletableEntityRepository<ProductType> _types;
        private readonly IDeletableEntityRepository<ProductModel> _models;
        private readonly IDeletableEntityRepository<Product> _products;

        public TypeService(IDeletableEntityRepository<ProductCategory> categories,
            IDeletableEntityRepository<ProductType> types,
            IDeletableEntityRepository<ProductModel> models,
            IDeletableEntityRepository<Product> products)
        {
            _categories = categories;
            _types = types;
            _models = models;
            _products = products;
        }

        public async Task<IEnumerable<TypeViewModel>> GetTypesInfoAsync()
        {
            var typesInfo = new List<TypeViewModel>();

            var types = await _types.AllAsNoTracking()
                .Select(t => t.Name)
                .ToListAsync();

            foreach (var type in types)
            {
                var categories = await _categories.AllAsNoTracking()
                    .Where(c => c.ProductTypes.Any(x => x.Name == type) && !c.IsDeleted)
                    .CountAsync();

                var models = await _models.AllAsNoTracking()
                    .Where(m => m.Type.Name == type)
                    .ToListAsync();

                var products = await _products.AllAsNoTracking()
                    .Where(p => models.Contains(p.Model))
                    .CountAsync();

                var firstProduct = await _products.AllAsNoTracking()
                    .FirstOrDefaultAsync(p => models.Contains(p.Model));

                typesInfo.Add(new TypeViewModel
                {
                    Name = type,
                    ProductCategoriesCount = categories,
                    ProductModelsCount = models.Count(),
                    ProductsCount = products,
                    ImageUrl = firstProduct.ImageUrl
                });
            }

            return typesInfo;
        }

        public async Task<IEnumerable<CategoryTypeViewModel>> GetCategoriesByTypeInfoAsync(string typeName)
        {
            var categoryTypesInfo = new List<CategoryTypeViewModel>();

            var type = await _types.AllAsNoTracking()
                .FirstOrDefaultAsync(t => t.Name == typeName);

            var categories = await _categories.AllAsNoTracking()
                .Where(c => c.ProductTypes.Contains(type))
                .ToListAsync();

            foreach (var category in categories)
            {
                var models = await _models.AllAsNoTracking()
                   .Where(m => m.Category.Name == category.Name && m.Type == type)
                   .ToListAsync();

                var products = await _products.AllAsNoTracking()
                    .Where(p => models.Contains(p.Model))
                    .CountAsync();

                var firstProduct = await _products.AllAsNoTracking()
                    .FirstOrDefaultAsync(p => models.Contains(p.Model));

                categoryTypesInfo.Add(new CategoryTypeViewModel
                {
                    CategoryName = category.Name,
                    TypeName = type.Name,
                    ProductModelsCount = models.Count(),
                    ProductsCount = products,
                    CategoryImageUrl = category.ImageUrl,
                    TypeImageUrl = firstProduct.ImageUrl
                });
            }

            return categoryTypesInfo;
        }
    }
}
