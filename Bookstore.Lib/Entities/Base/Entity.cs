using Bookstore.Interfaces;

namespace Bookstore.Lib.Entities.Base
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
