using Aplicacao.DTOs.CadeirasDto;
using Aplicacao.DTOs.SalasDto;
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
    public class SalaService: ISalaService
    {
        private readonly ISalaRepository _salaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SalaService(ISalaRepository salaRepository, IUnitOfWork unitOfWork)
        {
            _salaRepository = salaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<RespostaSala> AtualizarSalaAsync(Guid id, ModificarSala salaDto)
        {
            if(salaDto == null)
            {
                throw new ArgumentNullException(nameof(salaDto));
            }
            if(id == Guid.Empty)
            {
                throw new ArgumentException("Id da sala inválido.");
            }
            if(salaDto.Capacidade <= 0)
            {
                throw new ArgumentException("Capacidade da sala inválida.");
            }
            var sala = await _salaRepository.ObterSalaPorIdAsync(id);
            if(sala == null)
            {
                throw new KeyNotFoundException("Sala não encontrada.");
            }
            sala.AtualizarSala(salaDto.Capacidade);
            _salaRepository.AtualizarSalaAsync(sala);
            await _unitOfWork.CommitAsync();
            return MapearSala(sala);

        }

        public async Task<RespostaSala> CadastrarSalaAsync(CadastrarSala salaDto)
        {
           if(salaDto == null)
            {
                throw new ArgumentNullException(nameof(salaDto));
            }
           if(salaDto.NumeroSala <= 0)
            {
                throw new ArgumentException("Número da sala inválido.");
            }
            if (salaDto.Capacidade <= 0)
            {
                throw new ArgumentException("Capacidade da sala inválida.");
            }
           var sala = Sala.CreateSala(salaDto.NumeroSala, salaDto.Capacidade);
            await _salaRepository.AdicionarSalaAsync(sala);
              await _unitOfWork.CommitAsync();
              return MapearSala(sala);
        }

        public static RespostaSala MapearSala(Sala sala)
        {
            if (sala == null)
            {
                throw new ArgumentNullException(nameof(sala));
            }
            return new RespostaSala
            {
                NumeroSala = sala.NumeroSala,
                Capacidade = sala.Capacidade,
                Status = sala.Status,
                Cadeiras = sala.CadeirasDisponiveis.Select(c => new RespostaCadeira
                {
                    NumeroCadeira = c.NumeroCadeira,
                    Status = c.Status
                }).ToList()
            };
        }

        public async Task<string> ColocarSalaEmManutencao(StatusSala statusSala)
        {
            var sala = await _salaRepository.ObterStatusSalaIndisponivelAsync(statusSala);

            if (sala == null)
            {
                throw new Exception("Sala está nula");
            }
            if(sala.Equals(StatusSala.Disponivel))
            {
                sala.TornarIndisponivel();
            }
            return "Sala está fechada para manutenção";
        }

        public async Task<string> DisponibilizarSala(StatusSala sala)
        {
            var salaStatus = await _salaRepository.ObterStatusSalaIndisponivelAsync(sala);
            if(salaStatus == null)
            {
                throw new Exception("Sala está nula");

            }
            if (salaStatus.Equals(StatusSala.Indisponivel))
            {
                salaStatus.TornarDisponivel();
            }
            return "Sala foi aberta novamente.";
        }
    }
}
