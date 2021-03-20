using Bookstore.Lib.Context;
using Bookstore.Lib.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Bookstore.Lib.Repositories
{
    class BooksRepository : DbRepository<Book>
    {
        public BooksRepository(BookstoreDbContext db) : base(db) { }

        // Переопределяем свойство items. Т.е. при загрузке книг, мы еще хотим включать информацию о категориях
        public override IQueryable<Book> Items => base.Items.Include(item => item.Category);
    }
}