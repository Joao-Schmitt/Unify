using System;
using System.Linq;
using Unify.Budgets.Domain.Abstractions;

namespace Unify.Budgets.Domain.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        T Get(long id);
        IQueryable<T> Query();
    }
}
