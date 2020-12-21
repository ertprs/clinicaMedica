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
    public class AtendimentoService : ServiceBase<Atendimento>, IAtendimento
    {
        protected ClinicaContext _context;
        public AtendimentoService(IRepository<Atendimento> repository, ClinicaContext context ) : base(repository)
        {
            _context = context;
        }

        public async Task<AtendimentoDTO> GetAtendimentoById(int idAtendimento)
        {
           IQueryable<Atendimento> query = _context.Atendimentos
           .Include(_=> _.paciente);

 
           var retorno =  query.Where(_ => _.id == idAtendimento)
           .Select(atendimento => new AtendimentoDTO() 
           {
               id = atendimento.id,
               prontuario = atendimento.prontuario,
               paciente = new PacienteDTO{
                   id = atendimento.paciente.id,
                   nome = atendimento.paciente.nome,
                   sexo = atendimento.paciente.sexo,
                   dt_nascimento = atendimento.paciente.dt_nascimento,
                   documento = atendimento.paciente.documento
               },   
           });

            


           return await retorno.FirstOrDefaultAsync();
        }

        public async Task<List<AtendimentoSimplificadoDTO>> GetAtendimentoSimplificado()
        {
           IQueryable<Atendimento> query = _context.Atendimentos
           .Include(_=> _.paciente);

 
           var retorno =  query
           .Select(atendimento => new AtendimentoSimplificadoDTO() 
           {
               id = atendimento.id,
               prontuario = atendimento.prontuario,
               nome = atendimento.paciente.nome 
           });

        
           return await retorno.ToListAsync();
        }

        public async Task<AtendimentoSimplificadoDTO> GetAtendimentoSimplificadoById(int idAtendimento)
        {
           IQueryable<Atendimento> query = _context.Atendimentos
           .Include(_=> _.paciente);

 
           var retorno = query.Where(_ => _.id == idAtendimento)
           .Select(atendimento => new AtendimentoSimplificadoDTO() 
           {
                id = atendimento.id,
                nome = atendimento.paciente.nome,
                sexo = atendimento.paciente.sexo,
                dt_nascimento = atendimento.paciente.dt_nascimento,
                documento = atendimento.paciente.documento,
                prontuario = atendimento.prontuario
           });

        
           return await retorno.FirstOrDefaultAsync();
        }


        public async Task<List<AtendimentoDTO>> ListaAtendimento()
        {
           IQueryable<Atendimento> query = _context.Atendimentos
           .Include(_=> _.paciente);

 
           var retorno =  query.Select(atendimento => new AtendimentoDTO() 
           {
               id = atendimento.id,
               prontuario = atendimento.prontuario,
               paciente = new PacienteDTO{
                   id = atendimento.paciente.id,
                   nome = atendimento.paciente.nome,
                   sexo = atendimento.paciente.sexo,
                   dt_nascimento = atendimento.paciente.dt_nascimento,
                   documento = atendimento.paciente.documento
               },   
           });

           return await retorno.ToListAsync();
        }

        public async Task<bool> NovoAtendimento(Atendimento atendimento)
        {
            try
            {
                _context.Add(atendimento);
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