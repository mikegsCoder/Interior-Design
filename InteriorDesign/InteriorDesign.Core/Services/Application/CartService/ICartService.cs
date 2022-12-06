using InteriorDesign.Core.ViewModels.ConfiguredProductViewModels;

namespace InteriorDesign.Core.Services.Application.CartService
{
    public interface ICartService
    {
        Task<IEnumerable<ConfiguredProductViewModel>> GetAllProductsByUserIdAsync(string userId);

        Task<ConfiguredProductViewModel> GetProductByIdAsync(string productId);

        Task EditAsync(ConfiguredProductViewModel model);

        Task DeleteProductByIdAsync(string productId);

        Task<bool> ProductExistsInCartAsync(string productId);
    }
}
