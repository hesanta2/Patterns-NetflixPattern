using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Common.Infrastructure.Infrastructure
{
    public interface IRepository<T> where T : IEntity
    {
        T Get(long id);

        IEnumerable<T> Get(Func<T, bool> expression = null);

        void Add(T entity);

        void Remove(T entity);
    }
}