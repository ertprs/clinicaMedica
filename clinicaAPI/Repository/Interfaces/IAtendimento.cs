using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaAPI.Models;
using ClinicaAPI___Copia.Repository.DTO;

namespace ClinicaAPI.Repository.Interfaces
{
    public interface IAtendimento
    {
        Task<bool> NovoAtendimento(Atendimento atendimento);
        Task <List<AtendimentoDTO>> ListaAtendimento(); 
        Task <AtendimentoDTO> GetAtendimentoById(int idAtendimento);
        Task <List<AtendimentoSimplificadoDTO>> GetAtendimentoSimplificado();
        Task <AtendimentoSimplificadoDTO> GetAtendimentoSimplificadoById(int idAtendimento);
         
    }
}