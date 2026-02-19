using System;
using System.Collections.Generic;
using System.Linq;
using Unify.Budgets.CrossCutting.Persistence.Context;
using Unify.Budgets.Domain.Entities;
using Unify.Budgets.Domain.Interfaces;

namespace Unify.Budgets.CrossCutting.Persistence.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext ctx) : base(ctx)
        {

        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return this.Query().OrderBy(x => x.Nome).ToList();
        }
    }
}
