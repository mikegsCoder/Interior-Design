using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using InteriorDesign.Infrastructure.Data.Models.DataBaseModels;
using InteriorDesign.Infrastructure.Repositories;
using InteriorDesign.Core.ViewModels.AdministrationViewModels.DashboardViewModels;

namespace InteriorDesign.Core.Services.Administration.DashboardService
{
    public class AdminDashboardService : IAdminDashboardService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDeletableEntityRepository<ProductCategory> _categories;
        private readonly IDeletableEntityRepository<ProductModel> _models;
        private readonly IDeletableEntityRepository<ProductColor> _colors;
        private readonly IDeletableEntityRepository<Product> _products;
        private readonly IDeletableEntityRepository<ConfiguredProduct> _configuredProducts;
        private readonly IDeletableEntityRepository<Order> _orders;
        private readonly IDeletableEntityRepository<Contact> _contacts;
        private readonly IDeletableEntityRepository<DesignImage> _images;
        private readonly IDeletableEntityRepository<TeamMember> _members;
        private readonly IDeletableEntityRepository<Testimonial> _testimonials;
        private readonly IDeletableEntityRepository<ChatMessage> _chatMessages;

        public AdminDashboardService(
            UserManager<ApplicationUser> userManager,
            IDeletableEntityRepository<ProductColor> colors,
            IDeletableEntityRepository<ProductModel> models,
            IDeletableEntityRepository<ProductCategory> categories,
            IDeletableEntityRepository<Product> products,
            IDeletableEntityRepository<ConfiguredProduct> configuredProducts,
            IDeletableEntityRepository<Order> orders,
            IDeletableEntityRepository<Contact> contacts,
            IDeletableEntityRepository<DesignImage> images,
            IDeletableEntityRepository<TeamMember> members,
            IDeletableEntityRepository<Testimonial> testimonials,
            IDeletableEntityRepository<ChatMessage> chatMessages)
        {
            _userManager = userManager;
            _colors = colors;
            _models = models;
            _categories = categories;
            _products = products;
            _configuredProducts = configuredProducts;
            _orders = orders;
            _contacts = contacts;
            _images = images;
            _members = members;
            _testimonials = testimonials;
            _chatMessages = chatMessages;
        }

        public async Task<AdminDashboardVeiwModel> GetDashboardInfo()
        {
            var dashboardInfo = new AdminDashboardVeiwModel();

            try
            {
                // Use this exception to test error handling:
                //throw new Exception();

                var accounts = await _userManager.Users.Where(u => !u.IsDeleted).CountAsync();
                var admins = await _userManager.GetUsersInRoleAsync("Administrator");
                var allEmployees = await _userManager.GetUsersInRoleAsync("Employee");
                var employees = allEmployees.Count - admins.Count;
                var categories = await _categories.AllAsNoTracking().CountAsync();
                var colors = await _colors.AllAsNoTracking().CountAsync();
                var models = await _models.AllAsNoTracking().CountAsync();
                var products = await _products.AllAsNoTracking().CountAsync();
                var configuredProducts = await _configuredProducts.AllAsNoTracking().CountAsync();
                var orders = await _orders.AllAsNoTracking().Where(o => !o.IsShipped).CountAsync();
                var ordersValue = await _orders.AllAsNoTracking().Where(o => !o.IsShipped).SumAsync(o => o.Price);
                var newContacts = await _contacts.AllAsNoTracking().Where(c => !c.IsAnswered).CountAsync();
                var activeImages = await _images.AllAsNoTracking().Where(i => i.IsActive).CountAsync();
                var members = await _members.AllAsNoTracking().CountAsync();
                var testimonials = await _testimonials.AllAsNoTracking().Where(t => t.IsActive).CountAsync();
                var chatMessagesCount = await _chatMessages.AllAsNoTracking().CountAsync();

                dashboardInfo = new AdminDashboardVeiwModel
                {
                    Created = true,
                    AccountsCount = accounts,
                    AdministratorsCount = admins.Count,
                    EmployeesCount = employees,
                    CategoriesCount = categories,
                    ModelsCount = models,
                    ColorsCount = colors,
                    ProductsCount = products,
                    ConfiguredProductsCount = configuredProducts,
                    OrdersCount = orders,
                    OrdersValue = ordersValue,
                    NewContactsCount = newContacts,
                    ActiveGalleryImagesCount = activeImages,
                    TeamMembersCount = members,
                    TestimonialsCount = testimonials,
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
