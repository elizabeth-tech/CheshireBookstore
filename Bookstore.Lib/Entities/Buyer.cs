using Bookstore.Lib.Entities.Base;

namespace Bookstore.Lib.Entities
{
    public class Buyer : Person
    {
        public override string ToString() => $"Покупатель {Surname} {Name} {Patronymic}";
    }
}
