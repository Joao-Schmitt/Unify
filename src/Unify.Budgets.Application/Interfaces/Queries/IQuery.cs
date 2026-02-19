using System.Data.Entity.Infrastructure;

namespace Unify.Budgets.Application.Interfaces.Queries
{
    public interface IQuery
    {
        DbRawSqlQuery<T> SqlQuery<T>(string sql);
    }
}
