using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bookstore.Interfaces
{
    // Накладываем ограничения. Тип T должен быть классом, разделять интерфейс сущности и должен иметь конструктор по умолчанию без параметров
    public interface IRepository<T> where T : class, IEntity, new()
    {
        IQueryable<T> Items { get; }

        T Get(int id);
        Task<T> GetAsync(int id, CancellationToken cancel = default);

        T Add(T item);
        Task<T> AddAsync(T item, CancellationToken cancel = default);

        void Update(T item);
        Task UpdateAsync(T item, CancellationToken cancel = default);

        void Remove(int id);
        Task RemoveAsync(int id, CancellationToken cancel = default);
    }
}
