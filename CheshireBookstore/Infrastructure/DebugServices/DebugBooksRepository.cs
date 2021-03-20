using Bookstore.Interfaces;
using Bookstore.Lib.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CheshireBookstore.Infrastructure.DebugServices
{
    class DebugBooksRepository : IRepository<Book>
    {
        public IQueryable<Book> Items { get; }

        public DebugBooksRepository()
        {
            var books = Enumerable.Range(1, 100)
              .Select(i => new Book
              {
                  Id = i,
                  Name = $"Книга {i}"
              })
              .ToArray();

            var categories = Enumerable.Range(1, 10)
               .Select(i => new Category
               {
                   Id = i,
                   Name = $"Категория {i}"
               })
               .ToArray();

            foreach (var book in books)
            {
                var category = categories[book.Id % categories.Length];
                category.Books.Add(book);
                book.Category = category;
            }

            Items = books.AsQueryable();
        }


        public Book Add(Book item) { throw new NotImplementedException(); }
        public Task<Book> AddAsync(Book item, CancellationToken cancel = default) { throw new NotImplementedException(); }

        public Book Get(int id) { throw new NotImplementedException(); }
        public Task<Book> GetAsync(int id, CancellationToken cancel = default) { throw new NotImplementedException(); }

        public void Remove(int id) { throw new NotImplementedException(); }
        public Task RemoveAsync(int id, CancellationToken cancel = default) { throw new NotImplementedException(); }

        public void Update(Book item) { throw new NotImplementedException(); }
        public Task UpdateAsync(Book item, CancellationToken cancel = default) { throw new NotImplementedException(); }
    }
}
