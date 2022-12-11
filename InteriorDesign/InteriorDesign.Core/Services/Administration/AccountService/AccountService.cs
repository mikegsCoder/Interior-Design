using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using InteriorDesign.Core.ViewModels.AdministrationViewModels.AccountViewModels;
using InteriorDesign.Infrastructure.Data.Models.DataBaseModels;
using InteriorDesign.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace InteriorDesign.Core.Services.Administration.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly PasswordHasher<ApplicationUser> _hasher;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDeletableEntityRepository<Order> _orders;
        private readonly IDeletableEntityRepository<ConfiguredProduct> _configuredProducts;
        private readonly ILogger _logger;

        public AccountService(
            UserManager<ApplicationUser> userManager,
            IDeletableEntityRepository<Order> orders,
            IDeletableEntityRepository<ConfiguredProduct> configuredProducts,
            ILogger<AccountService> logger)
        {
            _userManager = userManager;
            _orders = orders;
            _configuredProducts = configuredProducts;
            _hasher = new PasswordHasher<ApplicationUser>();
            _logger = logger;
        }

        public async Task<IndexUsersViewModel> GetAccountsInfoAsync()
        {
            var users = new List<UsersViewModel>();

            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test Exception");

                var admins = await _userManager.GetUsersInRoleAsync("Administrator");
                var employees = await _userManager.GetUsersInRoleAsync("Employee");

                users = await _userManager.Users
                    .Where(u => u.Email != "admin@mail.com" && !u.IsDeleted)
                    .Select(u => new UsersViewModel
                    {
                        Id = u.Id,
                        Email = u.Email,
                        IsAdmin = admins.Contains(u),
                        IsEmployee = employees.Contains(u),
                        IsEmailConfirmed = u.EmailConfirmed,
                    })
                    .OrderBy(u => u.IsAdmin == false)
                    .ThenBy(u => u.IsEmailConfirmed == false)
                    .ThenBy(u => u.Email)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(nameof(AccountService), " - ", nameof(GetAccountsInfoAsync), ": ", ex.Message), ex);

                return new IndexUsersViewModel()
                {
                    Created = false,
                    Users = new List<UsersViewModel>(),
                };
            }

            return new IndexUsersViewModel()
            {
                Created = true,
                Message = null,
                Users = users,
            };
        }

        public async Task<bool> MakeUserAdministratorAsync(string id)
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test Exception");

                var user = await _userManager.Users
                    .FirstOrDefaultAsync(u => u.Id == id);


                var result = await _userManager.AddToRoleAsync(user, "Administrator");

                return result.Succeeded;
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(nameof(AccountService), " - ", nameof(MakeUserAdministratorAsync), ": ", ex.Message), ex);

                return false;
            }
        }

        public async Task<bool> MakeUserEmployeeAsync(string id)
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test Exception");

                var user = await _userManager.Users
                    .FirstOrDefaultAsync(u => u.Id == id);

                var result = await _userManager.AddToRoleAsync(user, "Employee");

                return result.Succeeded;
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(nameof(AccountService), " - ", nameof(MakeUserEmployeeAsync), ": ", ex.Message), ex);

                return false;
            }
        }

        public async Task<bool> RemoveUserAdministratorRoleAsync(string id)
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test Exception");

                var user = await _userManager.Users
                    .FirstOrDefaultAsync(u => u.Id == id);

                var result = await _userManager.RemoveFromRoleAsync(user, "Administrator");

                return result.Succeeded;
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(nameof(AccountService), " - ", nameof(RemoveUserAdministratorRoleAsync), ": ", ex.Message), ex);

                return false;
            }
        }

        public async Task<bool> RemoveUserEmployeeRoleAsync(string id)
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test Exception");

                var user = await _userManager.Users
                    .FirstOrDefaultAsync(u => u.Id == id);

                var result = await _userManager.RemoveFromRoleAsync(user, "Employee");

                return result.Succeeded;
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(nameof(AccountService), " - ", nameof(RemoveUserEmployeeRoleAsync), ": ", ex.Message), ex);

                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test Exception");

                var user = await _userManager.Users
                    .Include(u => u.Orders)
                    .ThenInclude(o => o.ConfiguredProducts)
                    .FirstOrDefaultAsync(u => u.Id == id);

                foreach (var order in user.Orders)
                {
                    foreach (var product in order.ConfiguredProducts)
                    {
                        if (product.IsDeleted == false)
                        {
                            _configuredProducts.Delete(product);
                        }
                    }

                    if (order.IsDeleted == false)
                    {
                        _orders.Delete(order);
                    }
                }

                bool isAdmin = await _userManager.IsInRoleAsync(user, "Administrator");
                bool isEmployee = await _userManager.IsInRoleAsync(user, "Employee");

                if (isAdmin)
                {
                    await _userManager.RemoveFromRoleAsync(user, "Administrator");
                }

                if (isEmployee)
                {
                    await _userManager.RemoveFromRoleAsync(user, "Employee");
                }

                user.IsDeleted = true;
                user.DeletedOn = DateTime.UtcNow;
                user.EmailConfirmed = false;
                user.PasswordHash = _hasher.HashPassword(null, DateTime.UtcNow.ToString());

                await _configuredProducts.SaveChangesAsync();
                await _orders.SaveChangesAsync();
                var result = await _userManager.UpdateAsync(user);

                return result.Succeeded;
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(nameof(AccountService), " - ", nameof(DeleteUserAsync), ": ", ex.Message), ex);

                return false;
            }
        }

        public async Task<bool> ConfirmUserEmailAsync(string id)
        {
            try
            {
                // Use this exception to test error handling:
                //throw new Exception("Test Exception");

                var user = await _userManager.Users
                    .FirstOrDefaultAsync(u => u.Id == id);

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                var result = await _userManager.ConfirmEmailAsync(user, token);

                return result.Succeeded;
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Concat(nameof(AccountService), " - ", nameof(ConfirmUserEmailAsync), ": ", ex.Message), ex);

                return false;
            }
        }
    }
}
