using Microsoft.Extensions.DependencyInjection;
using Unify.Budgets.Application.Interfaces;
using Unify.Budgets.Application.Interfaces.Queries;
using Unify.Budgets.Application.Queries;
using Unify.Budgets.Application.Queries.Abstract;
using Unify.Budgets.Application.Services;
using Unify.Budgets.CrossCutting.Email;
using Unify.Budgets.CrossCutting.Logging;
using Unify.Budgets.CrossCutting.Persistence.Context;
using Unify.Budgets.CrossCutting.Persistence.Repositories;
using Unify.Budgets.CrossCutting.Persistence.UnitOfWork;
using Unify.Budgets.Domain.Interfaces;

namespace Unify.Budgets.Infrastructure.IoC
{
    public static class DependencyInjection
    {
        public static ServiceProvider Configure(this ServiceCollection services)
        {
            // Context
            services.AddScoped<AppDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositories
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IUnidadeRepository, UnidadeRepository>();
            services.AddScoped<IServicoRepository, ServicoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IOrcamentoRepository, OrcamentoRepository>();
            services.AddScoped<IOrcamentoMaterialRepository, OrcamentoMaterialRepository>();
            services.AddScoped<IOrcamentoServicoRepository, OrcamentoServicoRepository>();

            // Queries
            services.AddScoped<IOrcamentoQueries, OrcamentoQueries>();

            // Services
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IUnidadeService, UnidadeService>();
            services.AddScoped<IServicoService, ServicoService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IOrcamentoService, OrcamentoService>();

            // Geral
            services.AddScoped<ILogger, Logger>();
            services.AddScoped<ISmtpEmailSender, SmtpEmailSender>();

            return services.BuildServiceProvider();
        }


    }
}
