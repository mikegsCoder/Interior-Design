using InteriorDesign.Core.ViewModels.ProductModelViewModels;
using InteriorDesign.Infrastructure.Data.Models.DataBaseModels;
using InteriorDesign.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InteriorDesign.Core.Services.Application.ModelService
{
    public class ModelService : IModelService
    {
        private readonly IDeletableEntityRepository<ProductModel> _models;
        private readonly IDeletableEntityRepository<Product> _products;

        public ModelService(
            IDeletableEntityRepository<ProductModel> models,
            IDeletableEntityRepository<Product> products)
        {
            _models = models;
            _products = products;
        }

        public async Task<IEnumerable<ProductModelInfoViewModel>> GetModelsInfoAsync(string categoryName, string typeName)
        {
            var modelsInfo = new List<ProductModelInfoViewModel>();

            var models = await _models.AllAsNoTracking()
                .Where(m => m.Category.Name == categoryName && m.Type.Name == typeName && m.Products.Any())
                .ToListAsync();

            foreach (var model in models)
            {
                var products = await _products.AllAsNoTracking()
                    .Where(p => p.Model.Name == model.Name)
                    .CountAsync();

                var imageUrl = await _products.All()
                    .Where(p => p.Model.Name == model.Name)
                    .Select(p => p.ImageUrl)
                    .FirstOrDefaultAsync();

                var modelInfo = new ProductModelInfoViewModel
                {
                    Id = model.Id,
                    ModelName = model.Name,
                    CategoryName = categoryName,
                    TypeName = typeName,
                    ProductsCount = products,
                    ImageUrl = imageUrl
                };

                modelsInfo.Add(modelInfo);
            }

            return modelsInfo;
        }
    }
}
