using Cloud.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Cloud.Shared.Infrastructure
{
    public abstract class InMemoryRepository<T> : IRepository<T> where T : IEntity
    {
        protected static ICollection<T> inMemoryEntities = new List<T>();

        public InMemoryRepository()
        {
            this.Seed(inMemoryEntities);
        }

        protected abstract void Seed(ICollection<T> inMemoryEntities);

        public virtual void Add(T entity)
        {
            inMemoryEntities.Add(entity);
        }

        public virtual T First(Func<T, bool> expression = null)
        {
            return expression != null ? inMemoryEntities.FirstOrDefault(expression) : inMemoryEntities.FirstOrDefault();
        }

        public virtual T Get(long id)
        {
            return inMemoryEntities.FirstOrDefault(entity => entity.Id == id);
        }

        public virtual IEnumerable<T> Get(Func<T, bool> expression = null)
        {
            return expression != null ? inMemoryEntities.Where(expression) : inMemoryEntities;
        }

        public virtual void Update(T entity) { }

        public virtual void Remove(T entity)
        {
            inMemoryEntities.Remove(entity);
        }
    }
}
