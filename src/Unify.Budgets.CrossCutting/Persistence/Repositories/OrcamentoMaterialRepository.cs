using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unify.Budgets.CrossCutting.Persistence.Context;
using Unify.Budgets.Domain.Entities;
using Unify.Budgets.Domain.Interfaces;

namespace Unify.Budgets.CrossCutting.Persistence.Repositories
{
    public class OrcamentoMaterialRepository : Repository<OrcamentoMaterial>, IOrcamentoMaterialRepository
    {
        public OrcamentoMaterialRepository(AppDbContext ctx) : base(ctx)
        {

        }

        public IEnumerable<OrcamentoMaterial> ObterTodos()
        {
            return this.Query().OrderBy(x => x.Id).ToList();
        }
    }
}
