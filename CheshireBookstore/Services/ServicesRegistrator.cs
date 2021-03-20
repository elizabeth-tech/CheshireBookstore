using CheshireBookstore.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CheshireBookstore.Services
{
    static class ServicesRegistrator
    {
        // Метод регистрации любых сервисов
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddTransient<ISalesService, SalesService>()
            .AddTransient<IUserDialog, UserDialogService>()
            ;
    }
}
