using System;
using System.Collections.Generic;
using System.Linq;
using Unify.Budgets.CrossCutting.Persistence.Context;
using Unify.Budgets.Domain.Entities;
using Unify.Budgets.Domain.Interfaces;

namespace Unify.Budgets.CrossCutting.Persistence.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext ctx) : base(ctx)
        {

        }

        public bool ExisteComMesmoNome(string nome, long? ignorarId = null)
        {
            return this.Query().Any(p => p.Nome == nome && (!ignorarId.HasValue || p.Id != ignorarId));
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return this.Query().OrderBy(x => x.Nome).ToList();
        }
    }
}
