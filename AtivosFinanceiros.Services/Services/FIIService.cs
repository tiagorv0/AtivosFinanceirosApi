using AtivosFinanceiros.Core.Exceptions;
using AtivosFinanceiros.Domain.Entities;
using AtivosFinanceiros.Infra.Interfaces;
using AtivosFinanceiros.Services.DTO;
using AtivosFinanceiros.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosFinanceiros.Services.Services
{
    public class FIIService : IBaseService<FIIDTO>
    {
        private readonly IMapper _mapper;
        private readonly IFIIRepository _fiiRepository;

        public FIIService(IMapper mapper, IFIIRepository fiiRepository)
        {
            _mapper = mapper;
            _fiiRepository = fiiRepository;
        }

        public async Task<FIIDTO> AtualizarAsync(FIIDTO obj)
        {
            var fiiExiste = await _fiiRepository.ListarAsync(obj.Id);

            if (fiiExiste == null)
                throw new DomainException("Nenhum FII existente com o id informado.");

            var fii = _mapper.Map<FII>(obj);
            fii.Validate();

            var fiiAtualizado = await _fiiRepository.AtualizarAsync(fii);

            return _mapper.Map<FIIDTO>(fiiAtualizado);
        }

        public async Task<List<FIIDTO>> BuscarPorNomeAsync(string nomeAtivo)
        {
            var fiis = await _fiiRepository.BuscarPorNomeAsync(nomeAtivo);

            return _mapper.Map<List<FIIDTO>>(fiis);
        }

        public async Task<List<FIIDTO>> BuscarPorSetorAsync(string nomeSetor)
        {
            var fiis = await _fiiRepository.BuscarPorSetorAsync(nomeSetor);

            return _mapper.Map<List<FIIDTO>>(fiis); 
        }

        public async Task<FIIDTO> BuscarPorSiglaAsync(string sigla)
        {
            var fii = await _fiiRepository.BuscarPorSiglaAsync(sigla);

            return _mapper.Map<FIIDTO>(fii);
        }

        public async Task<FIIDTO> CriarAsync(FIIDTO obj)
        {
            var fiiExists = await _fiiRepository.BuscarPorSiglaAsync(obj.Sigla);

            if (fiiExists != null)
                throw new DomainException("FII já existente!");

            var fii = _mapper.Map<FII>(obj);
            fii.Validate();

            var fiiCriada = await _fiiRepository.CriarAsync(fii);

            return _mapper.Map<FIIDTO>(fiiCriada);
        }

        public async Task<FIIDTO> ListarAsync(long id)
        {
            var fii = await _fiiRepository.ListarAsync(id);

            return _mapper.Map<FIIDTO>(fii);
        }

        public async Task<List<FIIDTO>> ListarTodosAsync()
        {
            var fiis = await _fiiRepository.ListarTodosAsync();

            return _mapper.Map<List<FIIDTO>>(fiis);
        }

        public async Task RemoverAsync(long id)
        {
            var fiiExiste = await _fiiRepository.ListarAsync(id);

            if (fiiExiste == null)
                throw new DomainException("Nenhum FII existente com o id informado.");

            await _fiiRepository.RemoverAsync(id);
        }
    }
}
