using AtivosFinanceiros.API.ViewModels;
using AtivosFinanceiros.Services.DTO;
using AtivosFinanceiros.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AtivosFinanceiros.API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class AcaoController : ControllerBase
    {
        private readonly IBaseService<AcaoDTO> _acaoService;
        private readonly IMapper _mapper;

        public AcaoController(IBaseService<AcaoDTO> acaoService, IMapper mapper)
        {
            _acaoService = acaoService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarViewModel acaoViewModel)
        {
            try
            {
                var acaoDTO = _mapper.Map<AcaoDTO>(acaoViewModel);
                var acaoCriado = await _acaoService.CriarAsync(acaoDTO);
                return Ok(acaoCriado);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarViewModel acaoViewModel)
        {
            try
            {
                var acaoDTO = _mapper.Map<AcaoDTO>(acaoViewModel);
                var acaoAtualizado = await _acaoService.AtualizarAsync(acaoDTO);
                return Ok(acaoAtualizado);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(long id)
        {
            try
            {
                await _acaoService.RemoverAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                var acoes = await _acaoService.ListarTodosAsync();

                return Ok(acoes);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Listar(long id)
        {
            try
            {
                var acoes = await _acaoService.ListarAsync(id);

                return Ok(acoes);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> BuscarPorNome([FromQuery] string nomeDoAtivo)
        {
            try
            {
                var acoes = await _acaoService.BuscarPorNomeAsync(nomeDoAtivo);

                if (acoes.Count == 0)
                    return NotFound();

                return Ok(acoes);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> BuscarPorSigla([FromQuery] string siglaDoAtivo)
        {
            try
            {
                var acao = await _acaoService.BuscarPorSiglaAsync(siglaDoAtivo);

                if (acao == null)
                    return NotFound();

                return Ok(acao);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> BuscarPorSetor([FromQuery] string setor)
        {
            try
            {
                var acoes = await _acaoService.BuscarPorSetorAsync(setor);

                if (acoes.Count == 0)
                    return NotFound();

                return Ok(acoes);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
