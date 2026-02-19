using System;
using System.Collections.Generic;
using System.Linq;
using Unify.Budgets.CrossCutting.Persistence.Context;
using Unify.Budgets.Domain.Entities;
using Unify.Budgets.Domain.Interfaces;

namespace Unify.Budgets.CrossCutting.Persistence.Repositories
{
    public class ServicoRepository : Repository<Servico>, IServicoRepository
    {
        public ServicoRepository(AppDbContext ctx) : base(ctx)
        {

        }

        public IEnumerable<Servico> ObterTodos()
        {
            return this.Query().OrderBy(x => x.Nome).ToList();
        }
    }
}
