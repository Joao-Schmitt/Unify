using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unify.Application.DTOs;
using Unify.CrossCutting.Persistence.Context;
using Unify.Domain.Entities;
using Unify.Domain.Interfaces;

namespace Unify.CrossCutting.Persistence.Repositories
{
    public class OrcamentoRepository : Repository<Orcamento>, IOrcamentoRepository
    {
        public OrcamentoRepository(AppDbContext ctx) : base(ctx)
        {

        }

        public IEnumerable<Orcamento> ObterTodos()
        {
            return this.Query().OrderBy(x => x.Id).ToList();
        }
    }
}
