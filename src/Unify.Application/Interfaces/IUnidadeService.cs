using System.Collections.Generic;
using Unify.Application.DTOs;

namespace Unify.Application.Interfaces
{
    public interface IUnidadeService
    {
        UnidadeDTO ObterPorSigla(string sigla);
        IEnumerable<UnidadeDTO> ObterTodos();
        void Criar(UnidadeDTO dto);
        void Atualizar(UnidadeDTO dto);
        void Excluir(long id);
    }
}
