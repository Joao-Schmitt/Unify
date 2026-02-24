using System;

namespace Unify.Application.DTOs
{
    public class ClienteDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Complemento { get; set; }
        public bool Ativo { get; set; }
        public DateTime Dt_Criacao { get; set; }
    }
}
