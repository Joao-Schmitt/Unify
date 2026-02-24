using Unify.Application.DTOs;

namespace Unify.Application.Interfaces
{
    public interface ISecurityService
    {
        SenhaDTO CriarSenha(string senha);
        bool ValidarSenha(string senha, byte[] hashBanco, byte[] saltBanco);
        string GerarCodigoValidacao();
    }
}
