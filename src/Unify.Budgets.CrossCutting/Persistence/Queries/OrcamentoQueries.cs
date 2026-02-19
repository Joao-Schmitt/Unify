using System;
using System.Collections.Generic;
using System.Linq;
using Unify.Budgets.Application.DTOs;
using Unify.Budgets.Application.Interfaces.Queries;
using Unify.Budgets.Application.Queries.Abstract;
using Unify.Budgets.CrossCutting.Persistence.Context;

namespace Unify.Budgets.Application.Queries
{
    public class OrcamentoQueries : Query, IOrcamentoQueries
    {
        public OrcamentoQueries(AppDbContext ctx) : base(ctx) { }

        public IEnumerable<OrcamentoDetalhadoDTO> ObterTodosDetalhado()
        {
            var query = @"SELECT 
							Orcamentos.Id,
							Orcamentos.ClienteId,
							Clientes.Nome,
							Clientes.Documento,
							Clientes.Email,
							Clientes.Telefone,
							Orcamentos.Rua,
							Orcamentos.Cidade,
							Orcamentos.Bairro,
							Orcamentos.Numero,
							Orcamentos.Estado,
							Orcamentos.CEP,
							Orcamentos.Complemento,
							Orcamentos.SituacaoId,
							OrcamentoSituacoes.Descricao as SituacaoDescricao,
							Orcamentos.UsuarioId,
							Orcamentos.Dt_Criacao,
							Orcamentos.Dt_Validade,
							Orcamentos.Dt_PrazoFinalizacao,
							Orcamentos.Dt_PrazoGarantia,
							Orcamentos.Observacoes,
							Orcamentos.ValorTotal
						FROM 
							Orcamentos
							LEFT JOIN Clientes ON Orcamentos.ClienteId = Clientes.Id
							LEFT JOIN OrcamentoSituacoes ON Orcamentos.SituacaoId = OrcamentoSituacoes.Id";

            return this.SqlQuery<OrcamentoDetalhadoDTO>(query).OrderBy(x => x.Id).ToList();
        }
    }
}
