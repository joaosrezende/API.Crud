using Application.Interfaces;
using Application.Interfaces.Queries;
using Application.Services;
using Domain.Interfaces;
using Infra.Context;
using Infra.Queries;
using Infra.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Infra.IoC;

[ExcludeFromCodeCoverage]
public static class DependencyInjectionApi
{
    public static IServiceCollection AddInfrastructureApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ApplicationDbContext>();

        #region Services
        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<IProdutoService, ProdutoService>();
        #endregion

        #region Queries
        services.AddScoped<IClienteQuery, ClienteQuery>();
        services.AddScoped<IProdutoQuery, ProdutoQuery>();
        #endregion

        #region Repository
        services.AddScoped<IClienteProdutoRepository, ClienteProdutoRepository>();
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        #endregion

        return services;
    }
}