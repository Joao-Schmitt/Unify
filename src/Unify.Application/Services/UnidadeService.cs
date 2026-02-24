using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unify.Application.DTOs;
using Unify.Application.Interfaces;
using Unify.Domain.Entities;
using Unify.Domain.Exceptions;
using Unify.Domain.Interfaces;

namespace Unify.Application.Services
{
    public class UnidadeService : IUnidadeService
    {
        private readonly IUnidadeRepository _repo;
        private readonly IUnitOfWork _uow;
        public UnidadeService(IUnidadeRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public UnidadeDTO ObterPorSigla(string sigla)
        {
            return _repo.Query()
                        .Where(x => x.Sigla == sigla)
                        .Select(p => new UnidadeDTO
                        {
                            Sigla = p.Sigla,
                            Descricao = p.Descricao
                        })
                        .FirstOrDefault();
        }

        public IEnumerable<UnidadeDTO> ObterTodos()
        {
            return _repo.ObterTodos()
                .Select(p => new UnidadeDTO
                {
                    Sigla = p.Sigla,
                    Descricao = p.Descricao
                }).OrderBy(x => x.Id).ToList();
        }

        public void Criar(UnidadeDTO dto)
        {
            if (_repo.ExisteComMesmaSigla(dto.Sigla))
            {
                throw new ValidationException("Sigla já existente!");
            }

            var Unidade = new Unidade();
            Unidade.AlterarSigla(dto.Sigla);
            Unidade.AlterarDescricao(dto.Descricao);

            _repo.Add(Unidade);
            _uow.Commit();
        }

        public void Atualizar(UnidadeDTO dto)
        {
            if (_repo.ExisteComMesmaSigla(dto.Sigla))
            {
                throw new ValidationException("Sigla já existente!");
            }

            var Unidade = _repo.Get(dto.Id);

            Unidade.AlterarSigla(dto.Sigla);
            Unidade.AlterarDescricao(dto.Descricao);

            _uow.Commit();
        }
        public void Excluir(long id)
        {
            var Unidade = _repo.Get(id);

            // TODO
            //if (UnidadePossuiMovimento(id))
            //    throw new AppException(
            //        "Unidade com movimentação");

            _repo.Remove(Unidade);
            _uow.Commit();
        }
    }
}
