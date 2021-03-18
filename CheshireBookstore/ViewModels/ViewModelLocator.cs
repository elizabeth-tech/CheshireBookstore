using Microsoft.Extensions.DependencyInjection;

namespace CheshireBookstore.ViewModels
{
    class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();
    }
}
