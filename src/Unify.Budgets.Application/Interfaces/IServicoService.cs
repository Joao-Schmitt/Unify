using System.Collections.Generic;
using Unify.Budgets.Application.DTOs;

namespace Unify.Budgets.Application.Interfaces
{
    public interface IServicoService
    {
        IEnumerable<ServicoDTO> ObterTodos();
        void Criar(ServicoDTO dto);
        void Atualizar(ServicoDTO dto);
        void Excluir(long id);
    }
}
