using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unify.CrossCutting.Persistence.Context;
using Unify.Domain.Entities;
using Unify.Domain.Interfaces;

namespace Unify.CrossCutting.Persistence.Repositories
{
    public class OrcamentoServicoRepository : Repository<OrcamentoServico>, IOrcamentoServicoRepository
    {
        public OrcamentoServicoRepository(AppDbContext ctx) : base(ctx)
        {

        }

        public IEnumerable<OrcamentoServico> ObterTodos()
        {
            return this.Query().OrderBy(x => x.Id).ToList();
        }
    }
}
