using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Common.Infrastructure.Infrastructure
{
    public abstract class InMemoryRepository<T> : IRepository<T> where T : IEntity
    {
        protected ICollection<T> inMemoryEntities = new List<T>();

        public InMemoryRepository()
        {
            this.InitMemoryEntities(this.inMemoryEntities);
        }

        protected abstract void InitMemoryEntities(ICollection<T> inMemoryEntities);

        public void Add(T entity)
        {
            this.inMemoryEntities.Add(entity);
        }

        public T Get(long id)
        {
            return this.inMemoryEntities.First(entity => entity.Id == id);
        }

        public IEnumerable<T> Get(Func<T, bool> expression = null)
        {
            return expression != null ? this.inMemoryEntities.Where(expression) : this.inMemoryEntities;
        }

        public void Remove(T entity)
        {
            this.inMemoryEntities.Remove(entity);
        }
    }
}
