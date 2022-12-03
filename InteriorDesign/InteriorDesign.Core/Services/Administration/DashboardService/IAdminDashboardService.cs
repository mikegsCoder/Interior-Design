using InteriorDesign.Core.ViewModels.AdministrationViewModels.DashboardViewModels;

namespace InteriorDesign.Core.Services.Administration.DashboardService
{
    public interface IAdminDashboardService
    {
        Task<AdminDashboardVeiwModel> GetDashboardInfo();
    }
}
