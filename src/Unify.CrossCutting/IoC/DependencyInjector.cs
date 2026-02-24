using Microsoft.Extensions.DependencyInjection;
using Unify.Application.Interfaces;
using Unify.Application.Interfaces.Queries;
using Unify.Application.Queries;
using Unify.Application.Queries.Abstract;
using Unify.Application.Services;
using Unify.CrossCutting.Email;
using Unify.CrossCutting.Logging;
using Unify.CrossCutting.Persistence.Context;
using Unify.CrossCutting.Persistence.Repositories;
using Unify.CrossCutting.Persistence.UnitOfWork;
using Unify.Domain.Interfaces;

namespace Unify.Infrastructure.IoC
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
