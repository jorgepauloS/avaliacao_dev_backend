using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vectra.Avaliacao.BLL;
using Vectra.Avaliacao.BLL.Interfaces;
using Vectra.Avaliacao.DAL.Context;
using Vectra.Avaliacao.DAL.Context.Interfaces;
using Vectra.Avaliacao.DAL.Repositories;
using Vectra.Avaliacao.DAL.Repositories.Interfaces;

namespace Vectra.Avaliacao.IOC
{
    public static class DependencyInjection
    {
        public static void AddBusinessLogic(IServiceCollection services)
        {
            services.AddScoped<IContasBLL, ContasBLL>();
        }

        public static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IContasRepository, ContasRepository>();
        }

        public static void AddContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EFContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
                opt.UseLazyLoadingProxies();
                opt.EnableSensitiveDataLogging();
            });

            services.AddTransient<IEFContext, EFContext>();
        }
    }
}