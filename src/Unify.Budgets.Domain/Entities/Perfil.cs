using System.Collections.Generic;
using Unify.Budgets.Domain.Abstractions;

namespace Unify.Budgets.Domain.Entities
{
    public class Perfil : Entity
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Permissoes> Permissoes { get; set; }
    }
}
