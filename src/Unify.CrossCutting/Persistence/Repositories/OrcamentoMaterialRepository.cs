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
