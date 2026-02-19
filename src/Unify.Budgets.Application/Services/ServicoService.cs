using System;
using System.Collections.Generic;
using System.Linq;
using Unify.Budgets.Application.DTOs;
using Unify.Budgets.Application.Interfaces;
using Unify.Budgets.Domain.Entities;
using Unify.Budgets.Domain.Interfaces;

namespace Unify.Budgets.Application.Services
{
    public class ServicoService : IServicoService
    {
        private readonly IServicoRepository _repo;
        private readonly IUnitOfWork _uow;
        public ServicoService(IServicoRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public IEnumerable<ServicoDTO> ObterTodos()
        {
            return _repo.ObterTodos()
                .Select(p => new ServicoDTO
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    PrecoBase = p.PrecoBase,
                    TempoMedioMinutos = p.TempoMedioMinutos,
                    Observacoes = p.Observacoes,
                    Ativo = p.Ativo
                }).OrderBy(x => x.Id).ToList();
        }

        public void Criar(ServicoDTO dto)
        {
            var servico = new Servico();
            servico.AlterarNome(dto.Nome);
            servico.AlterarPrecoBase(dto.PrecoBase);
            servico.AlterarTempoMedioMinutos(dto.TempoMedioMinutos);
            servico.AlterarObservacao(dto.Observacoes);
            servico.AlterarStatusAtivo(dto.Ativo);

            _repo.Add(servico);
            _uow.Commit();
        }

        public void Atualizar(ServicoDTO dto)
        {
            var servico = _repo.Get(dto.Id);

            servico.AlterarNome(dto.Nome);
            servico.AlterarPrecoBase(dto.PrecoBase);
            servico.AlterarTempoMedioMinutos(dto.TempoMedioMinutos);
            servico.AlterarObservacao(dto.Observacoes);
            servico.AlterarStatusAtivo(dto.Ativo);

            _uow.Commit();
        }
        public void Excluir(long id)
        {
            var servico = _repo.Get(id);

            // TODO
            //if (ServicoPossuiMovimento(id))
            //    throw new AppException(
            //        "Servico com movimentação");

            _repo.Remove(servico);
            _uow.Commit();
        }

    }
}
