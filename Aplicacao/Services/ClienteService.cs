using Aplicacao.DTOs.ClientesDto;
using Aplicacao.Interfaces.Repository;
using Aplicacao.Interfaces.Services;
using Domain.Entidades;
using Domain.ObjectValue.Cliente;
using Infraestrutura.Interface.Senha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceSenhaHash serviceSenhaHash;

        public ClienteService(IClienteRepository clienteRepository, IUnitOfWork unitOfWork, IServiceSenhaHash serviceSenhaHash)
        {
            _clienteRepository = clienteRepository;
            _unitOfWork = unitOfWork;
            this.serviceSenhaHash = serviceSenhaHash;
        }
        public async Task<RespostaCliente> AtualizarClienteAsync(Guid id,ModificarCliente clienteDto)
        {
           if(clienteDto == null)
            {
                throw new ArgumentNullException(nameof(clienteDto));
            }
            if(id == Guid.Empty)
            {
                throw new ArgumentException("Identificador do cliente inválido.");
            }
            var clienteExistente = await _clienteRepository.ObterClientePorIdAsync(id);
            if(clienteExistente == null)
            {
                throw new ArgumentException("Cliente não encontrado.");
            }
           var nome = ObjectNome.CreateName(clienteDto.PrimeiroNome, clienteDto.UltimoNome);
            clienteExistente.AtualizarCliente(nome.PrimeiroNome, nome.UltimoNome, clienteDto.Idade);
            _clienteRepository.AtualizarCliente(clienteExistente);
            await _unitOfWork.CommitAsync();
            return MapearCliente(clienteExistente);



        }

        public async Task<RespostaCliente> CadastrarClienteAsync(CadastrarCliente clienteDto)
        {
           if(clienteDto == null)
            {
                throw new ArgumentNullException(nameof(clienteDto));
            }
           string nomeCompleto = $"{clienteDto.PrimeiroNome} {clienteDto.UltimoNome}";
            if (string.IsNullOrWhiteSpace(nomeCompleto))
            {
                throw new ArgumentException("O nome do cliente não pode ser nulo ou vazio.");
            }
            if(clienteDto.Idade < 0)
            {
                throw new ArgumentException("A idade do cliente não pode ser negativa.");
            }
            if(string.IsNullOrWhiteSpace(clienteDto.Email))
            {
                throw new ArgumentException("O email do cliente não pode ser nulo ou vazio.");
            }
            if(string.IsNullOrWhiteSpace(clienteDto.Senha))
            {
                throw new ArgumentException("A senha do cliente não pode ser nula ou vazia.");
            }

            var senhaHash = serviceSenhaHash.GerarHash(clienteDto.Senha);
            var nome = ObjectNome.CreateName(clienteDto.PrimeiroNome, clienteDto.UltimoNome);
            var email = ObjectEmail.CreateEmail(clienteDto.Email);
            var cliente = Cliente.CriarCliente(
                nome.PrimeiroNome,
                nome.UltimoNome,
                clienteDto.Idade,
                email.CorpoEmail,
                senhaHash
            );

            await _clienteRepository.AdicionarClienteAsync(cliente);
            await _unitOfWork.CommitAsync();
            return MapearCliente(cliente);
        }

        public async Task RemoverClienteAsync(Guid Id)
        {
            if(Id == Guid.Empty)
            {
                throw new ArgumentException("Identificador do cliente inválido.");
            }
            var cliente = await _clienteRepository.ObterClientePorIdAsync(Id);
            if(cliente == null)
            {
                throw new ArgumentException("Cliente não encontrado.");
            }
            await _clienteRepository.RemoverCliente(cliente);
            await _unitOfWork.CommitAsync();
            Console.WriteLine("Cliente removido com sucesso.");
        }

        public static RespostaCliente MapearCliente (Cliente cliente)
        {
            return new RespostaCliente
            {
                PrimeiroNome = cliente.Nome.PrimeiroNome,
                UltimoNome = cliente.Nome.UltimoNome,
                Idade = cliente.Idade,
                Email = cliente.Email.CorpoEmail,
                TipoDeCliente = cliente.TipoDeCliente.ToString(),
                StatusCliente = cliente.StatusCliente.ToString()
            };
        }
    }
}
