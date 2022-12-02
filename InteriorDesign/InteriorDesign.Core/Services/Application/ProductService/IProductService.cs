using InteriorDesign.Core.ViewModels.ProductViewModels;

namespace InteriorDesign.Core.Services.Application.ProductService
{
    public interface IProductService
    { 
        Task<IEnumerable<ProductInfoViewModel>> GetAllProductsAsync();

        Task<IEnumerable<ProductInfoViewModel>> GetProductsByModelIdAsync(string modelId);
    }
}
