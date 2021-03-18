using Bookstore.Lib.Entities.Base;

namespace Bookstore.Lib.Entities
{
    public class Book : NamedEntity
    {
        public virtual Category Category { get; set; } // У одной книги только одна категория

        public override string ToString() => $"Книга {Name}";
    }
}
