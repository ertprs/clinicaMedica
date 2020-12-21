using System;
using System.Threading.Tasks;
using ClinicaAPI.Models;
using ClinicaAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaAPI.Controllers
{
    [Route("api/paciente")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private IPaciente _paciente;
        public PacienteController(IPaciente paciente)
        {
            _paciente = paciente;
        }

        [Route("ListaPaciente")]
        [HttpGet]
        public async Task<IActionResult> ListaPaciente()
        {
            try
            {
                var results = await _paciente.ListaPaciente();
                return Ok(results);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("NovoPaciente")]
        [HttpPost]
        public async Task<IActionResult> NovoPaciente(Paciente paciente)
        {
            try
            {

                var results = await _paciente.NovoPaciente(paciente);

                return Ok(results);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        [Route("{idPaciente}")]
        [HttpGet]
        public async Task<IActionResult> GetPacienteById(int idPaciente)
        {
            try
            {
                var results = await _paciente.GetPacienteById(idPaciente);
                return Ok(results);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}