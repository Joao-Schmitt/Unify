using Unify.Budgets.CrossCutting.Persistence.Context;
using Unify.Budgets.Domain.Interfaces;

namespace Unify.Budgets.CrossCutting.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _ctx;
        public UnitOfWork(AppDbContext ctx) => _ctx = ctx;
        public void Commit() => _ctx.SaveChanges();
    }

}
