using Bookstore.Lib.Context;
using Bookstore.Lib.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Bookstore.Lib.Repositories
{
    class DealsRepository : DbRepository<Deal>
    {
        public DealsRepository(BookstoreDbContext db) : base(db) { }
        
        // Переопределяем свойство items. Т.е. при загрузке сделок, мы еще хотим включать информацию о книгах, продавцах и покупателях
        public override IQueryable<Deal> items => base.items
            .Include(item => item.Book)
            .Include(item => item.Seller)
            .Include(item => item.Buyer)
            ;
    }
}