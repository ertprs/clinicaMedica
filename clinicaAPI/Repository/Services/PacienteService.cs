using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaAPI.Data;
using ClinicaAPI.Models;
using ClinicaAPI.Repository.Interfaces;
using ClinicaAPI___Copia.Repository.DTO;
using Microsoft.EntityFrameworkCore;

namespace ClinicaAPI.Repository.Services
{
    public class PacienteService : ServiceBase<Paciente>, IPaciente
    {
        protected ClinicaContext _context;
        public PacienteService(IRepository<Paciente> repository, ClinicaContext context) : base(repository)
        {
            _context = context;
        }

        public async Task<PacienteSimpleDTO> GetPacienteById(int idPaciente)
        {
            IQueryable<Paciente> query = _context.Pacientes;


            var retorno = query.Where(_ => _.id == idPaciente)
            .Select(paciente => new PacienteSimpleDTO()
            {
                id = paciente.id,
                nome = paciente.nome,
                sexo = paciente.sexo,
                dt_nascimento = paciente.dt_nascimento,
                documento = paciente.documento

            });

            return await retorno.FirstOrDefaultAsync();
        }

        public async Task<List<Paciente>> ListaPaciente()
        {
            IQueryable<Paciente> query = _context.Pacientes;

            return await query.ToListAsync();
        }

        public async Task<bool> NovoPaciente(Paciente paciente)
        {
            try
            {
                _context.Add(paciente);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
