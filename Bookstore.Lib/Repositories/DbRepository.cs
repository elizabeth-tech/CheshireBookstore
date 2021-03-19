using Bookstore.Interfaces;
using Bookstore.Lib.Context;
using Bookstore.Lib.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bookstore.Lib.Repositories
{
    internal class DbRepository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly BookstoreDbContext db;
        private readonly DbSet<T> set;

        // если будем добавлять большое кол-во записей, то можно выключить этот флаг и вызвать db.SaveChanges вручную 
        // тогда данные отправятся пакетно, что повышает быстродействие
        public bool AutoSaveChanges { get; set; } = true; 

        public DbRepository(BookstoreDbContext db)
        {
            this.db = db;
            this.set = db.Set<T>();
        }

        public virtual IQueryable<T> items => set; // Можем переопределить в наследниках нюансы чтения\добавления сущностей

        // Добавление в бд
        public T Add(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            db.Entry(item).State = EntityState.Added; // если элемент не пустой, то отмечаем сущность как добавленную
            if (AutoSaveChanges)
                db.SaveChanges();
            return item;
        }

        public async Task<T> AddAsync(T item, CancellationToken cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            db.Entry(item).State = EntityState.Added; // если элемент не пустой, то отмечаем сущность как добавленную
            if (AutoSaveChanges)
                await db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return item;
        }

        // Извлечение одной сущности
        public T Get(int id) => items.SingleOrDefault(item => item.Id == id);

        public async Task<T> GetAsync(int id, CancellationToken cancel = default) => await items
            .SingleOrDefaultAsync(item => item.Id == id, cancel)
            .ConfigureAwait(false);

        // Удаление сущности
        public void Remove(int id)
        {
            db.Remove(new T { Id = id });
            if (AutoSaveChanges)
                db.SaveChanges();
        }

        public async Task RemoveAsync(int id, CancellationToken cancel = default)
        {
            db.Remove(new T { Id = id });
            if (AutoSaveChanges)
                await db.SaveChangesAsync(cancel).ConfigureAwait(false);
        }

        // Обновление сущности
        public void Update(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            db.Entry(item).State = EntityState.Modified; // если элемент не пустой, то отмечаем сущность как добавленную
            if (AutoSaveChanges)
                db.SaveChanges();
        }

        public async Task UpdateAsync(T item, CancellationToken cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            db.Entry(item).State = EntityState.Modified; // если элемент не пустой, то отмечаем сущность как добавленную
            if (AutoSaveChanges)
                await db.SaveChangesAsync(cancel).ConfigureAwait(false);
        }
    }
}
