using System.Collections.Generic;
using Unify.Domain.Entities;

namespace Unify.Domain.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        IEnumerable<Cliente> ObterTodos();
    }
}
