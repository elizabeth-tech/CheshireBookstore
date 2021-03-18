using Microsoft.Extensions.DependencyInjection;

namespace CheshireBookstore.ViewModels
{
    static class ViewModelsRegistrator
    {
        // Метод регистрации любых ViewModel
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
            ;
    }
}
