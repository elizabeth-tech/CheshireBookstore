using CheshireBookstore.Data;
using CheshireBookstore.Services;
using CheshireBookstore.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace CheshireBookstore
{
    public partial class App : Application
    {
        public static bool IsDesignTime { get; private set; } = true;

        private static IHost _host;

        // Запуск хоста при старте приложения (будет создаваться только один хост, благодаря singleton)
        public static IHost Host => _host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        // Возможность доступа к сервисам посредством хоста. Если произойдет раннее обращение, то это все равно приведет к созданию хоста
        public static IServiceProvider Services => Host.Services;

        // Регистрируем все ViewModel и сервисы
        internal static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
            .AddDatabase(host.Configuration.GetSection("Database")) // Регистрируем БД и отправляем Database из конфигурационного файла
            .AddServices()
            .AddViewModels();

        protected override async void OnStartup(StartupEventArgs e)
        {
            IsDesignTime = false;

            var host = Host;

            // Вызываем инициализацию БД (заполнение тестовыми значениями)
            using (var scope = Services.CreateScope())
                await scope.ServiceProvider.GetRequiredService<DbInitializer>().InitializeAsync();

            base.OnStartup(e);
            await host.StartAsync();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using var host = Host;
            base.OnExit(e);
            await host.StopAsync();
        }
    }
}
