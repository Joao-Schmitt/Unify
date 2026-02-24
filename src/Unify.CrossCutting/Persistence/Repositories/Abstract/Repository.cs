using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unify.CrossCutting.Persistence.Context;
using Unify.Domain.Abstractions;
using Unify.Domain.Interfaces;

namespace Unify.CrossCutting.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly AppDbContext _ctx;

        public Repository(AppDbContext ctx) => _ctx = ctx;

        public void Add(T e) => _ctx.Set<T>().Add(e);
        public void Update(T e) => _ctx.Entry(e).State = EntityState.Modified;
        public void Remove(T e) => _ctx.Set<T>().Remove(e);
        public T Get(long id) => _ctx.Set<T>().Find(id);
        public IQueryable<T> Query() => _ctx.Set<T>();
    }

}
