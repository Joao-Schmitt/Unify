using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Unify.Application.DTOs;
using Unify.Application.Interfaces;
using Unify.Application.Interfaces.Queries;
using Unify.Domain.Entities;
using Unify.Domain.Enums;
using Unify.Domain.Exceptions;
using Unify.Domain.Interfaces;

namespace Unify.Application.Services
{
    public class OrcamentoService : IOrcamentoService
    {
        private readonly IOrcamentoRepository _repo;
        private readonly IOrcamentoQueries _query;
        private readonly IOrcamentoMaterialRepository _repoMaterial;
        private readonly IOrcamentoServicoRepository _repoServico;
    
        private readonly IUnidadeRepository _unidadeRepo;
        private readonly IUnitOfWork _uow;
        public OrcamentoService(IOrcamentoRepository repo, IOrcamentoQueries query, IUnidadeRepository unidadeRepo, IOrcamentoMaterialRepository repoMaterial, IOrcamentoServicoRepository repoServico, IUnitOfWork uow)
        {
            _repo = repo;
            _query = query;
            _repoMaterial = repoMaterial;
            _repoServico = repoServico;
            _unidadeRepo = unidadeRepo;
            _uow = uow;
        }

        public IEnumerable<OrcamentoDTO> ObterTodos()
        {
            return _repo.ObterTodos()
                .Select(p => new OrcamentoDTO
                {
                    Id = p.Id,
                    ClienteId = p.ClienteId,
                    Rua = p.Rua,
                    Cidade = p.Cidade,
                    Bairro = p.Bairro,
                    Numero = p.Numero,
                    Estado = p.Estado,
                    CEP = p.CEP,
                    SituacaoId = p.SituacaoId,
                    UsuarioId = p.UsuarioId,
                    Dt_Criacao = p.Dt_Criacao,
                    Dt_PrazoFinalizacao = p.Dt_PrazoFinalizacao,
                    Dt_PrazoGarantia = p.Dt_PrazoGarantia,
                    Dt_Validade = p.Dt_Validade,
                    Complemento = p.Complemento,
                    ValorTotal = p.ValorTotal
                }).OrderBy(x => x.Id).ToList();
        }

        public IEnumerable<OrcamentoDetalhadoDTO> ObterTodosDetalhado()
        {
            return _query.ObterTodosDetalhado()
                        .OrderBy(x => x.Id)
                        .ToList();
        }

        public IEnumerable<OrcamentoMaterialDetalhadoDTO> ObterMateriais(long orcamentoId)
        {
            return _query.ObtertMateriaisDetalhado(orcamentoId)
                         .OrderBy(x => x.Id)
                         .ToList();
        }

        public IEnumerable<OrcamentoServicoDTO> ObterServicos(long orcamentoId)
        {
            return _repoServico.Query()
                .Where(x => x.OrcamentoId == orcamentoId)
                .Select(p => new OrcamentoServicoDTO
                {
                    Id = p.Id,
                    OrcamentoId = p.OrcamentoId,
                    ServicoId = p.ServicoId,
                    Preco = p.Preco,
                    Quantidade = p.Quantidade,
                    PrecoTotal = p.PrecoTotal,
                    Observacoes = p.Observacoes
                }).OrderBy(x => x.Id).ToList();
        }

        public void Criar(OrcamentoDTO dto)
        {
            var orcamento = new Orcamento();

            orcamento.AlterarCliente(dto.ClienteId);
            orcamento.AlterarRua(dto.Rua);
            orcamento.AlterarBairro(dto.Bairro);
            orcamento.AlterarNumero(dto.Numero);
            orcamento.AlterarCidade(dto.Cidade);
            orcamento.AlterarEstado(dto.Estado);
            orcamento.AlterarCEP(dto.CEP);
            orcamento.AlterarSituacao((OrcamentoSituacao)dto.SituacaoId);
            orcamento.AlterarUsuarioCriador(dto.UsuarioId);
            orcamento.AlterarDtCriacao(DateTime.Now);
            orcamento.AlterarDtValidade(dto.Dt_Validade);
            orcamento.AlterarDtPrazoFinalizacao(dto.Dt_PrazoFinalizacao);
            orcamento.AlterarDtPrazoGarantia(dto.Dt_PrazoGarantia);
            orcamento.AlterarValorTotal(dto.ValorTotal);

            _repo.Add(orcamento);
            _uow.Commit();
        }

        public void Duplicar(OrcamentoDTO dto)
        {
            var orcamento = new Orcamento();

            orcamento.AlterarCliente(dto.ClienteId);
            orcamento.AlterarRua(dto.Rua);
            orcamento.AlterarBairro(dto.Bairro);
            orcamento.AlterarNumero(dto.Numero);
            orcamento.AlterarCidade(dto.Cidade);
            orcamento.AlterarEstado(dto.Estado);
            orcamento.AlterarCEP(dto.CEP);
            orcamento.AlterarSituacao((OrcamentoSituacao)dto.SituacaoId);
            orcamento.AlterarUsuarioCriador(dto.UsuarioId);
            orcamento.AlterarDtCriacao(DateTime.Now);
            orcamento.AlterarDtValidade(dto.Dt_Validade);
            orcamento.AlterarDtPrazoFinalizacao(dto.Dt_PrazoFinalizacao);
            orcamento.AlterarDtPrazoGarantia(dto.Dt_PrazoGarantia);
            orcamento.AlterarValorTotal(dto.ValorTotal);

            _repo.Add(orcamento);
            _uow.Commit();

            var materiais = ObterMateriais(dto.Id).ToList();
            materiais.ForEach(x =>
            {
                x.OrcamentoId = orcamento.Id;
                AdicionarMaterial(x);
            });


            var servicos = ObterServicos(dto.Id).ToList();
            servicos.ForEach(x =>
            {
                x.OrcamentoId = orcamento.Id;
                AdicionarServico(x);
            });

            _uow.Commit();
        }

