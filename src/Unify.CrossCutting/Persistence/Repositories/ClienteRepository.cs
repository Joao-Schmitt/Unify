using System;
using System.Collections.Generic;
using System.Linq;
using Unify.CrossCutting.Persistence.Context;
using Unify.Domain.Entities;
using Unify.Domain.Interfaces;

namespace Unify.CrossCutting.Persistence.Repositories
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
