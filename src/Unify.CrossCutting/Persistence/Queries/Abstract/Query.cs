using System.Data.Entity.Infrastructure;
using Unify.Application.Interfaces.Queries;
using Unify.CrossCutting.Persistence.Context;

namespace Unify.Application.Queries.Abstract
{
    public class Query : IQuery
    {
        protected readonly AppDbContext _ctx;
        public Query(AppDbContext ctx) => _ctx = ctx;
        public DbRawSqlQuery<T> SqlQuery<T>(string sql) => _ctx.Database.SqlQuery<T>(sql);
    }
}
