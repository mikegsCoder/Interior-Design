using InteriorDesign.Core.ViewModels;
using InteriorDesign.Core.ViewModels.AdministrationViewModels.AccountViewModels;
using InteriorDesign.Core.ViewModels.AdministrationViewModels.DashboardViewModels;

namespace InteriorDesign.Tests.ViewModelTests
{
    public class ViewModelsTests
    {
        [Fact]
        public void IndexUsersViewModelWorksProperly()
        {
            var usersViewModels = new List<UsersViewModel>();

            for (int i = 0; i < 10; i++)
            {
                usersViewModels.Add(new UsersViewModel()
                {
                    Id = i.ToString(),
                    Email = i.ToString(),
                    IsAdmin = false,
                    IsEmployee = false,
                    IsEmailConfirmed = true
                });
            }

            var indexVm = new IndexUsersViewModel()
            {
                Message = "test",
                Users = usersViewModels,
                Created = true
            };

            Assert.IsType<IndexUsersViewModel>(indexVm);
            Assert.Equal(usersViewModels.Count, indexVm.Users.Count);
            Assert.Equal("test", indexVm.Message);
            Assert.True(indexVm.Created);
            usersViewModels.Should().BeEquivalentTo(indexVm.Users);
            usersViewModels[0].Should().BeEquivalentTo(indexVm.Users[0]);
        }

        [Fact]
        public void AdminDashboardVeiwModelWorksProperly()
        {

            var model = new AdminDashboardVeiwModel()
            {
                Created = true,
                AccountsCount = 3,
                AdministratorsCount = 1,
                EmployeesCount = 1,
                CategoriesCount = 5,
                ModelsCount = 20,
                ColorsCount = 10,
                ProductsCount = 120,
                ConfiguredProductsCount = 2,
                OrdersCount = 1,
                OrdersValue = 340,
                TeamMembersCount = 4,
                ActiveGalleryImagesCount = 6,
                NewContactsCount = 1,
                MessagesCount = 2,
                TestimonialsCount = 8
            };

            Assert.IsType<AdminDashboardVeiwModel>(model);
            Assert.True(model.Created);
            Assert.Equal(3, model.AccountsCount);
            Assert.Equal(1, model.AdministratorsCount);
            Assert.Equal(1, model.EmployeesCount);
            Assert.Equal(5, model.CategoriesCount);
            Assert.Equal(20, model.ModelsCount);
            Assert.Equal(10, model.ColorsCount);
            Assert.Equal(120, model.ProductsCount);
            Assert.Equal(2, model.ConfiguredProductsCount);
            Assert.Equal(1, model.OrdersCount);
            Assert.Equal(340, model.OrdersValue);
            Assert.Equal(4, model.TeamMembersCount);
            Assert.Equal(6, model.ActiveGalleryImagesCount);
            Assert.Equal(1, model.NewContactsCount);
            Assert.Equal(2, model.MessagesCount);
            Assert.Equal(8, model.TestimonialsCount);
        }

        [Fact]
        public void ErrorViewModelWorksProperly()
        {

            var model = new ErrorViewModel()
            {
                RequestId = "test"
            };

            Assert.IsType<ErrorViewModel>(model);
            Assert.Equal("test", model.RequestId);
            Assert.True(model.ShowRequestId);
        }
    }
}
