using AtivosFinanceiros.API.Utilities;
using AtivosFinanceiros.API.ViewModels;
using AtivosFinanceiros.Core.Exceptions;
using AtivosFinanceiros.Services.DTO;
using AtivosFinanceiros.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace AtivosFinanceiros.API.Controllers
{
    [Route("api/v1/[controller]")]
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

        [SwaggerResponse(201, "Criado com Sucesso", typeof(CriarViewModel))]
        [SwaggerResponse(400, "Campos obrigatórios")]
        [SwaggerResponse(500, "Erro Interno")]
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarViewModel acaoViewModel)
        {
            try
            {
                var acaoDTO = _mapper.Map<AcaoDTO>(acaoViewModel);
                var acaoCriado = await _acaoService.CriarAsync(acaoDTO);
                return CreatedAtAction(nameof(Listar), new { Id = acaoCriado.Id }, acaoCriado);
            }
            catch (DomainException e)
            {
                return StatusCode(400, ErrorMessage.DomainError(e.Message, e.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, ErrorMessage.InternalError());
            }
        }

        [SwaggerResponse(200, "Atualizado com Sucesso", typeof(AtualizarViewModel))]
        [SwaggerResponse(400, "Campos obrigatórios")]
        [SwaggerResponse(500, "Erro Interno")]
        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarViewModel acaoViewModel)
        {
            try
            {
                var acaoDTO = _mapper.Map<AcaoDTO>(acaoViewModel);
                var acaoAtualizado = await _acaoService.AtualizarAsync(acaoDTO);
                return Ok(acaoAtualizado);
            }
            catch (DomainException e)
            {
                return BadRequest(ErrorMessage.DomainError(e.Message, e.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, ErrorMessage.InternalError());
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
            catch (Exception)
            {
                return StatusCode(500, ErrorMessage.InternalError());
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
            catch (Exception)
            {
                return StatusCode(500, ErrorMessage.InternalError());
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
            catch (Exception)
            {
                return StatusCode(500, ErrorMessage.InternalError());
            }
        }

        [HttpGet]
        [Route("BuscarPorNome")]
        public async Task<IActionResult> BuscarPorNome([FromQuery] string nomeDoAtivo)
        {
            try
            {
                var acoes = await _acaoService.BuscarPorNomeAsync(nomeDoAtivo);

                if (acoes.Count == 0)
                    return NotFound();

                return Ok(acoes);
            }
            catch (Exception)
            {
                return StatusCode(500, ErrorMessage.InternalError());
            }
        }

        [HttpGet]
        [Route("BuscarPorSigla")]
        public async Task<IActionResult> BuscarPorSigla([FromQuery] string siglaDoAtivo)
        {
            try
            {
                var acao = await _acaoService.BuscarPorSiglaAsync(siglaDoAtivo.ToUpper());

                if (acao == null)
                    return NotFound();

                return Ok(acao);
            }
            catch (Exception)
            {
                return StatusCode(500, ErrorMessage.InternalError());
            }
        }

        [HttpGet]
        [Route("BuscarPorSetor")]
        public async Task<IActionResult> BuscarPorSetor([FromQuery] string setor)
        {
            try
            {
                var acoes = await _acaoService.BuscarPorSetorAsync(setor);

                if (acoes.Count == 0)
                    return NotFound();

                return Ok(acoes);
            }
            catch (Exception)
            {
                return StatusCode(500, ErrorMessage.InternalError());
            }
        }
    }
}
