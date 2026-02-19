using System.Data.Entity.Infrastructure;
using Unify.Budgets.Application.Interfaces.Queries;
using Unify.Budgets.CrossCutting.Persistence.Context;

namespace Unify.Budgets.Application.Queries.Abstract
{
    public class Query : IQuery
    {
        protected readonly AppDbContext _ctx;
        public Query(AppDbContext ctx) => _ctx = ctx;
        public DbRawSqlQuery<T> SqlQuery<T>(string sql) => _ctx.Database.SqlQuery<T>(sql);
    }
}
