using System;
using System.Collections.Generic;
using System.Linq;
using Unify.CrossCutting.Persistence.Context;
using Unify.Domain.Entities;
using Unify.Domain.Interfaces;

namespace Unify.CrossCutting.Persistence.Repositories
{
    public class UnidadeRepository : Repository<Unidade>, IUnidadeRepository
    {
        public UnidadeRepository(AppDbContext ctx) : base(ctx)
        {

        }

        public IEnumerable<Unidade> ObterTodos()
        {
            return this.Query().OrderBy(x => x.Sigla).ToList();
        }

        public bool ExisteComMesmaSigla(string sigla, long? ignorarId = null)
        {
            return this.Query().Any(p => p.Sigla == sigla && (!ignorarId.HasValue || p.Id != ignorarId));
        }

    }
}
