using Bookstore.Lib.Entities.Base;

namespace Bookstore.Lib.Entities
{
    public class Seller : Person
    {
        public override string ToString() => $"Продавец {Surname} {Name} {Patronymic}";
    }
}
