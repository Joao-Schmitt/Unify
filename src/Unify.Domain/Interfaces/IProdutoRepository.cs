using System;
using System.Collections.Generic;
using Unify.Domain.Entities;

namespace Unify.Domain.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IEnumerable<Produto> ObterTodos();
        bool ExisteComMesmoNome(string nome, long? ignorarId = null);
    }
}
