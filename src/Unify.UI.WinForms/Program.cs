using Microsoft.Extensions.DependencyInjection;
using System;
using Unify.Infrastructure.IoC;
using Unify.UI.WinForms.Classes;
using Unify.UI.WinForms.Forms.Cadastros.Produtos;
using Unify.UI.WinForms.Forms.Cadastros.Servicos;
using Unify.UI.WinForms.Forms.Cadastros.Unidades;
using Unify.UI.WinForms.Forms.Inicio;

namespace Unify.UI.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            // Registra forms 
            FormResolver.RegisterForms(services);

            // Dependence Injector
            var provider = services.Configure();

            FormResolver.Provider = provider;

            // Inicialização
            System.Windows.Forms.Application.Run(FormResolver.Resolve<frmMDI>());

            //using (var loginForm = new frmLogin())
            //{
            //    if (loginForm.ShowDialog() == DialogResult.OK)
            //    {
            //        System.Windows.Forms.Application.Run(new frmDashboard());
            //    }
            //    else
            //    {
            //        System.Windows.Forms.Application.Exit();
            //    }
            //}
        }
    }
}
