using InteriorDesign.Core.Services.Application.AboutUsService;
using InteriorDesign.Core.Services.Application.CartService;
using InteriorDesign.Core.Services.Application.CategoryService;
using InteriorDesign.Core.Services.Application.GalleryService;
using InteriorDesign.Core.Services.Application.ModelService;
using InteriorDesign.Core.Services.Application.OurTeamService;
using InteriorDesign.Core.Services.Application.ProductService;
using InteriorDesign.Core.Services.Application.TypeService;
using InteriorDesign.Core.Services.Application.UserContactService;
using InteriorDesign.Core.Services.Application.UserOrderService;
using InteriorDesign.Core.Services.Common.EmailSendService;
using InteriorDesign.Infrastructure.Data.Models.DataBaseModels;
using InteriorDesign.Infrastructure.Repositories;
using InteriorDesign.Web.Services;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InteriorDesignServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient(typeof(CustomEmailConfirmationTokenProvider<ApplicationUser>));

            services.AddScoped(typeof(IEmailSender), typeof(EmailSender));
            services.AddScoped(typeof(IOurTeamService), typeof(OurTeamService));
            services.AddScoped(typeof(IAboutUsService), typeof(AboutUsService));
            services.AddScoped(typeof(IGalleryService), typeof(GalleryService));
            services.AddScoped(typeof(IUserContactService), typeof(UserContactService));
            services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
            services.AddScoped(typeof(IModelService), typeof(ModelService));
            services.AddScoped(typeof(ITypeService), typeof(TypeService));
            services.AddScoped(typeof(IProductService), typeof(ProductService));
            services.AddScoped(typeof(ICartService), typeof(CartService));
            services.AddScoped(typeof(IUserOrderService), typeof(UserOrderService));

            // common services used by Administrator and Employee roles:
            services.AddScoped(typeof(IAppEmailSender), typeof(AppEmailSender));

            return services;
        }
    }
}
