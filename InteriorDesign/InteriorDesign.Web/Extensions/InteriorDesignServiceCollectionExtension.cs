using InteriorDesign.Core.Services.Application.AboutUsService;
using InteriorDesign.Core.Services.Application.GalleryService;
using InteriorDesign.Core.Services.Application.OurTeamService;
using InteriorDesign.Infrastructure.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InteriorDesignServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped(typeof(IOurTeamService), typeof(OurTeamService));
            services.AddScoped(typeof(IAboutUsService), typeof(AboutUsService));
            services.AddScoped(typeof(IGalleryService), typeof(GalleryService));

            return services;
        }
    }
}
