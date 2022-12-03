using Microsoft.EntityFrameworkCore;
using InteriorDesign.Infrastructure.Data.Models.DataBaseModels;
using InteriorDesign.Infrastructure.Repositories;
using InteriorDesign.Core.ViewModels.EmployeeViewModels.DashboardViewModels;

namespace InteriorDesign.Core.Services.Employee.DashboardService
{
    public class EmployeeDashboardService : IEmployeeDashboardService
    {
        private readonly IDeletableEntityRepository<ConfiguredProduct> _configuredProducts;
        private readonly IDeletableEntityRepository<Order> _orders;
        private readonly IDeletableEntityRepository<Contact> _contacts;
        private readonly IDeletableEntityRepository<ChatMessage> _chatMessages;

        public EmployeeDashboardService(
            IDeletableEntityRepository<ConfiguredProduct> configuredProducts,
            IDeletableEntityRepository<Order> orders,
            IDeletableEntityRepository<Contact> contacts,
            IDeletableEntityRepository<ChatMessage> chatMessages)
        {
            _configuredProducts = configuredProducts;
            _orders = orders;
            _contacts = contacts;
            _chatMessages = chatMessages;
        }

        public async Task<EmployeeDashboardVeiwModel> GetDashboardInfo()
        {
            var dashboardInfo = new EmployeeDashboardVeiwModel();

            try
            {
                // Use this exception to test error handling:
                //throw new Exception();

                var configuredProducts = await _configuredProducts.AllAsNoTracking().CountAsync();
                var orders = await _orders.AllAsNoTracking().Where(o => !o.IsShipped).CountAsync();
                var ordersValue = await _orders.AllAsNoTracking().Where(o => !o.IsShipped).SumAsync(o => o.Price);
                var newContacts = await _contacts.AllAsNoTracking().Where(c => !c.IsAnswered).CountAsync();
                var chatMessagesCount = await _chatMessages.AllAsNoTracking().CountAsync();

                dashboardInfo = new EmployeeDashboardVeiwModel
                {
                    Created = true,
                    ConfiguredProductsCount = configuredProducts,
                    OrdersCount = orders,
                    OrdersValue = ordersValue,
                    NewContactsCount = newContacts,
                    MessagesCount = chatMessagesCount
                };
            }
            catch (Exception)
            {
                dashboardInfo.Created = false;
            }

            return dashboardInfo;
        }
    }
}
