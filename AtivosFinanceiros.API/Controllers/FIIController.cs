﻿using AtivosFinanceiros.API.ViewModels;
using AtivosFinanceiros.Services.DTO;
using AtivosFinanceiros.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AtivosFinanceiros.API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class FIIController : ControllerBase
    {
        private readonly IBaseService<FIIDTO> _fiiService;
        public readonly IMapper _mapper;

        public FIIController(IBaseService<FIIDTO> fiiService, IMapper mapper)
        {
            _fiiService = fiiService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarViewModel fiiViewModel)
        {
            try
            {
                var fiiDTO = _mapper.Map<FIIDTO>(fiiViewModel);
                var fiiCriado = await _fiiService.CriarAsync(fiiDTO);
                return Ok(fiiCriado);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarViewModel fiiViewModel)
        {
            try
            {
                var fiiDTO = _mapper.Map<FIIDTO>(fiiViewModel);
                var fiiAtualizado = await _fiiService.AtualizarAsync(fiiDTO);
                return Ok(fiiAtualizado);
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
                await _fiiService.RemoverAsync(id);
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
                var fiis = await _fiiService.ListarTodosAsync();

                return Ok(fiis);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Listar(long id)
        {
            try
            {
                var fiis = await _fiiService.ListarAsync(id);

                return Ok(fiis);
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
                var fiis = await _fiiService.BuscarPorNomeAsync(nomeDoAtivo);

                if(fiis.Count == 0)
                    return NotFound();

                return Ok(fiis);
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
                var fii = await _fiiService.BuscarPorSiglaAsync(siglaDoAtivo);

                if (fii == null)
                    return NotFound();

                return Ok(fii);
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
                var fiis = await _fiiService.BuscarPorSetorAsync(setor);

                if (fiis.Count == 0)
                    return NotFound();

                return Ok(fiis);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
