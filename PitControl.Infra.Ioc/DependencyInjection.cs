
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PitControl.Application.Interfaces;
using PitControl.Application.Services;
using PitControl.Domain.Interfaces;
using PitControl.Infra.Data.Data;
using PitControl.Infra.Data.Repository;

namespace PitControl.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    configuration.GetConnectionString("DefaultConnection"),
                    ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))
                ));

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<ISetorEstoqueRepository, SetorEstoqueRepository>();
            services.AddScoped<ISetorEstoqueService, SetorEstoqueService>();
            services.AddHttpClient<ViaCepService>();
            return services;
        }
    }
}