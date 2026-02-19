using Unify.Budgets.Domain.Abstractions;

namespace Unify.Budgets.Domain.Entities
{
    public class Permissoes : Entity
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
