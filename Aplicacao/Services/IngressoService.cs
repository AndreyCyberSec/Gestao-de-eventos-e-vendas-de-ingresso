using Aplicacao.DTOs.IngressosDto;
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
    public class IngressoService : IIngressoService
    {
        private readonly IIngressoRepository _ingressoRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public IngressoService(IIngressoRepository ingressoRepository, IUnitOfWork unitOfWork)
        {
            _ingressoRepository = ingressoRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<RespostaIngresso> AtualizarIngressoAsync(Guid Id,ModificarIngresso ingressoDto)
        {
            if (Id == Guid.Empty)
                throw new ArgumentException(
                    "Identificador do ingresso inválido.");


            if (ingressoDto == null)
                throw new ArgumentNullException(nameof(ingressoDto));

            var ingresso = await _ingressoRepository.ObterIngressoPorIdAsync(Id);

            if (ingresso == null)
                throw new KeyNotFoundException("Ingresso não encontrado.");

            if (ingresso.Status != StatusDoIngresso.Disponivel)
                throw new InvalidOperationException(
                    "Não é possível alterar o preço de um ingresso indisponível.");

            bool possuiPagamento =
                await _ingressoRepository.PossuiPagamentoAsync(Id);

            if (possuiPagamento)
                throw new InvalidOperationException(
                    "Não é possível alterar o preço de um ingresso que possui histórico de pagamento.");

            ingresso.AtualizarPreco(ingressoDto.Valor);

            _ingressoRepository.AtualizarIngresso(ingresso);

            await _unitOfWork.CommitAsync();

            return MapearIngresso(ingresso);
        }

        public async Task<RespostaIngresso> CadastrarIngressoAsync(CadastrarIngresso ingressoDto)
        {
            if (ingressoDto == null)
                throw new ArgumentNullException(nameof(ingressoDto));

            if (await _ingressoRepository.CodigoExistenteAsync(
               ingressoDto.CodigoIngresso))
            {
                throw new InvalidOperationException(
                    "Já existe um ingresso com esse código.");
            }

            if (!Enum.IsDefined(ingressoDto.TipoDeIngresso))
                throw new ArgumentException("Tipo de ingresso inválido.");

            var ingresso = Ingresso.CreateIngresso(
                ingressoDto.Valor,
                ingressoDto.CodigoIngresso,
                ingressoDto.TipoDeIngresso
            );

            await _ingressoRepository.AdicionarIngressoAsync(ingresso);

            await _unitOfWork.CommitAsync();

            return MapearIngresso(ingresso);
        }

        public async Task RemoverIngressoAsync(Guid Id)
        {
            if (Id == Guid.Empty)
                throw new ArgumentException(
                    "Identificador do ingresso inválido.");

            var ingresso = await _ingressoRepository.ObterIngressoPorIdAsync(Id);
            if (ingresso == null)
                throw new KeyNotFoundException("Ingresso não encontrado.");

            bool possuiPagamento =
                await _ingressoRepository.PossuiPagamentoAsync(Id);

            if (possuiPagamento)
                throw new InvalidOperationException(
                    "Não é possível excluir um ingresso que possui histórico de pagamento. Utilize o cancelamento.");

            if (ingresso.Status != StatusDoIngresso.Disponivel)
                throw new InvalidOperationException(
                    "Somente ingressos disponíveis podem ser excluídos.");

            _ingressoRepository.RemoverIngresso(ingresso);

            await _unitOfWork.CommitAsync();

          
        }

        public async Task CancelarIngressoAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException(
                    "Identificador do ingresso inválido.");

            var ingresso = await _ingressoRepository.ObterIngressoPorIdAsync(id);

            if (ingresso == null)
                throw new KeyNotFoundException("Ingresso não encontrado.");

            bool possuiPagamentoPendente =
                await _ingressoRepository.PossuiPagamentoPendenteAsync(id);

            if (possuiPagamentoPendente)
                throw new InvalidOperationException(
                    "Não é possível cancelar um ingresso com pagamento pendente.");

            bool possuiPagamentoAprovado =
               await _ingressoRepository.PossuiPagamentoAprovadoAsync(id);

            if (possuiPagamentoAprovado)
                throw new InvalidOperationException(
                    "Não é possível cancelar diretamente um ingresso que já foi vendido.");


            ingresso.CancelarIngresso();

            _ingressoRepository.AtualizarIngresso(ingresso);

            await _unitOfWork.CommitAsync();
        }

        private static RespostaIngresso MapearIngresso(Ingresso ingresso)
        {
            return new RespostaIngresso
            {

                Valor = ingresso.Preco.Valor,
                CodigoIngresso = ingresso.CodigoIngresso,
                TipoDeIngresso = ingresso.TipoDeingresso,
                StatusDoIngresso = ingresso.Status

            };
        }
    }
}
