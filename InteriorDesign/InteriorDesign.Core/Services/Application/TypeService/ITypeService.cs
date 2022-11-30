using InteriorDesign.Core.ViewModels.CategoryTypeViewModels;
using InteriorDesign.Core.ViewModels.TypeViewModels;

namespace InteriorDesign.Core.Services.Application.TypeService
{
    public interface ITypeService
    {
        Task<IEnumerable<TypeViewModel>> GetTypesInfoAsync();
    }
}
