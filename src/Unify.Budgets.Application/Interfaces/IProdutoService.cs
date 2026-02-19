using System.Collections.Generic;
using Unify.Budgets.Application.DTOs;

namespace Unify.Budgets.Application.Interfaces
{
    public interface IProdutoService
    {
        ProdutoDTO Obter(long id);
        IEnumerable<ProdutoDTO> ObterTodos();
        void Criar(ProdutoDTO dto);
        void Atualizar(ProdutoDTO dto);
        void Excluir(long id);
    }
}
