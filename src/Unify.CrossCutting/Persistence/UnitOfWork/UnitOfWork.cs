using Unify.CrossCutting.Persistence.Context;
using Unify.Domain.Interfaces;

namespace Unify.CrossCutting.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _ctx;
        public UnitOfWork(AppDbContext ctx) => _ctx = ctx;
        public void Commit() => _ctx.SaveChanges();
    }

}
