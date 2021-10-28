using EasyOrder.Api.Extensions;
using EasyOrder.Business.Interfaces;
using EasyOrder.Business.Interfaces.INotifications;
using EasyOrder.Business.Interfaces.Repositories;
using EasyOrder.Business.Interfaces.Services;
using EasyOrder.Business.Notifications;
using EasyOrder.Business.Services;
using EasyOrder.Data.Context;
using EasyOrder.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EasyOrder.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<EasyOrderContext>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IExtraRepository, ExtraRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IExtraService, ExtraService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
