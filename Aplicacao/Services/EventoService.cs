using Aplicacao.DTOs.EventosDto;
using Aplicacao.Interfaces.Repository;
using Aplicacao.Interfaces.Services;
using Domain.Entidades;
using Domain.ObjectValue.Evento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly ISalaRepository _salaRepository;
        private readonly IUnitOfWork _unitOfWork;
        public EventoService(IEventoRepository eventoRepository, ISalaRepository salaRepository, IUnitOfWork unitOfWork)
        {
            _eventoRepository = eventoRepository;
            _salaRepository = salaRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<RespostaEvento> AtualizarEventoAsync(Guid id, ModificarEvento eventoDto)
        {
            if(eventoDto == null)
            {
                throw new ArgumentNullException(nameof(eventoDto));
            }
            if(id == Guid.Empty)
            {
                throw new ArgumentException("O ID do evento não pode ser vazio.", nameof(id));
            }
            var eventoExistente = await _eventoRepository.ObterEventoPorIdAsync(id);
            if(eventoExistente == null)
            {
                throw new InvalidOperationException($"Evento com ID {id} não encontrado.");
            }
            var nomeEventoValido = ObejctNomeEvento.CreateNomeEvento(eventoDto.NomeEvento);
            var localEvento = ObjectLocalEvento.CreateLocalEvento(eventoDto.EnderecoEvento, eventoDto.CidadeEvento, eventoDto.EstadoEvento, eventoDto.PaisEvento);
            var descricaoDoEvento = ObjectDescricaoEvento.CreateDescricaoEvento(eventoDto.DescricaoEvento);
            eventoExistente.AtualizarEvento(
                nomeEventoValido.NomeEvento,
                localEvento.Endereco,
                localEvento.Cidade,
                localEvento.Estado,
                localEvento.Pais,
                eventoDto.InicioEvento,
                eventoDto.FimEvento,
                descricaoDoEvento.Descricao
            );
            await _eventoRepository.AtualizarEventoAsync(eventoExistente);
            await _unitOfWork.CommitAsync();
            return MapearEvento(eventoExistente);
        }

        public async Task<RespostaEvento> CadastrarEventoAsync(CadastrarEvento eventoDto)
        {
           if(eventoDto == null)
            {
                throw new ArgumentNullException(nameof(eventoDto));
            }
           if(string.IsNullOrWhiteSpace(eventoDto.NomeEvento))
            {
                throw new ArgumentException("O nome do evento não pode ser nulo ou vazio.", nameof(eventoDto.NomeEvento));
            }
           if(string.IsNullOrWhiteSpace(eventoDto.EnderecoEvento))
            {
                throw new ArgumentException("O endereço do evento não pode ser nulo ou vazio.", nameof(eventoDto.EnderecoEvento));
            }
            if (string.IsNullOrWhiteSpace(eventoDto.CidadeEvento))
                {
                 throw new ArgumentException("A cidade do evento não pode ser nula ou vazia.", nameof(eventoDto.CidadeEvento));
            }
            if (string.IsNullOrEmpty(eventoDto.PaisEvento))
            {
                throw new ArgumentException("O pais do evento não pode ser nulo ou vazio.", nameof(eventoDto.PaisEvento));
            }
            if(eventoDto.InicioEvento >= eventoDto.FimEvento)
            {
                throw new ArgumentException("A data de início do evento deve ser anterior à data de fim do evento.", nameof(eventoDto.InicioEvento));
            }
            if(string.IsNullOrWhiteSpace(eventoDto.DescricaoEvento))
            {
                throw new ArgumentException("A descrição do evento não pode ser nula ou vazia.", nameof(eventoDto.DescricaoEvento));
            }
            var sala = await _salaRepository.ObterSalaPorIdAsync(eventoDto.IdSala);
            if (sala == null)
            {
                throw new Exception("Sala está vazia");
            }
            var momeEvento = ObejctNomeEvento.CreateNomeEvento(eventoDto.NomeEvento);
            var enderecoEvento = ObjectLocalEvento.CreateLocalEvento(eventoDto.EnderecoEvento, eventoDto.CidadeEvento, eventoDto.EstadoEvento, eventoDto.PaisEvento);
            var descricaoEvento = ObjectDescricaoEvento.CreateDescricaoEvento(eventoDto.DescricaoEvento);
            var evento = Evento.CreateEvento(
                sala.IdSala,
                momeEvento.NomeEvento,
                enderecoEvento.Endereco,
                enderecoEvento.Cidade,
                enderecoEvento.Estado,
                enderecoEvento.Pais,
                eventoDto.InicioEvento,
                eventoDto.FimEvento,
                descricaoEvento.Descricao
                );
            sala.AdicionarEvento(evento);
             _eventoRepository.AdicionarEventoAsync(evento);
            await _unitOfWork.CommitAsync();
            return MapearEvento(evento);
        }

        public static RespostaEvento MapearEvento(Evento evento)
        {
            if (evento == null)
            {
                throw new ArgumentNullException(nameof(evento));
            }
            return new RespostaEvento
            {
             NomeEvento = evento.NomeEvento.NomeEvento,
             EnderecoEvento = evento.Endereco.Endereco,
             CidadeEvento = evento.Endereco.Cidade,
             EstadoEvento = evento.Endereco.Estado,
             PaisEvento = evento.Endereco.Pais,
             InicioEvento = evento.DataInicioEvento,
             FimEvento = evento.DataFimEvento,
             DescricaoEvento = evento.DescricaoEvento.Descricao
            };
        }
    }
}
