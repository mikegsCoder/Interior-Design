using InteriorDesign.Core.ViewModels.ProductModelViewModels;

namespace InteriorDesign.Core.Services.Application.ModelService
{
    public interface IModelService
    {
        Task<IEnumerable<ProductModelInfoViewModel>> GetModelsInfoAsync(string categoryName, string typeName);
    }
}
