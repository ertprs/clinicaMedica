using System;
using System.Threading.Tasks;
using ClinicaAPI.Models;
using ClinicaAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaAPI.Controllers
{
    [Route("api/atendimento")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        private IAtendimento _atendimento;
        public AtendimentoController(IAtendimento atendimento)
        {
            _atendimento = atendimento;
        }
        
        [Route("ListaAtendimento")]
        [HttpGet]
        public async Task<IActionResult> ListaAtendimento()
        {
            try
            {
                var results = await _atendimento.ListaAtendimento();
                return Ok(results);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("NovoAtendimento")]
        [HttpPost]
        public async Task<IActionResult> NovoAtendimento(Atendimento atendimento)
        {
            try
            {

                var results = await _atendimento.NovoAtendimento(atendimento);

                return Ok(results);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("{idAtendimento}")]
        [HttpGet]
        public async Task<IActionResult> GetAtendimentoById(int idAtendimento)
        {
            try
            {
                var results = await _atendimento.GetAtendimentoById(idAtendimento);
                return Ok(results);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("ListaAtendimentoSimplificado")]
        [HttpGet]
        public async Task<IActionResult> GetAtendimentoSimplificado()
        {
            try
            {
                var results = await _atendimento.GetAtendimentoSimplificado();
                return Ok(results);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("ListaAtendimentoSimplificado/{idAtendimento}")]
        [HttpGet]
        public async Task<IActionResult> GetAtendimentoSimplificadoById(int idAtendimento)
        {
            try
            {
                var results = await _atendimento.GetAtendimentoSimplificadoById(idAtendimento);
                return Ok(results);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}