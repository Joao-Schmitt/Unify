using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Unify.Budgets.Application.DTOs;
using Unify.Budgets.Application.Interfaces;
using Unify.Budgets.Domain.Entities;
using Unify.Budgets.Domain.Exceptions;
using Unify.Budgets.Domain.Interfaces;

namespace Unify.Budgets.Application.Services
{
    public class OrcamentoService : IOrcamentoService
    {
        private readonly IOrcamentoRepository _repo;
        private readonly IOrcamentoMaterialRepository _repoMaterial;
        private readonly IOrcamentoServicoRepository _repoServico;

        private readonly IUnidadeRepository _unidadeRepo;
        private readonly IUnitOfWork _uow;
        public OrcamentoService(IOrcamentoRepository repo, IUnidadeRepository unidadeRepo, IOrcamentoMaterialRepository repoMaterial, IOrcamentoServicoRepository repoServico, IUnitOfWork uow)
        {
            _repo = repo;
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
                    Nome = p.Nome,
                    Documento = p.Documento,
                    Email = p.Email,
                    Telefone = p.Telefone,
                    Rua = p.Rua,
                    Cidade = p.Cidade,
                    Bairro = p.Bairro,
                    Numero = p.Numero,
                    Estado = p.Estado,
                    CEP = p.CEP,
                    SituacaoId = (Domain.Enums.OrcamentoSituacao)p.SituacaoId,
                    UsuarioId = p.UsuarioId,
                    Dt_Criacao = p.Dt_Criacao,
                    Dt_Prazo = p.Dt_Prazo,
                    CustoTotal = p.CustoTotal,
                    PrecoTotal = p.PrecoTotal,
                    LucroTotal = p.LucroTotal,
                }).OrderBy(x => x.Id).ToList();
        }

        public IEnumerable<OrcamentoMaterialDTO> ObterMateriais(long orcamentoId)
        {
            return _repoMaterial.Query()
                .Where(x => x.OrcamentoId == orcamentoId)
                .Select(p => new OrcamentoMaterialDTO
                {
                    Id = p.Id,
                    OrcamentoId = p.OrcamentoId,
                    ProdutoId = p.ProdutoId,
                    PrecoUnidade = p.PrecoUnidade,
                    Quantidade = p.Quantidade,
                    PrecoTotal = p.PrecoTotal
                }).OrderBy(x => x.Id).ToList();
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
                    PrecoBase = p.PrecoBase,
                    TempoMedioMinutos = p.TempoMedioMinutos,
                    PrecoTotal = p.PrecoTotal,
                    Observacoes = p.Observacoes
                }).OrderBy(x => x.Id).ToList();
        }

        public void Criar(OrcamentoDTO dto)
        {
            var orcamento = new Orcamento();

            orcamento.AlterarNome(dto.Nome);
            orcamento.AlterarDocumento(dto.Documento);
            orcamento.AlterarEmail(dto.Email);
            orcamento.AlterarTelefone(dto.Telefone);
            orcamento.AlterarRua(dto.Rua);
            orcamento.AlterarBairro(dto.Bairro);
            orcamento.AlterarNumero(dto.Numero);
            orcamento.AlterarCidade(dto.Cidade);
            orcamento.AlterarEstado(dto.Estado);
            orcamento.AlterarCEP(dto.CEP);
            orcamento.AlterarSituacao(dto.SituacaoId);
            orcamento.AlterarUsuarioCriador(dto.UsuarioId);
            orcamento.AlterarDtCriacao(DateTime.Now);
            orcamento.AlterarDtPrazo(dto.Dt_Prazo);

            orcamento.AlterarCustoTotal(dto.CustoTotal);
            orcamento.AlterarPrecoTotal(dto.PrecoTotal);
            orcamento.AlterarLucroTotal(dto.LucroTotal);

            _repo.Add(orcamento);
            _uow.Commit();
        }

        public void Duplicar(OrcamentoDTO dto)
        {
            var orcamento = new Orcamento();

            orcamento.AlterarNome(dto.Nome);
            orcamento.AlterarDocumento(dto.Documento);
            orcamento.AlterarEmail(dto.Email);
            orcamento.AlterarTelefone(dto.Telefone);
            orcamento.AlterarRua(dto.Rua);
            orcamento.AlterarBairro(dto.Bairro);
            orcamento.AlterarNumero(dto.Numero);
            orcamento.AlterarCidade(dto.Cidade);
            orcamento.AlterarEstado(dto.Estado);
            orcamento.AlterarCEP(dto.CEP);
            orcamento.AlterarSituacao(dto.SituacaoId);
            orcamento.AlterarUsuarioCriador(dto.UsuarioId);
            orcamento.AlterarDtCriacao(DateTime.Now);
            orcamento.AlterarDtPrazo(dto.Dt_Prazo);

            orcamento.AlterarCustoTotal(dto.CustoTotal);
            orcamento.AlterarPrecoTotal(dto.PrecoTotal);
            orcamento.AlterarLucroTotal(dto.LucroTotal);

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
            orcamento.AlterarNome(dto.Nome);
            orcamento.AlterarDocumento(dto.Documento);
            orcamento.AlterarEmail(dto.Email);
            orcamento.AlterarTelefone(dto.Telefone);
            orcamento.AlterarRua(dto.Rua);
            orcamento.AlterarBairro(dto.Bairro);
            orcamento.AlterarNumero(dto.Numero);
            orcamento.AlterarCidade(dto.Cidade);
            orcamento.AlterarEstado(dto.Estado);
            orcamento.AlterarCEP(dto.CEP);
            orcamento.AlterarSituacao(dto.SituacaoId);
            orcamento.AlterarUsuarioCriador(dto.UsuarioId);
            orcamento.AlterarDtCriacao(DateTime.Now);
            orcamento.AlterarDtPrazo(dto.Dt_Prazo);
            orcamento.AlterarCustoTotal(dto.CustoTotal);
            orcamento.AlterarPrecoTotal(dto.PrecoTotal);
            orcamento.AlterarLucroTotal(dto.LucroTotal);

            _uow.Commit();
        }
        public void Excluir(long id)
        {
            var orcamento = _repo.Get(id);

            // TODO
            //if (OrcamentoPossuiMovimento(id))
            //    throw new AppException(
            //        "Orcamento com movimentação");

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
            material.AlterarQuantidade(dto.Quantidade);
            material.AlterarPrecoUnidade(dto.PrecoUnidade);
            material.AlterarPrecoTotal(dto.PrecoTotal);

            _repoMaterial.Add(material);
            _uow.Commit();

            AtualizaTotais(dto.OrcamentoId);
        }

        public void AtualizarMaterial(OrcamentoMaterialDTO dto)
        {
            var material = _repoMaterial.Get(dto.Id);

            material.AlterarProduto(dto.ProdutoId);
            material.AlterarQuantidade(dto.Quantidade);
            material.AlterarPrecoUnidade(dto.PrecoUnidade);
            material.AlterarPrecoTotal(dto.PrecoTotal);

            _uow.Commit();

            AtualizaTotais(dto.OrcamentoId);
        }

        public void ExcluirMaterial(long id)
        {
            var material = _repoMaterial.Get(id);

            _repoMaterial.Remove(material);
            _uow.Commit();
        }

        public void AdicionarServico(OrcamentoServicoDTO dto)
        {
            var servico = new OrcamentoServico()
            {
                OrcamentoId = dto.OrcamentoId
            };

            servico.AlterarServico(dto.ServicoId);
            servico.AlterarPrecoBase(dto.PrecoBase);
            servico.AlterarPrecoTotal(dto.PrecoTotal);
            servico.AlterarTempoMedio(dto.TempoMedioMinutos);
            servico.AlterarObservacoes(dto.Observacoes);

            _repoServico.Add(servico);
            _uow.Commit();

            AtualizaTotais(dto.OrcamentoId);
        }

        public void AtualizarServico(OrcamentoServicoDTO dto)
        {
            var servico = _repoServico.Get(dto.Id);

            servico.AlterarServico(dto.ServicoId);
            servico.AlterarPrecoBase(dto.PrecoBase);
            servico.AlterarPrecoTotal(dto.PrecoTotal);
            servico.AlterarTempoMedio(dto.TempoMedioMinutos);
            servico.AlterarObservacoes(dto.Observacoes);

            _uow.Commit();

            AtualizaTotais(dto.OrcamentoId);
        }

        public void ExcluirServico(long id)
        {
            var servico = _repoServico.Get(id);

            _repoServico.Remove(servico);
            _uow.Commit();
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

            orcamento.AlterarPrecoTotal(totalMateriais + totalServicos);
        }
    }
}
