using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using Unify.Budgets.Domain.Entities;
using Unify.Budgets.UI.WinForms.Forms.Cadastros.Clientes;
using Unify.Budgets.UI.WinForms.Forms.Cadastros.Orcamentos;
using Unify.Budgets.UI.WinForms.Forms.Cadastros.Produtos;
using Unify.Budgets.UI.WinForms.Forms.Cadastros.Servicos;
using Unify.Budgets.UI.WinForms.Forms.Cadastros.Unidades;
using Unify.Budgets.UI.WinForms.Forms.Inicio;

namespace Unify.Budgets.UI.WinForms.Classes
{
    public static class FormResolver
    {
        public static IServiceProvider Provider { get; set; }

        public static T Resolve<T>() where T : Form
            => Provider.GetRequiredService<T>();

        public static void RegisterForms(ServiceCollection services)
        {
            #region Core
            // MDI
            services.AddTransient<frmMDI>();

            #endregion

            #region Cadastros

            // Unidade
            services.AddTransient<frmUnidade>();
            services.AddTransient<frmListaUnidades>();

            // Produtos
            services.AddTransient<frmOrcamentoProduto>();
            services.AddTransient<frmListaProdutos>();

            // Serviços
            services.AddTransient<frmOrcamentoServico>();
            services.AddTransient<frmListaServicos>();

            // Clientes
            services.AddTransient<frmCliente>();
            services.AddTransient<frmListaClientes>();

            #endregion

            #region Orçamentos
            services.AddTransient<frmListaOrcamentos>();
            #endregion
        }
    }
}