        public void Atualizar(OrcamentoDTO dto)
        {
            var orcamento = _repo.Get(dto.Id);

            if (orcamento.SituacaoId != (long)Domain.Enums.OrcamentoSituacao.EmOrcamento)
            {
                throw new ValidationException($"Não é possível excluir um orçamento reisado!");
            }

            orcamento.AlterarCliente(dto.ClienteId);
            orcamento.AlterarRua(dto.Rua);
            orcamento.AlterarBairro(dto.Bairro);
            orcamento.AlterarNumero(dto.Numero);
            orcamento.AlterarCidade(dto.Cidade);
            orcamento.AlterarEstado(dto.Estado);
            orcamento.AlterarCEP(dto.CEP);
            orcamento.AlterarSituacao((OrcamentoSituacao)dto.SituacaoId);
            orcamento.AlterarUsuarioCriador(dto.UsuarioId);
            orcamento.AlterarDtCriacao(DateTime.Now);
            orcamento.AlterarDtValidade(dto.Dt_Validade);
            orcamento.AlterarDtPrazoFinalizacao(dto.Dt_PrazoFinalizacao);
            orcamento.AlterarDtPrazoGarantia(dto.Dt_PrazoGarantia);
            orcamento.AlterarValorTotal(dto.ValorTotal);

            _uow.Commit();
        }
        public void Excluir(long id)
        {
            var orcamento = _repo.Get(id);

            if (orcamento.SituacaoId != (long)Domain.Enums.OrcamentoSituacao.EmOrcamento)
            {
                throw new ValidationException($"Não é possível excluir um orçamento reisado!");
            }

            _repo.Remove(orcamento);
            _uow.Commit();
        }

        public void AdicionarMaterial(OrcamentoMaterialDTO dto)
        {
            var material = new OrcamentoMaterial()
            {
                OrcamentoId = dto.OrcamentoId
            };

            material.AlterarProduto(dto.ProdutoId);
            material.AlterarComprimento(dto.Comprimento);
            material.AlterarLargura(dto.Largura);
            material.AlterarPrecoUnidade(dto.PrecoUnidade);
            material.AlterarQuantidade(dto.Quantidade);
            material.AlterarObservacoes(dto.Observacoes);

            _repoMaterial.Add(material);
            _uow.Commit();

            AtualizaTotais(dto.OrcamentoId);
        }

        public void AtualizarMaterial(OrcamentoMaterialDTO dto)
        {
            var material = _repoMaterial.Get(dto.Id);

            material.AlterarProduto(dto.ProdutoId);
            material.AlterarComprimento(dto.Comprimento);
            material.AlterarLargura(dto.Largura);
            material.AlterarPrecoUnidade(dto.PrecoUnidade);
            material.AlterarQuantidade(dto.Quantidade);
            material.AlterarObservacoes(dto.Observacoes);

            _uow.Commit();

            AtualizaTotais(dto.OrcamentoId);
        }

        public void ExcluirMaterial(long id)
        {
            var material = _repoMaterial.Get(id);

            _repoMaterial.Remove(material);
            _uow.Commit();

            AtualizaTotais(material.OrcamentoId);
        }

        public void AdicionarServico(OrcamentoServicoDTO dto)
        {
            var servico = new OrcamentoServico()
            {
                OrcamentoId = dto.OrcamentoId
            };

            servico.AlterarServico(dto.ServicoId);
            servico.AlterarPreco(dto.Preco);
            servico.AlterarQuantidade(dto.Quantidade);
            servico.AlterarObservacoes(dto.Observacoes);

            _repoServico.Add(servico);
            _uow.Commit();

            AtualizaTotais(dto.OrcamentoId);
        }

        public void AtualizarServico(OrcamentoServicoDTO dto)
        {
            var servico = _repoServico.Get(dto.Id);

            servico.AlterarServico(dto.ServicoId);
            servico.AlterarPreco(dto.Preco);
            servico.AlterarQuantidade(dto.Quantidade);
            servico.AlterarObservacoes(dto.Observacoes);

            _uow.Commit();

            AtualizaTotais(dto.OrcamentoId);
        }

        public void ExcluirServico(long id)
        {
            var servico = _repoServico.Get(id);

            _repoServico.Remove(servico);
            _uow.Commit();

            AtualizaTotais(servico.OrcamentoId);
        }


        private void AtualizaTotais(long id)
        {
            var orcamento = _repo.Get(id);

            if (orcamento == null)
                throw new ValidationException("O orçamento não existe! Os totais não podem ser atualizados");


            // Preço total
            var totalMateriais = _repoMaterial.Query()
                                              .Where(x => x.OrcamentoId == id)
                                              .Sum(x => x.PrecoTotal);

            var totalServicos = _repoServico.Query()
                                              .Where(x => x.OrcamentoId == id)
                                              .Sum(x => x.PrecoTotal);

            orcamento.AlterarValorTotal(totalMateriais + totalServicos);
        }
    }
}
