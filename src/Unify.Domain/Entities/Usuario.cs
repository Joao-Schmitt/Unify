using System;
using Unify.Domain.Abstractions;

namespace Unify.Domain.Entities
{
    public class Usuario : Entity
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public byte[] SenhaHash { get; set; }
        public byte[] SenhaSalt { get; set; }
        public bool Ativo { get; set; }
        public DateTime CriadoEm { get; set; }
        public long PerfilId { get; set; }
        public Perfil Perfil { get; set; }
    }
}
