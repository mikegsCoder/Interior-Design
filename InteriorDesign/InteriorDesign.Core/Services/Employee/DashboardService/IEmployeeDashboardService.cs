
using InteriorDesign.Core.ViewModels.EmployeeViewModels.DashboardViewModels;

namespace InteriorDesign.Core.Services.Employee.DashboardService
{
    public interface IEmployeeDashboardService
    {
        Task<EmployeeDashboardVeiwModel> GetDashboardInfo();
    }
}
