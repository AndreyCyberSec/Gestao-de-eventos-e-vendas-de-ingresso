using Aplicacao.Interfaces.Repository;
using Infraestrutura.EventDataBase;
using Infraestrutura.Interface.Senha;
using Infraestrutura.Repositories;
using Infraestrutura.ServiceHashSenha;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura
{
    public static class DependencyInjection
    {
       public static IServiceCollection AddInfraestrutura(this IServiceCollection services)
        {
            //repositorios
            //scoped porque cada requisição terá sua própria instância do repositório
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ISalaRepository, SalaRepository>();
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<IIngressoRepository, IngressoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //service de senha hash
            services.AddScoped<IServiceSenhaHash, BcryptServiceSenhaHash>();

            return services;
        }
    }
}
