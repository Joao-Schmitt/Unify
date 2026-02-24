using Unify.Domain.Abstractions;

namespace Unify.Domain.Entities
{
    public class Permissoes : Entity
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
