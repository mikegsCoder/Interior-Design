﻿using InteriorDesign.Core.Services.Application.AboutUsService;
using InteriorDesign.Core.Services.Application.CategoryService;
using InteriorDesign.Core.Services.Application.GalleryService;
using InteriorDesign.Core.Services.Application.OurTeamService;
using InteriorDesign.Core.Services.Application.TypeService;
using InteriorDesign.Core.Services.Application.UserContactService;
using InteriorDesign.Infrastructure.Data.Models.DataBaseModels;
using InteriorDesign.Infrastructure.Repositories;
using InteriorDesign.Web.Services;

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

            services.AddScoped(typeof(IOurTeamService), typeof(OurTeamService));
            services.AddScoped(typeof(IAboutUsService), typeof(AboutUsService));
            services.AddScoped(typeof(IGalleryService), typeof(GalleryService));
            services.AddScoped(typeof(IUserContactService), typeof(UserContactService));
            services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
            services.AddScoped(typeof(ITypeService), typeof(TypeService));

            return services;
        }
    }
}
