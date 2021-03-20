using Bookstore.Lib.Entities.Base;
using System.Collections.Generic;

namespace Bookstore.Lib.Entities
{
    public class Category : NamedEntity
    {
        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();

        public override string ToString() => $"Категория {Name}";
    }
}
