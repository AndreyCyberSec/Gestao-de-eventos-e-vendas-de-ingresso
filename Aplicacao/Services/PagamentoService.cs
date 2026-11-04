using Aplicacao.DTOs.PagamentosDto;
using Aplicacao.Interfaces.Repository;
using Aplicacao.Interfaces.Services;
using Domain.Entidades;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IIngressoRepository _ingressoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PagamentoService(IPagamentoRepository pagamentoRepository, IIngressoRepository ingressoRepository, IUnitOfWork unitOfWork)
        {
            _pagamentoRepository = pagamentoRepository;
            _ingressoRepository = ingressoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<RespostaPagamento> AprovarPagamentoAsync(Guid idPagamento)
        {
            //Buscar pagamento
            var pagamento = await _pagamentoRepository
                .ObterPagamentoPorIdAsync(idPagamento);

            if (pagamento == null)
                throw new InvalidOperationException("Pagamento não encontrado.");

            //Buscar ingresso associado
            var ingresso = await _ingressoRepository
                .ObterIngressoPorIdAsync(pagamento.Idingresso);

            if (ingresso == null)
                throw new InvalidOperationException("Ingresso não encontrado.");

            //Aprovar pagamento
            pagamento.AprovarPagamento();

            //Tornar ingresso indisponível
            ingresso.IngressoIndisponivel();

            //Atualizar entidades
            _pagamentoRepository.AtualizarPagamento(pagamento);
            _ingressoRepository.AtualizarIngresso(ingresso);

            //Confirmar as alterações juntas
            await _unitOfWork.CommitAsync();

            return MapearPagamento(pagamento);
        }

        public async Task<RespostaPagamento> CadastrarPagamentoAsync(CadastrarPagamento pagamentoDto)
        {
            // Busca o ingresso
            var ingresso = await _ingressoRepository
                .ObterIngressoPorIdAsync(pagamentoDto.IdIngresso);

            if (ingresso == null)
                throw new InvalidOperationException("Ingresso não encontrado.");
            //Verifica disponibilidade
            if (ingresso.Status != StatusDoIngresso.Disponivel)
                throw new InvalidOperationException("Ingresso indisponível.");

            //Obter o preço
            decimal valor = ingresso.Preco.Valor;

            //Criar o pagamento
            var pagamento = Pagamento.CreatePagamento(
              ingresso.IdIngresso,
                valor,
                pagamentoDto.MetodoPagamento

            );
            //Adicionar ao contexto
            await _pagamentoRepository.AdicionarPagamentoAsync(pagamento);

            await _unitOfWork.CommitAsync();

            // 7. Retornar resposta
            return MapearPagamento(pagamento);
        }

        public async Task<RespostaPagamento> ReprovarPagamentoAsync(Guid idPagamento)
        {
            var pagamento = await _pagamentoRepository
               .ObterPagamentoPorIdAsync(idPagamento);

            if (pagamento == null)
                throw new InvalidOperationException("Pagamento não encontrado.");

            pagamento.ReprovarPagamento();

            _pagamentoRepository.AtualizarPagamento(pagamento);

            await _unitOfWork.CommitAsync();

            return MapearPagamento(pagamento);
        }

        private static RespostaPagamento MapearPagamento(
           Pagamento pagamento)
        {
            return new RespostaPagamento
            {
                IdPagamento = pagamento.IdPagamento,
                IdIngresso = pagamento.Idingresso,
                Valor = pagamento.Valor.Valor,
                TipoPagamento = pagamento.TipoPagamento.ToString(),
                Status = pagamento.Status.ToString(),
                DataPagamento = pagamento.DataPagamento
            };
        }
    }
}
