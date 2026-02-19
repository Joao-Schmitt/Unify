using System;
using System.Collections.Generic;
using System.Linq;
using Unify.Budgets.Application.DTOs;
using Unify.Budgets.Application.Interfaces;
using Unify.Budgets.Domain.Entities;
using Unify.Budgets.Domain.Interfaces;

namespace Unify.Budgets.Application.Services
{
    public class ClienteService: IClienteService
    {
        private readonly IClienteRepository _repo;
        private readonly IUnidadeRepository _unidadeRepo;
        private readonly IUnitOfWork _uow;
        public ClienteService(IClienteRepository repo, IUnidadeRepository unidadeRepo, IUnitOfWork uow)
        {
            _repo = repo;
            _unidadeRepo = unidadeRepo;
            _uow = uow;
        }

        public IEnumerable<ClienteDTO> ObterTodos()
        {
            return _repo.ObterTodos()
                .Select(p => new ClienteDTO
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Email = p.Email,
                    Documento = p.Documento,
                    CEP = p.CEP,
                    Complemento = p.Complemento,
                    Cidade = p.Cidade,
                    Estado = p.Estado,
                    Bairro = p.Bairro,
                    Numero = p.Numero,
                    Rua = p.Rua,
                    Telefone = p.Telefone,
                    Dt_Criacao = p.Dt_Criacao,
                    Ativo = p.Ativo
                }).OrderBy(x => x.Id).ToList();
        }

        public void Criar(ClienteDTO dto)
        {
            var cliente = new Cliente();
            cliente.AlterarNome(dto.Nome);
            cliente.AlterarDocumento(dto.Documento);
            cliente.AlterarEmail(dto.Email);
            cliente.AlterarTelefone(dto.Telefone);
            cliente.AlterarRua(dto.Rua);
            cliente.AlterarBairro(dto.Bairro);
            cliente.AlterarNumero(dto.Numero);
            cliente.AlterarCidade(dto.Cidade);
            cliente.AlterarEstado(dto.Estado);
            cliente.AlterarCEP(dto.CEP);
            cliente.AlterarComplemento(dto.Complemento);
            cliente.AlterarStatusAtivo(dto.Ativo);

            _repo.Add(cliente);
            _uow.Commit();
        }

        public void Atualizar(ClienteDTO dto)
        {
            var cliente = _repo.Get(dto.Id);
            cliente.AlterarNome(dto.Nome);
            cliente.AlterarDocumento(dto.Documento);
            cliente.AlterarEmail(dto.Email);
            cliente.AlterarTelefone(dto.Telefone);
            cliente.AlterarRua(dto.Rua);
            cliente.AlterarBairro(dto.Bairro);
            cliente.AlterarNumero(dto.Numero);
            cliente.AlterarCidade(dto.Cidade);
            cliente.AlterarEstado(dto.Estado);
            cliente.AlterarComplemento(dto.Complemento);
            cliente.AlterarCEP(dto.CEP);
            cliente.AlterarStatusAtivo(dto.Ativo);

            _uow.Commit();
        }
        public void Excluir(long id)
        {
            var cliente = _repo.Get(id);

            // TODO
            //if (ClientePossuiMovimento(id))
            //    throw new AppException(
            //        "Cliente com movimentação");

            _repo.Remove(cliente);
            _uow.Commit();
        }
    }
}
