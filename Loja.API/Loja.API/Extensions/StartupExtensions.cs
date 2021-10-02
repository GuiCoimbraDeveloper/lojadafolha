using Loja.Application.Services;
using Loja.Domain.Repositories;
using Loja.Domain.Service;
using Loja.Infra.Data;
using Loja.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace Loja.API.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<DbDataContext>(options =>
            {
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly("Loja.Infra")
                 );
            });
            //sqlServerOptionsAction: sqlOptions =>
            //{
            //    sqlOptions.CommandTimeout(30);
            //    sqlOptions.EnableRetryOnFailure(
            //        maxRetryCount: 5,
            //        maxRetryDelay: TimeSpan.FromSeconds(30),
            //        errorNumbersToAdd: null);
            //}
            services.AddScoped<DbDataContext, DbDataContext>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IPedidoService, PedidoService>();
            services.AddTransient<IProdutoService, ProdutoService>();
            return services;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();

            return services;
        }
    }
}
