using Bookstore.Lib.Context;
using Bookstore.Lib.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CheshireBookstore.Data
{
    class DbInitializer
    {
        private readonly BookstoreDbContext db; // Контекст БД
        private readonly ILogger<DbInitializer> logger; // Логирование в консоли

        public DbInitializer(BookstoreDbContext db, ILogger<DbInitializer> Logger)
        {
            this.db = db;
            logger = Logger;
        }

        // Метод инициализации БД
        public async Task InitializeAsync()
        {
            var timer = Stopwatch.StartNew();
            logger.LogInformation("Инициализация БД...");

            //logger.LogInformation("Удаление существующей БД...");
            //await db.Database.EnsureDeletedAsync().ConfigureAwait(false);
            //logger.LogInformation("Удаление существующей БД выполнено за {0} мс", timer.ElapsedMilliseconds);

            //_db.Database.EnsureCreated();

            logger.LogInformation("Миграция БД...");
            await db.Database.MigrateAsync().ConfigureAwait(false); // Migrate - создает бд, если ее нет и накатывает все миграции
            logger.LogInformation("Миграция БД выполнена за {0} мс", timer.ElapsedMilliseconds);

            if (await db.Books.AnyAsync()) return; // Если есть хоть одна книга, то выходим из инициализатора

            await InitializeCategories();
            await InitializeBooks();
            await InitializeSellers();
            await InitializeBuyers();
            await InitializeDeals();

            logger.LogInformation("Инициализация БД выполнена за {0} с", timer.Elapsed.TotalSeconds);
        }

        private const int categoriesCount = 10;
        private Category[] categories;
        private async Task InitializeCategories()
        {
            var timer = Stopwatch.StartNew();
            logger.LogInformation("Инициализация категорий...");

            categories = new Category[categoriesCount];
            for (var i = 0; i < categoriesCount; i++)
                categories[i] = new Category { Name = $"Категория {i + 1}" };

            await db.Categories.AddRangeAsync(categories); // Добавляем в контекст
            await db.SaveChangesAsync(); // Сохраняем в БД

            logger.LogInformation("Инициализация категорий выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

        private const int booksCount = 10;
        private Book[] books;
        private async Task InitializeBooks()
        {
            var timer = Stopwatch.StartNew();
            logger.LogInformation("Инициализация книг...");

            var rnd = new Random();
            books = Enumerable.Range(1, booksCount)
               .Select(i => new Book
               {
                   Name = $"Книга {i}",
                   Category = rnd.NextItem(categories)
               })
               .ToArray();

            await db.Books.AddRangeAsync(books);
            await db.SaveChangesAsync();

            logger.LogInformation("Инициализация книг выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

        private const int sellersCount = 10;
        private Seller[] sellers;
        private async Task InitializeSellers()
        {
            var timer = Stopwatch.StartNew();
            logger.LogInformation("Инициализация продавцов...");

            sellers = Enumerable.Range(1, sellersCount)
               .Select(i => new Seller
               {
                   Name = $"Продавец-Имя {i}",
                   Surname = $"Продавец-Фамилия {i}",
                   Patronymic = $"Продавец-Отчество {i}"
               })
               .ToArray();

            await db.Sellers.AddRangeAsync(sellers);
            await db.SaveChangesAsync();

            logger.LogInformation("Инициализация продавцов выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

        private const int buyersCount = 10;
        private Buyer[] buyers;
        private async Task InitializeBuyers()
        {
            var timer = Stopwatch.StartNew();
            logger.LogInformation("Инициализация покупателей...");

            buyers = Enumerable.Range(1, buyersCount)
               .Select(i => new Buyer
               {
                   Name = $"Покупатель-Имя {i}",
                   Surname = $"Покупатель-Фамилия {i}",
                   Patronymic = $"Покупатель-Отчество {i}"
               })
               .ToArray();

            await db.Buyers.AddRangeAsync(buyers);
            await db.SaveChangesAsync();

            logger.LogInformation("Инициализация покупателей выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

        private const int dealsCount = 1000;
        private async Task InitializeDeals()
        {
            var timer = Stopwatch.StartNew();
            logger.LogInformation("Инициализация сделок...");

            var rnd = new Random();

            var deals = Enumerable.Range(1, dealsCount)
               .Select(i => new Deal
               {
                   Book = rnd.NextItem(books),
                   Seller = rnd.NextItem(sellers),
                   Buyer = rnd.NextItem(buyers),
                   Price = (decimal)(rnd.NextDouble() * 4000 + 700)
               });

            await db.Deals.AddRangeAsync(deals);
            await db.SaveChangesAsync();

            logger.LogInformation("Инициализация сделок выполнена за {0} мс", timer.ElapsedMilliseconds);
        }
    }
}
