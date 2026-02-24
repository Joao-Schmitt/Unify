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
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repo;
        private readonly IUnidadeRepository _unidadeRepo;
        private readonly IUnitOfWork _uow;
        public ProdutoService(IProdutoRepository repo, IUnidadeRepository unidadeRepo, IUnitOfWork uow)
        {
            _repo = repo;
            _unidadeRepo = unidadeRepo;
            _uow = uow;
        }

        public ProdutoDTO Obter(long id)
        {
            var p = _repo.Get(id);
            return new ProdutoDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Unidade = p.Unidade,
                DescricaoUnidade = _unidadeRepo.Query().FirstOrDefault(u => u.Sigla == p.Unidade)?.Descricao ?? "",
                PrecoUnidade = p.PrecoUnidade,
                Ativo = p.Ativo
            };
        }

        public IEnumerable<ProdutoDTO> ObterTodos()
        {
            return _repo.ObterTodos()
                .Select(p => new ProdutoDTO
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Unidade = p.Unidade,
                    DescricaoUnidade = _unidadeRepo.Query().FirstOrDefault(u => u.Sigla == p.Unidade)?.Descricao?? "",
                    PrecoUnidade = p.PrecoUnidade,
                    Ativo = p.Ativo
                }).OrderBy(x => x.Id).ToList();
        }

        public void Criar(ProdutoDTO dto)
        {
            var produto = new Produto();
            produto.AlterarNome(dto.Nome);
            produto.AlterarUnidade(dto.Unidade);
            produto.AlterarPrecoUnidade(dto.PrecoUnidade);
            produto.AlterarStatusAtivo(dto.Ativo);

            _repo.Add(produto);
            _uow.Commit();
        }

        public void Atualizar(ProdutoDTO dto)
        {
            var produto = _repo.Get(dto.Id);

            produto.AlterarNome(dto.Nome);
            produto.AlterarUnidade(dto.Unidade);
            produto.AlterarPrecoUnidade(dto.PrecoUnidade);
            produto.AlterarStatusAtivo(dto.Ativo);

            _uow.Commit();
        }
        public void Excluir(long id)
        {
            var produto = _repo.Get(id);
            
            // TODO
            //if (ProdutoPossuiMovimento(id))
            //    throw new AppException(
            //        "Produto com movimentação");

            _repo.Remove(produto);
            _uow.Commit();
        }


    }
}
