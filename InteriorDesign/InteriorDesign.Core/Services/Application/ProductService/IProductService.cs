using InteriorDesign.Core.ViewModels.ProductViewModels;

namespace InteriorDesign.Core.Services.Application.ProductService
{
    public interface IProductService
    { 
        Task<IEnumerable<ProductInfoViewModel>> GetAllProductsAsync();

        Task<IEnumerable<ProductInfoViewModel>> GetProductsByModelIdAsync(string modelId);

        Task<ProductViewModel> GetProductByIdAsync(string productId);

        Task AddToCartAsync(ProductViewModel model);

        Task EditProductAsync(ProductViewModel model);

        Task DeleteProductByIdAsync(string productId);

        Task<AddProductViewModel> GetAddProductViewModelAsync();
    }
}
