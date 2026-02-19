using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unify.Budgets.Application.DTOs;

namespace Unify.Budgets.Application.Interfaces
{
    public interface IOrcamentoService
    {
        IEnumerable<OrcamentoDTO> ObterTodos();
        IEnumerable<OrcamentoMaterialDTO> ObterMateriais(long orcamentoId);
        IEnumerable<OrcamentoServicoDTO> ObterServicos(long orcamentoId);
        void Criar(OrcamentoDTO dto);
        void Duplicar(OrcamentoDTO dto);
        void Atualizar(OrcamentoDTO dto);
        void AdicionarMaterial(OrcamentoMaterialDTO dto);
        void AtualizarMaterial(OrcamentoMaterialDTO dto);
        void ExcluirMaterial(long id);
        void AdicionarServico(OrcamentoServicoDTO dto);
        void AtualizarServico(OrcamentoServicoDTO dto);
        void ExcluirServico(long id);
        void Excluir(long id);
    }
}
