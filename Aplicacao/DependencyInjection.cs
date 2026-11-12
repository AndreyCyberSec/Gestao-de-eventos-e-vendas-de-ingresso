using Aplicacao.Interfaces.Services;
using Aplicacao.Services;
using Infraestrutura.Interface.Senha;
using Infraestrutura.ServiceHashSenha;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicacao(this IServiceCollection services)
        {
           services.AddScoped<IPagamentoService, PagamentoService>();
            services.AddScoped<IIngressoService, IngressoService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IServiceSenhaHash, BcryptServiceSenhaHash>();
            return services;
        }
    }
}
