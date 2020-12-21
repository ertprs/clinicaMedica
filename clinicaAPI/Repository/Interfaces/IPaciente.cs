using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaAPI.Models;
using ClinicaAPI___Copia.Repository.DTO;

namespace ClinicaAPI.Repository.Interfaces
{
    public interface IPaciente
    {
        Task<bool> NovoPaciente(Paciente paciente);
        Task <List<Paciente>> ListaPaciente(); 
       Task <PacienteSimpleDTO> GetPacienteById(int idPaciente);
    }
}