using Bookstore.Lib.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Lib.Context
{
    class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base(options) { }

        // Свойства, которые хранят наборы объектов DbSet<T>. Через них осуществляется связь  с таблицами в бд

        public DbSet<Deal> Deals { get; set; } // можно было бы указать одно свойство, т.к EF сам поймет, что нужно создать связанные с Deal сущности

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Buyer> Buyers { get; set; }

        public DbSet<Seller> Sellers { get; set; }
    }
}
