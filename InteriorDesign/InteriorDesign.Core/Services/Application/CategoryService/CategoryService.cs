using InteriorDesign.Core.ViewModels.CategoryViewModels;
using InteriorDesign.Infrastructure.Data.Models.DataBaseModels;
using InteriorDesign.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InteriorDesign.Core.Services.Application.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<ProductCategory> _categories;
        private readonly IDeletableEntityRepository<ProductType> _types;
        private readonly IDeletableEntityRepository<ProductModel> _models;
        private readonly IDeletableEntityRepository<Product> _products;

        public CategoryService(
            IDeletableEntityRepository<ProductCategory> categories, 
            IDeletableEntityRepository<ProductType> types, 
            IDeletableEntityRepository<ProductModel> models,
            IDeletableEntityRepository<Product> products)
        {
            _categories = categories;
            _types = types;
            _models = models;
            _products = products;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategoriesInfoAsync()
        {
            var categoriesInfo = new List<CategoryViewModel>();

            var categories = await _categories.AllAsNoTracking()
                .ToListAsync();

            foreach (var category in categories)
            {
                var types = await _types.AllAsNoTracking()
                    .Where(t => t.ProductCategories.Any(x => x.Name == category.Name))
                    .CountAsync();

                var models = await _models.AllAsNoTracking()
                    .Where(m => m.Category.Name == category.Name)
                    .ToListAsync();

                var products = await _products.AllAsNoTracking()
                    .Where(p => models.Contains(p.Model))
                    .CountAsync();

                categoriesInfo.Add(new CategoryViewModel
                {
                    Name = category.Name,
                    ProductTypesCount = types,
                    ProductModelsCount = models.Count(),
                    ProductsCount = products,
                    ImageUrl = category.ImageUrl
                });
            }

            return categoriesInfo;
        }
    }
}
