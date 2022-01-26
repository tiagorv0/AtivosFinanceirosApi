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
    public class AcaoService : IBaseService<AcaoDTO>
    {
        private readonly IAcaoRepository _acaoRepository;
        private readonly IMapper _mapper;

        public AcaoService(IAcaoRepository acaoRepository, IMapper mapper)
        {
            _acaoRepository = acaoRepository;
            _mapper = mapper;
        }

        public async Task<AcaoDTO> CriarAsync(AcaoDTO obj)
        {
            var acaoExists = await _acaoRepository.BuscarPorSiglaAsync(obj.Sigla);

            if (acaoExists != null)
                throw new DomainException("Ação já existente!");

            var acao = _mapper.Map<Acao>(obj);
            acao.Validate();

            var acaoCriada = await _acaoRepository.CriarAsync(acao);

            return _mapper.Map<AcaoDTO>(acaoCriada);
        }

        public async Task<AcaoDTO> AtualizarAsync(AcaoDTO obj)
        {
            var acaoExists = await _acaoRepository.ListarAsync(obj.Id);

            if (acaoExists == null)
                throw new DomainException("Nenhuma ação existente com o id informado.");

            var acao = _mapper.Map<Acao>(obj);
            acao.Validate();

            var acaoAtulizada = await _acaoRepository.AtualizarAsync(acao);

            return _mapper.Map<AcaoDTO>(acaoAtulizada);
        }
        public async Task RemoverAsync(long id)
        {
            var acaoExists = await _acaoRepository.ListarAsync(id);

            if (acaoExists == null)
                throw new DomainException("Nenhuma ação existente com o id informado.");

            await _acaoRepository.RemoverAsync(id);
        }

        public async Task<List<AcaoDTO>> BuscarPorNomeAsync(string nomeAtivo)
        {
            var acaoPesquisada = await _acaoRepository.BuscarPorNomeAsync(nomeAtivo);

            return _mapper.Map<List<AcaoDTO>>(acaoPesquisada);
        }

        public async Task<List<AcaoDTO>> BuscarPorSetorAsync(string nomeSetor)
        {
            var setorPesquisado = await _acaoRepository.BuscarPorSetorAsync(nomeSetor);

            return _mapper.Map<List<AcaoDTO>>(setorPesquisado);
        }

        public async Task<AcaoDTO> BuscarPorSiglaAsync(string sigla)
        {
            var siglaPesquisada = await _acaoRepository.BuscarPorSiglaAsync(sigla);

            return _mapper.Map<AcaoDTO>(siglaPesquisada);
        }

        public async Task<AcaoDTO> ListarAsync(long id)
        {
            var acao = await _acaoRepository.ListarAsync(id);

            return _mapper.Map<AcaoDTO>(acao);
        }

        public async Task<List<AcaoDTO>> ListarTodosAsync()
        {
            var acoes = await _acaoRepository.ListarTodosAsync();

            return _mapper.Map<List<AcaoDTO>>(acoes);
        }

    }
}
