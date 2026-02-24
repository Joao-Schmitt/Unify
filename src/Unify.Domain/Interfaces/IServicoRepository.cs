using System.Collections.Generic;
using Unify.Domain.Entities;

namespace Unify.Domain.Interfaces
{
    public interface IServicoRepository : IRepository<Servico>
    {
        IEnumerable<Servico> ObterTodos();
    }
}
