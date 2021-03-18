using Microsoft.Extensions.Hosting;
using System;

namespace CheshireBookstore
{
    class Program
    {
        // Созданная точка входа приложения (не забыть в свойствах проекта указать точку входа)
        [STAThread]
        public static void Main()
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }

        // Метод, который создает хост приложения
        public static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureServices(App.ConfigureServices);
    }
}
