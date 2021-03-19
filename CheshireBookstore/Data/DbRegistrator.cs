using Bookstore.Lib.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CheshireBookstore.Data
{
    internal static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) => services
            .AddDbContext<BookstoreDbContext>(opt =>
            {
                var type = configuration["Type"]; // Получаем из файла конфигурации тип БД
                switch (type)
                {
                    case null: throw new InvalidOperationException("Не определен тип БД");

                    default: throw new InvalidOperationException($"Тип подключения {type} не поддерживается");

                    case "MSQL":
                        opt.UseSqlServer(configuration.GetConnectionString(type));
                        break;

                    case "SQLite":
                        opt.UseSqlite(configuration.GetConnectionString(type));
                        break;

                    case "InMemory":
                        opt.UseInMemoryDatabase("Bookstore.db");
                        break;
                }
            })
            //.AddTransient<DbInitializer>()
            //.AddRepositoriesInDB()
            ;
    }
}
