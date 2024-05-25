using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using NuGet.Protocol;
using RestaurantApp.Core.Contracts;
using RestaurantApp.Core.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RestaurantServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITownService, TownService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IGalleryService, GalleryService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<IChatService, ChatService>();

            var googleCredentialsPath = @"C:\Users\furka\Downloads\trusty-banner-424421-j4-3ba83bec3820.json";
            var credentials = GoogleCredential.FromFile(googleCredentialsPath);
            services.AddSingleton(s => StorageClient.Create(credentials));

            return services;
        }
    }
}
