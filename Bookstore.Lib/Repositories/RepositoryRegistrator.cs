using Bookstore.Interfaces;
using Bookstore.Lib.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Lib.Repositories
{
    public static class RepositoryRegistrator
    {
        // Регистрация репозиториев
        public static IServiceCollection AddRepositoriesInDB(this IServiceCollection services) => services
            .AddTransient<IRepository<Book>, BooksRepository>()
            .AddTransient<IRepository<Category>, DbRepository<Category>>()
            .AddTransient<IRepository<Seller>, DbRepository<Seller>>()
            .AddTransient<IRepository<Buyer>, DbRepository<Buyer>>()
            .AddTransient<IRepository<Deal>, DbRepository<Deal>>()
            ;
    }
}
