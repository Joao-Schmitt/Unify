using System.Collections.Generic;
using Unify.Budgets.Application.DTOs;

namespace Unify.Budgets.Application.Interfaces
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
