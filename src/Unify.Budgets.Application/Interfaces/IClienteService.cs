using System;
using System.Collections.Generic;
using Unify.Budgets.Application.DTOs;

namespace Unify.Budgets.Application.Interfaces
{
    public interface IClienteService
    {
        IEnumerable<ClienteDTO> ObterTodos();
        void Criar(ClienteDTO dto);
        void Atualizar(ClienteDTO dto);
        void Excluir(long id);
    }
}
