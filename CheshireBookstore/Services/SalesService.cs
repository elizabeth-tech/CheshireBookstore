using Bookstore.Interfaces;
using Bookstore.Lib.Entities;
using CheshireBookstore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheshireBookstore.Services
{
    class SalesService : ISalesService
    {
        private readonly IRepository<Book> books;
        private readonly IRepository<Deal> deals;

        public IEnumerable<Deal> Deals => deals.Items; // Свойство, которое отображает все продажи

        // Сервис знает о сущностях книг и сделок
        public SalesService(IRepository<Book> books, IRepository<Deal> deals)
        {
            this.books = books;
            this.deals = deals;
        }

        public async Task<Deal> MakeDeal(string bookName, Seller seller, Buyer buyer, decimal price)
        {
            var book = await books.Items.FirstOrDefaultAsync(b => b.Name == bookName).ConfigureAwait(false);
            if (book is null) return null; // Если книги нет, то сделку выполнить нельзя

            // Создаем сделку, заполняем свойства
            var deal = new Deal
            {
                Book = book,
                Seller = seller,
                Buyer = buyer,
                Price = price
            };

            return await deals.AddAsync(deal); // Добавляем в репозиторий
        }
    }
}
