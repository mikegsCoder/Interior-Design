using InteriorDesign.Core.ViewModels.CategoryViewModels;

namespace InteriorDesign.Core.Services.Application.CategoryService
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetCategoriesInfoAsync();
    }
}
