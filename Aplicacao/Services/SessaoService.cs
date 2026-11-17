using Aplicacao.DTOs.SessoesDto;
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
    public class SessaoService: ISessaoService
    {
        private readonly ISessaoRepository _sessaoRepository;
        private readonly IEventoRepository _eventoRepository;
        private readonly ISalaRepository _salaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SessaoService(ISessaoRepository sessaoRepository, IEventoRepository eventoRepository,ISalaRepository salaRepository ,IUnitOfWork unitOfWork)
        {
            _sessaoRepository = sessaoRepository;
            _eventoRepository = eventoRepository;
            _salaRepository = salaRepository;
            _unitOfWork = unitOfWork;
        }

        public Task AtualizarSessaoAsync(Guid id, CadastrarSessao sessaoDto)
        {
            throw new NotImplementedException();
        }

        public async Task<RespostaSessao?> BuscarSessaoPorIdAsync(Guid id)
        {
            var sessao = await _sessaoRepository.ObterSessaoPorIdAsync(id);

            if (sessao == null)
                return null;

            int quantidade = await _sessaoRepository
                .ContarIngressosPorSessaoAsync(id);

            return MapearSessao(sessao, quantidade);
        }

        public async Task<RespostaSessao> CadastrarSessaoAsync(CadastrarSessao sessaoDto)
        {
            if (sessaoDto == null)
                throw new ArgumentNullException(nameof(sessaoDto));

            var evento = await _eventoRepository
                .ObterEventoPorIdAsync(sessaoDto.IdEvento);

            var sala = await _salaRepository
                .ObterSalaPorIdAsync(sessaoDto.IdSala);

            if (evento == null)
                throw new Exception("Evento não encontrado.");

            if (sala == null)
                throw new Exception("Sala não encontrada.");

            var sessao = Sessao.CreateSessao(
                evento.IdEvento,
                sala.IdSala,
                sessaoDto.InicioSessao,
                sessaoDto.FimSessao
            );

            evento.AdicionarSessao(sessao);

            await _sessaoRepository.AdicionarSessaoAsync(sessao);

            await _unitOfWork.CommitAsync();

            return MapearSessao(sessao, 0);
        }

        public Task CancelarSessaoAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RespostaSessao>> ListarSessoesAsync()
        {
            var sessoes = await _sessaoRepository.ObterTodasSessoesAsync();

            var respostas = new List<RespostaSessao>();

            foreach (var sessao in sessoes)
            {
                int quantidade = await _sessaoRepository
                    .ContarIngressosPorSessaoAsync(sessao.IdSessao);

                respostas.Add(MapearSessao(sessao, quantidade));
            }

            return respostas;
        }

        public async Task<bool> VerificarDisponibilidadeAsync(Guid id)
        {
             var sessao = await _sessaoRepository.ObterSessaoPorIdAsync(id);

            if (sessao == null)
                throw new Exception("Sessão não encontrada.");

            int quantidade = await _sessaoRepository
                .ContarIngressosPorSessaoAsync(id);

            return sessao.Sala.Status == StatusSala.Disponivel
                && DateTime.Now < sessao.DataHoraInicio
                && quantidade < sessao.Sala.Capacidade;
        }

        private RespostaSessao MapearSessao(Sessao sessao,int quantidadeReservada)
        {
            int capacidade = sessao.Sala.Capacidade;

            return new RespostaSessao
            {
                InicioSessao = sessao.DataHoraInicio,
                FimSessao = sessao.DataHoraFim,
                Capacidade = capacidade,
                QuantidadeReservada = quantidadeReservada,
                LugaresDisponiveis = capacidade - quantidadeReservada,
                EstaLotada = quantidadeReservada >= capacidade
            };
        }
    }
}
