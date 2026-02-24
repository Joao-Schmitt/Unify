using System.Collections.Generic;
using Unify.Application.DTOs;

namespace Unify.Application.Interfaces
{
    public interface IServicoService
    {
        IEnumerable<ServicoDTO> ObterTodos();
        void Criar(ServicoDTO dto);
        void Atualizar(ServicoDTO dto);
        void Excluir(long id);
    }
}
