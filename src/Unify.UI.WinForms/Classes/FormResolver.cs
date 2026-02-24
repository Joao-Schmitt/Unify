using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using Unify.UI.WinForms.Forms.Cadastros.Clientes;
using Unify.UI.WinForms.Forms.Cadastros.Orcamentos;
using Unify.UI.WinForms.Forms.Cadastros.Produtos;
using Unify.UI.WinForms.Forms.Cadastros.Servicos;
using Unify.UI.WinForms.Forms.Cadastros.Unidades;
using Unify.UI.WinForms.Forms.Inicio;

namespace Unify.UI.WinForms.Classes
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
            services.AddTransient<frmProduto>();
            services.AddTransient<frmListaProdutos>();

            // Serviços
            services.AddTransient<frmServico>();
            services.AddTransient<frmListaServicos>();

            // Clientes
            services.AddTransient<frmCliente>();
            services.AddTransient<frmListaClientes>();

            #endregion

            #region Orçamentos
            services.AddTransient<frmListaOrcamentos>();
            services.AddTransient<frmOrcamentoProduto>();
            #endregion
        }
    }
}
